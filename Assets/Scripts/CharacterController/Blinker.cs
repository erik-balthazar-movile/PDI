using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blinker : MonoBehaviour {

	private bool activate = false;

	void Update () {
		if (activate) {
			if (!IsShowingMessage ()) {
				StartCoroutine ("BlinkOn");
			} else {
				StartCoroutine ("BlinkOff");
			}
		}
	}

	public void Show() {
		activate = true;
	}

	public void Hide() {
		activate = false;
		gameObject.GetComponent<Text> ().enabled = false;
	}

	private IEnumerator BlinkOn() {
		yield return new WaitForSeconds(1f);
		gameObject.GetComponent<Text> ().enabled = true;
	}

	private IEnumerator BlinkOff() {
		yield return new WaitForSeconds(1f);
		gameObject.GetComponent<Text> ().enabled = false;
	}

	private bool IsShowingMessage() {
		return gameObject.GetComponent<Text> ().enabled;
	}
}
