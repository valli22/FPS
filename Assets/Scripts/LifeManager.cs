using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

	public int life = 100;

	[SerializeField]
	float timeDeath = 3;

	[SerializeField]
	HUDManager hudManagerScript;

	[SerializeField]
	LevelManager lvlManager;

	// Use this for initialization
	void Start () {
		hudManagerScript = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUDManager> ();
		hudManagerScript.UpdateHp (life);
		lvlManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			/*GameObject deathcamara = this.gameObject.transform.GetChild (0).GetChild (2).gameObject;
			deathcamara.transform.parent = null;

			deathcamara.SetActive (true);
			lvlManager.Respawn (deathcamara);
			Destroy (this.gameObject);*/
			lvlManager.Respawn (this.gameObject);
		}	
	}

	public void TakeDamage(int damage){
		if (life > 0) {
			life -= damage;
			hudManagerScript.UpdateHp (life);
		}
	}


}
