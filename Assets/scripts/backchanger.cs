using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backchanger : MonoBehaviour {
	public GameObject[] backgroundlist;
	public int index;
	public GameObject[] instantlist;
	public GameObject backg;





	// Use this for initialization
	void Start () {
		
		index = PlayerPrefs.GetInt ("backindex",0);

		backgroundlist[index].SetActive (true);
		


	}
	
	// Update is called once per frame

	void Update()
	{
		instantlist=GameObject.FindGameObjectsWithTag("back");

	}


		public void left()
		{
			backgroundlist[index].SetActive (false);
			index--;
			if (index < 0)
			index = backgroundlist.Length - 1;

		backgroundlist[index].SetActive (true);
		Instantiate (backg, instantlist [0].transform.position,instantlist[0].transform.rotation);
		Instantiate (backg, instantlist [1].transform.position,instantlist[1].transform.rotation);
		Destroy (instantlist [0]);
		Destroy (instantlist [1]);


		PlayerPrefs.SetInt ("backindex", index);

			

		}

		public void right()
		{
		backgroundlist[index].SetActive (false);

			index++;
	Destroy (instantlist [0]);
	Destroy (instantlist [1]);
		if (index >= backgroundlist.Length)
				index = 0;
		
		backgroundlist [index].SetActive (true);
		Instantiate (backg, instantlist [0].transform.position,instantlist[0].transform.rotation);
		Instantiate (backg, instantlist [1].transform.position,instantlist[1].transform.rotation);
		Destroy (instantlist [0]);
		Destroy (instantlist [1]);

		PlayerPrefs.SetInt ("backindex", index);


		
		}


}
