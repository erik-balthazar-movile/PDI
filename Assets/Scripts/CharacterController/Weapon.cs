using UnityEngine;
using System.Collections;

public class Weapon : BasicGun {

	public float fireRate;
	private float nextFire = 0.0f;

	public override bool isInputForShooting() {
		if (Input.GetMouseButton (0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			return true;
		}
		return false;
	}
}
