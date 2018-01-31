using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {

	[SerializeField]
	GameObject lvlManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			lvlManager.GetComponent<LevelManager> ().PickUpTaken ();
			Destroy (this.gameObject);
		}
	}
}
