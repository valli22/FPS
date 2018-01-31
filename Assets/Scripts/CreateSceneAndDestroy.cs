using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSceneAndDestroy : MonoBehaviour, Iinteractive {

	[SerializeField]
	Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Action (){
		anim.SetTrigger ("OpenDoor2");
		SceneManager.LoadSceneAsync ("ObjectMainScene",LoadSceneMode.Additive);
	}
}
