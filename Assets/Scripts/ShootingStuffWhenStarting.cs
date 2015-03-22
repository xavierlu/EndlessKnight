using UnityEngine;
using System.Collections;

public class ShootingStuffWhenStarting : MonoBehaviour {
	public GameObject[] players;
	bool isFinished = false;

	void Start(){
		InvokeRepeating ("Spwan", 1, 1);
	}

	void Spwan () {
		Instantiate(players[Random.Range(0,players.Length)], new Vector3(Random.Range(-15,15),Random.Range(-5,5),Random.Range(-5,-25)),Quaternion.identity);
	}

	public void StartGame(){
		MainMenu menu = new MainMenu();
		menu.StartGame ();
	}


}
