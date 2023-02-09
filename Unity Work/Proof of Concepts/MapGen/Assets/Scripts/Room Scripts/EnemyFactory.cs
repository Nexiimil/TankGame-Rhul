using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies; //list of available enemy prefabs
    [SerializeField] private Transform parent; //the room that holds the enemies
    
    public void Create(Enemy type, int num){
        int spawnRadius = 2; //determines how far away from the unit circle an enemy can spawn
        float enemyWidth = 1.1f; //so enemies dont spawn on top of eachother, the specified distance away from eachother the enemies should spawn
        for(int i=0; i<num; i++){ //for n enemies
            Vector2 spawnPoint = new Vector2(parent.position.x, parent.position.y) + Random.insideUnitCircle * spawnRadius * enemyWidth; //sets up the spawn point
            GameObject enemy = Instantiate(enemies[(int)type], spawnPoint, parent.rotation, parent); //spawn an enemy given the various distances
        }
    }
}
