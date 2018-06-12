using UnityEngine;
using System.Collections;

public class rotateSkybox : MonoBehaviour
{
   
	// Use this for initialization
	void Start () {
       // alreadyRun = 0;
	}
	
	// Update is called once per frame
	void Update () {
	


	}
    //good way how to move constantly the skybox
    //make another camera
    //set the primary camera for depth only while the new camera is for the skybox
    //then apply this script to the moving skybox camera
	private Vector3 rotationValue; 
	private float turnValue = 0.0f;
  //   private int alreadyRun = 0;
	private float turnVal { get { return turnValue; } set { turnValue = value; if (turnValue >= 360f) turnValue = 0.0f; } }
  
	void LateUpdate()
	{
        
		//turnVal += Time.deltaTime;
        turnVal = .03125f; //orginal value  .03125f;
        rotationValue = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y + turnVal, Camera.main.transform.rotation.eulerAngles.z);
		transform.rotation = Quaternion.Euler(rotationValue);
        GameObject checkStats = GameObject.Find("InvPlayer");
        backendScores reallyStat = checkStats.GetComponent<backendScores>();
       
        if (reallyStat.FleetHull<0) //the game is over
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, .75f * Time.deltaTime);
            reallyStat.isGameover = 1;
        }
        else if (reallyStat.FleetHull >= 0 && reallyStat.FleetHull <= 100) //reset everything back into place
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 170, .75f * Time.deltaTime);
           reallyStat.isGameover = 0;
        }
         //could change when game over and go back, possibly change fov at start and end?
          //  Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, 1 * Time.deltaTime);
        
	}
}
