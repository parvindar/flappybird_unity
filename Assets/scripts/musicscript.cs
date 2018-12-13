using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicscript : MonoBehaviour {
	private character character;
	// Use this for initialization
	void Start () {
		character = FindObjectOfType<character> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void soundon()
	{
		character.music = true;

	}
	public void soundoff()
	{
		character.music = false;

	}
}
