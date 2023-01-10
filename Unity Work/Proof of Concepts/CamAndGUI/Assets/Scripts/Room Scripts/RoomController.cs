using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    EnemyFactory ef;
    // Start is called before the first frame update
    void Start() //when the room starts
    {
        ef = GetComponentInChildren<EnemyFactory>(); //ensure the factory exists
        ef.Create(EnemyFactory.Enemy.Shooter, 4); //create 4 shooter enemies (for the sake of enemy testing)
    }
}
