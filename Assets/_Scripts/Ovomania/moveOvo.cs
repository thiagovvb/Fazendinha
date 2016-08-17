using UnityEngine;
using System.Collections;

public class moveOvo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.z < -0.3) {
			Debug.Log("nhe");
			transform.RotateAround(transform.position,transform.up, -Time.deltaTime * 90);
			transform.Translate(new Vector3(0,0,Time.deltaTime), Space.World);
		}

	}
}
