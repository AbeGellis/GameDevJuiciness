using UnityEngine;
using System.Collections;

public class PlatformerControl : MonoBehaviour {
	public float turnSpeed;
	
	public float moveForce;
	public float runForce;
	public float maxMoveSpeedForward;
	public float maxRunSpeedForward;
	public float maxMoveSpeedBack;
	public float maxRunSpeedBack;
	
	//public float groundFric;
	//public float airFric;
	//public float jumpGrav;
	//public float fallGrav;
	
	public float jumpForce;
	public float jumpBoost;
	
	public ParticleSystem impact;
	
	bool falling = true;
	
	void Start () {
	
	}
	
	void Update () {
		Vector3 horizontalSpeed = Vector3.Scale(rigidbody.velocity, new Vector3(1f,0f,1f));
		
		Ray groundTest = new Ray(transform.position, -transform.up);
		RaycastHit groundTouch;
		bool grounded;
		
		grounded = Physics.Raycast(groundTest, out groundTouch, (collider.transform.localScale.y / 2f) + .5f);
		
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.up, -turnSpeed);
		if (Input.GetKey(KeyCode.D)) 
			transform.Rotate(Vector3.up, turnSpeed);
		if (Input.GetKey(KeyCode.LeftShift)) {
			if (Input.GetKey(KeyCode.W) && Vector3.Dot(horizontalSpeed, transform.forward) < maxRunSpeedForward)
				rigidbody.AddForce(transform.forward * runForce, ForceMode.Acceleration);
			if (Input.GetKey(KeyCode.S) && Vector3.Dot(horizontalSpeed, 
				-transform.forward) < maxRunSpeedBack)
				rigidbody.AddForce(transform.forward * -runForce, ForceMode.Acceleration);
		}
		else {
			if (Input.GetKey(KeyCode.W) && Vector3.Dot(horizontalSpeed, transform.forward) < maxMoveSpeedForward)
				rigidbody.AddForce(transform.forward * moveForce, ForceMode.Acceleration);
			if (Input.GetKey(KeyCode.S) && Vector3.Dot(horizontalSpeed, 
				-transform.forward) < maxMoveSpeedBack)
				rigidbody.AddForce(transform.forward * -moveForce, ForceMode.Acceleration);
		}
		/*else if (horizontalSpeed.magnitude > 0) {
			if (horizontalSpeed.magnitude > groundFric)
				rigidbody.velocity -= (horizontalSpeed.normalized * groundFric);
			else
				rigidbody.velocity.Scale(new Vector3(0,1,0));
		}*/
		
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			rigidbody.velocity.Scale(new Vector3(1f, 0f, 1f));
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Acceleration);
			grounded = falling = false;
			ParticleSystem impactEffect = Instantiate(impact) as ParticleSystem;
			impactEffect.transform.position = groundTouch.point;
		}
		/*if (!falling) {
			if (Input.GetKey(KeyCode.Space) && rigidbody.velocity.y > 0)
				rigidbody.AddForce(transform.up * jumpBoost, ForceMode.Acceleration);
			else 
				falling = true;
		}*/
	}
}
