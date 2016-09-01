using UnityEngine;
using System.Collections;

public class gameControllerFrog : MonoBehaviour {

	private Vector3[] positions;
	private Vector3[] goalPositions;
	public Transform[] frutas;
	public Transform pedra1;
	private float startTime;
	public static int remainingFruits;
	public static bool carryingFruit;

	// Use this for initialization
	void Start () {
	
		positions = new Vector3[4];
		goalPositions = new Vector3[6];

		startTime = Time.time;

		positions[0] = new Vector3(129.61f, 1.383f, 403.4f);
		positions[1] = new Vector3(129.61f, 1.383f, 406.5f);
		positions[2] = new Vector3(129.61f, 1.383f, 411.5f);
		positions[3] = new Vector3(129.61f, 1.383f, 415.8f);

		goalPositions[0] = new Vector3(134.2f,1.19f,419.26f);
		goalPositions[1] = new Vector3(142.3f,1.19f,419.26f);
		goalPositions[2] = new Vector3(152.1f,1.19f,419.26f);
		goalPositions[3] = new Vector3(162.1f,1.19f,419.26f);
		goalPositions[4] = new Vector3(172.1f,1.19f,419.26f);
		goalPositions[5] = new Vector3(182.7f,1.19f,419.26f);

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

		if(Time.time - startTime > 1){

			num = Random.Range(0,50);

			if(num >= 0 && num <= 30){
				pos = Random.Range(0,4);
				Instantiate(pedra1,positions[pos], Quaternion.identity);
			}
					
			startTime = Time.time;
		}

	}

	void prizeSetup(){

	}

}
