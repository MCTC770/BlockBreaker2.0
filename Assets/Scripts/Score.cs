using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

	float score = 0;
	[SerializeField] float scorePerBlock = 100;
	TextMeshProUGUI scoreTextElement;

	private void Awake()
	{
		if (FindObjectsOfType<Canvas>().Length <= 1)
		{
			DontDestroyOnLoad(this.gameObject);
		} else
		{
			gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		scoreTextElement = GetComponentInChildren<TextMeshProUGUI>();
		this.scoreTextElement.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(bool reset)
	{
		if (!reset)
		{
			score = score + (0.5f * scorePerBlock);
		} else
		{
			score = 0;
		}
		this.scoreTextElement.text = score.ToString();
	}
}
