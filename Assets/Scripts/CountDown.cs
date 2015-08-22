using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class CountDown : MonoBehaviour {
	float CountDownTime = 4.0f;
	public bool StartGame = false, tapped = false;
	public Text countDownText;

	void Start(){
		Advertisement.Initialize ("131625271", false);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)){
			if(!tapped)
				countDownText.rectTransform.position = new Vector3(countDownText.rectTransform.position.x,countDownText.rectTransform.position.y+190.0f,countDownText.rectTransform.position.z);
			tapped = true;
			countDownText.fontSize = 125;
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
