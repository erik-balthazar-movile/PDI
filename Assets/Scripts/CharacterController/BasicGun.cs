using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BasicGun : MonoBehaviour {

	public ShootManager bullet;
	public int initialNumberOfBullets;
	public int maxNumberOfBullets;
	public Text bulletCountText;

	private int numberOfBullets;
	private int totalNumberOfBullets;

	private const string ReloadTrigger = "GoToReload";
	private const string ReloadState = "Reloading";
	private const int NoBullets = 0;

	public abstract bool isInputForShooting();

	void Awake() {
		numberOfBullets = initialNumberOfBullets;
		totalNumberOfBullets = maxNumberOfBullets;
		UpdateBulletCount ();
	}

	public bool HasBullets() {
		return numberOfBullets > NoBullets;
	}

	public void DecBulletCount() {
		if (HasBullets()) {
			numberOfBullets--;
		}
	}

	public void Reload() {
		if (canReload()) {
			if (totalNumberOfBullets >= initialNumberOfBullets) {
				totalNumberOfBullets -= initialNumberOfBullets - numberOfBullets;
				numberOfBullets = initialNumberOfBullets;
			} else {
				totalNumberOfBullets = NoBullets;
				numberOfBullets = totalNumberOfBullets;
			}
			GetComponent<Animator>().SetTrigger(ReloadTrigger);
		}
	}

	public bool isReloading() {
		return GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash(ReloadState);
	}

	public void UpdateBulletCount() {
		bulletCountText.text = numberOfBullets + " / " + totalNumberOfBullets;
	}

	public void ManageShootBullets() {
		DecBulletCount();
		InstantiateNewBullet();
	}

	private bool canReload() {
		return totalNumberOfBullets > NoBullets;
	}

	private void InstantiateNewBullet() {
		GameObject newBullet = (GameObject) GameObject.Instantiate (bullet.gameObject, bullet.transform.position, bullet.transform.rotation);
		newBullet.GetComponent<ShootManager>().ShootBullet();
	}
}
