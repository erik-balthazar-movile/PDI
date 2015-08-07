using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertEnemy : MonoBehaviour {

	public float deltaDelay = 1f;
	private Color updatedColor;
	private bool isIncreasing;

	public const float InitialRedValue = 115f;
	public const float FinalRedValue = 230f;
	public const float DeltaRedValue = 5f;

	void Start() {
		updatedColor = GetComponent<Text> ().color;
		isIncreasing = true;
		StartCoroutine ("UpdateRedColorProperty");
	}

	private IEnumerator UpdateRedColorProperty() {
		//for (;;) {
			if (isIncreasing) {
				if (updatedColor.r < FinalRedValue) {
					updatedColor.r += DeltaRedValue;
				} else {
					isIncreasing = false;
					updatedColor.r = FinalRedValue;
				}
			} else {
				if (updatedColor.r > InitialRedValue) {
					updatedColor.r -= DeltaRedValue;
				} else {
					isIncreasing = true;
					updatedColor.r = InitialRedValue;
				}
			}
			GetComponent<Text> ().color = updatedColor;
			yield return new WaitForSeconds (deltaDelay);
		//}
	}

}
