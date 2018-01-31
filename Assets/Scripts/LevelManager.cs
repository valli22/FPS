using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	int lvl = 0;

	[SerializeField]
	GameObject player;

	GameObject checkPoint;

	[SerializeField]
	Vector3 firstPosition;

	[SerializeField]
	int pickUpsNeeded = 3;
	[SerializeField]
	int pickUps;

	[SerializeField]
	GameObject winText;

	[SerializeField]
	GameObject initialText;

	float timeToDeleteInitialText = 3;

	// Use this for initialization
	void Start () {
		pickUps = pickUpsNeeded;
		Invoke ("DeleteInitialText", timeToDeleteInitialText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextLvl(){
		if (pickUps <= 0) {
			winText.SetActive (true);
			Debug.Log ("Next lvl");
		}
	}

	public void SetCheckPoint(GameObject checkPointIn){
		Debug.Log ("CheckPoint set");
		checkPoint = checkPointIn;
	}

	public void Respawn(GameObject camera){
		Vector3 position;
		if (checkPoint == null) {
			position = firstPosition;
		} else {
			position = checkPoint.transform.position;
		}
		Instantiate (player, position, player.transform.rotation);	
		Destroy (camera);
	}

	public void PickUpTaken(){
		pickUps--;
	}

	void DeleteInitialText(){
		initialText.SetActive (false);
	}


}
