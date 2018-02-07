using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class HUDManager : MonoBehaviour {

	[SerializeField]
	private Text ammoHUD;
	[SerializeField]
	private GameObject pauseMenu;

	bool paused = false;

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(player==null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (Input.GetButtonDown ("Cancel")) {
			_PAUSEDGAME ();
		}
			
	}

	public void UpdateAmmo(int ammo){
		ammoHUD.text = ammo.ToString();
	}

	public void UpdateAmmo(int ammo, int ammoMax){
		ammoHUD.text = ammo.ToString()+" / "+ammoMax.ToString();
	}

	public void UpdateHp(int hp){
		ammoHUD.text = hp+" hp";
	}

	public void _RESTARTGAME(){
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void _EXIT(){
		Application.Quit ();
	}

	public void _PAUSEDGAME(){
		paused = !paused;
		Time.timeScale = paused ? 0 : 1;
		pauseMenu.SetActive (paused);
		Cursor.visible = paused;
		player.GetComponent<FirstPersonController> ().enabled = !paused;
		player.GetComponent<ShootRaycast> ().enabled = !paused;
	}
	
}
