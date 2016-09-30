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
}
