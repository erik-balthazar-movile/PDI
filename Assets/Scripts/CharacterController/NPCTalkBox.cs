using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCTalkBox : MonoBehaviour {
	public Text mainMessage;
	public Text alertMessage;

	public void SetMessage(string newMessage) {
		mainMessage.GetComponent<Typer> ().Message = newMessage;
	}

	public void InitTyper() {
		mainMessage.GetComponent<Typer> ().Init ();
	}

	public void CleanMessage() {
		mainMessage.GetComponent<Typer> ().Message = "";
	}

	public void ShowAlertMesssage() {
		alertMessage.GetComponent<Blinker> ().Show ();
	}

	public void HideAlertMesssage() {
		alertMessage.GetComponent<Blinker> ().Hide ();
	}

	public void ShowTalkBox() {
		GetComponent<ScaleFrom> ().Init ();
	}
}
