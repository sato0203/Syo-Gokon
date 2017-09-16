using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_retry : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	public void Retry()
	{
        SceneManager.LoadScene("InGame");
	}
}
