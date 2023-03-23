using UnityEngine;
using UnityEngine.UI;

public class MiniMapCreator : MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject nodePreFab;
    [SerializeField] private GameObject pathPreFab;

    void Start()
    {
        InitiateMapReRender(GetComponent<MapController>().Map);
    }

    public void InitiateMapReRender(Room floor){
        foreach (Transform child in minimap.transform){
            Destroy(child.gameObject);
        }
        RenderMap(floor, 0, 0);
    }

    void RenderMap(Room floor, float x, float y){
        SpawnNode(x, y, floor.State);
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
    void SpawnNode(float x, float y, RoomState special){
        GameObject returnNode = Instantiate(nodePreFab, minimap.transform);
        returnNode.transform.localPosition += new Vector3(x,y,0);
        if (special == RoomState.IncompleteBoss){
            Color c = returnNode.GetComponent<Image>().color;
            c.r = 255;
            c.b = 0;
            c.g = 0;
            returnNode.GetComponent<Image>().color = c;
        }
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
        if(n != Neighbours.Null){
            newpos.localPosition += new Vector3(x,y,0);
        } else {
            newpos.localPosition = new Vector3(200, -125,0);
        }
    }
}
