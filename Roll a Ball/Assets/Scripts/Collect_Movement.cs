using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//private Rigidbody rbV2;
	//public float speed;
	//public int horizantalLoc = 20;
	//public int verticalLoc = 20;

	// Use this for initialization
	void Start () {
	//	rbV2 = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate() //good for movement
	{
	//	Vector3 movement = new Vector3(horizantalLoc, 0.0f, verticalLoc);
	//	rbV2.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
	//	if (other.gameObject.CompareTag("ItemCollision"))
	//	{
	//		horizantalLoc = horizantalLoc * -1;
	//	   
		//}
		//if (other.gameObject.CompareTag("ItemCollision"))
		//{
	//		verticalLoc = verticalLoc * -1;

	//	}

	}
}
