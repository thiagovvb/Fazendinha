using UnityEngine;
using System.Collections;

public class UniqueMyo : MonoBehaviour {

	private static bool created = false;

	// Use this for initialization
	void Awake () {
	
		if(!created){

			Debug.Log("Nhegure");
			created = true;

		}else{

			Debug.Log("Nhegure2");
			Destroy(this);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
