using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterMonitor : MonoBehaviour {

	public Text placar;

	// Use this for initialization
	void Start () {
	
		placar.text = "Chegue ao outro lado e traga uma fruta.";

	}
	
	// Update is called once per frame
	void Update () {

		if(gameControllerFrog.carryingFruit){
			if(transform.position.z < 402){
				gameControllerFrog.carryingFruit = false;
				//Debug.Log("Cheguei do outro lado!");
				globalVariables.qtdFrutas++;
				globalVariables.qtdFrutas_Local++;
				placar.text = "Voce coletou a fruta! Continue assim!";
				globalVariables.stoneSpeed += 0.050f;
			}
		}

	}
		
	void OnTriggerEnter(Collider other){

		if(other.tag == "Fruta" && (!gameControllerFrog.carryingFruit)){
			gameControllerFrog.carryingFruit = true;
			gameControllerFrog.remainingFruits--;
			Destroy(other.gameObject);
			placar.text = "Voce pegou uma fruta! Agora volte para o outro lado.";
		}


		if(other.tag == "Pedra"){
			gameObject.transform.position = new Vector3(160.0f, 1.63f, 399.51f);
			gameControllerFrog.carryingFruit = false;
			placar.text = "Ah que pena! Voce colidiu com uma pedra!";
			globalVariables.stoneSpeed -= 0.050f;
		}
	}

}
