using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class character : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject pipe_up;
	public GameObject pipe_down;
	public TextMeshPro birdsay;

	public float movespeed=5f;
	public float jump=8f;
	public BoxCollider2D scorecollider;


	public TextMeshProUGUI recenttext;
	public int currentscore=0;
	public int recentscore=0;
	//public Button button;
	public Button pausebutton;
	public Button pausebutton2;
	public Button rewardbtn;
	public Button retrybtn;
	//private bool pause;
	public float rotatetime=1f;
	public TextMeshProUGUI highscore;
	public TextMeshProUGUI scoretext;

	public bool isdeath=false;
	public TextMeshProUGUI d_highscore;
	public TextMeshProUGUI d_scoretext;
	public GameObject deathmenu;
	public GameObject mainmenu;
	public GameObject retrymenu;
	public birdtalkscript birdtalk;
	public GameObject settings;
	public GameObject background;
	public GameObject newbackscript;
	public int coins;
	public int count=0;
	private Vector3 birdscale;
	public backchanger backchanger;
	characterchange characterchange;
	//private admanager_ admanager;

	public int adcount=0;
	private AudioSource audiosource;
	public bool music;
	public GameObject crash;
	public bool adwatched = false;
	public GameObject scoreboard;

	public GameObject goldmedal;
	public GameObject silvermedal;
	public GameObject bronzemedal;
	public bool isanim=false;
	public GameObject highscorepopup;
	PlayServicesScript playservicesscript;
	public GameObject infopanel;
	public float scaletime;


	public float initime;



	void OnTriggerEnter2D(Collider2D collider)

	{
		
		if (collider.gameObject.tag == "scorer") 
		{
			if(music)
			pausebutton.GetComponent<AudioSource> ().Play ();
			collider.gameObject.SetActive (false);


			currentscore++;

			count++;
			if (count == 21)
			{
				count = 0;
			}
			scoretext.text = currentscore.ToString ();



			switch (currentscore)
			{
			case 1:
				playservicesscript.UnlockAchievement (WingResources.achievement_entry_to_the_world);
				break;
			case 10:
				playservicesscript.UnlockAchievement (WingResources.achievement_little_experienced);
				
				break;
			case 50:
				playservicesscript.UnlockAchievement (WingResources.achievement_half_century);
				break;
			case 100:
				playservicesscript.UnlockAchievement (WingResources.achievement_century);
				break;
			case 150:
				playservicesscript.UnlockAchievement (WingResources.achievement_100__50);
				break;
			case 200:
				playservicesscript.UnlockAchievement (WingResources.achievement_pro_flyer);
				break;
			case 250:
				playservicesscript.UnlockAchievement (WingResources.achievement_200__50);
				break;
			case 500:
				playservicesscript.UnlockAchievement (WingResources.achievement_wing_master);
				break;
			default:
				
				break;
			}
		




		}
		
	}


	void Awake()
	{
		if (!mainmenu.activeSelf)
			mainmenu.SetActive (true);

		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {




		scaletime = 1.94f;
		playservicesscript = FindObjectOfType<PlayServicesScript> ();
		audiosource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D> ();
		birdtalk = FindObjectOfType<birdtalkscript> ();
		backchanger = FindObjectOfType<backchanger> ();
		characterchange = FindObjectOfType<characterchange> ();
		backchanger.backgroundlist [PlayerPrefs.GetInt("backindex",0)].SetActive(true);
		buildlevel();
		rewardbtn.gameObject.SetActive (false);
		highscore.text = "Highscore " +PlayerPrefs.GetInt ("highscore").ToString ();
	//	pause = false;

	//	button.onClick.AddListener (Application.Quit);
		Time.timeScale = 0;
		pausebutton.onClick.AddListener (pausefunc);

		mainmenu.SetActive (true);
		deathmenu.SetActive (false);
		Camera.main.orthographicSize = 12;

		birdscale = gameObject.transform.localScale;
		//admanager = FindObjectOfType<admanager_> ();


		highscorepopup.SetActive (false);
	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.timeScale!=0)
		if (Time.timeScale < scaletime) 
		{
			Time.timeScale += Time.deltaTime * 0.05f;
		}
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
		rb.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, -20), 1 * Time.fixedDeltaTime);
		if (rb.velocity.y < -5.5f)
			rb.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, -150), 1.5f * Time.fixedDeltaTime);

		if (Input.GetMouseButtonDown (0)) {
			if (music)
				audiosource.Play ();
			rb.velocity = new Vector2 (rb.velocity.x, jump);
			rb.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (transform.position.y >= 16 || transform.position.y <= -16) {
			if (music)
				Camera.main.GetComponent<AudioSource> ().Play ();
			death ();
		}


	}




	

	
	void Update()
	{
	//	Debug.Log (Application.targetFrameRate);

		if (retrymenu.activeSelf)
		{
			if (!isanim) {
				retrybtn.interactable = true;
				pausebutton2.gameObject.SetActive (true);
			}
		}



		if (Input.GetKeyDown (KeyCode.Escape)&&!isanim) 
		{
			if (!mainmenu.activeSelf) {
				if (infopanel.activeSelf)
					infopanel.SetActive (false);
				pausefunc ();
				if (bronzemedal.activeSelf)
					bronzemedal.SetActive (false);
				if (goldmedal.activeSelf)
					goldmedal.SetActive (false);
				if (silvermedal.activeSelf)
					silvermedal.SetActive (false);


			} else if (mainmenu.activeSelf)
			{
				backchanger.backgroundlist [PlayerPrefs.GetInt ("backindex")].SetActive (false);
				Application.Quit ();
			}


		}

		if (isdeath) 
		{
			if (deathmenu.activeSelf&&!retrymenu.activeSelf&&!mainmenu.activeSelf) {



				if (bronzemedal.activeSelf)
					bronzemedal.SetActive (false);
				if (goldmedal.activeSelf)
					goldmedal.SetActive (false);
				if (silvermedal.activeSelf)
					silvermedal.SetActive (false);

				if (highscorepopup.activeSelf) 
				{
					highscorepopup.SetActive (false);
				}
				if (Input.GetMouseButtonDown (0)) {
				
					Time.timeScale = 1.25f;

					rb.velocity = new Vector2 (rb.velocity.x, jump);
					birdsay.gameObject.SetActive (false);
					deathmenu.SetActive (false);
					isdeath = false;
					//------------------------------------------------gamesplayed------------------


				}
			}


		}

		if (mainmenu.activeSelf) {
			
				scoretext.GetComponent<AudioSource> ().Stop ();
			if(mainmenu.GetComponent<AudioSource> ().isPlaying==false)
			if (music)
			{
				mainmenu.GetComponent<AudioSource> ().Play();
			}

			if(mainmenu.GetComponent<AudioSource> ().isPlaying==true)
			if (!music)
			{
				mainmenu.GetComponent<AudioSource> ().Stop();
			}




			
			Camera.main.transform.position = gameObject.transform.position + new Vector3 (0, 1, -10);
			gameObject.transform.localScale = 1.5f*birdscale;
			pausebutton.gameObject.SetActive (false);
			birdsay.gameObject.SetActive (false);
			if (highscorepopup.activeSelf) {
				highscorepopup.SetActive (false);
			}
		} 

		if (!mainmenu.activeSelf)
		{
			pausebutton.gameObject.SetActive (true);
			gameObject.transform.localScale = birdscale;
		}




	}
	void pausefunc()
	{
		
//		if (pause == false) {
			

		scoretext.GetComponent<AudioSource> ().Stop();
		if (highscorepopup.activeSelf)
		{
			highscorepopup.SetActive (false);
		}

		if (highscorepopup.activeSelf) {
			highscorepopup.SetActive (true);
		}
			Time.timeScale = 0;
//			pause = true;
		mainmenu.SetActive (true);
		birdsay.gameObject.SetActive (false);
		deathmenu.SetActive (false);
		if (retrymenu.activeSelf)
			retrymenu.SetActive (false);

//		}


	}







	public void death ()
	{
		count = 0;
	//	print ("adwatch = " + adwatched);
		adcount++;
	
		/*
		if (currentscore >= 20 && adwatched == false) {

			if (newadscript.isrewardedvideoready())
			{
				rewardbtn.gameObject.SetActive (true);
				//	print ("reward enabled");
			} 
			else 
			{
				if (rewardbtn.gameObject.activeSelf) 
				{
					rewardbtn.gameObject.SetActive (false);
				}
			}
		} else if (rewardbtn.gameObject.gameObject.activeSelf)
			rewardbtn.gameObject.SetActive (true);

*/



		if (currentscore > PlayerPrefs.GetInt ("highscore")) {
			PlayerPrefs.SetInt ("highscore", currentscore);
			highscore.text = "Highscore" + " " + PlayerPrefs.GetInt ("highscore").ToString ();
			highscorepopup.SetActive (true);
			playservicesscript.AddScoreToLeaderboard (FlappyResources.leaderboard_leaderboard, currentscore);
		}

	
		rb.velocity = Vector3.zero;
		rb.transform.position = new Vector2 (5, 0);
		rb.transform.rotation= Quaternion.Euler(	0,0,0);

		rb.angularVelocity = 0;
		recentscore = currentscore;
		recenttext.text ="Score"+ " " + recentscore.ToString ();
	/*	if (recentscore >= PlayerPrefs.GetFloat ("highscore") && recentscore >= 15) 
		{
			firework.gameObject.SetActive (true);
			firework.Play ();

		} ------------------------------------- */
		if (recentscore >= 60) {
			goldmedal.SetActive (true);
			playservicesscript.UnlockAchievement (WingResources.achievement_gold_medalist);
			playservicesscript.UnlockAchievement (WingResources.achievement_wing_expert);
		} 
		else if (recentscore >= 35) {
			silvermedal.SetActive (true);
			playservicesscript.UnlockAchievement (WingResources.achievement_silver_medalist);
		}

		else if (recentscore >= 15) {
			bronzemedal.SetActive (true);
			playservicesscript.UnlockAchievement (WingResources.achievement_bronze_medalist);
		}




		currentscore = 0;

		scoretext.text = currentscore.ToString ();
		d_highscore.text = highscore.text;
		d_scoretext.text = recenttext.text;

		GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe") ;
		foreach (GameObject target in pipes) {
			GameObject.Destroy(target);
		}

		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("back") ;
		foreach (GameObject target in backgrounds) {
			GameObject.Destroy(target);
		}


	
		if (adwatched)
		{
			adwatched = false;
		}
		buildlevel();

		birdtalk.sayit();
		birdsay.gameObject.SetActive(true);
		if(!scoreboard.activeSelf)
		scoreboard.SetActive (true);
		deathmenu.SetActive (true);
		pausebutton2.gameObject.SetActive (false);
		retrybtn.interactable = false;
	 	
		retrymenu.SetActive (true);



		if (adcount >= 6 && recentscore >=5)
		{
	//		newadscript.showIntertitial ();
			adcount = 0;
		}

		//admanager.bannershowhide ();

		if (recentscore >= 50) 
		{
			if (backchanger.backgroundlist [4].activeSelf && (characterchange.birdlist [9].activeSelf || characterchange.birdlist [10].activeSelf)) 
			{
				playservicesscript.UnlockAchievement (WingResources.achievement_dark_knight);

			}
		}

		//--------------
		PlayerPrefs.SetInt ("gamesplayed",PlayerPrefs.GetInt("gamesplayed",0)+1);
		playservicesscript.AddScoreToLeaderboard (WingResources.leaderboard_games_played, PlayerPrefs.GetInt ("gamesplayed", 0));

		switch (PlayerPrefs.GetInt ("gamesplayed"))
		{
		case 5000:
			playservicesscript.UnlockAchievement (WingResources.achievement_professor);
			break;
		case 1234:
			playservicesscript.UnlockAchievement (WingResources.achievement_addicted);
			break;
		case 500:
			playservicesscript.UnlockAchievement (WingResources.achievement_fivehundreds);
			break;
		case 250:
			playservicesscript.UnlockAchievement (WingResources.achievement_twofifty);
			break;
		case 123:
			playservicesscript.UnlockAchievement (WingResources.achievement_onetwothree);
			break;
		case 100:
			playservicesscript.UnlockAchievement (WingResources.achievement_sophomore);
			break;
		case 50:
			playservicesscript.UnlockAchievement (WingResources.achievement_first_fifty);
			break;
	
		
		
		
		
		default:

			break;
		}

		//----------------------------------------
		isdeath = true;
		Time.timeScale = 0;



	}

		
	private void buildlevel()
	{


		float yran = Random.Range (-5, 5);

		Instantiate (pipe_up, new Vector2 ( 20 , 20+15.5f + yran ), transform.rotation);
		Instantiate(pipe_down,new Vector2( 20, -18.5f-15 + yran ),transform.rotation);

	
		yran = Random.Range (-5, 5 );

		Instantiate (pipe_up, new Vector2 ( 29.25f, 20+15 + yran), transform.rotation);
		Instantiate(pipe_down,new Vector2( 29.25f, -18.5f + yran-15),transform.rotation);

		Instantiate (pipe_up, new Vector2 ( 38.5f, 15+15), transform.rotation);
		Instantiate(pipe_down,new Vector2( 38.5f, 15-38.5f-15),transform.rotation);

		yran = Random.Range (-5, 5 );
		Instantiate (pipe_up, new Vector2 ( 47.75f , 20 +15+ yran), transform.rotation);
		Instantiate(pipe_down,new Vector2( 47.75f, -18.5f + yran-15 ),transform.rotation);

		Instantiate (pipe_up, new Vector2 ( 56+1 , 16+15), transform.rotation);
		Instantiate(pipe_down,new Vector2( 56+1, 16-38.5f-15 ),transform.rotation);

		Instantiate (pipe_up, new Vector2 ( 65+1.25f, 13+15 ), transform.rotation);
		Instantiate(pipe_down,new Vector2( 65+1.25f, 13-38.5f-15),transform.rotation);

	//	if(count==0)
		//backchanger.backgroundlist [PlayerPrefs.GetInt("backindex",0)].SetActive(true);
		 

			Instantiate (newbackscript.gameObject, new Vector2 (12, 4.6f), transform.rotation);
			Instantiate (newbackscript.gameObject, new Vector2 (62.5f, 4.6f), transform.rotation);




	}






}
