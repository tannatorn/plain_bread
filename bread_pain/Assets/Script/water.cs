using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] box2D;
    [SerializeField] private float posY = 0;
    [SerializeField] private GameObject[] kill;
    [SerializeField] private Transform point;
    private float time;

    private void Awake()
    {
        box2D = GetComponentsInChildren<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Bread.instance.isDie)
        {
            transform.position = new Vector2(transform.position.x - 10 * Time.deltaTime,
                                             transform.position.y + posY * Time.deltaTime);
        }


        if (transform.position.x < -7)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Bread.instance.PowerUp)
        {
            posY = 5;

            foreach (BoxCollider2D i in box2D)
            {
                i.enabled = false;
            }

        }
    }
}
