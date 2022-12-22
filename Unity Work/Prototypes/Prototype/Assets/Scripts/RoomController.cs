using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    EnemyFactory ef;
    // Start is called before the first frame update
    void Start()
    {
        ef = GetComponentInChildren<EnemyFactory>();
        ef.Create(EnemyFactory.Enemy.Shooter, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
