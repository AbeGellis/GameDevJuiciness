using UnityEngine;
using System.Collections;

public class BallClack : MonoBehaviour {
	public Vector3 start, end;
	
	
	// Use this for initialization
	void Start () {
		StartCoroutine(BallMove());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator BallMove() {
		
		while (true) {
			float t = Mathf.Abs(Mathf.Sin(Time.time));
			
			if (t < 0.51 && t > 0.49 && !audio.isPlaying)
				audio.Play();
			
			transform.position = Vector3.Lerp(start, end, t);
			yield return 0;
		}
		
		yield return new WaitForSeconds(5f);
		Debug.Log("5 seconds have passed");
	}
}
