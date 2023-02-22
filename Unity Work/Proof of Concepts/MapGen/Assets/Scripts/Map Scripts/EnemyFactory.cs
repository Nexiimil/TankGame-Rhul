using System;
using UnityEngine;
public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies; //list of available enemy prefabs
    [SerializeField] private Transform _telepoints; //the room that holds the enemies

    public Transform Telepoints { get => _telepoints; set => _telepoints = value; }

    public void Create(Enemy type, int num, Neighbours n){
        float spawnRadius = 1.3f; //determines how far away from the unit circle an enemy can spawn
        float enemyWidth = 1.1f; //so enemies dont spawn on top of eachother, the specified distance away from eachother the enemies should spawn
        for(int i=0; i<num; i++){ //for n enemies
            Vector3 preSpawn;
            if( n == Neighbours.Null){
                preSpawn = Telepoints.Find("West").position;
            }else{
                preSpawn = Telepoints.Find(Enum.GetName(typeof(Neighbours),(int)n)).position;
            }
            Vector2 spawnPoint = new Vector2(preSpawn.x, preSpawn.y) + UnityEngine.Random.insideUnitCircle * spawnRadius * enemyWidth; //sets up the spawn point
            Instantiate(enemies[(int)type], spawnPoint, Quaternion.identity, gameObject.transform); //spawn an enemy given the various distances
        }
    }
}
