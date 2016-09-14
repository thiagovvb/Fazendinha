using UnityEngine;
using System.Collections;

public class characterMonitor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(gameControllerFrog.carryingFruit){
			if(transform.position.z < 402){
				gameControllerFrog.carryingFruit = false;
				Debug.Log("Cheguei do outro lado!");
			}
		}


	}
		
	void OnTriggerEnter(Collider other){

		if(other.tag == "Fruta" && (!gameControllerFrog.carryingFruit)){
			gameControllerFrog.carryingFruit = true;
			gameControllerFrog.remainingFruits--;
			Destroy(other.gameObject);
		}


		if(other.tag == "Pedra") Debug.Log("Colidiu com pedra");

	}

}
