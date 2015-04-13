using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;
using System;

public class Ad : MonoBehaviour {
	public Button FreeCoinsButton;
	public Text FreeCoinsText;
	string oneHrMark = "1:00:00";
	DateTime last;
	public TileMap tm;

	void Start () {
		Advertisement.Initialize ("131625271", false);
		last = DateTime.Parse(PlayerPrefs.GetString ("LastTimePlayedAd"));

		if (DateTime.UtcNow - last >= TimeSpan.Parse(oneHrMark) && tm.thereIsConnection){
			FreeCoinsButton.enabled = true;
			FreeCoinsButton.image.enabled = true;
			FreeCoinsText.enabled = true;
		}
		else{
			FreeCoinsButton.enabled = false;
			FreeCoinsButton.image.enabled = false;
			FreeCoinsText.enabled = false;
		}
	}

	public void PlayAd(){
		DateTime now = DateTime.UtcNow;
		PlayerPrefs.SetString ("LastTimePlayedAd",now.ToString());
		Advertisement.Show ("rewardedVideoZone");
		PlayerPrefs.SetInt ("Coins",PlayerPrefs.GetInt("Coins")+15);
		FreeCoinsButton.enabled = false;
		FreeCoinsButton.image.enabled = false;
		FreeCoinsText.enabled = false;
	}

}
