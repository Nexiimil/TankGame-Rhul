using UnityEngine;

public class ResetMenus : MonoBehaviour
{
    [SerializeField] Transform itemContainer;
    [SerializeField] Transform statContainer;
    [SerializeField] Transform effectContainer;
    void StartGame(){
        foreach (Transform child in itemContainer){ //purges the current health bar, by iterating through each heart visible
            Destroy(child.gameObject); //deletes each heart object
        }
        foreach (Transform child in statContainer){ //purges the current health bar, by iterating through each heart visible
            Destroy(child.gameObject); //deletes each heart object
        }
        foreach (Transform child in effectContainer){ //purges the current health bar, by iterating through each heart visible
            Destroy(child.gameObject); //deletes each heart object
        }
    }
}
