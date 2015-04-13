using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateCamera : MonoBehaviour {
	public Camera topViewCamera;
	public Camera normalViewCamera;
	public Camera backViewCamera;

	public Button topViewButton;
	public Button normalViewButton;
	public Button backViewButton;

	void Start(){
		SwitchToNormalView ();
	}

	public void SwitchToTopView(){
		topViewCamera.enabled = true;
		normalViewCamera.enabled = false;
		backViewCamera.enabled = false;

		topViewButton.enabled = false;
		topViewButton.image.enabled = false;

		normalViewButton.enabled = true;
		normalViewButton.image.enabled = true;

		backViewButton.enabled = true;
		backViewButton.image.enabled = true;

	}

	public void SwitchToNormalView(){
		topViewCamera.enabled = false;
		normalViewCamera.enabled = true;
		backViewCamera.enabled = false;

		topViewButton.enabled = true;
		topViewButton.image.enabled = true;

		normalViewButton.enabled = false;
		normalViewButton.image.enabled = false;

		backViewButton.enabled = true;
		backViewButton.image.enabled = true;
	}

	public void SwitchToBackView(){
		topViewCamera.enabled = false;
		normalViewCamera.enabled = false;
		backViewCamera.enabled = true;

		normalViewButton.enabled = true;
		normalViewButton.image.enabled = true;

		topViewButton.enabled = true;
		topViewButton.image.enabled = true;

		backViewButton.enabled = false;
		backViewButton.image.enabled = false;
	}
}