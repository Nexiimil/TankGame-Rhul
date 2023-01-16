using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public class Item {
    private string name;
    private int rarity;
    private Dictionary<string, float[]> stats;
    private Dictionary<string, IEffect> effects;

    public Item item(string name, int rarity, Dictionary<string, float[]> stats, Dictionary<string, IEffect> effects){
        this.name = name;
        this.rarity = rarity;
        this.stats = stats;
        this.effects = effects;
        return this;
    }


}
