using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Canvas ShopCanvas,GameCanvas,HelpCanvas;
	public Canvas infoPage, pausePage;
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	public Text coinText,coinText2;

	public void StartGame(){
		Application.LoadLevel ("Game");
	}

	public void GameMenu(){
		Application.LoadLevel ("MainMenu");
	}

	public void Help(){
		HelpCanvas.enabled = !HelpCanvas.enabled;
	}

	public void Shop(){
		GameCanvas.enabled = !GameCanvas.enabled;
		ShopCanvas.enabled = !ShopCanvas.enabled;
	}

	public void Pause(){
		pausePage.enabled = !pausePage.enabled;
		pauseTime ();
	}

	void pauseTime(){
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();
	}

	void Lowpass(){
		if (Time.timeScale == 0) {
			paused.TransitionTo(0.01f);
		}
		else{
			unpaused.TransitionTo(0.01f);
		}
	}
	
	public void Info(){
		infoPage.enabled = !infoPage.enabled;
	}

}
