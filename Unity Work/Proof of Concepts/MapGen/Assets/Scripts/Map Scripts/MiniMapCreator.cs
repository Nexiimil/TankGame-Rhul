using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MiniMapCreator : MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject nodePreFab;
    [SerializeField] private GameObject pathPreFab;

    void Start()
    {
        RenderMap(GetComponent<MapController>().Map, 0, 0);
    }

    void RenderMap(Room floor, float x, float y){
        SpawnNode(x, y);
        float size = nodePreFab.GetComponent<RectTransform>().rect.width;
        if(floor.Neighbours.Count > 0){
            foreach(Room childnode in floor.Neighbours){
                float childx = x;
                float childy = y;
                Neighbours n = (Neighbours)(childnode.Roomkey - floor.Roomkey);
                switch ((int)n){
                    case 10:
                        childy += size;
                        SpawnPath(n, childx, childy);
                        childy += size;
                        break;
                    case -10:
                        childy += -size;
                        SpawnPath(n, childx, childy);
                        childy += -size;
                        break;
                    case -1:
                        childx += -size;
                        SpawnPath(n, childx, childy);
                        childx += -size;
                        break;
                    case 1:
                        childx += size;
                        SpawnPath(n, childx, childy);
                        childx += size;
                        break;
                    default:
                        break;
                }
                RenderMap(childnode, childx, childy);
            }
        }
    }
    void SpawnNode(float x, float y){
        GameObject returnNode = Instantiate(nodePreFab, minimap.transform);
        returnNode.transform.localPosition += new Vector3(x,y,0);
    }
    void SpawnPath(Neighbours n, float x, float y){
        GameObject path = Instantiate(pathPreFab, minimap.transform);
        float rotation = 0;
        if(n == Neighbours.South || n == Neighbours.North){
            rotation = 90;
        }
        path.transform.localPosition += new Vector3(x,y,0);
        path.transform.rotation = Quaternion.Euler(0,0,rotation);
    }
    public void Shift(Neighbours n){
        Transform newpos = minimap.transform;
        float x = 0;
        float y = 0;
        float size = 90;
        switch (n)
        {
            case Neighbours.North:
                y-=size;
                break;
            case Neighbours.East:
                x-=size;
                break;
            case Neighbours.South:
                y+=size;
                break;
            case Neighbours.West:
                x+=size;
                break;
        }
        newpos.localPosition += new Vector3(x,y,0);
    }
}
