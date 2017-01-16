using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updatePlacar : MonoBehaviour {

	public Text placarMilho;
	public Text placarOvos;
	public Text placarFrutas;

	// Use this for initialization
	void Start () {
		
		placarMilho.text = (globalVariables.qtdMilho + " / " + globalVariables.milhosQuota);
		placarFrutas.text = (globalVariables.qtdFrutas + " / " + globalVariables.frutasQuota);
		placarOvos.text = (globalVariables.qtdOvos + " / " + globalVariables.ovosQuota);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
