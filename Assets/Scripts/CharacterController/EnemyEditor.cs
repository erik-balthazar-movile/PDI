using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyCreator))]
public class EnemyEditor : Editor {
	public override void OnInspectorGUI ()
	{
		EnemyCreator enemy = (EnemyCreator)target;

		EditorGUILayout.LabelField ("Create an enemy bot");
		enemy.prefab = (GameObject) EditorGUILayout.ObjectField ("Enemy Prefab", enemy.prefab, typeof(GameObject), true);
		enemy.position = (Vector3) EditorGUILayout.Vector3Field ("Enemy Position", enemy.position);
		enemy.visionRadius = (float) EditorGUILayout.FloatField ("Vision Collider Radius", enemy.visionRadius);
		enemy.speed = (float) EditorGUILayout.FloatField ("Enemy Speed", enemy.speed);
		if (GUILayout.Button ("Create Enemy")) {
			if (enemy.CreateEnemy()) {
				GUILayout.Box("Inimigo criado com sucesso!");
			} else {
				GUILayout.Box("Falha ao criar!");
			}
		}
	}
}
