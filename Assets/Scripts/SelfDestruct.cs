using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float timeUntilSelfDestruct = 1f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, timeUntilSelfDestruct);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
