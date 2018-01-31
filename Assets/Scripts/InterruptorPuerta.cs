using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPuerta : MonoBehaviour, Iinteractive {

	[SerializeField]
	Animator puertaAnimation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Action(){
		puertaAnimation.SetTrigger ("OpenDoor");
		Destroy (this);
	}

}
