using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
  [SerializeField] private Rigidbody2D rb;

  void setRb(Rigidbody2D rb){this.rb = rb;}
  public Rigidbody2D getRb(){return this.rb;}

  void Start(){
    setRb(GetComponent<Rigidbody2D>());
  }
}
