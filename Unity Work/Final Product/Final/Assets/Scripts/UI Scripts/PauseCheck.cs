using UnityEngine;

public class PauseCheck : MonoBehaviour
{
    [SerializeField] private bool paused; //holds the pause state of the game
    [SerializeField] private GameObject pauseMenu; //the pause menu to invoke when paused

    public bool Paused { get => paused; set => paused = value; }
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }

    void Update(){  //checks every frame
        if (Input.GetKeyUp(KeyCode.Escape)){    //checks whether the user wants to pause the game
            TogglePause();  //toggle the pause state if so     
        }
    }

    public void TogglePause(){  //toggle the pause state
        PauseMenu.SetActive(!Paused);  //flips the pause menus active status
        if(Paused){ //checks the pause state
            UnpauseGame();  //flips to unpaused if paused
        } else {
            PauseGame();    //flips to paused if unpaused
        }
        Paused = !Paused; //flips the boolean
    }

    void PauseGame(){   //freezes game time
        Time.timeScale = 0f;    //time being 0 means frozen
    }

    public void UnpauseGame(){ //unfreezes game time
        Time.timeScale = 1f;    //time being 1 means unfrozen
    }
}
