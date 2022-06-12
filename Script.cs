using UnityEngine;

public class Script: MonoBehaviour{
	[SerializeField] protected GameObject playerHead;
	private Rigidbody rb;

	public bool invertVerticalLook;
	public bool inGround;
	public float jumpAmount;
	public float MoveSpeed;
	public float MouseSpeed;

	void Start(){
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		MoveSpeed = 400f;
		MouseSpeed = 100f;
		jumpAmount = 2000f;
		invertVerticalLook = false;
	}

	void FixedUpdate(){
		MovementLogic();
		MouseLookLogic();
		JumpLogic();
	}

	// Methods
	private void MovementLogic(){
		float MoveHor = Input.GetAxis("Horizontal");
		float MoveVer = Input.GetAxis("Vertical");

		Vector3 move = transform.right * MoveHor + transform.forward * MoveVer;
		rb.AddForce(move * MoveSpeed);
	}

	private void MouseLookLogic(){
		float MouseX = Input.GetAxis("Mouse X");
		float MouseY = Input.GetAxis("Mouse Y");

		float verticalLookDelta = (MouseY * MouseSpeed) * Time.deltaTime;
		float horizontalLookDelta = (MouseX * MouseSpeed) * Time.deltaTime;
		float desiredVerticalLookDelta = (invertVerticalLook) ? verticalLookDelta : -verticalLookDelta; 

		transform.Rotate(new Vector3(0.0f, horizontalLookDelta, 0.0f));
		playerHead.transform.Rotate(new Vector3(desiredVerticalLookDelta, 0.0f, 0.0f));
	}

	private void JumpLogic(){
		if (Input.GetAxis("Jump") > 0){
			if (inGround){
				rb.AddForce(Vector3.up * jumpAmount);
			}
		}
	}

	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground"){
			inGround = true;
		}
	}

	private void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Ground"){
			inGround = false;
		}
	}
}
