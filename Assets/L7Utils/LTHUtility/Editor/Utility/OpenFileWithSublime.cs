using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;


[InitializeOnLoad]
public class OpenFileWithSublime : EditorWindow {


	private const string sublimePathPref = "SublimePath";
	private const string sublimeEnablePref = "SublimeEnable";
	private const string extensionPref = "ExtensionsOpenBySublime";




	private static string sublimePath = "/";
	private static string extensionStrings = "";


	private static bool enable;
	private static bool haveSublime;
	private static string[] extensionArray;


	void OnGUI() {
		enable = EditorGUILayout.Toggle("开启", enable);
		GUILayout.BeginHorizontal();
		GUI.color = !haveSublime ? Color.red : Color.green;
		EditorGUILayout.TextField("Sublime Path:", sublimePath);
		GUI.color = Color.white;
		if (GUILayout.Button("find", GUILayout.MaxWidth(30f))) {
			string tempPath = EditorUtility.OpenFilePanel("sublime路径", "/", "exe");
			if (File.Exists(tempPath)) {
				sublimePath = tempPath;
			}
		}
		GUILayout.EndHorizontal();


		EditorGUILayout.LabelField("用sublime打开以下文件:");
		extensionStrings = EditorGUILayout.TextField(extensionStrings);
		if (GUI.changed) {
			EditorPrefs.SetString(sublimePathPref, sublimePath);
			EditorPrefs.SetBool(sublimeEnablePref, enable);
			EditorPrefs.SetString(extensionPref, extensionStrings);
			Reload();
		}
	}


	static OpenFileWithSublime() {
		Reload();
	}


	static void Reload() {
		sublimePath = EditorPrefs.GetString(sublimePathPref, "/");
		enable = EditorPrefs.GetBool(sublimeEnablePref, false);
		extensionStrings = EditorPrefs.GetString(extensionPref, "shader,cginc,js,lua");
		haveSublime = File.Exists(sublimePath);
		extensionArray = extensionStrings.Split(',');
	}


	static void OpenFileBySublime(string path) {
		ProcessStartInfo proc = new ProcessStartInfo
		{
			FileName = EditorPrefs.GetString(sublimePathPref, ""),
			Arguments = "\"" + path + "\""
		};
		Process.Start(proc);
	}


	[MenuItem("Assets/用sublime打开")]
	static void OpenSelectionWithSublime() {
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		OpenFileBySublime(path);
	}


	[MenuItem("LTH/Utility/配置Sublime打开文件")]
	public static void OpenWindow() {
		OpenFileWithSublime win = EditorWindow.GetWindow<OpenFileWithSublime>();
		win.Show();
	}


	[OnOpenAsset]
	static bool OpenBySublime(int instanceID, int line) {
		if (!enable || !haveSublime) {
			return false;
		}


		Object obj = EditorUtility.InstanceIDToObject(instanceID);
		string path = AssetDatabase.GetAssetPath(obj).ToLower();


		if (extensionArray.Where(s => !string.IsNullOrEmpty(s)).Any(s => path.EndsWith(s.ToLower()))) {
			OpenFileBySublime(path);
			return true;
		}
		return false;
	}




}
