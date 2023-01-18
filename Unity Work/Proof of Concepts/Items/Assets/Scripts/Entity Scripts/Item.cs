using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    [SerializeField] private string name;
    [SerializeField] private string rarity;
    private StatArray stats;
    private EffectsArray effects;

    public Item(string name, string rarity, StatArray stats, EffectsArray effects){
        this.name = name;
        this.rarity = rarity;
        this.stats = stats;
        this.effects = effects;
    }


}
