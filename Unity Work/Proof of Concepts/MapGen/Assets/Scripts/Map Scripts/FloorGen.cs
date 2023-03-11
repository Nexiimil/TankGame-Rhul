using System;
using System.Collections.Generic;
using UnityEngine;

public static class FloorGen{
    private static GameObject[] terrains; //item prefab
    private static int _enemies;
    private static Queue<Room> leftToGen = new();

    public static Room Generate(int rooms){
        Room root = new(0, 0, ItemPoolGeneration.GenerateRandomDrop(), 55);
        List<Room> floor = new();
        while(floor.Count < rooms){
            floor.Clear();
            floor = new(){root};
            leftToGen.Clear();
            leftToGen.Enqueue(root);
            while(rooms > 0 && leftToGen.Count > 0){
                Debug.Log("Rooms: " + rooms + "Left to Gen: " + leftToGen.Count);
                Console.WriteLine("Rooms: " + rooms + "Left to Gen: " + leftToGen.Count);
                Room currentRoom = leftToGen.Dequeue();
                foreach(Neighbours n in (Neighbours[])Enum.GetValues(typeof(Neighbours))){
                    int testkey = currentRoom.Roomkey + (int)n;
                    if (floor.FindIndex(r => r.Roomkey == testkey) == -1 && !GiveUp()){
                        Room gen = new(RandomRoomTemp(), RandomEnemyTemp(), ItemPoolGeneration.GenerateRandomDrop(), testkey);
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
        }
        floor[^1].State = RoomState.IncompleteBoss;
        return floor[0];
    }

    public static int RandomEnemyTemp(){
        System.Random rand = new();
        return rand.Next(1, GameObject.Find("/Map").GetComponent<RoomPools>().Enemies.Count);
    }
    public static int RandomRoomTemp(){
        System.Random rand = new();
        return rand.Next(0, GameObject.Find("/Map").GetComponent<RoomPools>().Terrains.Length);
    }
    public static bool GiveUp(){
        System.Random rand = new(){};
        if(rand.Next(0, 2) == 1){
            return true;
        }else{
            return false;
        }
    }
}
