using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController_Vaq : MonoBehaviour {

	private int state;
	private int currentSeq;
	private int hitSeq;
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

			int newValue = Random.Range(0,4);
			Debug.Log("Valor gerado = " + (newValue + 1));
			ordem.Add(newValue);
			state = 1;
			currentSeq = 0;

		}else if(state == 1){
			
			if(currentSeq >= ordem.Count){
				hitSeq = 0;
				state = 4;
			}else{
				lightsStartTime = Time.time;
				luzes[ordem[currentSeq]].GetComponent<Light>().enabled = true;
				state = 2;
			}

		}else if(state == 2){

			if(Time.time - lightsStartTime > 1){
				luzes[ordem[currentSeq++]].GetComponent<Light>().enabled = false;
				state = 3;
			}
		
		}else if(state == 3){
			if(Time.time - lightsStartTime > 1.5f){
				state = 1;
			}
		}else if(state == 4){

			if(hitSeq >= ordem.Count) state = 0;

			if(Input.GetKeyDown("1")){
				if(ordem[hitSeq] == 0){
					state = 5;
					lightsStartTime = Time.time;
					luzes[ordem[hitSeq]].GetComponent<Light>().enabled = true;
				}
				else state = 6;
			}
			if(Input.GetKeyDown("2")){
				if(ordem[hitSeq] == 1){
					state = 5;
					lightsStartTime = Time.time;
					luzes[ordem[hitSeq]].GetComponent<Light>().enabled = true;
				}
				else state = 6;
			}
			if(Input.GetKeyDown("3")){
				if(ordem[hitSeq] == 2){
					state = 5;
					lightsStartTime = Time.time;
					luzes[ordem[hitSeq]].GetComponent<Light>().enabled = true;
				}
				else state = 6;
			}
			if(Input.GetKeyDown("4")){
				if(ordem[hitSeq] == 3){
					state = 5;
					lightsStartTime = Time.time;
					luzes[ordem[hitSeq]].GetComponent<Light>().enabled = true;
				}
				else state = 6;
			}
				

		}else if(state == 5){
			if(Time.time - lightsStartTime > 0.75 && luzes[ordem[hitSeq]].GetComponent<Light>().enabled){
				luzes[ordem[hitSeq]].GetComponent<Light>().enabled = false;
			}

			if(Time.time - lightsStartTime > 1.25){
				hitSeq++;
				state = 4;
			}

		}else if(state == 6){
			Debug.Log("perdeu!");
		}

	}
}
