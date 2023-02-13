using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<Room> map;
    void Start()
    {
        map = FloorGen.Generate(15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
