using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

	public Image blackscreen;
	public Text gameOverTextComponent;
	public string gameOverMessage;

	public void ShowGameOver () {
		blackscreen.GetComponent<RectTransform> ().sizeDelta = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>().sizeDelta;
		gameOverTextComponent.text = gameOverMessage;
	}
}
