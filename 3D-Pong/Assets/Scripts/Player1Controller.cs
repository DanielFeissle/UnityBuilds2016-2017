using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
  //  bool goodToMove = true;
   
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
     float moveVertical    = Input.GetAxis("Vertical");
        
            //float moveHorizantal = Input.GetAxis("Horizontal");


        if (rb.position.y<-15)
        {
            //stop moving bottom
            Vector3 movement = new Vector3(0.0f, 2.0f, 0.0f);
             rb.AddForce(movement * speed);
            
        }
        else if (rb.position.y>28) //stop moving top
        {
            Vector3 movement = new Vector3(0.0f, -2.0f, 0.0f);
            rb.AddForce(movement * speed);
        }
        else
        {
            Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);
            //	moveHorizantal = 0.0f;
            moveVertical = 0.0f;
            rb.AddForce(movement * speed);
        }
   
      
       
	   
	}
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {
     //   goodToMove = true;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("BottomCollisionPlane"))
        {
            Debug.Log("IT HIT IT");
        }
    
    }
}
