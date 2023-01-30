using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EntityController : MonoBehaviour{
  [SerializeField] private List<Stats> sa = new List<Stats>();
  [SerializeReference] private List<IEffect> ef = new List<IEffect>();
  [SerializeField] private Rigidbody2D rb;

  public List<IEffect> Ef { get => ef; set => ef = value; }
  public List<Stats> Sa { get => sa; set => sa = value; }

  void setRB(Rigidbody2D rb){this.rb = rb;}

  public Rigidbody2D getRB(){return this.rb;}


  void Awake(){
    Sa = (new List<Stats>{
                      new Stats("BulletType", 0, 0),
                      new Stats("BulletDamage", 1, 0),
                      new Stats("BulletSpeed", 15, 0),
                      new Stats("BulletCrit", 0, 0),
                      new Stats("EntityArmor", 0, 0),
                      new Stats("EntitySpeed", 2, 0),
                      new Stats("EntityFireSpeed", 1, 0),
                      new Stats("EntityRoSpeed", 75, 0),
                      new Stats("MaxHealth", 5, 0),
                      new Stats("Cannons", 1 ,0)
                    }
                  );
  }
}
