using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Camera _camera = Camera.main;
		if(_camera == null)
			return;
        
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
