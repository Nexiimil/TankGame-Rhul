using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCannonHandler : MonoBehaviour
{
    [SerializeField] private int cannons = 1;
    [SerializeField] private GameObject cannonPreFab;
    [SerializeField] private Transform parent;

	public Transform getParent() {
		return this.parent;
	}

	public void setParent(Transform parent) {
		this.parent = parent;
	}

	public GameObject getCannonPreFab() {
		return this.cannonPreFab;
	}

	public int getCannons() {
		return this.cannons;
	}

	public void setCannons(int cannons) {
		this.cannons = cannons;
	}

    void Start()
    {
        Recalculate();
    }

    void Recalculate()
    {
        float x = 0;
        float angleOffset = (360/getCannons());
        float radius = 0.75f;
        float rightAngleCorrection = 90f;
        for(int n=0; n<getCannons(); n++){
            double xrad = x * -(Math.PI / 180);
            Vector3 positionalVector = getParent().position + new Vector3(radius*(float)Math.Sin(xrad), radius*(float)Math.Cos(xrad),0);
            GameObject cannon = Instantiate(getCannonPreFab(), positionalVector, Quaternion.identity, getParent());
            cannon.transform.rotation = Quaternion.AngleAxis(x+rightAngleCorrection, getParent().transform.forward);
            x += angleOffset;
        }
    }
}
