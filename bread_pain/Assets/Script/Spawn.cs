using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform spawnPoint;
    private float time;

    private void Awake()
    {
        spawnPoint = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 0.5)
        {
            time = 0;
            Instantiate(enemy[Random.Range(0, 2)], spawnPoint.position, Quaternion.identity);
        }
    }
}
