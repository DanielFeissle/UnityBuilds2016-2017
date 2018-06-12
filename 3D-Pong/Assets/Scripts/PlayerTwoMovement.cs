using UnityEngine;
using System.Collections;

  
public class PlayerTwoMovement : MonoBehaviour {
  
    private Rigidbody rb;
    public float speed;

    float enemyMove;
    float curHeight;

     Vector3 MovementPos=new Vector3(-72,21,52);
    // GameManager gameManager = GameObject.Find("GameManager").GetComponent<SphereCollider>();
 //   public GameObject gamemanager = GameObject.Find("GameManager").GetComponent();
   //  public GameObject gameManager;
	// Use this for initialization
    
	void Start () {
     //   var health : Health;
        rb = GetComponent<Rigidbody>();
        rb.position = MovementPos; //middle value ie 21 gets changed to match the ball
        curHeight = enemyMove;

    
        // Get current health
       // enemyHealth.CurrentHealth;

	}

	 

	// Update is called once per frame
	void Update () {
        //HOW TO FIND INFORMATION FROM OTHER SCRIPTS
        GameObject enemy = GameObject.Find("Sphere");
        BallBounceNstuff enemyHealth = enemy.GetComponent<BallBounceNstuff>();

        enemyMove = enemyHealth.BallHeight;
      
    //    Debug.Log(enemyMove.ToString() + "is current");
       // rb.position = MovementPos; //cheater cheater pumkin eater
        if (rb.position.y < -15)
        {
            //stop moving bottom
            Vector3 movement = new Vector3(0.0f, 2.0f, 0.0f);
            rb.AddForce(movement * speed);

        }
        else if (rb.position.y > 28) //stop moving top
        {
            Vector3 movement = new Vector3(0.0f, -2.0f, 0.0f);
            rb.AddForce(movement * speed);
        }
        else
        {
            if (enemyMove > transform.position.y)
            {
                MovementPos = new Vector3(0.0f, 5.0f, 0.0f);
                //  rb.AddForce(-MovementPos * speed);
            }
            else
            {
                MovementPos = new Vector3(0.0f, -5.0f, 0.0f);

            }
            rb.AddForce(MovementPos * speed);
            MovementPos = new Vector3(0.0f, 0.0f, 0.0f);
        }
      
	}
    void FixedUpdate()
    {
       
    }
}
