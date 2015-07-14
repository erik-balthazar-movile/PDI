using UnityEngine;
using System.Collections;

public class ShootManager : MonoBehaviour {

	public float lifeTime = 1.5f;
	public float speed = 1f;

	private float MaxFrames = 10f;
	private bool shooting = false;

	public void ShootBullet() {
		gameObject.SetActive (true);
		shooting = true;
	}

	void Update() {
		if (shooting) 
			GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetType() != typeof(ShootManager) && !other.transform.name.Equals("Gun"))
			Destroy(gameObject);
	}
}
