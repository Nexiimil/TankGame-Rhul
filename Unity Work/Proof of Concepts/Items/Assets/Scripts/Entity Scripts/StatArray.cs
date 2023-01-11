using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{
    [SerializeField] private Dictionary<string, float[]> statDict = new Dictionary<string, float[]>{
                                                        {"BulletType", new float[] {0, 999}},
                                                        {"BulletDamage", new float[] {1, 0}},
                                                        {"BulletSpeed", new float[] {1, 0}},
                                                        {"BulletCrit", new float[] {999, 0}},
                                                        {"EntityArmour", new float[] {0, 999}},
                                                        {"EntitySpeed", new float[] {30, 0}},
                                                        {"EntityFireSpeed", new float[] {30, 0}},
                                                        {"EntityRoSpeed", new float[] {30, 0}},
                                                        {"MaximumHealth", new float[] {5, 999}}
                                                    }; //stores all stats to be used in various scripts

    public float getStatFlat(string stat){return this.statDict[stat][0];}
    public float getStatPerc(string stat){return this.statDict[stat][1];}

    void Start(){
    }
    

    public void Adjust(string stat, float adjustment){
        int target = 0;
        if(adjustment < 1){
            target++;
        }
        statDict[stat][target] += adjustment;
    }
}