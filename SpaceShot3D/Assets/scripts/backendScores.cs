using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;


public class backendScores : MonoBehaviour {
    public int playerScore = 0;
    public int FleetHull = 100;
     public int isGameover = 2;
    public int totItemsHit = 0;
    public int itemsLetThrough = 0;
    private Rigidbody rb;
  //  public Image logoCode;
    public Text ScoreDisplay;
    public Text FleetDisplay;
    public Text uiDialog;
    public Text statisticallyFun;
    public AudioClip startEngine;
    public AudioClip crashedEngine;
    private int whereGameOver = 0;
    int tempTimer = 0;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        FleetHull = 1001;
        totItemsHit = 0;
        itemsLetThrough = 0;
        isGameover = 2;
        uiDialog.text = "Space Shot 3D \n\n\n\n\n 2016";
	}
	
	// Update is called once per frame
	void Update () {
      
	}
    void LateUpdate()
    {
        if (Input.GetButton("Fire2")&&isGameover==1)
        {
            playerScore = 0;
            isGameover = 0;
            FleetHull = 100; //reset
            uiDialog.text = "";
            itemsLetThrough = 0;
            totItemsHit = 0;
            AudioSource.PlayClipAtPoint(startEngine, new Vector3(rb.position.x, rb.position.y, rb.position.z));
        }
        else if (Input.GetButton("Fire2") && isGameover == 2) //for intial starting
        {
            playerScore = 0;
            isGameover = 0;
            FleetHull = 100; //reset
            uiDialog.text = "";
            itemsLetThrough = 0;
            totItemsHit = 0;
            AudioSource.PlayClipAtPoint(startEngine, new Vector3(rb.position.x, rb.position.y, rb.position.z));
         //   Destroy(logoCode.gameObject);
         
        }
      
        tempTimer++;
        if (tempTimer>10)
        {
            playerScore = playerScore + 10;
            tempTimer = 0;
        }
     
      
        if (FleetHull>100)
        {
            if (FleetHull!=1001)
            {
                FleetHull = 100; //cant go above 100
            }
            
          
        }
        if (FleetHull<0&&whereGameOver==0)
        {
            AudioSource.PlayClipAtPoint(crashedEngine, new Vector3(rb.position.x, rb.position.y, rb.position.z));
            whereGameOver = 1;
            uiDialog.text = "To return to space, press 'fire2'(lALT, rMouse, B[controller])";
            isGameover = 1;
        }
        if (isGameover==0)
        {
            whereGameOver = 0;
            ScoreDisplay.text = "Score: " + playerScore;
            FleetDisplay.text = "Fleet Integrity: " + FleetHull + "/100";
            statisticallyFun.text = "Debris Hit:Debris Through-" + totItemsHit + ":" + (itemsLetThrough);
        }
      

    }
}
