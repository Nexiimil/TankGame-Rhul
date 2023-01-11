using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
  [SerializeField] private StatArray sa;

  void setStatArray(StatArray sa){this.sa = sa;}
  public StatArray getStatArray(){return this.sa;}


  void Start(){
    setStatArray(GetComponent<StatArray>());
  }
}
