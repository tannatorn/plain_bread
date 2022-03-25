using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] box2D;

    [SerializeField] private GameObject[] bag;

    private void Awake()
    {
        box2D = GetComponentsInChildren<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                

                foreach (BoxCollider2D i in box2D)
                {
                    i.enabled = false;
                }

            }

            else if (!collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }


    }

}


