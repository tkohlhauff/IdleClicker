using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startButton()
    {
        SceneManager.LoadScene("MainGame");
        SceneManager.UnloadSceneAsync("Loading");
    }
    public void quit()
    {
        Application.Quit();
    }
}
