using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	GameObject popUP;

	[SerializeField]
	Toggle soundToggleON;
	[SerializeField]
	Toggle soundToggleOFF;

	//Invertir el eje y no se modifica puesto que habria que tocar el script MouseLook que viene del character controller (se podria hacer)
	[SerializeField]
	Toggle invertyToggleON;
	[SerializeField]
	Toggle invertyToggleOFF;

	// Use this for initialization
	void Start () {
		int sound = PlayerPrefs.GetInt ("sound",0);
		int inverty = PlayerPrefs.GetInt ("invertY",0);
		if (sound == 1) {
			soundToggleON.isOn = true;
			soundToggleOFF.isOn = false;
		} else {
			soundToggleON.isOn = false;
			soundToggleOFF.isOn = true;
		}
		if (inverty == 1) {
			invertyToggleON.isOn = true;
			invertyToggleOFF.isOn = false;
		} else {
			invertyToggleON.isOn = false;
			invertyToggleOFF.isOn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void _LOADSCENE(string scene){
		SceneManager.LoadScene (scene);
	}

	public void _SHOWPOPUP(){
		popUP.SetActive (true);
	}

	public void _CLOSEPOPUP(){
		popUP.SetActive (false);
	}

	public void _SOUND(int i){
		PlayerPrefs.SetInt("sound",i);
	}

	public void _INVERTY(int i){
		PlayerPrefs.SetInt ("invertY",i);
	}
}
