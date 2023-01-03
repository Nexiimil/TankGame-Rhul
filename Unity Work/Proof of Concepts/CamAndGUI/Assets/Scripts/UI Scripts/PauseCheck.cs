using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCheck : MonoBehaviour
{
    [SerializeField] private bool paused;
    [SerializeField] private GameObject pauseMenu;
	public bool IsPaused() {return this.paused;}
	public void SetPaused(bool paused) {this.paused = paused;}
    public GameObject GetPauseMenu() {return this.pauseMenu;}

    void Start()
    {
        SetPaused(true);
        PauseGame();
        GetPauseMenu().SetActive(false);
    }

    void Update(){
        if (Input.GetKeyUp(KeyCode.Escape)){
            TogglePause();
        }
    }

    public void TogglePause(){
        GetPauseMenu().SetActive(!IsPaused());
        if(IsPaused()){
            UnpauseGame();
        } else {
            PauseGame();
        }
        SetPaused(!IsPaused());
    }

    void PauseGame(){
        Time.timeScale = 0f;
    }

    void UnpauseGame(){
        Time.timeScale = 1f;
    }
}
