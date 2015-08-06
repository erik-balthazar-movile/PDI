using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Star : MonoBehaviour {
	public void PaintsRed() {
		GetComponent<Image> ().color = Color.red;
	}

	public void PaintsNormal() {
		GetComponent<Image> ().color = Color.white;
	}
}
