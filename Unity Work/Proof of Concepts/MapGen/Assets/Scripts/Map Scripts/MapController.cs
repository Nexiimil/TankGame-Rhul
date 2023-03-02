using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Room map;
    public Room Map { get => map; set => map = value; }

    public void NextFloor()
    {
        map = FloorGen.Generate(15);
    }

    void Start()
    {
        NextFloor();
    }
}
