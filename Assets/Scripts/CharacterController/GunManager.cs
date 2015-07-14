using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {

	public int initialNumberOfBullets;
	private int numberOfBullets;

	void Awake() {
		numberOfBullets = initialNumberOfBullets;
	}

	public bool HasBullets() {
		return numberOfBullets > 0;
	}

	public void DecBulletCount() {
		if (HasBullets()) {
			numberOfBullets--;
		}
	}

	public void Reload() {
		numberOfBullets = initialNumberOfBullets;
	}
}
