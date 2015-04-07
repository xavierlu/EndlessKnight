using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using UnityEngine.Events;
using System.Collections;
public class TileMap : MonoBehaviour {
	public GameObject[] selectedUnit;
	public GameObject tiles;
	public GameObject Target;
	public GameObject coinsManager;
	public GameObject fire;
	public Camera[] cams;
	public AudioClip[] coinSound; int coinSoundSelection = 0;
	public AudioMixer MasterMixer;
	public GameObject[] BackgroundSound;
	public Text currentScoreText;
	public int mapSizeX = 5;
	public int mapSizeY = 5;
	public int currGamePiece = 4;
	public int AdCycle = 6;
	public int TimeToRestart = 5;
	public Animator breakRecordAnim;
	public CountDown CD;
	public GameOver GameO;
	public float smooth = 5.5f;
	bool stillHasTime = true;
	bool getGamePiece = false;
	bool isHaveExtinguisher = false;
	int AddCoin = 1;
	int currentScore = 0;
	int playerCurrPositionX;
	int playerCurrPositionY;
	int TargetX;
	int TargetY;
	int obstacleX = 0;
	int obstacleY = 0;
	bool[,] fireGO = new bool[9,9];
	GameObject[,] go = new GameObject[9,9];
	GameObject playerGO;
	GameObject TargetGO;
	AudioSource source;
	Coins myCoin;
	bool flag = false,AdSetting = false;

	void Start() {
		if (PlayerPrefs.GetInt("AdCount") != 9 && !Advertisement.isShowing)
			PlayerPrefs.SetInt("AdCount",PlayerPrefs.GetInt("AdCount")+1);
		MasterMixer.SetFloat ("sfxVol", 0.0f);
		MasterMixer.SetFloat ("musicVol", -10.0f);
		GenerateMapVisual();
		InstantiateTargetTile ();
		myCoin = (Coins)coinsManager.GetComponent<Coins> ();
		Advertisement.Initialize ("131625271", false);
		Debug.LogError (PlayerPrefs.GetInt("AdCount"));
		if (!getGamePiece) {
			currGamePiece = PlayerPrefs.GetInt("SelectedGamePiece");
			Advantage();
			playerCurrPositionX = selectedUnit[currGamePiece].GetComponent<Unit>().tileX;
			playerCurrPositionY = selectedUnit[currGamePiece].GetComponent<Unit>().tileY;	
			InstantiatePlayer ();
			source = playerGO.GetComponent<AudioSource>();
			getGamePiece = true;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit(); 
		if (GameO.time <= 0 ){
			stillHasTime = false;
		}
		if (PlayerPrefs.GetInt("AdCount") == 9 && !flag) {
			PlayerPrefs.SetInt("AdCount",1);
			flag = true;
			if(!AdSetting)
				Advertisement.Show ("rewardedVideoZone");
		}
	}
	void Advantage(){
		switch(currGamePiece){//150240160
		case 0:
			break;
		case 1:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.870588f,0.721569f,0.529412f);
			}
			break;
		case 2:
			Instantiate(BackgroundSound[3], new Vector3(4.5f,10f,4.5f), Quaternion.identity);
			break;
		case 3:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.956863f,0.643137f,0.376471f);
			}
			break;
		case 4:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (1f,0.54902f,0f);
			}
			break;
		case 5:
			Instantiate(BackgroundSound[Random.Range(0,3)],new Vector3(4.5f,0f,4.5f),Quaternion.identity);
			break;
		case 6:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (1f,0.270588f,0f);
			}
			break;
		case 7:
			coinSoundSelection = 1;
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.827451f,0.827451f,0.827451f);
			}
			break;
		case 8:
			coinSoundSelection = 2;
			break;
		case 9:
			coinSoundSelection = 3;
			break;
		case 10:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.690196f,0.768627f,0.870588f);
			}
			break;
		case 11:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.690196f,0.878431f,0.901961f);
			}
			TimeToRestart = 7;
			coinSoundSelection = 5;
			break;
		case 12:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.690196f,0.878431f,0.901961f);
			}
			TimeToRestart = 8;
			coinSoundSelection = 6;
			break;
		case 13:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.870588f,0.721569f,0.529412f);
			}
			AddCoin = 2;
			break;
		case 14:
			isHaveExtinguisher = true;
			break;
		case 15:
			coinSoundSelection = 4;
			break;
		case 16:
			Instantiate(BackgroundSound[4], new Vector3(4.5f,0f,4.5f), Quaternion.identity);
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.839216f,0.839216f,0.839216f);
			}
			break;
		case 17:
			AdSetting = true;
			break;
		}
	}

	void InstantiateTargetTile(){
		TargetX = Random.Range (1,mapSizeX+1);
		TargetY = Random.Range (1,mapSizeY+1);
		TargetGO = (GameObject)Instantiate (Target, new Vector3(TargetX,0,TargetY),Quaternion.identity);
	}

	void LerpTargetGO(){
		do{
			TargetX = Random.Range (1,mapSizeX+1);
			TargetY = Random.Range (1,mapSizeY+1);
		}while(fireGO[TargetX,TargetY]);
		TargetGO.transform.position = Vector3.Lerp (TargetGO.transform.position, new Vector3(TargetX,0,TargetY),1f);
	}

	void SetObstacle(){
		do{
			obstacleX = Random.Range (1,mapSizeX+1);
			obstacleY = Random.Range (1,mapSizeY+1);
		}while(obstacleX == playerCurrPositionX && obstacleY == playerCurrPositionY);
		go [obstacleX, obstacleY].GetComponent<Renderer>().material.color = Color.red;
		SetTileColor (obstacleX, obstacleY, "red");
		Instantiate (fire, new Vector3(obstacleX,0.25f,obstacleY), Quaternion.identity);
		fireGO [obstacleX, obstacleY] = true;
	}

	void InstantiatePlayer(){
		int x;int y;
		do{
			x = Random.Range (1, mapSizeX+1);
			y = Random.Range (1, mapSizeY+1);
		}while(x == playerCurrPositionX && y == playerCurrPositionY);
		playerGO = (GameObject)Instantiate (selectedUnit[currGamePiece], new Vector3(x,0,y), Quaternion.identity);
		Unit ui = playerGO.GetComponent<Unit> ();
		ui.tileX = x;
		ui.tileY = y;
		playerCurrPositionX = ui.tileX;
		playerCurrPositionY = ui.tileY;
	}

	void GenerateMapVisual() {
		TargetX = Random.Range (1,mapSizeX+1);
		TargetY = Random.Range (1,mapSizeY+1);
		for(int x=1; x <= mapSizeX; x++) {
			for(int y=1; y <= mapSizeX; y++) {
				if (x%2 == y%2){
					go[x,y] = (GameObject)Instantiate( tiles, new Vector3(x, 0, y), Quaternion.identity );
					go[x,y].GetComponent<Renderer>().material.color = Color.black;
					InitClickableTile(x,y,"black");
				}
				else{
				    go[x,y] = (GameObject)Instantiate( tiles, new Vector3(x, 0, y), Quaternion.identity );
					go[x,y].GetComponent<Renderer>().material.color = Color.white;
					InitClickableTile(x,y,"white");
				}
			}
		}
	}

	void InitClickableTile(int x,int y, string color){
		ClickableTile ct = go[x,y].GetComponent<ClickableTile>();
		ct.tileX = x;
		ct.tileY = y;
		ct.map = this;
		ct.myColor = color;
	}

	void SetTileColor(int x,int y,string color){
		ClickableTile ct = go[x,y].GetComponent<ClickableTile>();
		ct.myColor = color;
	}
	
	public Vector3 TileCoordToWorldCoord(int x, int y) {
		return new Vector3(x, 0, y);
	}

	public void MoveSelectedUnitTo(int x, int y) {
		if (stillHasTime && CD.isStarted() && Time.timeScale == 1){
			if ((GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 0.5 || 
			    	GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -0.5) 
			    		&& Vector3.Distance(new Vector3(playerCurrPositionX,0,playerCurrPositionY),new Vector3(x,0,y)) == Mathf.Sqrt(5.0f)) {
				playerCurrPositionX = x;
				playerCurrPositionY = y;
				playerGO.transform.position = TileCoordToWorldCoord(x,y);	
				if (TargetX == playerCurrPositionX && TargetY == playerCurrPositionY) {
					if (currGamePiece == 15)
						AddCoin = Random.Range(-3,6);
					myCoin.AddCoins(AddCoin);
					source.PlayOneShot(coinSound[coinSoundSelection]);
					if(!isHaveExtinguisher)
						SetObstacle();
					LerpTargetGO();
					GameO.SetTime((float)TimeToRestart+0.9f);
					currentScore++;
					currentScoreText.text = ""+currentScore;
					if (currentScore > PlayerPrefs.GetInt("HighScore")){
						breakRecordAnim.SetTrigger("Break");
						PlayerPrefs.SetInt("HighScore", currentScore);
					}
				}
			}
		}
	}

	public float GetSlope(int x1, int y1, int x2, int y2){
		float x11 = (float)(x1);
		float y11 = (float)(y1);
		float x22 = (float)(x2);
		float y22 = (float)(y2);

		float slope = (float)((y22-y11)/(x22-x11)) ;
		return slope;
	}
		
	public void FBShare(){
		ShareToFacebook ("http://www.facebook.com/", "Endless Knight", "Come, download and play Endless Knight!",
		                 "My high score is "+PlayerPrefs.GetInt("HighScore")+" in Endless Knight. Can you beat me ;)", "http://i57.tinypic.com/ftfrjm.jpg"
		                 , "http://www.facebook.com/");
	}


	public void TwitterShare(){
		ShareToT ("My high score is " + PlayerPrefs.GetInt ("HighScore") + " in Endless Knight. Can you beat me ;)", "http://twitter.com/", " ","en");
	}
	const string AppId = "830811490287964";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + AppId +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	const string Address = "http://twitter.com/intent/tweet";
	public static void ShareToT(string text, string url,
	                         string related, string lang="en")
	{
		Application.OpenURL(Address +
		                    "?text=" + WWW.EscapeURL(text) +
		                    "&amp;url=" + WWW.EscapeURL(url) +
		                    "&amp;related=" + WWW.EscapeURL(related) +
		                    "&amp;lang=" + WWW.EscapeURL(lang));
	}
}