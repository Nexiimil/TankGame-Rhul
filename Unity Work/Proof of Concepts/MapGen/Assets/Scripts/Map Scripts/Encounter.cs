using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Encounter{
    [SerializeField] private List<Enemy> _enemy;
    [SerializeField] private List<int> _plurality;

    public List<Enemy> Enemy { get => _enemy; set => _enemy = value; }
    public List<int> Plurality { get => _plurality; set => _plurality = value; }
}