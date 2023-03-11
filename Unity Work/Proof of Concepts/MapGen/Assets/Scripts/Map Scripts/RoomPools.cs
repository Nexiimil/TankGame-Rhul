using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPools : MonoBehaviour
{
    [SerializeField] private GameObject[] terrains;
    [SerializeField] private List<Encounter> enemies;
    public List<Encounter> Enemies { get => enemies; set => enemies = value; }
    public GameObject[] Terrains { get => terrains; set => terrains = value; }
}
