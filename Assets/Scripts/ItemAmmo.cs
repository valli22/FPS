using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmmo : MonoBehaviour {

	public int ammoGiven = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Shoot> ().AmmoBox(ammoGiven);
			Destroy (this.gameObject);
		}
	}
}
