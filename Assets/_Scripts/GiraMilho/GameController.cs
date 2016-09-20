using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {


	private int state;
	private float speed;
	public GameObject milho;
	public GameObject molde;

	private int qtdMilho;
	private int qtdMilhosPerdidos;

	void Start () {

		state = 4; //Show GUI
		speed = 2.0f;
		qtdMilho = 0;
		qtdMilhosPerdidos = 0;

	}

	void OnGUI(){

		int boxWidth = 400;
		int boxHeight = 200;

		if(state == 4){
			GUI.Box(new Rect(Screen.width/2 - boxWidth/2, Screen.height/2 - boxHeight/2, boxWidth, boxHeight), "Dicas");

			GUI.Label(new Rect(Screen.width/2 - (boxWidth/2 - 20), Screen.height/2 - (boxHeight/2 - 20), 360, 100), "" +
				"Neste jogo você deve passar o milho pelo molde, a cada milho atravessado com sucesso, sua pontuação aumentará e você coletará mais milhos! Quando estiver pronto para continuar pressione o botão continuar utilizando o mouse.");

			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 25, 75, 25), "Continuar")){
			
				state = 0;

			}

			if(GUI.Button(new Rect(Screen.width/2 + 25, Screen.height/2 + 25, 75, 25), "Voltar")){

				SceneManager.LoadScene("MainMenu");

			}

		}

		if(state != 4){

			GUI.Box(new Rect(0,0,300,50), "Pontuação");

			GUI.Label(new Rect(10,25,300,50), "Milhos coletados: " + qtdMilho + "\tMilhos Perdidos: " + qtdMilhosPerdidos);

			if(GUI.Button(new Rect(Screen.width - 75, Screen.height - 25, 75, 25), "Voltar")){

				SceneManager.LoadScene("MainMenu");

			}

			if(GUI.Button(new Rect(Screen.width - 75, 0, 75, 25), "Objetivos")){

				Debug.Log("NÃO TEM NADA AQUI AINDA");

			}

		}

	}
	
	// Update is called once per frame
	void Update () {

		//Estado de jogo
		if(state == 0){

			//Passo
			float step = speed * Time.deltaTime;

			//Capturar a posição do Molde
			Vector3 pos = molde.transform.position;
			pos.z -= 1;

			//Cria um vetor na direção do molde
			milho.transform.position = Vector3.MoveTowards(milho.transform.position, pos, step);

			//Verifica se houve colisão
			CollisionDetection cd = milho.GetComponentInChildren<CollisionDetection>();
			if(cd.collision){
				state = 2;			
			}

			// Se o milho chegou no final da trilha, vá para o estado 1 (Preparação)
			if(milho.transform.position.z < -3.15) state = 3; 

		}else if (state == 1){ // Estado de preparação

			//Volta o milho para a posição inicial
			Vector3 t = milho.transform.position;
			t.z = 3.846f;

			milho.transform.position = t;

			//Nova rotação para o molde
			float angulo = Random.Range(0.0f, 180.0f);

			//Transformar angulos de euler em um quaternion
			Quaternion q = Quaternion.Euler(angulo,90,90);
			molde.transform.rotation = q;

			state = 0;

		}else if(state == 2){

			speed -= 0.05f;
			qtdMilhosPerdidos++;

			CollisionDetection cd = milho.GetComponentInChildren<CollisionDetection>();
			cd.collision = false;
			state = 1;

		}else if(state == 3){

			speed += 0.05f;
			Debug.Log("Você ganhou!");
			qtdMilho++;

			state = 1;

		}



	}
}
