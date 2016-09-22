﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class clickInterface : MonoBehaviour {

	public GameObject[] setas;
	public Camera camera;
	public int state = 0;
	public static bool started = false;
	public Text placarMilho;
	public Text placarOvos;
	public Text placarFrutas;
	public Canvas mainMenu;
	public Canvas gameplayMenu;

	// Use this for initialization
	void Start () {

		setas[0].SetActive(false);
		setas[1].SetActive(false);
		setas[2].SetActive(false);

		placarMilho.text = (globalVariables.qtdMilho + " / " + globalVariables.milhosQuota);
		placarFrutas.text = (globalVariables.qtdFrutas + " / " + globalVariables.frutasQuota);
		placarOvos.text = (globalVariables.qtdOvos + " / " + globalVariables.ovosQuota);

		if(!started){
			gameplayMenu.enabled = false;
			started = true;
		}else{
			mainMenu.enabled = false;
			state = 1;
		}

	}

	public void BtnManager(string input){

		if(input.Equals("Start")){
			mainMenu.enabled = false;
			gameplayMenu.enabled = true;
			state = 1;
		}

		if(input.Equals("Exit")){
			Application.Quit();
		}

	}

	/*void OnGUI(){

		int boxWidth = 200;
		int boxHeight = 300;

		/if(state == 0){

			GUI.Box(new Rect(Screen.width/2 - boxWidth/2, Screen.height/2 - boxHeight/2, boxWidth, boxHeight), "Menu");

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 75, 100, 25), "Iniciar")){
			
				state = 1;
			
			}

			GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 25), "Opções");

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - -25, 100, 25), "Sair")){

				Application.Quit();

			}

		}

		if(state == 1){
			
			GUI.Box(new Rect(Screen.width/2 - 225, Screen.height - 150, 425, 150), "Cota Diária");

		}

	}*/

	// Update is called once per frame
	void Update () {

		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(state == 1){
			if(SceneManager.GetActiveScene().name.Equals("MainMenu")){
				if (Physics.Raycast (ray, out hit, 100.0f))
				{  

					if(hit.collider.gameObject.name.Equals("celeironovo")){
						setas[0].SetActive(true);
						if(Input.GetMouseButtonDown(0)){
							SceneManager.LoadScene("JogoOvos");
						}
					}else setas[0].SetActive(false);

					if(hit.collider.gameObject.name.Equals("barn_norm")){
						setas[1].SetActive(true);
						if(Input.GetMouseButtonDown(0)){
							SceneManager.LoadScene("JogoMilho");
						}
					}else setas[1].SetActive(false);

					if(hit.collider.gameObject.tag.Equals("Horta")){
						setas[2].SetActive(true);
						if(Input.GetMouseButtonDown(0)){
							SceneManager.LoadScene("JogoFrogger");
						}
					}else setas[2].SetActive(false);

				}
			}
		}
			
	}
}
