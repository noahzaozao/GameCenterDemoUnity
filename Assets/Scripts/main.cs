#if UNITY_IPHONE
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
#elif UNITY_ANDROID
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
#else
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
#endif

public class main : MonoBehaviour {

#if UNITY_IPHONE
	// Use this for initialization
	void Start () {
		Social.Active = new GameCenterPlatform ();
		Social.localUser.Authenticate (onAuthenticate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onAuthenticate (bool authed){
		if (authed) {
			Social.LoadAchievements (onLoadAchievements);
		}
	}

	public void onLoadAchievements(IAchievement[] items) {
		Debug.Log ("onLoadAchievements");
	}

	public void onAuthenticateAndShowAchievementsUI (bool authed){
		if (authed) {
			Social.ShowAchievementsUI ();
		}
	}

	public void onAuthenticateAndShowLeaderboardUI (bool authed){
		if (authed) {
			Social.ShowLeaderboardUI ();
		}
	}

	public void onClickShowAchievementUI () {
		Debug.Log ("ShowAchievementUI start");
		if (Social.localUser.authenticated == false) {
			Social.localUser.Authenticate (onAuthenticateAndShowAchievementsUI);
		} else {
			onAuthenticateAndShowAchievementsUI(true);
		}
		Debug.Log ("ShowAchievementUI finished");
	}

	public void onClickShowLeaderboardUI () {
		Debug.Log ("ShowLeaderboardUI start");
		if (Social.localUser.authenticated == false) {
			Social.localUser.Authenticate (onAuthenticateAndShowLeaderboardUI);
		} else {
			onAuthenticateAndShowLeaderboardUI(true);
		}
		Debug.Log ("ShowLeaderboardUI finished");
	}
#elif UNITY_ANDROID
	void Awake () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			.EnableSavedGames()
				.WithInvitationDelegate((invitation, shouldAutoAccept) => {})
				.WithMatchDelegate((match, shouldAutoLaunch) => {})
				.Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
	}

	// Use this for initialization
	void Start () {
		Social.localUser.Authenticate((bool success) => {
			onAuthenticate(success);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void onAuthenticate (bool authed){
		if (authed) {
			Social.LoadAchievements (onLoadAchievements);
		}
	}
	
	public void onLoadAchievements(IAchievement[] items) {
		Debug.Log ("onLoadAchievements");
	}
	
	public void onAuthenticateAndShowAchievementsUI (bool authed){
		if (authed) {
			Social.ShowAchievementsUI ();
		}
	}
	
	public void onAuthenticateAndShowLeaderboardUI (bool authed){
		if (authed) {
			Social.ShowLeaderboardUI ();
		}
	}
	
	public void onClickShowAchievementUI () {
		Debug.Log ("ShowAchievementUI start");
		if (Social.localUser.authenticated == false) {
			Social.localUser.Authenticate (onAuthenticateAndShowAchievementsUI);
		} else {
			onAuthenticateAndShowAchievementsUI(true);
		}
		Debug.Log ("ShowAchievementUI finished");
	}
	
	public void onClickShowLeaderboardUI () {
		Debug.Log ("ShowLeaderboardUI start");
		if (Social.localUser.authenticated == false) {
			Social.localUser.Authenticate (onAuthenticateAndShowLeaderboardUI);
		} else {
			onAuthenticateAndShowLeaderboardUI(true);
		}
		Debug.Log ("ShowLeaderboardUI finished");
	}
#else
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void onAuthenticate (bool authed){
	}
	
	public void onLoadAchievements(IAchievement[] items) {
	}
	
	public void onAuthenticateAndShowAchievementsUI (bool authed){
	}
	
	public void onAuthenticateAndShowLeaderboardUI (bool authed){
	}
	
	public void onClickShowAchievementUI () {
	}
	
	public void onClickShowLeaderboardUI () {
	}
#endif

}
