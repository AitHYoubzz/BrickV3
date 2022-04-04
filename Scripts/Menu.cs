using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    // Start is called before the first frame update
    
    public void StartGame(int s)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + s);
    }

    public void RulesGame()
    {
        SceneManager.LoadScene("Rules");
    }
    public void StopGame()
    {
        Application.Quit();
    }
   
}