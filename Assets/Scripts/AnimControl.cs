using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {
	
	public float scrollSpeed;
	
	public PlatformerControl player;
	
	// Use this for initialization
	void Start () {
	
	}
	
    void Update() {
		if (player.grounded) {
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
				animation.CrossFade("Walk");
			else
				animation.CrossFade("Idle");
		}
		else
			animation.CrossFade("Jump");
    }
}
