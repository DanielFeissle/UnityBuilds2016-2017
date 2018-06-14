using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
public class PlayerController : MonoBehaviour
{
    private int count;
    public float speed;
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    public Text ScoreText;
    private int score = 0; //the time

    void Start()
    {
        rb=GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        ScoreText.text = "";
        score = 0;
    }
    void Update() //updates every frame
    {
        if (count<12)
        {
            score = score + 1;
            ScoreText.text = "Score: "+score.ToString();
          //  countText.text = "Count: " + count.ToString();
        }
       
    }
    
    void FixedUpdate() //pysics calcualation
    {
        float moveHorizantal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizantal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);

    }
    public AudioClip clip;
    public AudioClip edge;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {

            AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }


        if (other.gameObject.CompareTag("CollisionEast"))
        {
            AudioSource.PlayClipAtPoint(edge, new Vector3(5, 1, 2));


        }
        if (other.gameObject.CompareTag("CollisionWest"))
        {
            AudioSource.PlayClipAtPoint(edge, new Vector3(5, 1, 2));

        }
        if (other.gameObject.CompareTag("CollisionSouth"))
        {
            AudioSource.PlayClipAtPoint(edge, new Vector3(5, 1, 2));

        }
        if (other.gameObject.CompareTag("CollisionNorth"))
        {
            AudioSource.PlayClipAtPoint(edge, new Vector3(5, 1, 2));

        }
       
    }

 
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            winText.text = "YOU WIN!";
            
          
            
        }
    }

   

   

}
