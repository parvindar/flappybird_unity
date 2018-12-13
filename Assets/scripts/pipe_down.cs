using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_down : MonoBehaviour {

	public character character;
	private Vector2 movpos;
	public pipe_up pipe_up;
	// Use this for initialization
	void Start () {
		character = FindObjectOfType<character> ();
		pipe_up = FindObjectOfType<pipe_up> ();
		movpos = transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		if (character.transform.position.x - transform.position.x >= 30)
			Destroy (gameObject);
	}

	void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, movpos.y + 15), pipe_up.movespeed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag== "Player")
		{
			if(character.music)
				character.crash.GetComponent<AudioSource> ().Play ();
			Handheld.Vibrate ();
			character.death ();
		}
	}


}
