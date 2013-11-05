using UnityEngine;
using System.Collections;

public class WaterDeform : MonoBehaviour {
	
	MeshFilter mf;
	Vector3[] baseVertices;
	Vector3[] workingCopy;
	
	public float scaleWaves;
	public float waveSpeed;
	
	// Use this for initialization
	void Start () {
		mf = GetComponent<MeshFilter>();
		baseVertices = mf.mesh.vertices;
	}
	
	// Update is called once per frame
	void Update () {
		workingCopy = baseVertices;
		
		for (int i = 0; i < baseVertices.Length; ++i) {
			workingCopy[i].y = scaleWaves * Mathf.Sin(Time.time * waveSpeed + i);
		}
		
		mf.mesh.vertices = workingCopy;
		mf.mesh.RecalculateNormals();
	}
}
