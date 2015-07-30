using UnityEngine;
using System.Collections;

public class CharacterShootController : MonoBehaviour {
	
	public BasicGun[] guns;
	private BasicGun activeGun;

	void Start() {
		activeGun = guns [0];
		activeGun.gameObject.SetActive (true);
	}

	void Update () {
		Cursor.visible = false;
		if (activeGun.isInputForShooting() && activeGun.HasBullets() && !activeGun.isReloading()) {
			activeGun.ManageShootBullets();
			activeGun.UpdateBulletCount();
		}

		if (Input.GetKeyDown (KeyCode.R) && !activeGun.isReloading()) {
			activeGun.Reload();
			activeGun.UpdateBulletCount();
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			activeGun.gameObject.SetActive(false);
			activeGun = guns[0];
			activeGun.gameObject.SetActive (true);
			activeGun.UpdateBulletCount();
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			activeGun.gameObject.SetActive(false);
			activeGun = guns[1];
			activeGun.gameObject.SetActive (true);
			activeGun.UpdateBulletCount();
		}
	}
}
