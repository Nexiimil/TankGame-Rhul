using System.Collections.Generic;
using System;
using UnityEngine;
public class RoomController : MonoBehaviour
{
    [SerializeField] EnemyFactory _ef;
    [SerializeField] ItemFactory _itf;
    [SerializeField] GameObject rewardItemPrefab;
    [SerializeField] Room _current;
    [SerializeField] List<Room> _currentNeighbours = new List<Room>();
    [SerializeField] Transform _telepoints;
    [SerializeField] Transform[] _doors;
    [SerializeField] bool _clearFlag = false;

    public EnemyFactory Ef { get => _ef; set => _ef = value; }
    public ItemFactory Itf { get => _itf; set => _itf = value; }
    public List<Room> CurrentNeighbours { get => _currentNeighbours; set => _currentNeighbours = value; }
    public Transform Telepoints { get => _telepoints; set => _telepoints = value; }
    public Transform[] Doors { get => _doors; set => _doors = value; }
    public bool ClearFlag { get => _clearFlag; set => _clearFlag = value; }
    public Room Current { get => _current; set => _current = value; }

    // Start is called before the first frame update
    void Start(){
        ChangeRoom(Neighbours.Null);
    }
    public void RoomStart(Neighbours n){  //when the room starts
        foreach(Transform door in Doors){
            EnterDoor ed = door.gameObject.GetComponent<EnterDoor>();
            int testkey = Current.Roomkey + (int)ed.DoorDirection();
            bool doorbool = CurrentNeighbours.Exists(r => r?.Roomkey == testkey);
            door.Find("Closed").gameObject.SetActive(doorbool);
            door.Find("Blocked").gameObject.SetActive(!doorbool);
            door.Find("Open").gameObject.SetActive(false);
        }
        Ef = GetComponentInChildren<EnemyFactory>(); //ensure the factory exists
        Ef.Create(Enemy.Shooter, 3, n); //create 4 shooter enemies (for the sake of enemy testing)
        Ef.Create(Enemy.Chaser, 2, n); //create 4 shooter enemies (for the sake of enemy testing)
        ClearFlag = false;
    }

    void RoomCleared(){
        ClearFlag = true;
        Itf = GetComponentInChildren<ItemFactory>();
        Itf.Create(Current.ItemReward);
        foreach(Transform door in Doors){
            EnterDoor ed = door.gameObject.GetComponent<EnterDoor>();
            if(door.Find("Closed").gameObject.activeSelf){
                door.Find("Open").gameObject.SetActive(true);
                door.Find("Closed").gameObject.SetActive(false);
            }

        }
    }

    void Update(){
        int enemies = GameObject.Find("Enemies").transform.childCount;
        if(enemies == 0 & ClearFlag == false){
            RoomCleared();
        }
    }

    public void ChangeRoom(Neighbours n){
        if (n == Neighbours.Null){
            Current = GameObject.Find("/Map").GetComponent<MapController>().Map;
        }else{
            Current = CurrentNeighbours.Find(r => r.Roomkey == (Current.Roomkey + (int)n));
            Transform player = GameObject.FindWithTag("Player").transform;
            player.position = Telepoints.Find(Enum.GetName(typeof(Neighbours),(int)n*-1)).position;
            GameObject.Find("/Map").GetComponent<MiniMapCreator>().Shift(n);
        }
        CurrentNeighbours.Clear();
        CurrentNeighbours.AddRange(Current.Neighbours);
        CurrentNeighbours.Add(Current.Parent);
        ClearFlag = false;
        RoomStart(n);
    }
}
