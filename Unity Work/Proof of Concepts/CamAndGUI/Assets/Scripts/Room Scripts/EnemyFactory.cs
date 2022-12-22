using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
public class EnemyFactory : MonoBehaviour
{
    public enum Enemy { Shooter=0, Chaser=1 };
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void Create(Enemy type, int num){
        int spawnRadius = 2;
        float enemyWidth = 1.1f;
        for(int i=0; i<num; i++){
            Vector2 spawnPoint = new Vector2(parent.position.x, parent.position.y) + Random.insideUnitCircle * spawnRadius * enemyWidth;
            GameObject enemy = Instantiate(enemies[(int)type], spawnPoint, parent.rotation, parent);
        }
    }
}
