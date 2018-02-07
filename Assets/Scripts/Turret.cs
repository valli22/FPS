using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[SerializeField]
	GameObject ammoPos;

	int actualAmmoPos;
	int totalAmmoPos;

	public float fireRate = 2;
	public float firePower = 7;
	public float lifeTimeBullet = 6;

	[SerializeField]
	GameObject balaPrefab;

	bool canShoot;

	// Use this for initialization
	void Start () {
		canShoot = true;
		actualAmmoPos = 0;
		totalAmmoPos = ammoPos.transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){		
		if (other.tag == "Player") {
			this.gameObject.transform.LookAt (other.transform);
			if (canShoot) {
				actualAmmoPos = (actualAmmoPos+1) % totalAmmoPos;
				GameObject bala = Instantiate (balaPrefab, ammoPos.transform.GetChild(actualAmmoPos).position,ammoPos.transform.GetChild(actualAmmoPos).rotation) as GameObject;
				bala.GetComponent<Rigidbody> ().AddForce (bala.transform.forward*firePower,ForceMode.Impulse);
				Destroy (bala, lifeTimeBullet);
				StartCoroutine (WaitToShoot());
			}
		}
	}


	IEnumerator WaitToShoot(){
		canShoot = false;
		yield return new WaitForSeconds (fireRate);
		canShoot = true;
	}
}
