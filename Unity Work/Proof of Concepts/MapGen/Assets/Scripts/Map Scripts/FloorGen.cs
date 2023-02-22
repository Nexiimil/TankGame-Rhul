using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloorGen{
    private static List<EnemyTemplate> et;
    private static List<RoomTemplate> rt;
    private static Queue<Room> leftToGen = new Queue<Room>();
    private static Stack<Room> deadEnds;
    public static Room Generate(int rooms){
        Room root = new Room(null, null, ItemPoolGeneration.GenerateRandomDrop(), 55);
        List<Room> floor = new List<Room>();
        floor.Add(root);
        leftToGen.Enqueue(root);
        while(rooms > 0 && leftToGen.Count > 0){
            Debug.Log("Rooms: " + rooms + "Left to Gen: " + leftToGen.Count);
            Console.WriteLine("Rooms: " + rooms + "Left to Gen: " + leftToGen.Count);
            Room currentRoom = leftToGen.Dequeue();
            foreach(Neighbours n in (Neighbours[])Enum.GetValues(typeof(Neighbours))){
                int testkey = currentRoom.Roomkey + (int)n;
                if (floor.FindIndex(r => r.Roomkey == testkey) == -1 && !GiveUp()){
                    Room gen = new Room(null, null, ItemPoolGeneration.GenerateRandomDrop(), testkey);
                    currentRoom.Neighbours.Add(gen);
                    gen.Parent = currentRoom;
                    leftToGen.Enqueue(gen);
                    floor.Add(gen);
                    Debug.Log("Room created with key: " + testkey + "connected to: " + currentRoom.Roomkey);
                    Console.WriteLine("Room created with key: " + testkey + "connected to: " + currentRoom.Roomkey);
                    rooms--;
                    if(rooms == 0){
                        break;
                    }
                }
            }
        }
        return floor[0];
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
