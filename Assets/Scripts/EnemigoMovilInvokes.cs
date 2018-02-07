using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMovilInvokes : MonoBehaviour {

	NavMeshAgent navMesh;
	public float minWait = 1;
	public float maxWait = 5;

	bool hasArrived = false;

	public float movementRange = 10;

	NavMeshHit hit;

	public float distanceToShoot = 50;

	bool canFind = true;

	GameObject activePlayer;

	[SerializeField]
	Transform shootPoint;

	public int minBullets = 1;
	public int maxBullets = 4;
	public float timeBetweenBullets = 0.5f;
	[SerializeField]
	GameObject balaPrefab;
	public float bulletPower = 50;
	bool founded = false;

	// Use this for initialization
	void Start () {
		activePlayer = GameObject.FindGameObjectWithTag ("Player");
		navMesh = GetComponent<NavMeshAgent> ();
		Invoke ("Move",Random.Range(minWait,maxWait));
		founded = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activePlayer==null)
			activePlayer = GameObject.FindGameObjectWithTag ("Player");
		
		if (navMesh.remainingDistance <= 0.1 && canFind) {
			onRange ();
		}

		Vector3 whereToLook = founded ? activePlayer.transform.position : navMesh.destination;
		transform.LookAt (whereToLook);
		transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y,0);
	}

	void Move(){
		founded = false;
		while(!hasArrived){
			if(NavMesh.SamplePosition(transform.position + Random.insideUnitSphere*movementRange, out hit, 1.0f, NavMesh.AllAreas)){
				navMesh.destination = hit.position;
				hasArrived = true;
				canFind = true;
			}
		}
	}

	void onRange(){
		founded = true;
		float distance = Vector3.Distance (transform.position,activePlayer.transform.position);
		RaycastHit hitInfo;
		/*
		if (distance <= distanceToShoot && Physics.Raycast (shootPoint.position, activePlayer.transform.position-shootPoint.position, out hitInfo, distanceToShoot)) {
			Debug.Log ("Esta a rango");
			if (hitInfo.transform.tag == "Player") {
				Debug.Log ("Es un jugador");
				StartCoroutine (shootPlayer ());
			} else {
				hasArrived = false;
				Invoke ("Move",Random.Range(minWait,maxWait));
			}*/
		if (distance <= distanceToShoot){
			StartCoroutine (shootPlayer ());
		} else {
			Debug.Log ("no esta a rango");
			hasArrived = false;
			Invoke ("Move",Random.Range(minWait,maxWait));
		}
		canFind = false;
	}

	IEnumerator shootPlayer(){
		//this.gameObject.transform.LookAt (activePlayer.transform);
		int numberOfShoots = Random.Range (minBullets,maxBullets);
		for (int i = 0; i < numberOfShoots-1; i++) {

			GameObject bala = Instantiate (balaPrefab, shootPoint.position,shootPoint.rotation) as GameObject;
			bala.GetComponent<Rigidbody> ().AddForce (bala.transform.forward*bulletPower,ForceMode.Impulse);
			Destroy (bala, 5);
			yield return new WaitForSeconds (timeBetweenBullets);
		}
		hasArrived = false;
		Invoke ("Move",Random.Range(minWait,maxWait));
	}
}
