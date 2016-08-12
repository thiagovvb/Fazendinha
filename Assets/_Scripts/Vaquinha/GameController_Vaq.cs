using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController_Vaq : MonoBehaviour {

	private int state;
	private int currentSeq;
	private float lightsStartTime;
	private List<int> ordem = new List<int>();
	public GameObject[] luzes;

	// Use this for initialization
	void Start () {
		state = 0;
		ordem = new List<int>();
	}

	// Update is called once per frame
	void Update () {
	
		if(state == 0){
			
			int newValue = Random.Range(1,5);
			Debug.Log("Valor gerado = " + newValue);
			ordem.Add(newValue);
			state = 1;
			currentSeq = -1;

		}else if(state == 1){
			
			if(++currentSeq >= ordem.Count){
				state = 0;
			}else{
				lightsStartTime = Time.time;
				luzes[ordem[currentSeq]].GetComponent<Light>().enabled = true;
				state = 2;
			}

		}else if(state == 2){
		
			if(Time.time - lightsStartTime > 3){
				luzes[ordem[currentSeq]].GetComponent<Light>().enabled = false;
				state = 1;
			}
		
		}else if(state == 3){
			Debug.Log("Acabou");
		}

	}
}
