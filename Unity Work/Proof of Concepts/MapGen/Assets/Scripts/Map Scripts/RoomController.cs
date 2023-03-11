using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class RoomController : MonoBehaviour
{
    [SerializeField] EnemyFactory _ef;
    [SerializeField] ItemFactory _itf;
    [SerializeField] TerrainFactory _tf;
    [SerializeField] GameObject _deathScreen;
    [SerializeField] GameObject _player;
    [SerializeField] Room _current;
    [SerializeField] List<Room> _currentNeighbours = new();
    [SerializeField] Transform _telepoints;
    [SerializeField] Transform[] _doors;
    [SerializeField] bool _processed = false;
    [SerializeField] NavMeshSurface2d _terrain;

    public EnemyFactory Ef { get => _ef; set => _ef = value; }
    public ItemFactory Itf { get => _itf; set => _itf = value; }
    public TerrainFactory Tf { get => _tf; set => _tf = value; }
    public List<Room> CurrentNeighbours { get => _currentNeighbours; set => _currentNeighbours = value; }
    public Transform Telepoints { get => _telepoints; set => _telepoints = value; }
    public Transform[] Doors { get => _doors; set => _doors = value; }
    public Room Current { get => _current; set => _current = value; }
    public bool Processed { get => _processed; set => _processed = value; }
    public GameObject DeathScreen { get => _deathScreen; set => _deathScreen = value; }
    public GameObject Player { get => _player; set => _player = value; }

    // Start is called before the first frame update
    void StartGame()
    {
        Transform? player = transform.Find("Player(Clone)");
        if (player != null){
            Destroy(player.gameObject);
        }
        Instantiate(Player, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
        ChangeRoom(Neighbours.Null);
    }

    private void InitialiseRoomState(Neighbours n)
    {
        foreach (Transform door in Doors)
        {
            EnterDoor ed = door.gameObject.GetComponent<EnterDoor>();
            int testkey = Current.Roomkey + (int)ed.DoorDirection();
            bool doorbool = CurrentNeighbours.Exists(r => r?.Roomkey == testkey);
            door.Find("Closed").gameObject.SetActive(doorbool);
            door.Find("Blocked").gameObject.SetActive(!doorbool);
            door.Find("Open").gameObject.SetActive(false);
            door.Find("Stairs").gameObject.SetActive(false);
        }
        switch ((int)Current.State)
        {
            case < 2: //if room is not cleared
                SpawnEnemies(n);
                break;
            case < 4: //if room is cleared but the item not picked up
                SpawnReward();
                break;
        }
        SpawnTerrain();
    }

    void RoomCleared()
    {
        if (Current.State == RoomState.IncompleteStandard)
        {
            Current.State = RoomState.StandardCleared;
        }
        else if (Current.State == RoomState.IncompleteBoss)
        {
            Current.State = RoomState.BossCleared;
        }
        if (Current.State == RoomState.BossCleared || Current.State == RoomState.BossItemPickedUp)
        {
            Neighbours doordirection = (Neighbours)(Current.Roomkey - Current.Parent.Roomkey);
            GameObject boosDoor = GameObject.Find("/Map/Room/Doors/" + Enum.GetName(typeof(Neighbours), doordirection));
            boosDoor.transform.Find("Stairs").gameObject.SetActive(true);
            boosDoor.transform.Find("Closed").gameObject.SetActive(false);
            boosDoor.transform.Find("Blocked").gameObject.SetActive(false);
            gameObject.GetComponentInParent<MapController>().NextFloor();
        }
        foreach (Transform door in Doors)
        {
            if (door.Find("Closed").gameObject.activeSelf)
            {
                door.Find("Open").gameObject.SetActive(true);
                door.Find("Closed").gameObject.SetActive(false);
            }
        }
        if ((int)Current.State < 4 && (int)Current.State > 1)
        {
            SpawnReward();
        }
    }

    void Update()
    {
        int enemies = GameObject.Find("Enemies").transform.childCount;
        if (enemies == 0 && Processed == false)
        {
            RoomCleared();
            Processed = true;
        }
        GameObject? player = GameObject.Find("Player(Clone)");
        if (player == null){
            DeathScreen.SetActive(true);
        }
    }

    public void ChangeRoom(Neighbours n)
    {
        GameObject map = GameObject.Find("/Map");
        if (n == Neighbours.Null)
        {
            map.GetComponent<MapController>().NextFloor();
            Current = map.GetComponent<MapController>().Map;
            map.GetComponent<MiniMapCreator>().InitiateMapReRender(Current);
            Transform player = GameObject.FindWithTag("Player").transform;
            player.position = Telepoints.Find("East").position;
            GameObject.Find("/Map").GetComponent<MiniMapCreator>().Shift(Neighbours.Null);
        }
        else
        {
            Current = CurrentNeighbours.Find(r => r.Roomkey == (Current.Roomkey + (int)n));
            Transform player = GameObject.FindWithTag("Player").transform;
            player.position = Telepoints.Find(Enum.GetName(typeof(Neighbours), (int)n * -1)).position;
            GameObject.Find("/Map").GetComponent<MiniMapCreator>().Shift(n);
        }
        CurrentNeighbours.Clear();
        CurrentNeighbours.AddRange(Current.Neighbours);
        CurrentNeighbours.Add(Current.Parent);
        InitialiseRoomState(n);
        Processed = false;
        foreach (Transform child in GameObject.Find("Items").transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SpawnTerrain()
    {
        Tf = GetComponentInChildren<TerrainFactory>();
        Tf.Create(Current.Rt);
    }
    private void SpawnReward()
    {
        Itf = GetComponentInChildren<ItemFactory>();
        Itf.Create(Current.ItemReward);
    }
    private void SpawnEnemies(Neighbours n)
    {
        Ef = GetComponentInChildren<EnemyFactory>(); 
        Ef.Create(Current.Et, n); 
    }
}
