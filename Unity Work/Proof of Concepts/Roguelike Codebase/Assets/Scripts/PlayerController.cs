using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
  [SerializeField]
  private Rigidbody2D rb;

  [SerializeField]
  private float[] position = {0,0};

  void setRb(Rigidbody2D rb){this.rb = rb;}
  Rigidbody2D getRb(){return this.rb;}

  void setPosition(float[] position){this.position = position;}

  void setPositionHorizontal(float horizontal){this.position[0] = horizontal;}
  void setPositionVertical(float vertical){this.position[1] = vertical;}
  float getPositionHorizontal(){return this.position[0];}
  float getPositionVertical(){return this.position[1];}
  
  // Start is called before the first frame update
  void Start(){
    setRb(GetComponent<Rigidbody2D>());
  }

  // Update is called once per frame
  void Update(){
    setPosition(new float[] {Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")});
  }

  void FixedUpdate(){
    getRb().velocity = new Vector2(getPositionHorizontal(), getPositionVertical());
  }

}
