using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCannonHandler : MonoBehaviour
{
    [SerializeField] private EntityController entity;//the initial number of cannons the player has
    [SerializeField] private GameObject cannonPreFab; //the gameobject prefab for the cannon
    [SerializeField] private Transform parent; //the player, as is always the parent of this class
    [SerializeField] private int _cannons;

    public int Cannons { get => _cannons; set => _cannons = value; }

    public Transform getParent() {return this.parent;} //fetches the player transform for use
	public void setParent(Transform parent) {this.parent = parent;} //sets the player transform, if for any reason it chnages
	public GameObject getCannonPreFab() {return this.cannonPreFab;} //fetches the cannon prefab
	public EntityController getEntity() {return this.entity;} //fetches the number of cannons

    void Start()
    {
        PullStat(); //calls the calculation method
    }
    void PullStat(){
        Stats stat = getEntity().Sa.Find(r => r.statName == "Cannons");
        if(stat.flatStat != Cannons){
            Cannons = (int) Math.Max(Math.Min(stat.flatStat,10),1);
            Recalculate();
        }
        Cannons = (int) Math.Max(Math.Min(stat.flatStat,10),1);
    }

    void Recalculate() //recalculates the position of a number of cannons
    {
        foreach (Transform child in gameObject.transform){ //purges the current health bar, by iterating through each Cannon visible
            GameObject.Destroy(child.gameObject); //deletes each Cannon object
        }
        float x = 0; //stores the current angle that the new cannon should be made at, counts up each loop, possibly replaceable
        float angleOffset = (360/Cannons); //calculates the angle between each cannon
        float radius = 0.75f; //the radius from the centre of the player that the cannon spawns
        float rightAngleCorrection = 90f; //corrects for the initial positioning the player is in
        for(int n=0; n<Cannons; n++){ //repeat for n cannons
            double xrad = x * -(Math.PI / 180); //x in radian form, because the Math module uses raians, while unity uses degrees
            Vector3 positionalVector = getParent().position + new Vector3(radius*(float)Math.Sin(xrad), radius*(float)Math.Cos(xrad),0); //uses the radius of a circle to determine the x,z position of the cannon
            GameObject cannon = Instantiate(getCannonPreFab(), positionalVector, Quaternion.identity, getParent()); //creates the cannon prefab
            cannon.tag = "Player";
            cannon.transform.rotation = Quaternion.AngleAxis(x+rightAngleCorrection + gameObject.transform.rotation.z, getParent().transform.forward); //rotates the cannon prefab to the correct rotation
            x += angleOffset; //sets up the new angle for the next cannon
            cannon.GetComponent<CanonShoot>().PullStat();
        }
    }
}
