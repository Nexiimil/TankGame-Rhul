using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Room{
    [SerializeField] private RoomTemplate _rt;
    [SerializeField] private EnemyTemplate _et;
    [SerializeField] private Item _itemReward;
    [SerializeField] private Room parent;
    [SerializeField] private List<Room> _neighbours = new List<Room>();
    [SerializeField] private int _roomkey;

    public Room(RoomTemplate rt, EnemyTemplate et, Item itemReward, int roomkey){
        Rt = rt;
        Et = et;
        ItemReward = itemReward;
        Roomkey = roomkey;
    }

    public RoomTemplate Rt { get => _rt; set => _rt = value; }
    public EnemyTemplate Et { get => _et; set => _et = value; }
    public Item ItemReward { get => _itemReward; set => _itemReward = value; }
    public int Roomkey { get => _roomkey; set => _roomkey = value; }
    public List<Room> Neighbours { get => _neighbours; set => _neighbours = value; }
    public Room Parent { get => parent; set => parent = value; }

    public List<Room> AvailableNeighbours(){
        return new List<Room>(Neighbours.Where(r => r == null));
    }
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