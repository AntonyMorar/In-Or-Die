using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesController : MonoBehaviour
{
	private static bool isAuthenticated = false;

	void Start()
	{
		DontDestroyOnLoad(this);
		try
		{
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
			PlayGamesPlatform.InitializeInstance(config);
			PlayGamesPlatform.DebugLogEnabled = true;
			PlayGamesPlatform.Activate();
			Social.localUser.Authenticate((bool success) => {});
		}
		catch (Exception ex)
		{
			Debug.Log("Unable to setup google play account " + ex.InnerException);
		}
	}

	public static void AddScoreToLeaderBoard(string leaderBoard, int score)
	{
		if (Social.localUser.authenticated)
		{
			Social.ReportScore(score, leaderBoard, success => { });
		}
	}

	public void ShowLeaderBoard()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowLeaderboardUI();
		}
	}
}
