using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
   [SerializeField] private List<Item> _inventory;

   public List<Item> Inventory { get => _inventory; set => _inventory = value;}

   public Item getItem(int val){return this.Inventory[val];}

   public void addItem(Item i){
      Inventory.Add(i);
      EntityController statChanger = (EntityController)GetComponent("EntityController");
      if(i.Stats.Count > 0){
         foreach(Stats s in i.Stats){
            int statToChange = statChanger.Sa.FindIndex(r => r.statName == s.statName);
            if(statToChange == -1){
               statChanger.Sa.Add(s);
            } else {
               Stats mergedStat = statChanger.Sa[statToChange];
               mergedStat.flatStat = mergedStat.flatStat + s.flatStat;
               mergedStat.percentageStat = mergedStat.percentageStat + s.percentageStat;
               statChanger.Sa[statToChange] = mergedStat;
            }
         }
      }
      if(i.Effects.Count > 0){
         foreach(IEffect e in i.Effects){
            Debug.Log(e);
            Debug.Log(i.Effects);
            Debug.Log(statChanger);
            Debug.Log(statChanger.Ef);
            int effectToChange = statChanger.Ef.FindIndex(r => r.GetType() == e.GetType());
            if(effectToChange == -1){
               statChanger.Ef.Add(e);
            } else {
               IEffect mergedEffect = statChanger.Ef[effectToChange];
               mergedEffect.Aggregate(e);
               statChanger.Ef[effectToChange] = mergedEffect;
            }
         }
      }
   }

   public void PickUp(Item i){
      addItem(i);
   }
}
