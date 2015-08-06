using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Typer : MonoBehaviour {

	public float startDelay = 0f, typeDelay = 0.01f;
	public string message;
	public string Message { set { message = value; } get { return message; } }
	private Text textComponent;

	void Awake() {
		textComponent = GetComponent<Text>();
	}

	public void Init() {
		StartCoroutine ("Type");
	}

	private IEnumerator Type() {
		yield return new WaitForSeconds(startDelay);

		for (int i=0; i<=message.Length; i++) {
			textComponent.text = message.Substring(0, i);
			yield return new WaitForSeconds(typeDelay);
		}
	}
}	
