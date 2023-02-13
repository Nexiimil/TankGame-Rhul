using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloorGen{
    private static List<EnemyTemplate> et;
    private static List<RoomTemplate> rt;
    private static List<Room> floor = new List<Room>();
    private static Queue<Room> leftToGen = new Queue<Room>();
    private static Stack<Room> deadEnds;
    private static ItemPoolGeneration ipg = GameObject.FindWithTag("ItemPool").GetComponent<ItemPoolGeneration>();
    public static List<Room> Generate(int rooms){
        leftToGen.Enqueue(new Room(null, null, ipg.generateRandomDrop(), 55));
        while(rooms > 0 && leftToGen.Count > 0){
            Debug.Log("Rooms: " + rooms + "Left to Gen: " + leftToGen.Count);
            Room currentRoom = leftToGen.Dequeue();
            foreach(Neighbours n in (Neighbours[])Enum.GetValues(typeof(Neighbours))){
                int testkey = currentRoom.Roomkey + (int)n;
                if (floor.FindIndex(r => r.Roomkey == testkey) == -1 && !GiveUp()){
                    Room gen = new Room(null, null, ipg.generateRandomDrop(), testkey);
                    currentRoom.Neighbours.Add(gen);
                    gen.Neighbours.Add(currentRoom);
                    leftToGen.Enqueue(gen);
                    floor.Add(gen);
                    Debug.Log("Room created with key: " + testkey + "connected to: " + currentRoom.Roomkey);
                    rooms--;
                    if(rooms == 0){
                        break;
                    }
                }
            }
        }
        return floor;
    }

    public static EnemyTemplate randomEnemyTemp(){
        System.Random rand = new System.Random();
        return et[rand.Next(0, et.Count)];
    }
    public static RoomTemplate randomRoomTemp(){
        System.Random rand = new System.Random();
        return rt[rand.Next(0, rt.Count)];
    }
    public static bool GiveUp(){
        System.Random rand = new System.Random(){};
        if(rand.Next(0, 2) == 1){
            return true;
        }else{
            return false;
        }
    }
}
