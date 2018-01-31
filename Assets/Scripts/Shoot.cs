using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	[SerializeField]
	private GameObject balaPrefab;
	public float force = 50;

	[SerializeField]
	private GameObject ammoPos;

	[SerializeField]
	private ParticleSystem particleSystem;

	[SerializeField]
	private AudioClip audio;
	[SerializeField]
	private AudioClip reloadSound;

	[SerializeField]
	private Animator weaponAnimator;

	[SerializeField]
	private AnimationClip reloadAnim;
	[Range(0.5f,5.0f)]
	public float reloadAnimSpeed = 1;

	[SerializeField]
	private HUDManager hudManager;

	[SerializeField]
	private int maxAmmo = 50;
	[SerializeField]
	private int ammoCharger = 8;
	private int ammoCount;
	private int ammoLeft;

	private bool canShoot = true;

	// Use this for initialization
	void Start () {
		ammoCount = ammoCharger;
		ammoLeft = maxAmmo - ammoCharger;
		hudManager.UpdateAmmo (ammoCount, ammoLeft);
		weaponAnimator.SetFloat ("Speed",reloadAnimSpeed);
	}

	void Update(){
		if (Input.GetMouseButtonDown(1)) {
			if(!(ammoLeft==0) && !(ammoCount==ammoCharger)){
				AudioSource.PlayClipAtPoint (reloadSound, transform.position, 1);
				canShoot = false;
				weaponAnimator.SetTrigger ("Recarga");
				if (ammoLeft - (ammoCharger - ammoCount) >= 0) {
					ammoLeft -= ammoCharger - ammoCount;
					ammoCount = ammoCharger;
				} else {
					ammoCount += ammoLeft;
					ammoLeft = 0;
				}
				hudManager.UpdateAmmo (ammoCount,ammoLeft);
				StartCoroutine ("Reloading");
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (canShoot) {
			if (Input.GetMouseButtonDown (0) && ammoCount >= 1) {
				//weaponAnimator.SetTrigger ("Disparo");
				weaponAnimator.Play ("WeaponAnimation1", 0, 0);
				particleSystem.Play ();
				AudioSource.PlayClipAtPoint (audio, transform.position, 1);
				GameObject bala = Instantiate (balaPrefab, ammoPos.transform.position, ammoPos.transform.rotation);
				bala.GetComponent<Rigidbody> ().AddForce (bala.transform.forward * force, ForceMode.Impulse);
				Destroy (bala, 10);
				ammoCount--;
				hudManager.UpdateAmmo (ammoCount, ammoLeft);
			}
		}
	}

	IEnumerator Reloading(){
		yield return new WaitForSeconds (reloadAnim.length/reloadAnimSpeed);
		this.canShoot = true;
	}

	public void AmmoBox(int ammoGiven){
		ammoLeft += ammoGiven;
		hudManager.UpdateAmmo (ammoCount, ammoLeft);
	}
}
