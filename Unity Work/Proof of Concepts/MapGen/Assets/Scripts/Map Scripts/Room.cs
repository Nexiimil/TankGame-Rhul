using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Room{
    [SerializeField] private int _rt;
    [SerializeField] private int _et;
    [SerializeField] private Item _itemReward;
    [SerializeField] private Room parent;
    [SerializeField] private List<Room> _neighbours = new();
    [SerializeField] private int _roomkey;
    [SerializeField] private RoomState _state = RoomState.IncompleteStandard;

    public Room(int rt, int et, Item itemReward, int roomkey){
        Rt = rt;
        Et = et;
        ItemReward = itemReward;
        Roomkey = roomkey;
    }

    public int Rt { get => _rt; set => _rt = value; }
    public int Et { get => _et; set => _et = value; }
    public Item ItemReward { get => _itemReward; set => _itemReward = value; }
    public int Roomkey { get => _roomkey; set => _roomkey = value; }
    public List<Room> Neighbours { get => _neighbours; set => _neighbours = value; }
    public Room Parent { get => parent; set => parent = value; }
    public RoomState State { get => _state; set => _state = value; }
    public string NeighboursToString(){
        string toReturn = "";
        foreach(Room r in Neighbours){
            toReturn += r.ToString();
        }
        return toReturn;
    }
    public override string ToString(){
        return "Room: " + Roomkey.ToString() + ", Reward: " + ItemReward.ToString();
    }
}