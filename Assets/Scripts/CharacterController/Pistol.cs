using UnityEngine;
using System.Collections;

public class Pistol : BasicGun {
	public override bool isInputForShooting() {
		return Input.GetMouseButtonDown (0);
	}
}
