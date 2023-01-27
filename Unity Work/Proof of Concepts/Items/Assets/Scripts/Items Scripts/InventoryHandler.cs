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
   }

   public void PickUp(Item i){
      addItem(i);
   }
}
