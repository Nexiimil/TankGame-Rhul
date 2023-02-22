using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Room map;
    public Room Map { get => map; set => map = value; }

    void Start()
    {
        map = FloorGen.Generate(15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
