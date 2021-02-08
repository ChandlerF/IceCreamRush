using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            MainMenu();
        }
    }


    private void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
