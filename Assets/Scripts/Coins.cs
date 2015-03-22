using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coins : MonoBehaviour {
	int coin;
	Text text;

	void Start () {
		coin = PlayerPrefs.GetInt ("Coins");
		text = GetComponent<Text> ();
	}

	void Update () {
		text.text = "$"+PlayerPrefs.GetInt("Coins");
	}

	public void AddCoins(int amt){
		coin += amt;
		PlayerPrefs.SetInt ("Coins",coin);
	}
}