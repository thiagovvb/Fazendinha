using UnityEngine;
using System.Collections;

public class movePedra : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Rigidbody r = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;

		//if (transform.position.z < 0.3) {

		transform.RotateAround(transform.position,new Vector3(0,0,1), -Time.deltaTime * 90);
		transform.Translate(new Vector3(4*Time.deltaTime,0,0), Space.World);
		//}else if(!r.useGravity){
		//	r.useGravity = true;
		//	this.enabled = false;
		//}

	}
}
