using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Screen.orientation == ScreenOrientation.Landscape)
			Screen.orientation = ScreenOrientation.Landscape;
		else if (Screen.orientation == ScreenOrientation.Portrait)
			Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeorientation()
	{
		if (Screen.orientation == ScreenOrientation.Landscape)
			Screen.orientation = ScreenOrientation.Portrait;
		
		else if (Screen.orientation == ScreenOrientation.Portrait)
			Screen.orientation = ScreenOrientation.Landscape;




			
	}
}
