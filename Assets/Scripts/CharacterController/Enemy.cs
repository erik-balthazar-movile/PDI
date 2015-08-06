using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float speed;
	private bool isSeeingPlayer = false, isOnTheGround = false;
	private GameObject actualTarget;
	private float startTime;

	public float Speed { set { speed = value; } }

	void Start() {
		startTime = Time.time;
	}

	void Update() {
		if (isSeeingPlayer && isOnTheGround) {
			Vector3 targetPosition = new Vector3(actualTarget.transform.position.x,transform.position.y,actualTarget.transform.position.z);

			float distance = Vector3.Distance(transform.position, targetPosition);
			float fracDistance = speed / distance;
			Vector3 lerpAux = Vector3.Lerp(transform.position, targetPosition, fracDistance);

			Vector3 aux = transform.position;
			aux.x = lerpAux.x;
			aux.z = lerpAux.z;
			transform.position = aux;

			//transform.position = new Vector3(lerpAux.x,transform.position.y,lerpAux.z);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		CharacterShootController player = other.GetComponent<CharacterShootController> ();
		if (player != null) {
			actualTarget = other.gameObject;
			isSeeingPlayer = true;
			Debug.Log("Viu o Player");
		}
	}
	
	void OnTriggerExit(Collider other) {
		CharacterShootController player = other.GetComponent<CharacterShootController> ();
		if (player != null) {
			isSeeingPlayer = false;
			actualTarget = null;
			Debug.Log("Deixou de ver o Player");
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<TerrainCollider> () != null) {
			isOnTheGround = true;
		}

		CharacterShootController character = other.gameObject.GetComponent<CharacterShootController> ();
		if (character != null) {
			if (!character.IsGameOver()) {
				Debug.Log("!!!!!!");
				other.gameObject.GetComponent<CharacterShootController> ().GameOver();
			}
		}
	}

	void OnCollisionExit(Collision other) {
		if (other.gameObject.GetComponent<TerrainCollider> () != null) {
			isOnTheGround = false;
		}
	}
}
