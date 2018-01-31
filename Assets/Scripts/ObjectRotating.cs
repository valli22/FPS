using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotating : MonoBehaviour {

	public float rotateVelocity = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (rotateVelocity,0,0);
	}
}
