using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private GameObject panelResume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu();
        }
    }

    public void showMenu()
    {
        panelResume.SetActive(true);
        Time.timeScale = 0;
    }

    public void hideMenu()
    {
        panelResume.SetActive(false);
        Time.timeScale = 1;
    }

}
