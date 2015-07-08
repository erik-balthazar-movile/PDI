using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public GameObject mainMenu, settingsMenu;
	private bool opened = false;

	public void OpenMenu() {
		gameObject.SetActive (true);
		opened = true;
	}

	public void SettingClick() {
		mainMenu.SetActive(false);
		settingsMenu.SetActive(true);
	}

	public void ResumeClick() {
		CloseMenu ();
	}

	public void FirstPersonClick() {
		CameraManager cameraManager = Camera.main.GetComponent<CameraManager> ();
		cameraManager.ChangeToFirstPerson ();
	}

	public void ThirdPersonClick() {
		CameraManager cameraManager = Camera.main.GetComponent<CameraManager> ();
		cameraManager.ChangeToThirdPerson ();
	}

	public void BackSettingsClick() {
		settingsMenu.SetActive (false);
		mainMenu.SetActive (true);
	}

	public bool isOpened() {
		return opened;
	}

	public void CloseMenu() {
		mainMenu.SetActive (true);
		settingsMenu.SetActive (false);
		gameObject.SetActive (false);
		opened = false;
	}


}
