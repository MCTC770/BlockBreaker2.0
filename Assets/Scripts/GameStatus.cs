using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	[SerializeField] [Range(0.25f, 4f)] float timeScaling = 1f;
	[SerializeField] bool autoPlayOn = false;
	PaddleControls paddle;

	// Use this for initialization
	void Start () {
		paddle = FindObjectOfType<PaddleControls>();
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = timeScaling;
		if (autoPlayOn)
		{
			paddle.AutoPlay(true);
		}
	}
}
