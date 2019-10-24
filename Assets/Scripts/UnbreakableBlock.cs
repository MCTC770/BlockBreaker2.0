using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableBlock : MonoBehaviour {

	[SerializeField] AudioClip breakSound;
	Camera playerCamera;

	private void Start()
	{
		playerCamera = GameObject.FindObjectOfType<Camera>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(breakSound, playerCamera.transform.position);
	}
}

