using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class helpCanvasManager : MonoBehaviour {

	public Text placarMilho;
	public Text placarOvos;
	public Text placarFrutas;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
		Canvas cv = gameObject.GetComponent<Canvas>();

		if(SceneManager.GetActiveScene().name == "MainMenu"){
			cv.enabled = false;
		}else cv.enabled = true;

		placarMilho.text = (": " + globalVariables.qtdMilho + " / " + globalVariables.milhosQuota);
		placarFrutas.text = (": " + globalVariables.qtdFrutas + " / " + globalVariables.frutasQuota);
		placarOvos.text = (": " + globalVariables.qtdOvos + " / " + globalVariables.ovosQuota);

	}

	public void helpBtn(){

		if(SceneManager.GetActiveScene().name.Equals("JogoFrogger")){
			
			gameControllerFrog frogCont = (gameControllerFrog)GameObject.Find("GameController").GetComponent<gameControllerFrog>();
			frogCont.activateHelp();

		}else if(SceneManager.GetActiveScene().name.Equals("JogoOvos")){
			gameController ovosCont = (gameController)GameObject.Find("GameController").GetComponent<gameController>();
			ovosCont.activateHelp();
		}else if(SceneManager.GetActiveScene().name.Equals("JogoMilho")){
			GameController milhoCont = (GameController)GameObject.Find("GameController").GetComponent<GameController>();
			milhoCont.activateHelp();
		}

	}

}
