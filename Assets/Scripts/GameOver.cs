using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{ 
	public float time;
	float restartTimer;
	Animator anim;                          
	public Text Timetext;
	public Text highScoreText;
	public CountDown CD;

	void Start ()
	{
		anim = GetComponent <Animator> ();
	}

	void Update ()
	{
		bool isStart = CD.isStarted();
		if (isStart){
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