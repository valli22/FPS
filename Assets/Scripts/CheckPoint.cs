using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

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
			lvlManager.GetComponent<LevelManager> ().SetCheckPoint (this.gameObject);
			GetComponent<MeshRenderer> ().material.color = new Color(0,1,0,0.5f);
			Destroy (this);
		}
			
	}
}
