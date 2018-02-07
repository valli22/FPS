using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrap : MonoBehaviour {

	public int damage = 5;
	public float timeBetweenDamage = 1.0f;

	private LifeManager actualPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			actualPlayer = other.gameObject.GetComponent<LifeManager>();
			InvokeRepeating ("MakeDamage", 0, timeBetweenDamage);
		}
	}

	void OnTriggerExit(Collider other){
		CancelInvoke ();
	}

	void MakeDamage(){
		actualPlayer.TakeDamage (damage);
	}

	public void CancelInvokeOutSide(){
		CancelInvoke ();
	}
}
