using UnityEngine;
using System.Collections;


public class eggWatcher : MonoBehaviour {

	private int qtdOvosBrancos;
	private int qtdOvosPodres;
	private bool guardado;

	// Use this for initialization
	void Start () {
	
		guardado = false;
		qtdOvosPodres = 0;
		qtdOvosBrancos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z > 3){
			Destroy(gameObject);
		}

		if(transform.position.y < 2.4 && transform.position.z < 1 && !guardado){
			guardado = true;
			if(tag.Equals("OvoBranco")){
				globalVariables.qtdOvos++;
				globalVariables.qtdOvosBrancos_Local++;
			}
			else if(tag.Equals("OvoPodre")) globalVariables.qtdOvosPodres_Local++;
		}

	}
}
