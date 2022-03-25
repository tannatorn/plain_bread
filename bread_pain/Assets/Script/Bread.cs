using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bread : MonoBehaviour
{
    public float speed = 5f;
   
    public float jump = 5f;

    public float time = 30;

    Rigidbody2D rb;


    [SerializeField] private GameObject[] bag;

    [SerializeField] private LayerMask ground;

   

    [SerializeField] public bool isDie = false;

    [SerializeField] private SpriteRenderer sr;

  

    [SerializeField] private bool isMove;
    [SerializeField] private bool isGround;

    
    [SerializeField] private bool isWater;
    [SerializeField] private bool isBurn;
    [SerializeField] private bool isStill;

    [SerializeField] public bool PowerUp;
  
    
    [SerializeField] private GameObject bread_2;
    [SerializeField] private GameObject bread_3;

    [SerializeField] private Animator Animation;



    public static Bread instance;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        Animation = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        time--;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        CheckGround();
        AnimationBread();

        


        if (Input.GetKeyDown(KeyCode.Space) && isGround && isWater && !isDie)
        {
            rb.velocity = Vector2.up * jump;
            AudioManager.instance.audioJump();
        }

       

      


    }


    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        isMove = (Input.GetAxisRaw("Horizontal") != 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            


        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
           
        }
    }


    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(transform.position, 1.6f, ground);
    }

    void AnimationBread()
    {
        
        Animation.SetBool("move", isMove);
        Animation.SetBool("ground", isGround);
        Animation.SetBool("die", isDie);
        Animation.SetBool("water", isWater);
        Animation.SetBool("still", isStill);
        Animation.SetBool("burn", isBurn);


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("killer") && !PowerUp)
        {
            AudioManager.instance.audioDie();
            isDie = true;
            Animation.SetBool("die", isDie);
            StartCoroutine(delayDie());

        }

        else if (collision.gameObject.CompareTag("water") && !PowerUp)
        {
            AudioManager.instance.audioDie();
            isWater = true;
            getWater();
          
           

        }

        else if (collision.gameObject.CompareTag("Ligth") && !PowerUp)
        {
            AudioManager.instance.audioDie();
          
            isStill = true;
            getLigth();

        }

        else if (collision.gameObject.CompareTag("Ligthen") && !PowerUp)
        {
            AudioManager.instance.audioDie();
            isBurn = true;
            getLigthen();

        }

         else if (collision.gameObject.CompareTag("finish") && !PowerUp)
        {
            AudioManager.instance.audioDie();
           
            StartCoroutine(delayDie());

        }

        else if (!collision.gameObject.CompareTag("killer"))
        {
           
            AudioManager.instance.audioLand();
        }

        else if (!collision.gameObject.CompareTag("bag"))
        {

            Destroy(gameObject);

            getaddTime();
        }
    }


    void getWater()
    {
        speed = 2f;
        jump = 3f;

        


        if (speed <= 0)
        {

        }
    }

    void getLigth()
    {
        speed = 5f;
        jump = 5f;

        bread_3.SetActive(true);


        if (speed <= 0)
        {

        }
    }

    void getLigthen()
    {
        speed = 10f;
        jump = 10f;




        if (speed <= 0)
        {

        }
    }


    void getaddTime()
    {
        time = 30;
    }

    void timeUp()
    {
        time--;
        
        isDie = true;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
       
        if (time <= 0)
        {
            gameObject.SetActive(false);
        }
    }

  

    IEnumerator delayDie()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
