using UnityEngine;
using System.Collections;

public class globalVariables : MonoBehaviour {

	public static int activeBox; // Active box selected 
	public static int currentGesture; //Gesu
	public static Classifier classifer;


	// Use this for initialization
	void Start () {
		activeBox = 0;
		currentGesture = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
