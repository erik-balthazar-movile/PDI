using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCController : MonoBehaviour, Interactive {

	public NPCTalksController npcTalksController;
	public string npcId;
	public NPCTalkBox npcTalkBoxPrefab;

	private NPCTalkBox npcTalkBox;

	private int index = -1;

	void Start() {
		//gameObject.AddComponent<RectTransform> ();
	}

	private void Talk() {
		if (IsTheBeginningOfTheTalk ()) {
			npcTalkBox = (NPCTalkBox)GameObject.Instantiate (npcTalkBoxPrefab);
			npcTalkBox.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
			npcTalkBox.ShowTalkBox ();
		}
		if (IsTheEndingOfTheTalk ()) {
			GameObject.Destroy(npcTalkBox.gameObject);
			ResetIndex();
		} else {
			string message = npcTalksController.NpcTalks [npcId] [++index];
			npcTalkBox.SetMessage (message);
			npcTalkBox.InitTyper();
			//StartCoroutine("ActivateAlertMessage");
		}
	}

	private bool IsTheBeginningOfTheTalk() {
		return index == -1;
	}

	private bool IsTheEndingOfTheTalk() {
		return index == npcTalksController.NpcTalks [npcId].Count-1;
	}

	public void Interact() {
		Talk ();
	}

	private void ResetIndex() {
		index = -1;
	}
}
