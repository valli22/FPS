using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {
	[SerializeField]
	Animator animator;
	[SerializeField]
	GameObject escenario;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			animator.SetTrigger ("CloseDoor2");
			Destroy (escenario);
		}
	}
}
