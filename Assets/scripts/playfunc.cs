using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playfunc : MonoBehaviour {
	public character character;


	void Start()
	{
		character = FindObjectOfType<character> ();
	}
	public void playf()
	{

			if (character.music)
				character.scoretext.GetComponent<AudioSource> ().Play ();
			character.birdsay.gameObject.SetActive (false);
			Time.timeScale = 1.25f;
			character.rb.velocity = new Vector2 (character.rb.velocity.x, character.jump);
			character.isdeath = false;
		//------------------------------------------------gamesplayed--------------------------------------

	}


}
