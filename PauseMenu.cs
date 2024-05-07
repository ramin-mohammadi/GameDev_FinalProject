using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        music.Play();
    }

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        music.Pause();
        
    }

    public void Quit(){
        //bring back to main menu screen
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
}
