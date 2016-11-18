using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public struct Range {
	public float min;
	public float max;
}

public class TreeTrunk : MonoBehaviour {

	public float initialTreeRadius;
	public int initialTreeSubdivisions;
	public Range initialTreeRadiusRange;

	private Mesh mesh;

	void Awake() {
		mesh = new Mesh();
	}

	void InitBottom() {
		var realRadius = initialTreeRadius * Random.Range(initialTreeRadiusRange.min, initialTreeRadiusRange.max);
	}



}

