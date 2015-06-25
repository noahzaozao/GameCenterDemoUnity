using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class main : MonoBehaviour {

	public GameCenterPlatform gcp = new GameCenterPlatform ();
	// Use this for initialization
	void Start () {
		this.gcp.localUser.Authenticate (onAuthenticate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onAuthenticate (bool authed){
		if (authed) {
			this.gcp.LoadAchievements (onLoadAchievements);
		}
	}

	public void onAuthenticateAndShowAchievementsUI (bool authed){
		if (authed) {
			this.gcp.ShowAchievementsUI ();
		}
	}

	public void onLoadAchievements(IAchievement[] items) {
		Debug.Log ("onLoadAchievements");
	}

	public void onClickShowAchievementUI () {
		Debug.Log ("ShowAchievementUI start");
		if (this.gcp.localUser.authenticated == false) {
			this.gcp.localUser.Authenticate (onAuthenticateAndShowAchievementsUI);
		} else {
			onAuthenticateAndShowAchievementsUI(true);
		}
		Debug.Log ("ShowAchievementUI finished");
	}

}
