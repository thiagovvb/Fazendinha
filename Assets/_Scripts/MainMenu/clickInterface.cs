using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class clickInterface : MonoBehaviour {

	public GameObject[] setas;
	public Camera camera;
	public Camera placaCamera;
	public int state = 0;
	public static bool started = false;
	public Text placarMilho;
	public Text placarOvos;
	public Text placarFrutas;
	public Canvas mainMenu;
	public Canvas gameplayMenu;
	public Canvas objetivosMenu;
    public Canvas perfilMenu;
    public Canvas criarPerfilMenu;
	public Canvas creditosCanvas;
	public Text tx;
	public TextMesh[] opArray;


	// Use this for initialization
	void Start () {

		setas[0].SetActive(false);
		setas[1].SetActive(false);
		setas[2].SetActive(false);

		if(!started){
			gameplayMenu.enabled = false;
			objetivosMenu.enabled = false;
            perfilMenu.enabled = false;
            criarPerfilMenu.enabled = false;
			creditosCanvas.enabled = false;
			//camera.enabled = false;
            started = true;
		}else{
			mainMenu.enabled = false;
			objetivosMenu.enabled = false;
            perfilMenu.enabled = false;
            criarPerfilMenu.enabled = false;
			creditosCanvas.enabled = false;
            state = 2;
		}

	}

	public void BtnManager(string input){

		if(input.Equals("Start")){

			if(string.Equals(globalVariables.activeProfile,"")){
				camera.enabled = true;
				placaCamera.enabled = false;

				mainMenu.enabled = false;
				objetivosMenu.enabled = true;

				placarMilho.text = (globalVariables.qtdMilho + " / " + globalVariables.milhosQuota);
				placarFrutas.text = (globalVariables.qtdFrutas + " / " + globalVariables.frutasQuota);
				placarOvos.text = (globalVariables.qtdOvos + " / " + globalVariables.ovosQuota);

				state = 1;
			}else tx.color = Color.red;
		}

		if(input.Equals("Exit")){
			Application.Quit();
		}

		if(input.Equals("Continue")){
			objetivosMenu.enabled = false;
			gameplayMenu.enabled = true;
			state = 2;
		}

        if (input.Equals("Perfis"))
        {
			camera.enabled = true;
			placaCamera.enabled = false;
            mainMenu.enabled = false;
            perfilMenu.enabled = true;
        }

        if (input.Equals("CriarPerfil"))
        {
            perfilMenu.enabled = false;
            criarPerfilMenu.enabled = true;
        }

        if (input.Equals("CriouPerfil"))
        {
            perfilMenu.enabled = true;
            criarPerfilMenu.enabled = false;
            perfilManager pm = (perfilManager) perfilMenu.GetComponent<perfilManager>();
            pm.UpdateList();
        }

		if (input.Equals("SelecionouPerfil"))
		{
			Debug.Log("Nhe");
			perfilMenu.enabled = false;
			mainMenu.enabled = true;
			placaCamera.enabled = true;
			camera.enabled = false;
		}

		if (input.Equals("Creditos"))
		{
			camera.enabled = true;
			placaCamera.enabled = false;
			mainMenu.enabled = false;
			creditosCanvas.enabled = true;
		}

		if (input.Equals("voltarCreditos"))
		{
			creditosCanvas.enabled = false;
			mainMenu.enabled = true;
			placaCamera.enabled = true;
			camera.enabled = false;
		}

		if(input.Equals("VoltarMenuP")){

			camera.enabled = false;
			placaCamera.enabled = true;
			mainMenu.enabled = true;
			gameplayMenu.enabled = false;
			state = 0;
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

		if(state == 0){
		
			RaycastHit hit = new RaycastHit();
			Ray ray = placaCamera.ScreenPointToRay (Input.mousePosition);

			if(SceneManager.GetActiveScene().name.Equals("MainMenu")){

				if (Physics.Raycast (ray, out hit, 100.0f))
				{  

					//Debug.Log(hit.collider.gameObject.name);

					if(hit.collider.gameObject.name.Equals("Op01")){
						opArray[0].color = Color.red;
						if(Input.GetMouseButtonDown(0)){
							BtnManager("Start");
						}
					}else opArray[0].color = Color.yellow;

					if(hit.collider.gameObject.name.Equals("Op02")){
						opArray[1].color = Color.red;
						if(Input.GetMouseButtonDown(0)){
							//BtnManager("Start"); Não implementado ainda!
							BtnManager("Perfis");
						}
					}else opArray[1].color = Color.yellow;

					if(hit.collider.gameObject.name.Equals("Op03")){
						opArray[2].color = Color.red;
						if(Input.GetMouseButtonDown(0)){
							BtnManager("Creditos");
						}
					}else opArray[2].color = Color.yellow;

					if(hit.collider.gameObject.name.Equals("Op04")){
						opArray[3].color = Color.red;
						if(Input.GetMouseButtonDown(0)){
							BtnManager("Exit");
						}
					}else opArray[3].color = Color.yellow;
						

				}

			}

		}

		if(state == 2){

			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

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
