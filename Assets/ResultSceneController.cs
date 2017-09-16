using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCount > 0)
#endif
		{
			SceneManager.LoadScene("home_scene");
		}
	}
}
