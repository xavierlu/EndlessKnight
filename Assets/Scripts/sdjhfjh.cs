using UnityEngine;
using System.Collections;

public class sdjhfjh : MonoBehaviour {
	public GameObject[] player;
	GameObject[] GO = new GameObject[16];
	int i = 0;
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			GO[i] = (GameObject)Instantiate(player[i], new Vector3(0,1,2),Quaternion.identity);
		}
		if (Input.GetKeyUp (KeyCode.KeypadEnter)) {
			Destroy(GO[i]);
			i++;
		}
	}
}
