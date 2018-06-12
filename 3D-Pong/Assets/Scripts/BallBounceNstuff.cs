using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BallBounceNstuff : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

    public bool finder=false;
	private float Hor1 = 80;
	private float Ver1 = 80;
	private float Hei1 = 80;

    int score1=0;
    int score2=0;
    public float BallHeight;
	Vector3 OgPosition = new Vector3(0,0,50);

    public Text countText1;
    public Text countText2;
    public Text winnerDelare;

	private int lastTouched = 2; //one is player 1, 2 is player 2

    public AudioClip BallMove;
    public AudioClip Score1;
    public AudioClip fart;

    public AudioClip victory;
    public AudioClip loss;
  
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        winnerDelare.text = "";
		Hor1 = 80;
		Ver1 = 80;
		Hei1 = 80;
		Vector3 movement = new Vector3(Hor1, 0.0f, Ver1);
		rb.AddForce(movement * speed);
        UICountStuff();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(Hor1, Hei1, Ver1);
		rb.AddForce(movement * speed);
		Hor1 = 0;
		Ver1 = 0;
		Hei1 = 0;

		if (lastTouched == 1)
		{
			Hor1 = -2 * 2;
		}
		else if (lastTouched == 2)
		{
			Hor1 = 2 * 2;
		}

        BallHeight = transform.position.y;
      
	}
	void FixedUpdate() //physics calculations
	{
	

	   
	  
	}
	void LateUpdate() //Late update, updates after update and gurentees position
	{
	   
		/*
		float moveHorizantal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


		Vector3 movement = new Vector3(Hor1, moveVertical, 0.0f);
		rb.AddForce(movement * speed);
		 * */

       
		
	}

    private void UICountStuff()
    {
        winnerDelare.text = "";
             if (speed==5) //new round
        {
            speed = 25;
            score2 = 0;
            score1 = 0;
        }
        else if (score1>9)
        {
            AudioSource.PlayClipAtPoint(victory, new Vector3(rb.position.x, rb.position.y, rb.position.z));
            winnerDelare.text = "You are the winner (good..)";
            speed = 5;
        }
        else if (score2>9)
        {
            AudioSource.PlayClipAtPoint(loss, new Vector3(rb.position.x, rb.position.y, rb.position.z));
            winnerDelare.text = "A winner is not you (ai #1 :))";
            speed = 5;
        }
    
        countText1.text = "Player One: "+score1;
        countText2.text = "Player Two: "+score2;
    }
	
	  void OnTriggerEnter(Collider other)
	{
        AudioSource.PlayClipAtPoint(fart, new Vector3(rb.position.x, rb.position.y, rb.position.z));
		  //check for collision for goal points below
			if (other.gameObject.CompareTag("GoalPoint"))
			{
                AudioSource.PlayClipAtPoint(Score1, new Vector3(rb.position.x, rb.position.y, rb.position.z));
				lastTouched = 1;
				Hor1 = -80*2;
				rb.position = OgPosition;
                score2 = score2 + 1;
                UICountStuff();
			}
			else if (other.gameObject.CompareTag("GoalPoint2"))
			{
                AudioSource.PlayClipAtPoint(Score1, new Vector3(rb.position.x, rb.position.y, rb.position.z));
				lastTouched = 2;
				Hor1 =80*2;
				rb.position = OgPosition;
                score1 = score1 + 1;
                UICountStuff();
			}
		  //end check for goalpoints above
			int blarg = Random.Range(0, 100);
		  //now we do the paddles, which is the same as the goal points
			if (other.gameObject.CompareTag("PaddlePlayer1"))
			{
			//	speed = speed + 1;
				Hor1 = -80 * 2;
                AudioSource.PlayClipAtPoint(BallMove, new Vector3(rb.position.x, rb.position.y, rb.position.z));
				if (blarg<44) //height up
				{
					Hei1 = 80 * 2;
				}
				else if (blarg<77) //height down
				{
					Hei1 = -80 * 2;
				}
				else //nothing
				{

				}
				
			  
				lastTouched = 1;
			}
			else if (other.gameObject.CompareTag("PaddlePlayer2"))
			{
                AudioSource.PlayClipAtPoint(BallMove, new Vector3(rb.position.x, rb.position.y, rb.position.z));
				//speed = speed + 1;
				Hor1 = 80 * 2;
				if (blarg < 44) //height up
				{
					Hei1 = 80 * 2;
				}
				else if (blarg < 77) //height down
				{
					Hei1 = -80 * 2;
				}
				lastTouched = 2;
			}
		  //end of paddles

		  //Front plane first then backplane which modifies the vertical
			if (other.gameObject.CompareTag("FrontPlane1"))
			{
				Hor1 = 0;
				Ver1 = 80 * 2;
			}
			else if (other.gameObject.CompareTag("BackPlane1"))
			{
				Hor1 = 0;
				Ver1 = -80 * 2;
			}
		  //end of that front n back planes

		  //Now bottom and top planes
			if (other.gameObject.CompareTag("TopPlane1"))
			{

				Hei1 = -80 * 2;
			}
			else if (other.gameObject.CompareTag("BottomPlane1"))
			{

				Hei1 = 80 * 2;
			}
			if (other.gameObject.CompareTag("NoEscape"))
			{
				rb.position = OgPosition;
			}
		
	}
}
