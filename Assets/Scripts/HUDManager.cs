using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField]
	private Text ammoHUD;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateAmmo(int ammo){
		ammoHUD.text = ammo.ToString();
	}

	public void UpdateAmmo(int ammo, int ammoMax){
		ammoHUD.text = ammo.ToString()+" / "+ammoMax.ToString();
	}
}
