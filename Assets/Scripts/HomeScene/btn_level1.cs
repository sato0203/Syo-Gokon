﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_level1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void GoStage() {
        PlayerPrefs.SetInt("stage", 0);
        PlayerPrefs.Save();
		SceneManager.LoadScene("InGame");

	}
}
