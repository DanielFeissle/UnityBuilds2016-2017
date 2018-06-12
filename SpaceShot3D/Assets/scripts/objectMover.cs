using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class objectMover : MonoBehaviour {
	private Rigidbody rb;
	public int hp;
	int ogHp;

   
   private int dificultyIncreaser = 0;
   
  
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		ogHp = hp;
	   
	}
	
	// Update is called once per frame
	void Update () {

        GameObject PlayerScore = GameObject.Find("InvPlayer");
        backendScores ScoreCount = PlayerScore.GetComponent<backendScores>();

        if ((ScoreCount.isGameover == 1 && rb.useGravity == true)||(ScoreCount.isGameover==2))
        {
            rb.useGravity = false;
          //  rb.AddForce(new Vector3(0, -2f, 0));
            rb.velocity = new Vector3(0,0,0); //stop moving completly
            rb.position = new Vector3(rb.position.x, 190, rb.position.z);
        }
        else if (ScoreCount.isGameover == 0 && rb.useGravity == false)
        {
            rb.useGravity = true;
        }
        

        /* below old idea that needs work on if used in future projects..
        scoreTabber = ScoreCount.playerScore-subScoreTab; //keep the ratio mantained
        if ((scoreTabber>200)&&(nutSpawn==0)) //spawn a challenge
        {
            subScoreTab = ScoreCount.playerScore;
            nutSpawn=1;//the nut has been spawned
            GameObject sirNutiful = GameObject.Find("SirNut");
           sirNutiful.gameObject.transform.position = new Vector3(0, 130, 0);
            scoreTabber = 0;
         //  AudioSource.PlayClipAtPoint(nut, new Vector3(rb.position.x, rb.position.y, rb.position.z));
            dificultyIncreaser++;
            
        }
        else if (scoreTabber>100&&nutSpawn==1)
        {
            subScoreTab = ScoreCount.playerScore;
            scoreTabber = 0;
            GameObject sirNutiful = GameObject.Find("SirNut");
          //  sirNutiful.gameObject.transform.position = new Vector3(0, 777, 0);
            nutSpawn = 0;
        }
         * */
          if (ScoreCount.FleetHull <=0) //reset because player died...
          {
            //  scoreTabber = 0;
            //  dificultyIncreaser = 0;
          }
	}
	int count = 0;

    public AudioClip hit;

    public AudioClip asteroidHit;
    public AudioClip asteroidDef;

    public AudioClip nut;

	void OnTriggerEnter(Collider other)
	{

        //for backend scores and calculating of perchents
        GameObject PlayerScore = GameObject.Find("InvPlayer");
        backendScores ScoreCount = PlayerScore.GetComponent<backendScores>();

        if (ScoreCount.isGameover==1&&rb.useGravity==true)
        {
            rb.useGravity = false;
            rb.AddForce(new Vector3(0,-2, 0));
        }
        else if (ScoreCount.isGameover==0&&rb.useGravity==false)
        {
            rb.useGravity = true;
        }
	  if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ff");
            ScoreCount.FleetHull = ScoreCount.FleetHull - 9999;
        }
		if (other.gameObject.CompareTag("BottomCollision"))
		{
            int tempHit = Random.Range(0, ScoreCount.FleetHull); //as more objects are let through, the smaller the more likely the hits will continue
            if (tempHit < 50 + hp * 5)
            {
                if (ScoreCount.FleetHull != 1001)
                {
                    ScoreCount.FleetHull = ScoreCount.FleetHull - Random.Range(0, hp);
                    AudioSource.PlayClipAtPoint(hit, new Vector3(rb.position.x, rb.position.y, rb.position.z));
                }


            }
			count++;
			float arg = Random.Range(-49, 49); //player space is really 100, though this is for extra space to help avoid clipping
			float darg = Random.Range(-49, 49);
			Debug.Log(count);
			rb.position = new Vector3(arg, 175.7f, darg);
			rb.AddForce(0, 1000, 0);
            hp = ogHp;
            hp = Random.Range(ogHp, ogHp + 5);
         
            rb.mass = Random.Range(6,12)+(dificultyIncreaser*2);
          
            ScoreCount.itemsLetThrough++; //increase the items let through count
           
           
		   
		 //   175.7

           
		}
        
			if (other.gameObject.CompareTag("PlayerBeam"))
			{
             
                //fancy explosion mabye?!

                //HOW TO FIND INFORMATION FROM OTHER SCRIPTS
                GameObject PlayerLocation = GameObject.Find("Kapow_Explosion");
                KapowExplosion ExplosionWhere = PlayerLocation.GetComponent<KapowExplosion>();

               
               
                ExplosionWhere.powX = rb.position.x;
                ExplosionWhere.powY = rb.position.y;
                ExplosionWhere.powZ = rb.position.z;


                AudioSource.PlayClipAtPoint(asteroidHit, new Vector3(rb.position.x, rb.position.y, rb.position.z));
               

				hp--;
				if (hp<1)
				{
                    AudioSource.PlayClipAtPoint(asteroidDef, new Vector3(rb.position.x, rb.position.y, rb.position.z));
                    int tempMass = (int)rb.mass; //how to cast from float to int <---- yay :)
                    ScoreCount.totItemsHit++;//increase the items hit to dipslay
					hp = ogHp;
                    hp = Random.Range(ogHp, ogHp + 5);
                    ScoreCount.playerScore = ScoreCount.playerScore + (ogHp * 7)*tempMass;
					float arg = Random.Range(-49, 49); //player space is really 100, though this is for extra space to help avoid clipping
					float darg = Random.Range(-49, 49);
					rb.position = new Vector3(arg, 175.7f, darg);
					rb.AddForce(0, 1000, 0);
                 
                    
                    ScoreCount.FleetHull = ScoreCount.FleetHull + Random.Range(ogHp, ogHp+10*(tempMass)); //fleet gets health back for destroyed asteroids, the faster the asteroid the more health that is returned
                  //  rb.mass = Random.Range(1,5);
                    rb.mass = Random.Range(6,12) + (dificultyIncreaser * 2);
                
				}
                else
                {
                    ScoreCount.playerScore = ScoreCount.playerScore + hp * 7;
                }
			   
			}

	}
}
