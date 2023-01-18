using System.Collections;
using System.Collections.Generic;
public class EffectsArray{

    private Dictionary<string, IEffect> effects;

    public EffectsArray(Dictionary<string, IEffect> effects){
        this.effects = effects;
    }
}