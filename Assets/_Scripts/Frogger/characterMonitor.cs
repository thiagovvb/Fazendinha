using UnityEngine;
using System.Collections;

public class characterMonitor : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		CharacterController controller = GetComponent<CharacterController>();

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		controller.Move(moveDirection * Time.deltaTime);

		if(gameControllerFrog.carryingFruit){
			if(transform.position.z < 402){
				gameControllerFrog.carryingFruit = false;
				Debug.Log("Cheguei do outro lado!");
			}
		}


	}

	void OnTriggerEnter(Collider other){

		if(other.tag == "Fruta" && (!gameControllerFrog.carryingFruit)){
			gameControllerFrog.carryingFruit = true;
			gameControllerFrog.remainingFruits--;
			Destroy(other.gameObject);
		}


		if(other.tag == "Pedra") Debug.Log("Colidiu com pedra");

	}

}
