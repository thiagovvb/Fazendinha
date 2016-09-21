using UnityEngine;
using System.Collections;

public class globalVariables : MonoBehaviour {

	public static int activeBox; // Active box selected 
	public static int currentGesture; //Gesu
	public static Classifier classifer;
	public static int qtdMilho;
	public static int qtdOvos;
	public static int qtdFrutas;

	public static int frutasQuota;
	public static int milhosQuota;
	public static int ovosQuota;

	public static bool blurActive;


	// Use this for initialization
	void Start () {
		blurActive = true;
		activeBox = 0;
		currentGesture = 0;
		qtdMilho = 0;
		qtdOvos = 0;
		qtdFrutas = 0;
		frutasQuota = 0;
		milhosQuota = 0;
		ovosQuota = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
