using UnityEngine;
using System.Collections;

public class CharacterShootController : MonoBehaviour {
	
	public BasicGun[] guns;
	public GameOverScreen gameOverScreenPrefab;

	private BasicGun activeGun;
	private Interactive interactiveObject = null;
	private bool gameOver = false;

	private const KeyCode ReloadKey = KeyCode.R;
	private const KeyCode CarryFirstGunKey = KeyCode.Alpha1;
	private const KeyCode CarrySecondGunKey = KeyCode.Alpha2;
	private const KeyCode InteractKey = KeyCode.Return;

	void Start() {
		activeGun = guns [0];
		activeGun.gameObject.SetActive (true);
	}

	void Update () {
		Cursor.visible = false;
		if (!gameOver) {
			if (activeGun.isInputForShooting () && activeGun.HasBullets () && !activeGun.isReloading ()) {
				activeGun.ManageShootBullets ();
				activeGun.UpdateBulletCount ();
			}

			if ((Input.GetKeyDown (ReloadKey) && !activeGun.isReloading () && !activeGun.IsFullyCharged ()) 
				|| !activeGun.HasBullets ()) {
				activeGun.Reload ();
				activeGun.UpdateBulletCount ();
			}

			if (Input.GetKeyDown (CarryFirstGunKey)) {
				activeGun.gameObject.SetActive (false);
				activeGun = guns [0];
				activeGun.gameObject.SetActive (true);
				activeGun.UpdateBulletCount ();
			}

			if (Input.GetKeyDown (CarrySecondGunKey)) {
				activeGun.gameObject.SetActive (false);
				activeGun = guns [1];
				activeGun.gameObject.SetActive (true);
				activeGun.UpdateBulletCount ();
			}

			if (Input.GetKeyDown (InteractKey) && HasInteractiveObject ()) {
				interactiveObject.Interact ();
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		Interactive auxInteractive = other.GetComponent<Interactive> ();
		if (auxInteractive != null) {
			interactiveObject = auxInteractive;
			Debug.Log ("Interativo Enter: " + other.name);
		}
	}

	void OnTriggerExit(Collider other) {
		Interactive auxInteractive = other.GetComponent<Interactive> ();
		if (auxInteractive != null) {
			interactiveObject = null;
			Debug.Log ("Interativo Exit: " + other.name);
		}
	}

	private bool HasInteractiveObject() {
		return interactiveObject != null;
	}

	public void GameOver() {
		gameOver = true;
		GameOverScreen gameOverScreen = (GameOverScreen) GameObject.Instantiate(gameOverScreenPrefab);
		gameOverScreen.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
		gameOverScreen.ShowGameOver ();
	}

	public bool IsGameOver() {
		return gameOver;
	}
}
