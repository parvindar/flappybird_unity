using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newbackscript : MonoBehaviour {

	public character character;


	void Start()
	{
		character = FindObjectOfType<character> ();
	}

	void Update()
	{
		gameObject.transform.position += new Vector3 (2f * Time.fixedDeltaTime, 0, 0);

		if ((character.gameObject.transform.position.x - gameObject.transform.position.x >= 49.8f) && character.gameObject.transform.position.x >= 15) 
		{
			//Debug.Log ("adding back....!");
			gameObject.transform.position += new Vector3 (101f, 0, 0);
		}


		if (( gameObject.transform.position.x -character.gameObject.transform.position.x>= 49.8f) && Time.timeScale==0 ) 
		{
			//Debug.Log ("adding back....! backward");
			gameObject.transform.position += new Vector3 (-101f, 0, 0);
		}


		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, Camera.main.transform.position.y + 4.5f, gameObject.transform.position.z);
	}



}
