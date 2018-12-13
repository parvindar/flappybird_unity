using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animuiscript : MonoBehaviour {
	[SpaceAttribute(10)]
	[Header("Scale")]
	public bool animateonstart=true;
	public bool offset =true;
	public bool animateonenable=true;




	[SpaceAttribute(10)]
	[Header("timing")]
	public float delay=0;
	public float effecttime=1;
	[SpaceAttribute(10)]
	[Header("Scale")]
	public Vector3 startscale;
	public AnimationCurve scalecurve;

	[SpaceAttribute(10)]
	[Header("position")]
	public Vector3 startpos;
	public AnimationCurve poscurve;

	Vector3 endscale;
	Vector3 endpos;
	 character character;
	// Use this for initialization
	void Start () {
		character = FindObjectOfType<character> ();
		if (animateonstart) {
			if (isActiveAndEnabled)
				startanim ();

			animateonstart= false;

		}



	
	}

	void OnEnable()
	{
		if (animateonenable && !animateonstart) {
			startanim ();

		}
	}


	public void startanim()
	{
		Setvariables ();
		StartCoroutine (anim ());
	}
	void Setvariables()
	{
		endscale = transform.localScale;
		endpos = transform.localPosition;
		if (offset) {
			startpos += endpos;
		}


	}

	public IEnumerator anim()
	{
		transform.localPosition = startpos;
		transform.localScale = startscale;
		character.isanim = true;
		yield return new WaitForSecondsRealtime (delay);

		float time=0;
		float perc = 0;
		float lasttime = Time.realtimeSinceStartup;
		do {
			if(!character.isanim)
			character.isanim = true;
			time+=Time.realtimeSinceStartup- lasttime;
			lasttime=Time.realtimeSinceStartup;
			perc=Mathf.Clamp01(time/effecttime);
			Vector3 tempscale = Vector3.LerpUnclamped(startscale,endscale,scalecurve.Evaluate(perc));
			Vector3 temppos = Vector3.LerpUnclamped(startpos,endpos,poscurve.Evaluate(perc));



			transform.localScale= tempscale;
			transform.localPosition=temppos;
			
			yield return null;

		} while(perc < 1);

		transform.localPosition = endpos;
		transform.localScale = endscale;
		character.isanim = false;
		yield return null;

	}
		
	}

