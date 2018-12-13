using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightchange : MonoBehaviour {
	
	public GameObject[] backlist;
	public GameObject backg;
	public character character;
	private GameObject[] instantlist;

	// Use this for initialization
	void Start () {
		

		character = FindObjectOfType<character> ();


	}
	
	// Update is called once per frame
	void Update ()
	{
		




	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		//Debug.Log ("score");
		if (collider.gameObject.tag == "scorer") 
		{
			instantlist = GameObject.FindGameObjectsWithTag ("back");

			// city day-night.
			if (backlist[1].activeSelf) 
			{
				//Debug.Log ("count = " +character.count);
				if (character.count == 20) {
					character.count = 0;
					//Debug.Log ("change.... yoooooo");
					backlist [1].SetActive (false);
					backlist [2].SetActive (true);
					PlayerPrefs.SetInt ("backindex", 5);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);


				}
			}

			else	if (backlist [2].activeSelf) 
			{
				//Debug.Log ("count = " +character.count);
				if (character.count == 20)  {
					character.count = 0;
					//Debug.Log ("change....");
					backlist [2].SetActive (false);
					backlist [1].SetActive (true);
					PlayerPrefs.SetInt("backindex",1);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);


				}
			}


			//forest day-night.

			if (backlist[8].activeSelf) 
			{
				
				if (character.count == 20)  {
					character.count = 0;
					Debug.Log ("change....");
					backlist [8].SetActive (false);
					backlist [9].SetActive (true);
					PlayerPrefs.SetInt("backindex",8);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);

				}
			}

			else	if (backlist [9].activeSelf) 
			{
				
				if (character.count == 20)  {
					//Debug.Log ("change....");
					backlist [9].SetActive (false);
					backlist [8].SetActive (true);
					PlayerPrefs.SetInt("backindex",9);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);
					character.count = 0;
				}
			}


			//desert day-night


			if (backlist[6].activeSelf) 
			{
				
				if (character.count == 20)  {
					character.count = 0;
					Debug.Log ("change....");
					backlist [6].SetActive (false);
					backlist [7].SetActive (true);
					PlayerPrefs.SetInt("backindex",7);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);

				}
			}

			else	if (backlist [7].activeSelf) 
			{
				
				if (character.count == 20)  {
					character.count = 0;
					//Debug.Log ("change....");
					backlist [7].SetActive (false);
					backlist [6].SetActive (true);
					PlayerPrefs.SetInt("backindex",6);
					Instantiate (backg, instantlist [0].transform.position, instantlist [0].transform.rotation);
					Instantiate (backg, instantlist [1].transform.position, instantlist [1].transform.rotation);
					Destroy (instantlist [0]);
					Destroy (instantlist [1]);

				}
			}






		}

	}
}

	
