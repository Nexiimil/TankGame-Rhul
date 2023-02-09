using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space") && GetComponentInParent<Text>().text.Substring(0,3) == " - "){
            Debug.Log("Quitting Game");
            Application.Quit(); //terminates the game
        }
    }
}
