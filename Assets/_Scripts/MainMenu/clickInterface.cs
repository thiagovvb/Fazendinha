using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class clickInterface : MonoBehaviour {

	public GameObject[] setas;

	// Use this for initialization
	void Start () {
		setas[0].SetActive(false);
		setas[1].SetActive(false);
		setas[2].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

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
