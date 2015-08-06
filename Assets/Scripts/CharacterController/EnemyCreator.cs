using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
	public GameObject prefab;
	public Vector3 position; 
	public float visionRadius;
	public float speed;

	private bool isSeeingPlayer = false;
	private Vector3 playerPosition;
	private float startTime;

	public bool CreateEnemy() {
		if (PositionIsOnTheField () && PositiveRadius()) {
			GameObject enemy = (GameObject) GameObject.Instantiate (prefab, position, transform.rotation);
			enemy.transform.position = position;
			enemy.GetComponent<Enemy>().Speed = speed;
			enemy.GetComponent<SphereCollider>().radius = visionRadius;
			enemy.transform.name = "Enemy";
			return true;
		} else {
			return false;
		}
	}

	private bool PositionIsOnTheField() {
		return ((position.x >= 0f && position.x <= 200f) && 
			(position.z >= 0f && position.z <= 200f) &&
			position.y >= 1f);
	}

	private bool PositiveRadius() {
		return (visionRadius > 0);
	}
}
