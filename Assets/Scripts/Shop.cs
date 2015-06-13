using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shop : MonoBehaviour {
	int gamePiece = 0;
	public Canvas confirmCanvas;
	public Animator equippedAnim;
	public Text confirmText, coinText;
	public Button FreeCoinsButton;
	public Text FreeCoinsText;
	string oneHrMark = "1:00:00";
	DateTime last;
	public TileMap tm;

	void Start()
	{

		Advertisement.Initialize ("131625271", false);
		last = DateTime.Parse(PlayerPrefs.GetString ("LastTimePlayedAd"));
		if (DateTime.UtcNow - last >= TimeSpan.Parse(oneHrMark) && tm.isConnectedToInternet){
			FreeCoinsButton.enabled = true;
			FreeCoinsButton.image.enabled = true;
			FreeCoinsText.enabled = true;
		}
		else{
			FreeCoinsButton.enabled = false;
			FreeCoinsButton.image.enabled = false;
			FreeCoinsText.enabled = false;
		}
		coinText.text = ""+PlayerPrefs.GetInt("Coins");
	}

	public void PlayAd(){
		DateTime now = DateTime.UtcNow;
		PlayerPrefs.SetString ("LastTimePlayedAd",now.ToString());
		Advertisement.Show ("rewardedVideoZone");
		PlayerPrefs.SetInt ("Coins",PlayerPrefs.GetInt("Coins")+20);
		FreeCoinsButton.enabled = false;
		FreeCoinsButton.image.enabled = false;
		FreeCoinsText.enabled = false;
	}

	public void BuyWhiteKnight(){
		//equippedAnim.SetBool("equipped",false);
		PlayerPrefs.SetInt ("SelectedGamePiece",0);
		//equippedAnim.SetBool("equipped",true);
	}

	public void BuyCube(bool TorF){
		//equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("cube")) {
			equippedAnim.SetBool("equipped",true);
			PlayerPrefs.SetInt ("SelectedGamePiece",1);
		}
		else if (!TorF)
			Confirm (100,1); 
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",1);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"cube");
			}
		}
	}

	public void BuyPlant(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("plant")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",2);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,2);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",2);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"plant");
			}
		}
	}

	public void BuyBook(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("book")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",3);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,3);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",3);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"book");
			}
		}
	}

	public void BuyPostBox(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("postbox")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",4);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,4);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",4);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"postbox");
			}
		}
	}

	public void BuyGuitar(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("guitar")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",5);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,5);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",5);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"guitar");
			}
		}
	}

	public void BuyGasBottle(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("gasbottle")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",6);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,6);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",6);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"gasbottle");
			}
		}
	}

	public void BuyCreeper(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("creeper")) {
			equippedAnim.SetBool("equipped",true);
			PlayerPrefs.SetInt ("SelectedGamePiece",19);
		}
		else if (!TorF)
			Confirm (100,19); 
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",19);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"creeper");
			}
		}
	}

	public void BuyToilet(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("toilet")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",7);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,7);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
			PlayerPrefs.SetInt ("SelectedGamePiece",7);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"toilet");
			}
		}
	}

	public void BuyVendingMachine(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("vendingmachine")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",8);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,8);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
			PlayerPrefs.SetInt ("SelectedGamePiece",8);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"vendingmachine");
			}
		}
	}

	public void BuyKnuckle(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("knuckle")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",9);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,9);
		else {
		if (PlayerPrefs.GetInt ("Coins") >= 100) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
			PlayerPrefs.SetInt ("SelectedGamePiece",9);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"knuckle");
			}
		}
	}
	
	public void BuyWrench(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("wrench")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",10);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,10);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
			PlayerPrefs.SetInt ("SelectedGamePiece",10);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"wrench");
			}
		}
	}

	public void BuyPiano(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("piano")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",16);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (115,16);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 115) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-115);
				PlayerPrefs.SetInt ("SelectedGamePiece",16);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"piano");
			}
		}
	}

	public void BuyBathTube(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("bathtub")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",11);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (175,11);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 175) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-175);
				PlayerPrefs.SetInt ("SelectedGamePiece",11);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"bathtub");
			}
		}
	}

	public void BuyPrinter(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("printer")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",12);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,12);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",12);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"printer");
			}
		}
	}

	public void BuyChest(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("chest")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",13);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (225,13);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 225) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 225);
				PlayerPrefs.SetInt ("SelectedGamePiece", 13);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"chest");
			}
		}
	}
	
	public void BuyExtinguisher(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("extinguisher")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",14);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm(200,14);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 200) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-200);
				PlayerPrefs.SetInt ("SelectedGamePiece",14);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"extinguisher");
			}
		}
	}
	
	public void BuySlotMachine(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("slotmachine")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",15);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm(200,15);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 200) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-200);
				PlayerPrefs.SetInt ("SelectedGamePiece",15);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"slotmachine");
			}
		}
	}

	public void BuyBillBoard(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("billboard")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",15);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm(9999,17);
		else{
			if (PlayerPrefs.GetInt ("Coins") >= 9999) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-9999);
				PlayerPrefs.SetInt ("SelectedGamePiece",17);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"billboard");
			}
		}
	}

	public void BuySodaCan(bool TorF){
		equippedAnim.SetBool("equipped",false);
		if (PlayerPrefs.GetString ("BroughtGamePiece").Contains ("sodacan")) {
			PlayerPrefs.SetInt ("SelectedGamePiece",18);
			equippedAnim.SetBool("equipped",true);
		}
		else if (!TorF)
			Confirm (100,18);
		else {
			if (PlayerPrefs.GetInt ("Coins") >= 100) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins")-100);
				PlayerPrefs.SetInt ("SelectedGamePiece",18);
				PlayerPrefs.SetString("BroughtGamePiece",PlayerPrefs.GetString("BroughtGamePiece")+"sodacan");
			}
		}
	}

	public void Confirm(int num, int gameP){
		confirmCanvas.enabled = true;
		confirmText.text = "Confirm? ¢" + num;
		gamePiece = gameP;
	}

	public void click(bool TorF){
		equippedAnim.SetBool("equipped",false);
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
			case 18:
				BuySodaCan(true);
				break;
			case 19:
				BuyCreeper(true);
				break;
			}
			equippedAnim.SetBool("equipped",true);

		}
		coinText.text = ""+PlayerPrefs.GetInt("Coins");
		confirmCanvas.enabled = false;
	} 

	void OnDestroy(){
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins"));
	}
}