using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    EnemyFactory ef;
    ItemFactory itf;
    [SerializeField] GameObject rewardItemPrefab;

    [SerializeField] Item reward;

    [SerializeField] bool clearFlag = false;

    // Start is called before the first frame update
    void Start(){  //when the room starts
        ef = GetComponentInChildren<EnemyFactory>(); //ensure the factory exists
        ef.Create(EnemyFactory.Enemy.Shooter, 4); //create 4 shooter enemies (for the sake of enemy testing)
    }

    void RoomCleared(){
        clearFlag = true;
        itf = GetComponentInChildren<ItemFactory>();
        itf.Create(1);
    }

    void Update(){
        int enemies = GameObject.FindWithTag("Enemies").transform.childCount;
        if(enemies == 0 & clearFlag == false){
            enemies--;
            RoomCleared();
        }
    }
}
