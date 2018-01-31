using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableElement : MonoBehaviour {
	[SerializeField]
	int life = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetDamage(int i){
		life -= i;
		if (life <= 0)
			Destroy (this.gameObject);
	}
}
