using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour {

	[SerializeField][Range (1, 3)] int blockHP = 3;
	[SerializeField] Sprite blockSpriteDamage1;
	[SerializeField] Sprite blockSpriteDamage2;
	[SerializeField] AudioClip breakSound;
	[SerializeField] ParticleSystem destroyParticles;
	Camera playerCamera;
	bool spritesError = false;
	bool soundError = false;
	bool particleError = false;

	private void Start()
	{
		playerCamera = GameObject.FindObjectOfType<Camera>();
		ShowBlockDamage();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		blockHP -= 1;
		ShowBlockDamage();
	}

	void ShowBlockDamage()
	{
		if (blockSpriteDamage1 == null || blockSpriteDamage2 == null)
		{
			spritesError = true;
			Debug.LogError("Block sprite is missing. " + gameObject.name);
		} else if (breakSound == null)
		{
			soundError = true;
			Debug.LogError("Break sound is missing. " + gameObject.name);
		} else if (destroyParticles == null)
		{
			particleError = true;
			Debug.LogError("Particle effect is missing. " + gameObject.name);
		}

		if (blockHP == 2 && !spritesError)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = blockSpriteDamage1;
		}
		else if (blockHP == 1 && !spritesError)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = blockSpriteDamage2;
		}
		else if (blockHP <= 0 && !soundError && destroyParticles)
		{
			AudioSource.PlayClipAtPoint(breakSound, playerCamera.transform.position);
			Instantiate<ParticleSystem>(destroyParticles, this.gameObject.transform.position, Quaternion.identity);
			FindObjectOfType<Score>().UpdateScore(false);
			Destroy(this.gameObject);
		}
	}
}
