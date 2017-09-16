using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_backhome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void BackHome()
	{
		SceneManager.LoadScene("home_scene");
	}
}
