using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject[] Screens;
    // Start is called before the first frame update

    public bool gameStarted;
    void Start()
    {
        Screens[0].SetActive(true);
        gameStarted = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.anyKey && gameStarted == false)
        //{
        //    Screens[0].SetActive(false);
        //    Debug.Log("A key or mouse click has been detected");
        //    gameStarted = true;
        //}


        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //Application.Quit();
        }
    }
}
