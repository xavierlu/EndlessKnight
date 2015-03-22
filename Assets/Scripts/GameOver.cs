using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{ 
	public float time = 7.5f;
	float restartTimer;
	Animator anim;                          
	public Text Timetext;
	public Text highScoreText;
	public CountDown CD;

	void Start ()
	{
		Advertisement.Initialize ("131625271", false);
		anim = GetComponent <Animator> ();
	}

	void Update ()
	{
		bool isStart = CD.isStarted();
		if (!Advertisement.isShowing && isStart){
			if (time > 0) {
				time -= Time.deltaTime;		
			}
			if(time <= 0)
			{
				anim.SetTrigger ("GameOver");
				highScoreText.text = "High Score\n" + PlayerPrefs.GetInt ("HighScore");
			}
			Timetext.text = ""+(int)time;
		}
	}
	
	public void SetTime(float amt){
		time = amt;
	}
}