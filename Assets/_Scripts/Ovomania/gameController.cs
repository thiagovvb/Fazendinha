using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pose = Thalmic.Myo.Pose;

public class gameController : MonoBehaviour {

	public Transform ovoBranco;
	public Transform ovoPodre;
	public Transform ovoEspecial;
	public Text ovosBrancos;
	public Text ovosPodres;
	private Vector3[] positions;
	private Quaternion defaultQuaternion;
	private float startTime;
	public GameObject[] tampas;
	private bool[] tampaFechada;
	private Pose lastGesture;
	public int state;
	public Canvas helpCanvas;
	private GameObject myo = null;

	// Use this for initialization
	void Start () {

		state = 0;

		defaultQuaternion = Quaternion.Euler(new Vector3(90,-90,0));
		lastGesture = 0;

		tampaFechada = new bool[4];
		for(int i = 0; i < 4; i++) tampaFechada[i] = true;

		startTime = Time.time;

		positions = new Vector3[4];

		positions[0] = new Vector3(2.65f, 3.13f, -6.06f);
		positions[1] = new Vector3(1.32f, 3.13f, -6.06f);
		positions[2] = new Vector3(0.13f, 3.13f, -6.06f);
		positions[3] = new Vector3(-1.14f, 3.13f, -6.06f);

		myo = GameObject.Find("Myo");
	}
	
	// Update is called once per frame
	void Update () {

		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if(state == 1){
			int num;
			if(Time.time - startTime > 1){
				for(int i = 0; i < 4; i++){

					num = Random.Range(0,150);

					if(num >= 80 && num <= 90){
						Debug.Log("Numero gerado = " + num + " BRANCO");
						Instantiate(ovoBranco,positions[i],defaultQuaternion);
					}

					if(num >= 50 && num <= 55){
						Debug.Log("Numero gerado = " + num + " PODRE");
						Instantiate(ovoPodre,positions[i],defaultQuaternion);
					}
					
				}
				startTime = Time.time;
			}

			Pose cGesture = thalmicMyo.pose;
			int cBox = globalVariables.activeBox;

			if(thalmicMyo.pose != lastGesture){
				if(thalmicMyo.pose == Pose.FingersSpread){
					Debug.Log("Fingers Spread, cbox = " + cBox);
					if(tampaFechada[cBox]){
						tampaFechada[cBox] = false;
						tampas[cBox].transform.Translate(new Vector3(0,0,2), Space.World);
					}
				}

				if(thalmicMyo.pose == Pose.Fist){
					Debug.Log("Fist, cbox = " + cBox);
					if(!tampaFechada[cBox]){
						tampas[cBox].transform.Translate(new Vector3(0,0,-2), Space.World);
						tampaFechada[cBox] = true;
					}
				}
				lastGesture = thalmicMyo.pose;
			}

			ovosBrancos.text = ": " + globalVariables.qtdOvosBrancos_Local;
			ovosPodres.text = ": " + globalVariables.qtdOvosPodres_Local;
		}

		/*if(Input.GetKeyDown("1")){
			if(tampaFechada[0]){
				tampas[0].transform.Translate(new Vector3(0,0,2), Space.World);
				tampaFechada[0] = false;
			}else{
				tampas[0].transform.Translate(new Vector3(0,0,-2), Space.World);
				tampaFechada[0] = true;
			}
		}else if(Input.GetKeyDown("2")){
			if(tampaFechada[1]){
				tampaFechada[1] = false;
				tampas[1].transform.Translate(new Vector3(0,0,2), Space.World);
			}else{
				tampas[1].transform.Translate(new Vector3(0,0,-2), Space.World);
				tampaFechada[1] = true;
			}
		}else if(Input.GetKeyDown("3")){
			if(tampaFechada[2]){
				tampaFechada[2]= false;
				tampas[2].transform.Translate(new Vector3(0,0,2), Space.World);
			}else{
				tampas[2].transform.Translate(new Vector3(0,0,-2), Space.World);
				tampaFechada[2] = true;
			}
		}else if(Input.GetKeyDown("4")){
			if(tampaFechada[3]){
				tampaFechada[3] = false;
				tampas[3].transform.Translate(new Vector3(0,0,2), Space.World);
			}else{
				tampas[3].transform.Translate(new Vector3(0,0,-2), Space.World);
				tampaFechada[3] = true;
			}
		}*/


	}

	public void voltarBtn(){
		Debug.Log("NHEGURE");
		SceneManager.LoadScene("MainMenu");
		perfilManager.UpdateVariables();
	}
		
	public void btnContinua(){
		helpCanvas.enabled = false;
		state = 1;
	}

	public void activateHelp(){
		state = 2;
		helpCanvas.enabled = true;
	}

}
