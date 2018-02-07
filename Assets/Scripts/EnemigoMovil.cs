using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMovil : MonoBehaviour {

	NavMeshAgent navMesh;
	public float movementRange = 10;

	public float minWait = 1;
	public float maxWait = 5;

	bool enterMove = true;

	string state;

	NavMeshHit navHit;

	// Use this for initialization
	void Start () {
		navMesh = GetComponent<NavMeshAgent> ();
		state = "Wait";
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (state);
		switch (state) 
		{
		case "Wait":
			WaitState ();
			break;

		case "CalculatePosition":
			if (enterMove) {
				enterMove = false;
				CalculateState ();

			}
			break;
		
		case "Move":
			Move ();
			break;

		case "Moving":
			Debug.Log ("Moving");
			if (navMesh.remainingDistance <= 0.1f) {
				Debug.Log ("Wait");
				state = "Wait";

			}
			break;
		}
	}


	void WaitState(){
		float secondsWaiting = Random.Range (minWait,maxWait);
		StartCoroutine (Wait(secondsWaiting));
	}

	IEnumerator Wait(float seconds){
		yield return new WaitForSeconds (seconds);
		state = "CalculatePosition";
	}


	void CalculateState(){
		Vector3 position;
		do {
			position = this.transform.position + Random.insideUnitSphere * movementRange;
		} while(!NavMesh.SamplePosition (position, out navHit, 1, NavMesh.AllAreas));
		state = "Move";
		enterMove = true;
	}

	void Move(){
		navMesh.destination = navHit.position;
		Debug.Log (navMesh.remainingDistance);
		state = "Moving";
	}
}
