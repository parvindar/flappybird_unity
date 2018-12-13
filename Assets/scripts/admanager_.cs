using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class admanager_ : MonoBehaviour
{
	InterstitialAd interstitial;
	BannerView banner;
	public RewardBasedVideoAd rewardvideo;
	character character;


	// Use this for initialization
	void Start()
	{
		MobileAds.Initialize("ca-app-pub-7625851577040770~7032019239");
		
		character = FindObjectOfType<character> ();
		//Request Ad
		RequestInterstitialAds();
		requestbanner ();
		Requestrewardvideo ();



		character.rewardbtn.onClick.AddListener (showrewardvideo);

		banner.Hide ();
	}

	void Update()
	{
		
	}

	public void showInterstitialAd()
	{
		//Show Ad
		if (interstitial.IsLoaded())
		{
			interstitial.Show();

			//Stop Sound
			//

		//	Debug.Log("SHOW AD interstitial");
		}

	}

	public void bannershowhide()
	{
		
		if (character.adcount>2) {
			banner.Show ();
		} else
			banner.Hide ();
	}

	private void RequestInterstitialAds()
	{
		string adID = "ca-app-pub-7625851577040770/2968968370";

		#if UNITY_ANDROID
		string adUnitId = adID;
		#elif UNITY_IOS
		string adUnitId = adID;
		#else
		string adUnitId = adID;
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);

		AdRequest request = new AdRequest.Builder().Build();

		//Register Ad Close Event
		interstitial.OnAdClosed += Interstitial_OnAdClosed;

		// Load the interstitial with the request.
		interstitial.LoadAd(request);

		//Debug.Log("AD LOADED interstitial");

		}

		//Ad Close Event
		private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
		{
		//Resume Play Sound
		if(!interstitial.IsLoaded())
			RequestInterstitialAds ();

		}


		private void requestbanner()
		{
		string adID = "ca-app-pub-7625851577040770/5471116434";

		#if UNITY_ANDROID
		string adUnitId = adID;
		#elif UNITY_IOS
		string adUnitId = adID;
		#else
		string adUnitId = adID;
		#endif

		// Initialize an bannerAd.
		AdSize adSize = new AdSize(325, 45);
		banner = new BannerView(adUnitId,adSize,AdPosition.Bottom);

		AdRequest request = new AdRequest.Builder().Build();

		//Register Ad Close Event
		//interstitial.OnAdClosed += Interstitial_OnAdClosed;

		// Load the interstitial with the request.
		banner.LoadAd(request);

		//Debug.Log("AD LOADED banner");

	//	banner.Show ();

		}



		public void Requestrewardvideo()
		{
		string adID = "ca-app-pub-7625851577040770/8205090989";

		#if UNITY_ANDROID
		string adUnitId = adID;
		#elif UNITY_IOS
		string adUnitId = adID;
		#else
		string adUnitId = adID;
		#endif

		// Initialize an InterstitialAd.
		rewardvideo = RewardBasedVideoAd.Instance;

		AdRequest request = new AdRequest.Builder().Build();

		//Register Ad Close Event
		//interstitial.OnAdClosed += Interstitial_OnAdClosed;
		rewardvideo.OnAdRewarded += Rewardvideo_OnAdRewarded;
		rewardvideo.OnAdClosed+= Rewardvideo_OnAdClosed;
		//rewardvideo.OnAdFailedToLoad+= Rewardvideo_OnAdFailedToLoad;
		// Load the interstitial with the request.
		rewardvideo.LoadAd(request,adUnitId);

	//	Debug.Log("AD LOADED interstitial");

		}

		void Rewardvideo_OnAdFailedToLoad (object sender, AdFailedToLoadEventArgs e)
		{

		}

		void Rewardvideo_OnAdClosed (object sender, System.EventArgs e)
		{

			Requestrewardvideo ();
		}

		void Rewardvideo_OnAdRewarded (object sender, Reward e)
		{
			character.currentscore = character.recentscore;
		character.scoretext.text = character.currentscore.ToString ();
			character.adwatched = true;

		}


		public void showrewardvideo()
		{
		if (rewardvideo.IsLoaded ())
			rewardvideo.Show ();
		else
			Requestrewardvideo ();

		character.rewardbtn.gameObject.SetActive (false);
		}


		}

