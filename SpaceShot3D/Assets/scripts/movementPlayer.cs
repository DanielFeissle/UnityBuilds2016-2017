using UnityEngine;
using System.Collections;

public class movementPlayer : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public float PlayerLocationX;
	public float PlayerLocationZ;
  

   //  Quaternion newRotation;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	  //  newRotation = rb.rotation;
		PlayerLocationX = transform.position.x;
		PlayerLocationZ = transform.position.z;
	}
	
	void FixedUpdate() //good for movement
	{
	   
		float moveVertical = Input.GetAxis("Vertical");
	  
		float moveHorizantal = Input.GetAxis("Horizontal");

		moveVertical = -(moveVertical);
	
			Vector3 movement = new Vector3(moveHorizantal, 0.0f, -moveVertical);
			moveHorizantal = 0.0f;
			moveVertical = 0.0f;
			rb.AddForce((movement * speed)*2);
			
	}

	// Update is called once per frame

	void Update () {

		
	}
	void LateUpdate()
	{
		 
			PlayerLocationX = transform.position.x;
			PlayerLocationZ = transform.position.z;
	   
	}

}
