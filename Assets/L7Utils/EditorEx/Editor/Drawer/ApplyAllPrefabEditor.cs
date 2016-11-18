using System;
using UnityEditor;
using UnityEngine;

namespace L7 {
	[CustomEditor(typeof(ApplyAllPrefab))]
	[CanEditMultipleObjects]
	public class ApplyAllPrefabEditor : Editor {

		private ApplyAllPrefab ins;
		private Transform parent;

		private Vector3 tempPosition;
		private Quaternion tempRotation;
		private Vector3 tempScale;

		void OnEnable() {
			ins = (ApplyAllPrefab)target;
			parent = ins.transform;
		}

		public override void OnInspectorGUI() {
			ins.ResetPosition = EditorGUILayout.Toggle("Reset Position", ins.ResetPosition);
			ins.ResetRotation = EditorGUILayout.Toggle("Reset Rotation", ins.ResetRotation);
			ins.ResetScale = EditorGUILayout.Toggle("Reset Scale", ins.ResetScale);

			if (GUILayout.Button("ApplyAllPrefab")) {
				try {
					for (int i = 0; i < parent.childCount; i++) {
						EditorUtility.DisplayProgressBar("处理中", i + "/" + parent.childCount, (float)i / parent.childCount);
						var child = parent.GetChild(i);

						tempPosition = child.localPosition;
						tempRotation = child.localRotation;
						tempScale = child.localScale;

						if (ins.ResetPosition) {
							child.localPosition = Vector3.zero;
						}
						if (ins.ResetRotation) {
							child.localRotation = Quaternion.identity;
						}
						if (ins.ResetScale) {
							child.localScale = Vector3.one;
						}

						var prefab = PrefabUtility.GetPrefabParent(child.gameObject);
						if (prefab != null) {
							PrefabUtility.ReplacePrefab(child.gameObject, prefab);
						}

						child.localPosition = tempPosition;
						child.localRotation = tempRotation;
						child.localScale = tempScale;
					}

				} finally {
					EditorUtility.ClearProgressBar();
				}
			}
		}
	}
}