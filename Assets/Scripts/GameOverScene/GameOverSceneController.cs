using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneController : MonoBehaviour {

	[SerializeField]
	private GameObject panel = null;
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
			if (panel)
				panel.SetActive(true);
		}
	}
}
