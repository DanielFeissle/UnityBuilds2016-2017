using UnityEngine;
using System.Collections;

public class KapowExplosion : MonoBehaviour {
    private Rigidbody rb;
    public float powX;
    public float powY;
    public float powZ;
    int timer = -1;
	// Use this for initialization
	void Start () {
	
           rb = GetComponent<Rigidbody>();

           powX = transform.position.x;
           powY = transform.position.z;
           powZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (powY!=-500)
        {
            timer++;
        }
        if (timer>25)
        {
            timer = -1;
            powY = -500;
        }
        rb.position = new Vector3(powX, powY, powZ);
	}

    void LateUpdate()
    {
      
    }
}
