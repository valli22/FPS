using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvl : MonoBehaviour {

	[SerializeField]
	GameObject levelManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			levelManager.GetComponent<LevelManager> ().NextLvl ();
	}
}
