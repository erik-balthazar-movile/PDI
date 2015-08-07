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

			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

			Vector3 forward = actualTarget.transform.TransformDirection(Vector3.forward);
			Vector3 toOther = transform.position - actualTarget.transform.position;
			float dot = Vector3.Dot(forward, toOther);

			if (dot < 0f) {
				actualTarget.GetComponent<CharacterShootController>().ShowBackMessage();
				actualTarget.GetComponent<CharacterShootController>().HideFrontMessage();
				Debug.Log("ATRAS DE VOCE - "+dot);
			} else if (dot > 0f) {
				actualTarget.GetComponent<CharacterShootController>().ShowFrontMessage();
				actualTarget.GetComponent<CharacterShootController>().HideBackMessage();
				Debug.Log("NA SUA FRENTE - "+dot);
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		CharacterShootController player = other.GetComponent<CharacterShootController> ();
		if (player != null) {
			actualTarget = other.gameObject;
			isSeeingPlayer = true;
			//Debug.Log("Viu o Player");
		}
	}
	
	void OnTriggerExit(Collider other) {
		CharacterShootController player = other.GetComponent<CharacterShootController> ();
		if (player != null) {
			isSeeingPlayer = false;
			actualTarget = null;
			Vector3 forward = other.transform.TransformDirection(Vector3.forward);
			Vector3 toOther = transform.position - other.transform.position;
			float dot = Vector3.Dot(forward, toOther);
			
			if (dot < 0f) {
				other.gameObject.GetComponent<CharacterShootController>().HideBackMessage();
				Debug.Log("ATRAS DE VOCE - "+dot);
			} else if (dot > 0f) {
				other.gameObject.GetComponent<CharacterShootController>().HideFrontMessage();
				Debug.Log("NA SUA FRENTE - "+dot);
			}
			//Debug.Log("Deixou de ver o Player");
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<TerrainCollider> () != null) {
			isOnTheGround = true;
		}

		CharacterShootController character = other.gameObject.GetComponent<CharacterShootController> ();
		if (character != null) {
			if (!character.IsGameOver()) {
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
