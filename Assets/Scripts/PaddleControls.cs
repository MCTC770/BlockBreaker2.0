using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControls : MonoBehaviour {

	public Rigidbody2D paddleRigidbody;
	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float paddleBottom = 0.4f;
	[SerializeField] float minValue = 1.4f;
	[SerializeField] float maxValue = 14.6f;
	[SerializeField] Rigidbody2D ballRigidbody2D;
	[SerializeField] Vector2 startForce = new Vector2(0, 100);
	bool autoplayEnabled = false;
	float positioning;
	bool initializationComplete = false;
	Vector2 mousePositioning;
	Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		BallToPaddle();
		LaunchOnMouseClick();
	}

	private void BallToPaddle()
	{
		positioning = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
		float clampedPosition = Mathf.Clamp(positioning, minValue, maxValue);
		mousePositioning = new Vector2(clampedPosition, paddleBottom);
		paddleRigidbody.position = mousePositioning;
	}

	private void LaunchOnMouseClick()
	{
		if ((Input.GetMouseButton(0) && initializationComplete == false) || (autoplayEnabled && initializationComplete == false))
		{
			ball.notStarted = false;
			ballRigidbody2D.AddForce(startForce);
			initializationComplete = true;
		}
	}

	public void AutoPlay(bool autoPlayOn)
	{
		if (autoPlayOn)
		{
			gameObject.transform.position = new Vector2
				(Mathf.Clamp(ball.transform.position.x, minValue, maxValue),
				gameObject.transform.position.y);
			autoplayEnabled = true;
		}
		else
		{
			autoplayEnabled = false;
		}
	}
}