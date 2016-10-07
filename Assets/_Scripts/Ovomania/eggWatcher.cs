﻿using UnityEngine;
using System.Collections;


public class eggWatcher : MonoBehaviour {

	private int qtdOvosBrancos;
	private int qtdOvosPodres;

	// Use this for initialization
	void Start () {

		qtdOvosPodres = 0;
		qtdOvosBrancos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z > 3){
			if(tag.Equals("OvoBranco")){
				globalVariables.qtdOvosBrancosPerdidos_Local++;
				globalVariables.eggSpeed -= 0.015f;
			}
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Tampa"){
			if(tag.Equals("OvoBranco")){
				globalVariables.qtdOvos++;
				globalVariables.qtdOvosBrancos_Local++;
				globalVariables.eggSpeed += 0.030f;
			}
			else if(tag.Equals("OvoPodre")){
				globalVariables.qtdOvosPodres_Local++;
				globalVariables.eggSpeed -= 0.015f;
			}
		}
	}

}
