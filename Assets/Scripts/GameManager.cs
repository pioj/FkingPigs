using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager UIManager;
    [SerializeField]
    public bool gameIsPaused;


    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        UIManager.Resume();        
        gameIsPaused = false;        
    }
    void Pause()
    {
        UIManager.Pause();
        
        gameIsPaused = true;


    }
    public void Retry()
    {
        Time.timeScale = 1;
        //reset level
        //vidas --
    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        //gameOver
        //puntuacion
        //Pantalla titulo
    }
    public bool IsPaused()
    {
        return gameIsPaused;
    }



}
