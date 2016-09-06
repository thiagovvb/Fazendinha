using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	private int state;
	private float speed;
	public GameObject milho;
	public GameObject molde;

	void Start () {

		state = 0; //Play
		speed = 2.0f;

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

			Debug.Log("Você perdeu!");

			CollisionDetection cd = milho.GetComponentInChildren<CollisionDetection>();
			cd.collision = false;
			state = 1;

		}else if(state == 3){
			
			Debug.Log("Você ganhou!");

			state = 1;

		}



	}
}
