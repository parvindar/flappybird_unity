using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_up : MonoBehaviour {
	private character character;
	public GameObject pipe_down;
	 
	private Vector2 movpos;
	public int movespeed;

	// Use this for initialization
	void Start () {
		character = FindObjectOfType<character> ();
		movpos = transform.position;
		if (character.currentscore< 20)
			movespeed = 4;
		else
		movespeed = Random.Range (2, 7);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		if (character.transform.position.x - transform.position.x > 27)
		{
			
			//float xran = Random.Range (0,.25f);
			float yran = Random.Range (-4.75f, 5f);
			float gap = Random.Range (0f, .5f);

			Instantiate (gameObject, new Vector2 (transform.position.x + 54 +1.5f , 35f + yran +gap), transform.rotation);
		

		
			Instantiate(pipe_down,new Vector2(transform.position.x + 54 +1.5f, -18.5f-15 + yran ),transform.rotation);

			Destroy (gameObject);
		}

		transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, movpos.y - 15), movespeed * Time.deltaTime);


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
