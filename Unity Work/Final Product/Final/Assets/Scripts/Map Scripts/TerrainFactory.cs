using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TerrainFactory : MonoBehaviour
{
    [SerializeField] private Transform parent; //the room that holds the item
    [SerializeField] private GameObject navmesh; //the room that holds the item
    
    public void Create(int rt){
        if(parent.transform.childCount > 2){
            parent.transform.GetChild(2).localPosition = new Vector2 (100,100);
            Destroy(parent.transform.GetChild(2).gameObject);
        }
        StartCoroutine(ReNav(rt));
    }
    IEnumerator ReNav(int rt){
        GameObject[] terrain = GameObject.Find("/Map").GetComponent<RoomPools>().Terrains; //the room that holds the item
        Vector2 spawnPoint = new(6f, 0); //sets up the spawn point
        Instantiate(terrain[rt], spawnPoint, Quaternion.identity, parent); //spawn an item given the various distances
        navmesh.GetComponent<NavMeshSurface2d>().BuildNavMesh();
        yield return null;
    }
}
