using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Ad : MonoBehaviour {
	Coins coin;
	// Use this for initialization
	void Start () {
		coin = GetComponent<Coins> ();
		Advertisement.Initialize ("131625271", false);
	}

	public void PlayAd(){
		Advertisement.Show ();
		PlayerPrefs.SetInt ("Coins",PlayerPrefs.GetInt("Coins")+10);
	}

}
