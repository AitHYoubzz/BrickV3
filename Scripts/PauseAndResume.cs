using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        UI.SetActive(true);
        Time.timeScale = 0;
    }
   public void ContinueGame()
    {
        UI.SetActive(false);
        Time.timeScale = 1;
    }
}
