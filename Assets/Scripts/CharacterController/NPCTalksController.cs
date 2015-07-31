using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class NPCTalksController : MonoBehaviour {

	//private const string TalksFile = @"Assets/Resources/npctalks.rtf";
	//private const char IdIdentifier = ':';
	//private const char TalkIdentifier = '-';

	private Dictionary<string, List<string>> npcTalks = new Dictionary<string, List<string>>();
	public Dictionary<string, List<string>> NpcTalks { get { return npcTalks; } }
	
	void Awake () {
		/*
		string[] allTalks = File.ReadAllLines (TalksFile);
		string actualId = "";
		for (int i=0; i<allTalks.Length; i++) {
			if (IsId(allTalks[i])) {
				actualId = GetValue(allTalks[i]);
			} else if (IsTalk(allTalks[i])) {
				npcTalks[actualId].Add(GetValue(allTalks[i]));
			}
			Debug.Log (actualId+" - "+GetValue(allTalks[i]));
		}
		*/
		List<string> str = new List<string> ();
		str.Add ("Cuidado! Tem criaturas ferozes atacando por aqui.");
		str.Add ("Oh!");
		str.Add ("Você está armado! Isso certamente irá te ajudar.");
		npcTalks.Add ("cube", str);

		str = new List<string> ();
		str.Add("Vai lá! Acaba com eles!");
		npcTalks.Add ("sphere", str);

		str = new List<string> ();
		str.Add("Você é a nossa esperança?");
		str.Add ("…");
		str.Add ("Pois bem. Dê o seu melhor, soldado!");
		npcTalks.Add ("capsule", str); 
	}

	/*
	private bool IsId(string line) {
		return line.StartsWith (IdIdentifier+"");
	}

	private bool IsTalk(string line) {
		return line.StartsWith (TalkIdentifier+"");
	}

	private string GetValue(string line) {
		return line.Substring (1);
	}
	*/
}
