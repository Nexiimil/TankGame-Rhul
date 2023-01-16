using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{
    [SerializeField] private Dictionary<string, float[]> statDict = new Dictionary<string, float[]>{
                                                        {"BulletType", new float[] {0, 0}},
                                                        {"BulletDamage", new float[] {1, 0}},
                                                        {"BulletSpeed", new float[] {20, 0}},
                                                        {"BulletCrit", new float[] {0, 0}},
                                                        {"EntityArmour", new float[] {0, 0}},
                                                        {"EntitySpeed", new float[] {2, 0}},
                                                        {"EntityFireSpeed", new float[] {30, 0}},
                                                        {"EntityRoSpeed", new float[] {2, 0}},
                                                        {"MaxHealth", new float[] {5, 0}},
                                                        {"Cannons", new float[] {2,0}}
                                                    }; //stores all stats to be used in various scripts

    public float getStat(string stat){return (this.statDict[stat][0] * (1+statDict[stat][1]));}
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