using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class CountDown : MonoBehaviour {
	float CountDownTime = 4.0f;
	public bool StartGame = false;
	private bool tapped = false;
	public Text TapAnywheretoStartText,countDownText;

	void Start(){
		Advertisement.Initialize ("131625271", false);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)){
			if(!tapped)
				TapAnywheretoStartText.enabled = false;
			tapped = true;
		}
		if (tapped){
			if(CountDownTime < 1.1){
				StartGame = true;
				countDownText.text = " ";
			}
			else if (!StartGame && !Advertisement.isShowing) {
				CountDownTime -= Time.deltaTime;	
				countDownText.text = "" + (int)CountDownTime;
			}	
		}
	}

	public bool isStarted(){
		return StartGame;
	}
}
