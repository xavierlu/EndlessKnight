using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class CountDown : MonoBehaviour {
	float CountDownTime = 4.0f;
	public bool StartGame = false;
	public Text countDownText;

	void Start(){
		Advertisement.Initialize ("131625271", false);
	}

	void Update () {
		if(CountDownTime < 1.1){
			StartGame = true;
			countDownText.text = " ";

		}
		else if (!StartGame && !Advertisement.isShowing) {
			CountDownTime -= Time.deltaTime;	
			countDownText.text = "" + (int)CountDownTime;
		}
	}

	public bool isStarted(){
		return StartGame;
	}
}
