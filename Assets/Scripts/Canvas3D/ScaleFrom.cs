using UnityEngine;
using System.Collections;

public class ScaleFrom : MonoBehaviour {

	public float startDelay, scaleDelay;
	public Vector3 from;

	public void Init() {
		StartCoroutine ("Scale");
	}

	private IEnumerator Scale() {
		const int ScaleSteps = 10;
		Vector3 finalScale = transform.localScale;
		transform.localScale = from;

		yield return new WaitForSeconds (startDelay); 

		float xDelta = (finalScale.x - from.x) / ScaleSteps,
			  yDelta = (finalScale.y - from.y) / ScaleSteps,
			  zDelta = (finalScale.z - from.z) / ScaleSteps;

		for (int i=0; i<ScaleSteps; i++) {
			float newX = xDelta + transform.localScale.x;
			float newY = yDelta + transform.localScale.y;
			float newZ = zDelta + transform.localScale.z;
			transform.localScale = new Vector3(newX, newY, newZ);
			yield return new WaitForSeconds (scaleDelay);
		}
	}
}
