using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
		public GameObject player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate()
	{//Late update, updates after update and gurentees position
		transform.position = player.transform.position + offset;
	}
}

