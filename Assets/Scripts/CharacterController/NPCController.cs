using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCController : MonoBehaviour {

	public NPCTalksController npcTalksController;
	public string npcId;

	private int index = -1;

	public void Talk() {
		if (IsTheBeginningOfTheTalk ()) {
		
		}
	}

	private bool IsTheBeginningOfTheTalk() {
		return index == -1;
	}
}
