using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class objectivesBtnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void btnManager(){
	
		SceneManager.LoadScene("MainMenu");
		perfilManager.UpdateVariables();
	
	}
}
