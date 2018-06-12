using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class playerShot : MonoBehaviour {
	private Rigidbody rb;
	bool isShot = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	public AudioClip shot;
	void FixedUpdate()
	{
		GameObject PlayerDead = GameObject.Find("InvPlayer");
		backendScores CheckPlayer = PlayerDead.GetComponent<backendScores>();
		if (CheckPlayer.isGameover==0)
		{
			if (Input.GetButton("Fire1") && isShot == false)
			{
			  
			   
				
				//HOW TO FIND INFORMATION FROM OTHER SCRIPTS
				GameObject PlayerLocation = GameObject.Find("InvPlayer");
				movementPlayer enemyHealth = PlayerLocation.GetComponent<movementPlayer>();

				float beamX;
				float beamZ;

				beamX = enemyHealth.PlayerLocationX;
				beamZ = enemyHealth.PlayerLocationZ;

				rb.position = new Vector3(beamX, 0, beamZ + .5f);
				rb.AddForce(new Vector3(0.0f, 777.777f, 0.0f) * 44);
				isShot = true;
				AudioSource.PlayClipAtPoint(shot, new Vector3(rb.position.x, 0, rb.position.z),volume:.20f);
			}
			/*
		else
		{
			rb.position = new Vector3(0f, 75f, -55.5f);
		}
			 * */

			if (isShot == true)
			{


				if (rb.position.y > 175.7f)
				{

					rb.AddForce(new Vector3(0.0f, -777.777f, 0.0f) * 44);
					rb.position = new Vector3(0.0f, -500.0f, 0.0f);
					isShot = false;
				}

			}
		}
		
	}
	// Update is called once per frame
	void Update () {
	   
	}

	void LateUpdate()
	{
	   
	}
}
