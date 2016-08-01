using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GestureRecognizer : MonoBehaviour {

	public GameObject myo = null;
	public System.IO.StreamWriter file;
	public bool write;
	private bool writing;
	private Classifier c;
	private Classifier gesturec;
	//private int j;
	private List<double[]> emgData;
	private int currentGesture;

	private float startTime;
	private bool isTime;

	// Use this for initialization
	void Start () {

		emgData = new List<double[]>();
		writing = false;
		isTime = false;

		//j = 0;
		/*file = new System.IO.StreamWriter("bancoMovimento.csv");
		write = true;*/

		//Dataset d1 = new Dataset("bancoFinal.csv");
		//Dataset d2 = new Dataset("treinamento_programa.csv");
		//Dataset d2 = new Dataset("bancoFinal.csv");
		Dataset d3 = new Dataset("treinamento_final.csv");

		Dataset d1 = new Dataset("treinamento_final.csv");
		Dataset d2 = new Dataset("treinamento_final.csv");

		c = new Classifier(d1);
		//gesturec = new Classifier(d3);

		//gesturec.openDataset();
		//gesturec.setupNetwork(16, new int[2]{10,5});
		//gesturec.trainBackprop(1000,0.3,0.2);

		c.openDataset();
		c.setupNetwork(16, new int[2]{10,5});
		c.trainBackprop(1000,0.3,0.2);

		d2.openAndLoad();

		double[] sample = c.computDataset(d2);
		int correct = 0;

		for(int i = 0; i < sample.Length; i++){

			if(sample[i] == d2.getValueClass(i)) correct++;

		}

		Debug.Log("NLines = " + d2.getNLines());

		Debug.Log("Taxa de acerto = " + ((float)correct)/d2.getNLines());

	}

	public int classifyGesture(double[,] matMaxMin){

		double[] input = new double[16];

		for(int i = 0; i < 8; i++){

			input[i*2] = matMaxMin[i,0];
			input[i*2 + 1] = matMaxMin[i,1];

		}

		Debug.Log("[0]: " + input[0] + "[1]: " + input[1] + "[2]: " + input[2] + "[3]: " + input[3] + "[4]: " + input[4] +
			"[5]: " + input[5] + "[6]: " + input[6] + "[7]: " + input[7] + "[8]: " + input[8] + "[9]: " + input[9] +
			"[10]: " + input[10] + "[11]: " + input[11] + "[12]: " + input[12] + "[13]: " + input[13] + "[14]: " + input[14] +
			"[15]: " + input[15]);

		return gesturec.convertToNumerical(gesturec.compute(input));

	}

	public void setClassifier(Classifier c){

		this.c = c;

	}

	double[,] getMaxAndMin(List<double[]> a1){

		double[] minValue = new double[8];
		double[] maxValue = new double[8];

		for(int i = 0; i < 8; i++){

			minValue[0] = maxValue[0] = a1[0][0];
			minValue[1] = maxValue[1] = a1[0][1];
			minValue[2] = maxValue[2] = a1[0][2];
			minValue[3] = maxValue[3] = a1[0][3];
			minValue[4] = maxValue[4] = a1[0][4];
			minValue[5] = maxValue[5] = a1[0][5];
			minValue[6] = maxValue[6] = a1[0][6];
			minValue[7] = maxValue[7] = a1[0][7];

		}

		for(int i = 1; i < a1.Count; i++){

			for(int j = 0; j < 8; j++){

				if(minValue[j] > a1[i][j]) minValue[j] = a1[i][j];

				if(maxValue[j] < a1[i][j]) maxValue[j] = a1[i][j];

			}

		}

		double[,] matMinMax = new double[8,2];
		for(int i = 0; i < 8; i++){

			matMinMax[i,0] = minValue[i];
			matMinMax[i,1] = maxValue[i];

		}

		//string line1 = minValue[0] + "," + minValue[1] + "," + minValue[2] + "," + minValue[3] + "," + minValue[4] + "," + minValue[5] + "," + minValue[6] + "," + minValue[7];
		//string line2 = maxValue[0] + "," + maxValue[1] + "," + maxValue[2] + "," + maxValue[3] + "," + maxValue[4] + "," + maxValue[5] + "," + maxValue[6] + "," + maxValue[7];

		//Debug.Log("Min: " + line1);
		//Debug.Log("Max: " + line2);

		return matMinMax;

	}

	// Update is called once per frame
	void Update () {

		ThalmicHub hub = ThalmicHub.instance;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		float time;

		int[] emg = thalmicMyo.emg;
		double[] emgDouble = new double[emg.Length];

		for(int i = 0; i < emg.Length; i++){
			emgDouble[i] = emg[i];
		}
			
		if(!isTime){
			startTime = Time.time;
			isTime = true;
		}else{
			time = Time.time;

			if(time - startTime > 1){
				isTime = false;
				int gesture = classifyGesture(getMaxAndMin(emgData));
				Debug.Log("Gesture: " + gesture);
			}else{
				emgData.Add(emgDouble);
			}


		}


		/*ThalmicHub hub = ThalmicHub.instance;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		int[] emg = thalmicMyo.emg;
		double[] emgDouble = new double[emg.Length];

		for(int i = 0; i < emg.Length; i++){
			emgDouble[i] = emg[i];
		}

		UpdateListBef(emgDouble);

		double[] res = c.compute(emgDouble);
		//int classf = Mathf.RoundToInt((float)res[0]);
		int classf = 0;
		double[,] matRes;

		if(Input.GetKeyDown("space")) classf = 1;

		if(writing == false){
			if(classf == 0){
				//Debug.Log("False && 0");
				UpdateListBef(emgDouble);
			}else if(classf == 1){
				//Debug.Log("False && 1");
				writing = true;
			}
		}else{
			if(emgAft.Count < 300){
				Debug.Log("Count " + emgAft.Count);
				emgAft.Add(emgDouble);
			}else{
				Debug.Log("Finised counting");
				writing = false;
				matRes = getMaxAndMin(emgAft,emgBef);

				string line1 = matRes[0,0] + "," + matRes[1,0] + "," + matRes[2,0] + "," + matRes[3,0] + "," + matRes[4,0] + "," + matRes[5,0] + "," + matRes[6,0] + "," + matRes[7,0];
				string line2 = matRes[0,1] + "," + matRes[1,1] + "," + matRes[2,1] + "," + matRes[3,1] + "," + matRes[4,1] + "," + matRes[5,1] + "," + matRes[6,1] + "," + matRes[7,1];

				Debug.Log("Min: " + line1);
				Debug.Log("Max: " + line2);

				Debug.Log("Classified as: " + classifyGesture(matRes));


			}
		}



		/*int classf = Mathf.RoundToInt((float)res[0]);

		string time = DateTime.UtcNow.ToString("HH:mm:ss.fffffff");

		if(classf == 1){
			Debug.Log("Movimento " + time);
		}*/
		/*ThalmicHub hub = ThalmicHub.instance;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		int[] emg = thalmicMyo.emg;

		Debug.Log("emg size = " + emg.Length);

		if(write){

			string line = emg[0] + "," + emg[1] + "," + emg[2] + "," + emg[3] + "," + emg[4] + "," + emg[5] + "," + emg[6] + "," + emg[7] + "," + "1";
			file.WriteLine(line);

		}

		if(Input.GetKeyDown("space") && write){
			write = false;
			file.Close();
		}*/

		//print(" emg [1] = " + (int)emg[0] + " emg [2] = " + (int)emg[1] + " emg [3] = " + (int)emg[2] + " emg [4] = " + (int)emg[3] +
		//	  " emg [5] = " + (int)emg[4] + " emg [6] = " + (int)emg[5] + " emg [7] = " + (int)emg[6] + " emg [8] = " + (int)emg[7]);

	}


}
