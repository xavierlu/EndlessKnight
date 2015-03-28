using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {
	int currentCoins = 0;
	int gamePiece = 0;
	public Canvas confirmCanvas;
	public Text confirmText;
	public Button backButton;

	public void BuyWhiteKnight(){
		PlayerPrefs.SetInt ("SelectedGamePiece",0);
	}

	public void BuyCube(bool TorF){
		if (!TorF)
			Confirm (20,1);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 20) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-20);
			PlayerPrefs.SetInt ("SelectedGamePiece",1);
			}
		}
	}

	public void BuyPlant(bool TorF){
		if (!TorF)
			Confirm (30,2);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 30) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-30);
			PlayerPrefs.SetInt ("SelectedGamePiece",2);
			}
		}
	}

	public void BuyBook(bool TorF){
		if (!TorF)
			Confirm (40,3);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 40) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-40);
			PlayerPrefs.SetInt ("SelectedGamePiece",3);
			}
		}
	}

	public void BuyPostBox(bool TorF){
		if (!TorF)
			Confirm (50,4);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 50) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-50);
			PlayerPrefs.SetInt ("SelectedGamePiece",4);
			}
		}
	}

	public void BuyGuitar(bool TorF){
		if (!TorF)
			Confirm (60,5);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 60) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-60);
			PlayerPrefs.SetInt ("SelectedGamePiece",5);
			}
		}
	}

	public void BuyGasBottle(bool TorF){
		if (!TorF)
			Confirm (70,6);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 70) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-70);
			PlayerPrefs.SetInt ("SelectedGamePiece",6);
			}
		}
	}

	public void BuyToilet(bool TorF){
		if (!TorF)
			Confirm (80,7);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 80) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-80);
			PlayerPrefs.SetInt ("SelectedGamePiece",7);
			}
		}
	}

	public void BuyVendingMachine(bool TorF){
		if (!TorF)
			Confirm (90,8);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 90) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-90);
			PlayerPrefs.SetInt ("SelectedGamePiece",8);
			}
		}
	}

	public void BuyKnuckle(bool TorF){
		if (!TorF)
			Confirm (100,9);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 100) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
			PlayerPrefs.SetInt ("SelectedGamePiece",9);
			}
		}
	}
	
	public void BuyWrench(bool TorF){
		if (!TorF)
			Confirm (110,10);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 110) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-110);
			PlayerPrefs.SetInt ("SelectedGamePiece",10);
			}
		}
	}

	public void BuyPiano(bool TorF){
		if (!TorF)
			Confirm (10,16);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-10);
				PlayerPrefs.SetInt ("SelectedGamePiece",16);
			}
		}
	}

	public void BuyBathTube(bool TorF){
		if (!TorF)
			Confirm (10,11);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-10);
				PlayerPrefs.SetInt ("SelectedGamePiece",11);
			}
		}
	}

	public void BuyPrinter(bool TorF){
		if (!TorF)
			Confirm (10,12);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-10);
			PlayerPrefs.SetInt ("SelectedGamePiece",12);
			}
		}
	}

	public void BuyChest(bool TorF){
		if (!TorF)
			Confirm (10,13);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 10);
				PlayerPrefs.SetInt ("SelectedGamePiece", 13);
			}
		}
	}
	
	public void BuyExtinguisher(bool TorF){
		if (!TorF)
			Confirm(10,14);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-10);
				PlayerPrefs.SetInt ("SelectedGamePiece",14);
			}
		}
	}
	
	public void BuySlotMachine(bool TorF){
		if (!TorF)
			Confirm(10,15);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 10) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-10);
				PlayerPrefs.SetInt ("SelectedGamePiece",15);
			}
		}
	}

	public void BuyBillBoard(bool TorF){
		if (!TorF)
			Confirm(1000,17);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 1000) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-1000);
				PlayerPrefs.SetInt ("SelectedGamePiece",17);
			}
		}
	}

	public void Confirm(int num, int gameP){
		backButton.enabled = false;
		backButton.image.enabled = false;
		confirmCanvas.enabled = true;
		confirmText.text = "Confirm? ¢" + num;
		gamePiece = gameP;
	}

	public void click(bool TorF){
		if (TorF) {
			switch(gamePiece){
			case 0:
				BuyWhiteKnight();
				break;
			case 1:
				BuyCube(true);
				break;
			case 2:
				BuyPlant(true);
				break;
			case 3:
				BuyBook(true);
				break;
			case 4:
				BuyPostBox(true);
				break;
			case 5:
				BuyGuitar(true);
				break;
			case 6:
				BuyGasBottle(true);
				break;
			case 7:
				BuyToilet(true);
				break;
			case 8:
				BuyVendingMachine(true);
				break;
			case 9:
				BuyKnuckle(true);
				break;
			case 10:
				BuyWrench(true);
				break;
			case 11:
				BuyBathTube(true);
				break;
			case 12:
				BuyPrinter(true);
				break;
			case 13:
				BuyChest(true);
				break;
			case 14:
				BuyExtinguisher(true);
				break;
			case 15:
				BuySlotMachine(true);
				break;
			case 16:
				BuyPiano(true);
				break;
			case 17:
				BuyBillBoard(true);
				break;
			}		
		}
		backButton.enabled = true;
		backButton.image.enabled = true;
		confirmCanvas.enabled = false;
	}
	//SelectedGamePiece
	/**
	 * 0 = white knight
	 * 1 = hollow cube
	 * 2 = plant
	 * 3 = book
	 * 4 = postbox
	 * 5 = guitar
	 * 6 = gas bottle
	 * 7 = toilet
	 * 8 = Vending machine
	 * 9 = knuckle
	 * 10 = wrench
	 * */

	void OnDestroy(){
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins"));
	}
}