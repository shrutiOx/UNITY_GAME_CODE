using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject unpause;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void PauseGame()
    {
            unpause.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 0;
            isPaused = true;
        transform.gameObject.SetActive(false);
        
        
    }
    public void ResumeGame()
    {
        unpause.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
        transform.gameObject.SetActive(true);
    }
}
