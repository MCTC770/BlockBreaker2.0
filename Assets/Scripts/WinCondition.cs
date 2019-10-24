using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponentsInChildren<DamageBlock>().Length <= 0)
		{
			FindObjectOfType<SceneLoader>().LoadNextScene();
		}
	}
}
