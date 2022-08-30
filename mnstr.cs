using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]

public class mnstr : MonoBehaviour
{
	[SerializeField] Sprite _deadsprite;
	[SerializeField] ParticleSystem _ParticleSystem;
	bool _hasDied;
	   
	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if(ShouldDieForCollision(collision))
		   {
			StartCoroutine(Die());
		   }
	}
	
	private bool ShouldDieForCollision(Collision2D collision)
	{
		if (_hasDied)
			return false;
		
		finalBird bird = collision.gameObject.GetComponent<finalBird>();
		if(bird != null)
			return true;
		if(collision.contacts[0].normal.y < -0.5)
			return true;
		
		return false;
		
	}
		
	IEnumerator Die()
	{
		_hasDied = true;
		GetComponent<SpriteRenderer>().sprite = _deadsprite;
		_ParticleSystem.Play();
		yield return new WaitForSeconds(1);
		gameObject.SetActive(false);
	}


}
