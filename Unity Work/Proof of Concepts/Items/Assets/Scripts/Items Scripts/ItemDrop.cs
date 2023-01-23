using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private Item _me;

    public Item Me { get => _me; set => _me = value; }

    void Start(){

    }
}
