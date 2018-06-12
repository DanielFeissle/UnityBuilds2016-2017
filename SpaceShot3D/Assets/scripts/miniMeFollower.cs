using UnityEngine;
using System.Collections;

public class miniMeFollower : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
   
	// Update is called once per frame
	void Update () {
     
	}
    void LateUpdate()
    {
        GameObject Movement = GameObject.Find("InvPlayer");
        movementPlayer CheckPlayer = Movement.GetComponent<movementPlayer>();
        //  rb.position = new Vector3(beamX, 0, beamZ + .5f);
        rb.position = new Vector3(CheckPlayer.PlayerLocationX,0, CheckPlayer.PlayerLocationZ);
      //  rb.AddForce(new Vector3(0, 3, 0));
      
    }
}
