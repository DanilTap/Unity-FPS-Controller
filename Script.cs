using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Moving : MonoBehaviour{

	// Preferences
	private Rigidbody rb;
	public float PlayerSpeed;
	public float MouseSpeed = 1f;


	void Start(){
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		PlayerSpeed = 6f;
	}


	void FixedUpdate(){
		// Not physical movement
		float MoveHor = Input.GetAxis("Horizontal");
		float MoveVer = Input.GetAxis("Vertical");
		Vector3 MoveVector = new Vector3(MoveHor, 0.0f, MoveVer);

		rb.AddForce(MoveVector * PlayerSpeed); 

	}

}

// Connect the script to the object with the RigitBody class
