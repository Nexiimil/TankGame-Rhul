using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCheck : MonoBehaviour
{
    [SerializeField] private bool paused; //holds the pause state of the game
    [SerializeField] private GameObject pauseMenu; //the pause menu to invoke when paused

	public bool IsPaused() {return this.paused;}    //fetches the current pause state
	public void SetPaused(bool paused) {this.paused = paused;}  //sets the current pause state
    public GameObject GetPauseMenu() {return this.pauseMenu;}   //fetches the pause menu object to invoke

    // void Start(){ //call on object creation
    //     Application.targetFrameRate = 60;
    //     SetPaused(true);    //sets the initial pause state to true, so the game doesnt run while the main menu is showing
    //     PauseGame();        //freezes game time to pause
    //     GetPauseMenu().SetActive(false);    //disables the pause menu, so it doesnt render while the main menu renders
    // }

    void Update(){  //checks every frame
        if (Input.GetKeyUp(KeyCode.Escape)){    //checks whether the user wants to pause the game
            TogglePause();  //toggle the pause state if so     
        }
    }

    public void TogglePause(){  //toggle the pause state
        GetPauseMenu().SetActive(!IsPaused());  //flips the pause menus active status
        if(IsPaused()){ //checks the pause state
            UnpauseGame();  //flips to unpaused if paused
        } else {
            PauseGame();    //flips to paused if unpaused
        }
        SetPaused(!IsPaused()); //flips the boolean
    }

    void PauseGame(){   //freezes game time
        Time.timeScale = 0f;    //time being 0 means frozen
    }

    public void UnpauseGame(){ //unfreezes game time
        Time.timeScale = 1f;    //time being 1 means unfrozen
    }
}
