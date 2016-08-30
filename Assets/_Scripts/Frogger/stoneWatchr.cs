using UnityEngine;
using System.Collections;

public class stoneWatchr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > 196.9){
			Destroy(gameObject);
		}
	}
}
