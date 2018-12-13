using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camscript : MonoBehaviour {

	public Transform target;
	public character character;

	public bool smoothcam;
	// Use this for initialization
	public Vector3 offset;
	public float smoothspeed= .5f;
	public Vector3 velocity= Vector3.one;


	public bool looktarget;
	// Update is called once per frame


	void Start()
	{
		character = FindObjectOfType<character> ();


	}
	void Update()
	{
		if (character.isdeath&&!character.mainmenu.activeSelf) {
			transform.position = target.position + offset;
		//	Debug.Log ("death,...");
		}

		
		}
	void LateUpdate () {

		if (!character.mainmenu.activeInHierarchy) {

			Vector3 desiredpos = new Vector3 (target.position.x, 0, 0) + offset;
			if (smoothcam == false) {
				transform.position = desiredpos;
			} else {
				transform.position = Vector3.Lerp (transform.position, desiredpos, smoothspeed);
			}
			if (looktarget == true)
				transform.LookAt (target);
		}
	}
}
