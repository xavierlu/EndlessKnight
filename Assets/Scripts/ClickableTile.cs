using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {
	public int tileX;
	public int tileY;
	public TileMap map;
	public string myColor;
	
	public void OnMouseUp() {
		if (!myColor.Equals("red"))
			map.MoveSelectedUnitTo(tileX, tileY);
	}

	public void OnPointerClick(){
		if (!myColor.Equals("red"))
			map.MoveSelectedUnitTo(tileX, tileY);
	}
}