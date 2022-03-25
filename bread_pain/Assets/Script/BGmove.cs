using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float endPosition;
    [SerializeField] private float startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Bread.instance.isDie)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
        if (transform.position.x <= endPosition)
        {
            transform.position = new Vector2(startPosition, transform.position.y);
        }

    }
}
