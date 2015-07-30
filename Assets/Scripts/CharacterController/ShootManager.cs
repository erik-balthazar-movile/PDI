using UnityEngine;
using System.Collections;

public class ShootManager : MonoBehaviour {
	
	public float lifeTime = 1.5f;
	public float speed = 1f;

	private bool shooting = false;
	private float inicialTime;

	public void ShootBullet() {
		inicialTime = Time.time;
		gameObject.SetActive (true);
		shooting = true;
	}

	void Update() {
		if (shooting) {
			GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		}
		if (Time.time - inicialTime > lifeTime) 
		{
			GameObject.Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetType() != typeof(ShootManager))
			Destroy(gameObject);
	}
}
