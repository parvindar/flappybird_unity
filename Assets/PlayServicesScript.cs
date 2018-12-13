using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//using GooglePlayServices;
using GooglePlayGames;
using GooglePlayGames.BasicApi;



public class PlayServicesScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build ();
		PlayGamesPlatform.InitializeInstance (config); 
		PlayGamesPlatform.Activate();

		signin();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void signin()
	{
		Social.localUser.Authenticate((bool success) =>
			{
				if (success)
				{
					((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(GooglePlayGames.BasicApi.Gravity.TOP);

					AddScoreToLeaderboard(WingResources.leaderboard_leaderboard,PlayerPrefs.GetInt ("highscore",0));
					AddScoreToLeaderboard (WingResources.leaderboard_games_played, PlayerPrefs.GetInt ("gamesplayed", 0));

					UnlockAchievement(WingResources.achievement_sign_in);
				}
			});
	}

	public void UnlockAchievement(string id)
	{
		Social.ReportProgress (id,100, success => {});
	}

	public void showachievementsUI()
	{

		if (!Social.localUser.authenticated)
		{
			signin ();
		}


		Social.ShowAchievementsUI();
	}


	public void showleaderboardUI()
	{
		if (!Social.localUser.authenticated)
		{
			signin ();
		}


		Social.ShowLeaderboardUI ();
	}

	public void AddScoreToLeaderboard(string leaderboardid, long score)
	{
		Social.ReportScore (score, leaderboardid, success => {
		});
	}
}
