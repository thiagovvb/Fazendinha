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
		if(GameObject.Find("GameController").GetComponent<gameControllerFrog>().state != 2){
			transform.RotateAround(transform.position,new Vector3(0,0,1), -Time.deltaTime * 60);
			transform.Translate(new Vector3(globalVariables.stoneSpeed * 4 *Time.deltaTime,0,0), Space.World);
			Debug.Log("Stone speed = " + globalVariables.stoneSpeed);
		}
		//}else if(!r.useGravity){
		//	r.useGravity = true;
		//	this.enabled = false;
		//}

	}
}
