using UnityEngine;
using System.Collections;

public class CharacterShootController : MonoBehaviour {

	public GameObject bullet;
	public GunManager gunManager;

	void Update () {
		if (Input.GetMouseButtonDown(0) && gunManager.HasBullets()) {
			gunManager.DecBulletCount();
			GameObject newBullet = (GameObject) GameObject.Instantiate (bullet, bullet.transform.position, bullet.transform.rotation);
			newBullet.GetComponent<ShootManager>().ShootBullet();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			gunManager.Reload();
		}
	}
}
