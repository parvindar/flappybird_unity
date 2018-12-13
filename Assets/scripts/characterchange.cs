using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterchange : MonoBehaviour {
	public GameObject[] birdlist;

	private int index;
	// Use this for initialization
	void Start () {
		index=PlayerPrefs.GetInt ("birdindex", 0);
		birdlist [index].SetActive (true);


	}
	

	public void left()
	{
		birdlist [index].SetActive (false);
		index--;
	//	Debug.Log ("index = "+index);
		if (index < 0)
			index = birdlist.Length - 1;

		birdlist [index].SetActive (true);
		PlayerPrefs.SetInt ("birdindex", index);

		
	}

	public void right()
	{
		birdlist [index].SetActive (false);
		index++;
		if (index >= birdlist.Length)
			index = 0;

		birdlist [index].SetActive (true);
		PlayerPrefs.SetInt ("birdindex", index);


	}


}
