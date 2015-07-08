using UnityEngine;
using System.Collections;

public class BalloonManager : MonoBehaviour {
	public Typer textTyper;

	public void ShowBalloon() {
		gameObject.SetActive (true);
		GetComponent<ScaleFrom>().Init();
		textTyper.Init();
	}
}
