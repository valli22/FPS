using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour {

	[SerializeField]
	private Transform shootPosition;
	private RaycastHit hitInfo;

	public int gunDamage = 10;
	public float fireDelay = 0.3f;
	public int gunDistance = 50;
	public float hitForce = 100;

	public float actionDistance = 10;
	float timeToShoot;
	[SerializeField]
	private LineRenderer lineRenderer;

	private float timeLineRendering = 1;

	[SerializeField]
	int maxAmmo = 20;
	int ammoCount;

	[SerializeField]
	GameObject shootMark;
	[SerializeField]
	float timeToDestroyShotMark = 5;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().enabled = PlayerPrefs.GetInt ("sound") == 1;
		ammoCount = maxAmmo;
		timeToShoot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && ammoCount>0 && Time.time > timeToShoot) {
			//apuntado en el centro de la camara
			Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3 (0.5f,0.5f,0));
			if (Physics.Raycast (origin, shootPosition.forward, out hitInfo, gunDistance)) {
				Debug.Log (hitInfo.collider.gameObject.name);
			}
			Debug.DrawRay (origin,shootPosition.forward*gunDistance,Color.red,2);
			timeToShoot = Time.time + fireDelay;

			lineRenderer.SetPosition (0,origin);
			if(hitInfo.collider!=null){
				lineRenderer.SetPosition (1,hitInfo.point);
				GameObject shotMark = Instantiate(shootMark,hitInfo.point, Quaternion.identity) as GameObject;
				shotMark.transform.forward = -hitInfo.normal;
				shotMark.transform.Translate (0,0,-0.001f);
				shotMark.transform.parent = hitInfo.transform;
				Destroy (shotMark, timeToDestroyShotMark);

				ShootableElement shootScipt = hitInfo.collider.gameObject.GetComponent<ShootableElement> ();
				if (shootScipt != null)
					shootScipt.GetDamage (gunDamage);
				Rigidbody rb = hitInfo.collider.gameObject.GetComponent<Rigidbody> ();
				if (rb != null)
					rb.AddForce (Camera.main.transform.forward*hitForce,ForceMode.Impulse);

			}else {
				lineRenderer.SetPosition (1,Camera.main.transform.forward*gunDistance);
			}

			StartCoroutine ("LineRendererDestroy");
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3 (0.5f,0.5f,0));
			if (Physics.Raycast (origin, shootPosition.forward, out hitInfo, actionDistance)) {
				if (hitInfo.collider.tag == "InteractiveObjects") {
					Iinteractive interactiveScript = hitInfo.collider.gameObject.GetComponent<Iinteractive> ();
					if (interactiveScript != null)
						interactiveScript.Action ();
				}
			}
		}
	}

	IEnumerator LineRendererDestroy(){
		lineRenderer.enabled = true;
		yield return new WaitForSeconds (timeLineRendering);
		lineRenderer.enabled = false;
	}
}
