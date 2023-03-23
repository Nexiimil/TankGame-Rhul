using UnityEngine;
using UnityEngine.UI;

public class ToggleGameStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] activate;
    [SerializeField] private GameObject room;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space") && GetComponentInParent<Text>().text.Substring(0,3) == " - "){
            ToggleGame();
        }
    }
    void ToggleGame(){
        Debug.Log("Game Toggled");
        GameObject.Find("DeathScreen")?.SetActive(false);
        foreach(GameObject go in activate){
            go.SetActive(!go.activeSelf);
        }
        GameObject enemyPool = GameObject.FindWithTag("Enemies");
        if (enemyPool != null){
            foreach (Transform child in enemyPool?.transform){ //purges the current health bar, by iterating through each heart visible
                Destroy(child.gameObject); //deletes each heart object
            }
        }
        PauseCheck pauseTrigger = GameObject.Find("Room").GetComponent<PauseCheck>();
        pauseTrigger.Paused = false;
        pauseTrigger.UnpauseGame();
        room.BroadcastMessage("PullStat");
        room.BroadcastMessage("StartGame");
    }
}

