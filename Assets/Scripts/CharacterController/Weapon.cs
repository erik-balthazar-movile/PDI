using UnityEngine;
using System.Collections;

public class Weapon : BasicGun {
	public override bool isInputForShooting() {
		return Input.GetMouseButton (0);
	}

	private IEnumerator Wait() {
		yield return new WaitForSeconds(2f);
	}
}
