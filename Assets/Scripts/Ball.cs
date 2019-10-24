using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] GameObject Paddle;
	[SerializeField] AudioClip[] bounceSound;
	[SerializeField] float addDirectionalForce = 1;
	AudioSource ballClickSound;
	Vector2 paddleToBallVector;
	public bool notStarted = true;
	//int soundRandomizer = 4;

	// Use this for initialization
	void Start () {
		paddleToBallVector = transform.position - Paddle.transform.position;
		ballClickSound = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 paddlePosition = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y);
		if (notStarted == true)
		{
			transform.position = paddlePosition + paddleToBallVector;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!notStarted)
		{
			int soundRandomizer = Random.Range(0, bounceSound.Length);
			ballClickSound.PlayOneShot(bounceSound[soundRandomizer]);
			float currentForceDirectional = Random.Range(-addDirectionalForce, addDirectionalForce);
			gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * currentForceDirectional);
			gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * currentForceDirectional);
		}
	}
}
