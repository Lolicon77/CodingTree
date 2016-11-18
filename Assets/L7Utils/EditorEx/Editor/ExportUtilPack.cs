using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;


namespace L7
{
	public class ExportUtilPack : MonoBehaviour
	{


		private static string[] toExport = new[]
		{
			"Assets/L7Utils"
		};


		[MenuItem("L7/ExportUtilPack &E")]
		static void Handle() {
			EditorUtility.DisplayProgressBar("pack","pack",0);
			AssetDatabase.ExportPackage(toExport,Path.Combine(Application.dataPath,"UnityUtils.unitypackage"),ExportPackageOptions.Recurse);
			EditorUtility.ClearProgressBar();
			Debug.Log("导出成功");
		}


	}
}
