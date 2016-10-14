using UnityEngine;
using System.Collections;

public class globalVariables : MonoBehaviour {

	public static int activeBox; // Active box selected 
	public static int currentGesture; //Gesu
	public static Classifier classifer;

	public static int qtdMilho;
	public static int qtdOvos;
	public static int qtdFrutas_Local;
	public static int qtdOvosBrancos_Local;
	public static int qtdOvosPodres_Local;
	public static int qtdOvosBrancosPerdidos_Local;
	public static int qtdFrutas;

	public static int frutasQuota;
	public static int milhosQuota;
	public static int ovosQuota;

	public static bool blurActive;

	public static float eggSpeed;
	public static float stoneSpeed;
	public static float cornSpeed;

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
		qtdOvosBrancos_Local = 0;
		qtdOvosPodres_Local = 0;
		qtdOvosBrancosPerdidos_Local = 0;
		eggSpeed = 1f;
		stoneSpeed = 1f;
		cornSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
