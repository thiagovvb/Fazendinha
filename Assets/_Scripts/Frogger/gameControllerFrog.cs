using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameControllerFrog : MonoBehaviour {

	private Vector3[] positions;
	private Vector3[] goalPositions;
	public Transform[] frutas;
	public Transform pedra1;
	private float startTime;
	public static int remainingFruits;
	public static bool carryingFruit;
	public Transform player;
	private int lastGesture;
	public Text placar;
	public Canvas helpCanvas;
	private int state;

	private int tempoRespawn;

	// Use this for initialization
	void Start () {
	
		positions = new Vector3[4];
		goalPositions = new Vector3[6];
		lastGesture = 0;
		globalVariables.qtdFrutas_Local = 0;
		state = 0;

		startTime = Time.time;

		positions[0] = new Vector3(129.61f, 1.383f, 403.4f);
		positions[1] = new Vector3(129.61f, 1.383f, 406.5f);
		positions[2] = new Vector3(129.61f, 1.383f, 411.5f);
		positions[3] = new Vector3(129.61f, 1.383f, 415.8f);

		goalPositions[0] = new Vector3(160f,1.63f,419.66f);
		goalPositions[1] = new Vector3(170f,1.19f,419.26f);
		goalPositions[2] = new Vector3(180f,1.19f,419.26f);
		goalPositions[3] = new Vector3(150f,1.19f,419.26f);
		goalPositions[4] = new Vector3(140f,1.19f,419.26f);
		goalPositions[5] = new Vector3(130f,1.19f,419.26f);

		remainingFruits = 6;
		carryingFruit = false;

		int fPos;

		for(int i = 0; i < 6; i++){
			fPos = Random.Range(0,3);
			Instantiate(frutas[fPos],goalPositions[i], Quaternion.identity);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
		int num;
		int pos;

		if(state == 1){

			movementManager();

			placar.text = ": " + globalVariables.qtdFrutas_Local;

			if(Time.time - startTime > 1){

				num = Random.Range(0,50);

				if(num >= 0 && num <= 30){
					pos = Random.Range(0,4);
					Instantiate(pedra1,positions[pos], Quaternion.identity);
				}
						
				startTime = Time.time;
			}

			if(remainingFruits == 0){
				for(int i = 0; i < 6; i++){
					Instantiate(frutas[Random.Range(0,3)],goalPositions[i], Quaternion.identity);
				}
			}

		}

	}
		
	void movementManager(){

		int cGesture = globalVariables.currentGesture;

		if(lastGesture != cGesture){

			if(cGesture == 1){
				if(player.transform.position.z <= 416.0f) player.transform.Translate(0f,0f,4.1f);
			}else if(cGesture == 2){
				if(player.transform.position.z >= 403.4f) player.transform.Translate(0f,0f,-4.1f);
			}else if(cGesture == 3){
				player.transform.Translate(-10f,0f,0f);
			}else if(cGesture == 4){
				player.transform.Translate(10f,0f,0f);
			}
			lastGesture = cGesture;

		}

	}

	public void voltarBtn(){
		Debug.Log("NHEGURE");
		SceneManager.LoadScene("MainMenu");
	}

	public void continuarBtn(){
		helpCanvas.enabled = false;
		state = 1;
	}
		

}
