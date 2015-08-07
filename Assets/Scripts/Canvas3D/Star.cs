using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Star : MonoBehaviour {
	private int index = 0;
	private Color[] colors = {Color.magenta, Color.red, Color.black, Color.blue, Color.green, Color.grey};
	delegate void MyPaintDelegate(Color[] c, int i);
	MyPaintDelegate myPaintDelegate;

	public void OnEnterStar() {
		if (index >= colors.Length) {
			index = 0;
		}
		myPaintDelegate = Paints;
		myPaintDelegate (colors, index);
		index++;
	}

	void Paints(Color[] c, int i) {
		GetComponent<Image> ().color = c [i];
	}

	public void PaintsNormal() {
		GetComponent<Image> ().color = Color.white;
	}
}
