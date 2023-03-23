using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
   [SerializeField] private List<Item> _inventory;
   [SerializeField] private GameObject _ui;
   [SerializeField] private GameObject _uiItemPrefab;
   [SerializeField] private GameObject _uiStatPrefab;

   public List<Item> Inventory { get => _inventory; set => _inventory = value;}
   public GameObject Ui { get => _ui; set => _ui = value; }
   public GameObject UiItemPrefab { get => _uiItemPrefab; set => _uiItemPrefab = value; }
   public GameObject UiStatPrefab { get => _uiStatPrefab; set => _uiStatPrefab = value; }
   public Item getItem(int val){return Inventory[val];}

   void Start(){
      Ui = GameObject.Find("UIStateController").transform.GetChild(0).gameObject;
      Inventory.Clear();
   }

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
      BroadcastMessage("PullStat");
      AddToItemView();
      UpdateStats();
      UpdateEffects();
   }
   public void AddToItemView(){
      Transform itemContainer = Ui.transform.Find("Items/ItemViewport/ItemContainer");
      foreach (Transform child in itemContainer){
         Destroy(child.gameObject);
      }
      Inventory.Sort((x, y) => x.Name.CompareTo(y.Name));
      int count = 0;
      for(int i = 0; i<Inventory.Count;i+=count){
         count = Inventory.FindAll(items => items.Name == Inventory[i].Name).Count;
         GameObject itemView = Instantiate(UiItemPrefab, itemContainer.position, itemContainer.rotation, itemContainer);
         itemView.GetComponent<Image>().sprite = Item.GetImage(Inventory[i]);
         itemView.transform.Find("Pluralism").GetComponent<Text>().text = "x" + count;
      }
   }

   public void UpdateStats(){
      Transform statContainer = Ui.transform.Find("Stats/StatViewport/StatContainer");
      foreach (Transform child in statContainer){
         Destroy(child.gameObject);
      }
      foreach(Stats s in gameObject.GetComponent<EntityController>().Sa){
         GameObject statView = Instantiate(UiStatPrefab, statContainer.position, statContainer.rotation, statContainer);
         statView.transform.Find("Image").GetComponent<Image>().sprite = Stats.GetImage(s);
         statView.transform.Find("StatFlat").GetComponent<Text>().text = s.flatStat.ToString();
         statView.transform.Find("StatPerc").GetComponent<Text>().text = ((int)(s.percentageStat*100)).ToString() + "%";
      }
   }

   public void UpdateEffects(){
      Transform effectContainer = Ui.transform.Find("Effects/EffectViewport/EffectContainer");
      foreach (Transform child in effectContainer){
         Destroy(child.gameObject);
      }
      foreach(IEffect e in gameObject.GetComponent<EntityController>().Ef){
         GameObject effectView = Instantiate(UiItemPrefab, effectContainer.position, effectContainer.rotation, effectContainer);
         effectView.GetComponent<Image>().sprite = IEffect.GetImage(e);
      }
   }

   public void PickUp(Item i){
      addItem(i);
   }
}
