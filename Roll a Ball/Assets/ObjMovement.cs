using UnityEngine;
using System.Collections;

public class ObjMovement : MonoBehaviour {
    private Rigidbody rb;
     public float speed;
     private float Hor1 = 80;
     private float Ver1 = 80;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Hor1 = 80;
      Ver1 = 80;
    }
    
    // Update is called once per frame
    void Update () {
       
    }

    void FixedUpdate()
    {
        
       
    }
    void LateUpdate()
    {
        Vector3 movement = new Vector3(Hor1, 0.0f, Ver1);
        rb.AddForce(movement * speed);
        Hor1 = 0;
        Ver1 = 0;
    }
    public AudioClip ding;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionEast"))
        {
            AudioSource.PlayClipAtPoint(ding, new Vector3(5, 1, 2));
            Hor1 = -80*2;
           
        }
        if (other.gameObject.CompareTag("CollisionWest"))
        {
            AudioSource.PlayClipAtPoint(ding, new Vector3(5, 1, 2));
            Hor1 = 80*2;
        }
        if (other.gameObject.CompareTag("CollisionSouth"))
        {
            AudioSource.PlayClipAtPoint(ding, new Vector3(5, 1, 2));
            Ver1 = 80*2;
        }
        if (other.gameObject.CompareTag("CollisionNorth"))
        {
            AudioSource.PlayClipAtPoint(ding, new Vector3(5, 1, 2));
            Ver1 = -80*2;
        }

    }
}
