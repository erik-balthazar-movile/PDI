using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class NPCTalksController : MonoBehaviour {

	//private const string TalksFile = @"Assets/Resources/npctalks.rtf";

	private Dictionary<string, List<string>> npcTalks = new Dictionary<string, List<string>>();
	public Dictionary<string, List<string>> NpcTalks { get { return npcTalks; } }
	
	void Awake () {
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
	
}
