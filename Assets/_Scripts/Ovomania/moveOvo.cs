using UnityEngine;
using System.Collections;

public class moveOvo : MonoBehaviour {

	// Use this for initialization

	public int trilha;
	public gameController gc;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Rigidbody r = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;

		if(GameObject.Find("GameController").GetComponent<gameController>().state != 2){
			//if (transform.position.z < 0.35) {
				transform.RotateAround(transform.position,transform.up, -Time.deltaTime * 60 * globalVariables.eggSpeed);
				transform.Translate(new Vector3(0,0,Time.deltaTime), Space.World);
			//}else if(!r.useGravity){
			if(transform.position.z > 0.4 && !r.useGravity){
				Debug.Log("Estou na trilha " + trilha);
				r.useGravity = true;
				this.enabled = false;
			}
		}
	}
}
