using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	[SerializeField]
	GameObject lvlManager;

	[SerializeField]
	float timeDeath = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			/*GameObject deathcamara = other.gameObject.transform.GetChild (0).GetChild (2).gameObject;
			deathcamara.transform.parent = null;

			deathcamara.SetActive (true);
			Destroy (other.gameObject);
			lvlManager.GetComponent<LevelManager> ().Respawn (deathcamara);
			*/
			lvlManager.GetComponent<LevelManager> ().Respawn (other.gameObject);
			//StartCoroutine (TimeDeath(deathcamara));
		}
	}

	/*
	IEnumerator TimeDeath(GameObject deathcamera){
		yield return new WaitForSeconds(timeDeath);
		lvlManager.GetComponent<LevelManager> ().Respawn (deathcamera);
	}*/
}
