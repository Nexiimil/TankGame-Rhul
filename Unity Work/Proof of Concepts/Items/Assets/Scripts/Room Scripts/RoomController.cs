using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    EnemyFactory ef;
    [SerializeField] GameObject rewardItemPrefab;

    [SerializeField] Item reward;


    // Start is called before the first frame update
    void Start(){  //when the room starts
        ef = GetComponentInChildren<EnemyFactory>(); //ensure the factory exists
        ef.Create(EnemyFactory.Enemy.Shooter, 4); //create 4 shooter enemies (for the sake of enemy testing)
    }

    void RoomCleared(){
        Vector2 spawnPoint = new Vector2(Transform.position.x, Transform.position.y) + Random.insideUnitCircle * 2; //sets up the spawn point
        GameObject rewardItem = Instantiate(rewardItemPrefab, spawnPoint, Quaternion.Identity, Transform);
    }

    void Update(){
        int enemies = GameObject.FindWithTag("Enemies").transform.childCount;
        if(enemies == 0){
            enemies--;
            RoomCleared();
        }
    }
}
