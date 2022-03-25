using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textTime : MonoBehaviour
{

    private float time = 30;

    [SerializeField] private Text texttime;

    private void Awake()
    {
        texttime = GetComponent<Text>();
    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!Bread.instance.isDie)
        {
            time -= Time.deltaTime;
            texttime.text = string.Format("Time : {0:F}", time);
        }


        if (time <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
