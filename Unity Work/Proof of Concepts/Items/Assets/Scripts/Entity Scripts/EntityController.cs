using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EntityController : MonoBehaviour{
  [SerializeField] private List<Stats> sa;
  [SerializeField] private Rigidbody2D rb;

  public void setStatArray(List<Stats> sa){this.sa = sa;}
  public List<Stats> getStatArray(){return this.sa;}

  void setRB(Rigidbody2D rb){this.rb = rb;}

  public Rigidbody2D getRB(){return this.rb;}


  void Start(){
    setStatArray(new List<Stats>{
                      new Stats("BulletType", 0, 0),
                      new Stats("BulletDamage", 1, 0),
                      new Stats("BulletSpeed", 0, 0),
                      new Stats("BulletCrit", 0, 0),
                      new Stats("EntityArmour", 0, 0),
                      new Stats("EntitySpeed", 2, 0),
                      new Stats("EntityFireSpeed", 30, 0),
                      new Stats("EntityRoSpeed", 5, 0),
                      new Stats("MaxHealth", 5, 0),
                      new Stats("Cannons", 1,0)
                    }
                  );
  }
}
