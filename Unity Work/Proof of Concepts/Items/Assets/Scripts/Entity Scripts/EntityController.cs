using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EntityController : MonoBehaviour{
  [SerializeField] private StatArray sa;
  [SerializeField] private Rigidbody2D rb;

  void setStatArray(StatArray sa){this.sa = sa;}
  public StatArray getStatArray(){return this.sa;}

  void setRB(Rigidbody2D rb){this.rb = rb;}

  public Rigidbody2D getRB(){return this.rb;}


  void Start(){
    setStatArray(new StatArray());
  }
}
