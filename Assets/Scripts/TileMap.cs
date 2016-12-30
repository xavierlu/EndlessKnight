using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using System.Collections;
using System.Net;

public class TileMap : MonoBehaviour {
	public GameObject[] selectedUnit;
	public GameObject tiles;
	public GameObject Target;
	public GameObject Coin;
	public GameObject fire;
	public Camera[] cams;
	public AudioClip[] coinSound; int coinSoundSelection = 8;
	public AudioMixer MasterMixer;
	public GameObject[] BackgroundSound;
	public Text currentScoreText;
	public Text coinText;
	public int mapSizeX = 5;
	public int mapSizeY = 5;
	public int currGamePiece = 4;
	public int AdCycle = 6;
	public int TimeToRestart;
	public Animator breakRecordAnim;
	public CountDown CD;
	public GameOver GameO;
	public float smooth = 5.5f;
	public Image check;
	bool stillHasTime = true;
	bool getGamePiece = false;
	bool isHaveExtinguisher = false;
	int AddCoin = 20;
	int currentScore = 0;
	int playerCurrPositionX;
	int playerCurrPositionY;
	int TargetX;
	int TargetY;
	int coinX;
	int coinY;
	int obstacleX = 0;
	int obstacleY = 0;
	bool[,] fireGO = new bool[9,9];
	GameObject[,] go = new GameObject[9,9];
	GameObject playerGO; //Go = gameobject
	GameObject TargetGO;
	GameObject coinGO;
	AudioSource source;
	bool flag = false,AdSetting = false;

	void Start() {
		coinText.text = PlayerPrefs.GetInt("Coins")+"";
		MasterMixer.SetFloat ("sfxVol", 0.0f);
		MasterMixer.SetFloat ("musicVol", -10.0f);
		GenerateMapVisual();
		InstantiateTargetTile ();
		if (!getGamePiece) {
			currGamePiece = PlayerPrefs.GetInt("SelectedGamePiece");
			Advantage();
			playerCurrPositionX = selectedUnit[currGamePiece].GetComponent<Unit>().tileX;
			playerCurrPositionY = selectedUnit[currGamePiece].GetComponent<Unit>().tileY;	
			InstantiatePlayer ();
			source = playerGO.GetComponent<AudioSource>();
			getGamePiece = true;
		}
		GameO.SetTime((float)TimeToRestart+0.9f);
		for(int i = 1; i <= mapSizeX; i++){
			for(int j = 1; j <= mapSizeX; j++){
				ClickableTile temp = go[i,j].GetComponent<ClickableTile> ();
				int x = temp.tileX;
				int y = temp.tileY;
				if ((GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 0.5 ||
				    GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -0.5)
				    && Vector3.Distance (new Vector3 (playerCurrPositionX, 0, playerCurrPositionY), new Vector3 (x, 0, y)) == Mathf.Sqrt (5.0f)) {
					go [x, y].GetComponent<Renderer> ().material.color = new Color (0.4f, 0.95f, 0.4f);
				}
			}
		}

	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit(); 
		if (GameO.time <= 0 ){
			stillHasTime = false;
			check.transform.position = GameObject.Find (selectedUnit[PlayerPrefs.GetInt ("SelectedGamePiece")].name).transform.position;
		}
	}
	void Advantage(){
		switch(currGamePiece){
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
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0,0.81f,1f);
			}
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
			TimeToRestart = 8;
			break;
		case 12:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.690196f,0.878431f,0.901961f);
			}
			TimeToRestart = 9;
			break;
		case 13:
			for (int i = 0; i < 3; i++){
				cams[i].backgroundColor = new Color (0.870588f,0.721569f,0.529412f);
			}
			AddCoin = 40;
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
		case 18:
			coinSoundSelection = 7;
			break;
		}
	}

	void InstantiateTargetTile(){
		TargetX = Random.Range (1,mapSizeX+1);
		TargetY = Random.Range (1,mapSizeY+1);
		TargetGO = (GameObject)Instantiate (Target, new Vector3(TargetX,0,TargetY),Quaternion.identity);
		coinX = Random.Range (1,mapSizeX+1);
		coinY = Random.Range (1,mapSizeY+1);
		coinGO = (GameObject)Instantiate (Coin, new Vector3(coinX,0,coinY),Quaternion.identity);
	}

	void LerpTargetGO(){
		do{
			TargetX = Random.Range (1,mapSizeX+1);
			TargetY = Random.Range (1,mapSizeY+1);
		}while(fireGO[TargetX,TargetY]);
		TargetGO.transform.position = new Vector3 (TargetX, 0, TargetY);
	}

	void LerpCoinGO(){
		do{
			coinX = Random.Range (1,mapSizeX+1);
			coinY = Random.Range (1,mapSizeY+1);
		}while(fireGO[coinX,coinY]);

		coinGO.transform.position = new Vector3 (coinX, 0, coinY);
	}

	void SetObstacle(){
		do{
			obstacleX = Random.Range (1,mapSizeX+1);
			obstacleY = Random.Range (1,mapSizeY+1);
		}while(obstacleX == playerCurrPositionX && obstacleY == playerCurrPositionY && obstacleX == coinX && obstacleY == coinY);
		go [obstacleX, obstacleY].GetComponent<Renderer>().material.color = Color.red;
		SetTileColor (obstacleX, obstacleY, "red");
		Instantiate (fire, new Vector3(obstacleX,0.25f,obstacleY), Quaternion.identity);
		fireGO [obstacleX, obstacleY] = true;
	}

	void InstantiatePlayer(){
		int x,y;
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

	public void MoveSelectedUnitTo(int x, int y) {
		if (stillHasTime && CD.isStarted() && Time.timeScale == 1){
			if ((GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == 0.5 || 
			    	GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -2 || GetSlope (playerCurrPositionX, playerCurrPositionY, x, y) == -0.5) 
			    		&& Vector3.Distance(new Vector3(playerCurrPositionX,0,playerCurrPositionY),new Vector3(x,0,y)) == Mathf.Sqrt(5.0f)) {
				playerCurrPositionX = x;
				playerCurrPositionY = y;
				playerGO.transform.position = new Vector3(x, 0, y);	
				if (TargetX == playerCurrPositionX && TargetY == playerCurrPositionY) {
					source.PlayOneShot(coinSound[coinSoundSelection]);
					if(!(isHaveExtinguisher && Random.Range(1,3)==1))
						SetObstacle();
					LerpTargetGO();
					GameO.SetTime((float)TimeToRestart+0.9f);
					currentScore++;
					currentScoreText.text = "Score: "+currentScore;
					if (currentScore > PlayerPrefs.GetInt("HighScore")){
						breakRecordAnim.SetTrigger("Break");
						PlayerPrefs.SetInt("HighScore", currentScore);
					}
				}
				if(coinX == playerCurrPositionX && coinY == playerCurrPositionY){
					source.PlayOneShot(coinSound[0]);
					PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+AddCoin);
					if (currGamePiece == 15)
						AddCoin = Random.Range(-15,40);
					coinText.text = ""+PlayerPrefs.GetInt("Coins");
					LerpCoinGO();
				}
				for(int i = 1; i <= mapSizeX; i++){
					for(int j = 1; j <= mapSizeX; j++){
						ClickableTile temp = go[i,j].GetComponent<ClickableTile> ();
						int _x = temp.tileX;
						int _y = temp.tileY;
						if ((GetSlope (playerCurrPositionX, playerCurrPositionY, _x, _y) == 2 || GetSlope (playerCurrPositionX, playerCurrPositionY, _x, _y) == 0.5 ||
						    GetSlope (playerCurrPositionX, playerCurrPositionY, _x, _y) == -2 || GetSlope (playerCurrPositionX, playerCurrPositionY, _x, _y) == -0.5)
						    && Vector3.Distance (new Vector3 (playerCurrPositionX, 0, playerCurrPositionY), new Vector3 (_x, 0, _y)) == Mathf.Sqrt (5.0f)) {
							go [_x, _y].GetComponent<Renderer> ().material.color = temp.myColor.Equals ("red") ? Color.red : new Color (0.4f, 0.95f, 0.4f);
						} else {
							go [_x, _y].GetComponent<Renderer> ().material.color = temp.myColor.Equals ("red") ? Color.red : (temp.myColor.Equals ("white") ? Color.white : Color.black);
						}
					}
				}
			}
		}
	}

	public float GetSlope(float x1, float y1, float x2, float y2){
		return (y2 - y1) / (x2 - x1);
	}
}