using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public bool collision;

	// Use this for initialization
	void Start () {
		collision = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getNhe(){
	}

	void OnTriggerEnter(Collider other){

		collision = true;
	
	}

}
