using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    [SerializeField] EnemyFactory _ef;
    [SerializeField] ItemFactory _itf;
    [SerializeField] GameObject rewardItemPrefab;

    [SerializeField] Item reward;

    [SerializeField] bool clearFlag = false;

    public EnemyFactory Ef { get => _ef; set => _ef = value; }
    public ItemFactory Itf { get => _itf; set => _itf = value; }

    // Start is called before the first frame update
    void Start(){  //when the room starts
        Ef = GetComponentInChildren<EnemyFactory>(); //ensure the factory exists
        Ef.Create(Enemy.Shooter, 4); //create 4 shooter enemies (for the sake of enemy testing)
    }

    void RoomCleared(){
        clearFlag = true;
        Itf = GetComponentInChildren<ItemFactory>();
        Itf.Create(1);
    }

    void Update(){
        int enemies = GameObject.FindWithTag("Enemies").transform.childCount;
        if(enemies == 0 & clearFlag == false){
            enemies--;
            RoomCleared();
        }
    }
}
