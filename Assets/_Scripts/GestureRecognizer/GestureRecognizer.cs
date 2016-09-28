using UnityEngine;
using UnityEngine.SceneManagement;
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
	private Classifier c;
	private List<double[]> emgData;
	private int currentGesture;
	private float startTime;
	private bool isTime;

	public string databaseName;

	// Use this for initialization
	void Start () {

		c = globalVariables.classifer;
		emgData = new List<double[]>();
		isTime = false;

		Dataset d = new Dataset("banco_completo5.csv");
		c = new Classifier(d);

		c.openDataset();
		c.setupNetwork(16, new int[2]{11,6});
		c.trainBackprop(1000,0.3,0.2);

		DontDestroyOnLoad(this);
		SceneManager.LoadScene("MainMenu");

	}

	public double[] normalizeData(Classifier cls, double[] data){

		double[] normData = new double[data.Length];

		for(int i = 0; i < data.Length; i++){
			normData[i] = (data[i] - (cls.getMaxValue()[i] + cls.getMinValue()[i])/2) / ((cls.getMaxValue()[i] - cls.getMinValue()[i])/2);
		}

		return normData;

	}

	public int classifyGesture(double[,] matMaxMin){

		double[] input = new double[16];

		for(int i = 0; i < 8; i++){

			input[i*2] = matMaxMin[i,0];
			input[i*2 + 1] = matMaxMin[i,1];

		}

		//Debug.Log("[0]: " + input[0] + "[1]: " + input[1] + "[2]: " + input[2] + "[3]: " + input[3] + "[4]: " + input[4] +
		//	"[5]: " + input[5] + "[6]: " + input[6] + "[7]: " + input[7] + "[8]: " + input[8] + "[9]: " + input[9] +
		//	"[10]: " + input[10] + "[11]: " + input[11] + "[12]: " + input[12] + "[13]: " + input[13] + "[14]: " + input[14] +
		//	"[15]: " + input[15]);

		return c.convertToNumerical(c.compute(normalizeData(c,input)));

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

		Debug.Log("MinValue: " + matMinMax[0,0] + " , " + matMinMax[1,0] + " , " + matMinMax[2,0] + " , " + matMinMax[3,0] + " , " + matMinMax[4,0] + " , " + matMinMax[5,0] + " , " + matMinMax[6,0] + " , " + matMinMax[7,0]);
		Debug.Log("MaxValue: " + matMinMax[0,1] + " , " + matMinMax[1,1] + " , " + matMinMax[2,1] + " , " + matMinMax[3,1] + " , " + matMinMax[4,1] + " , " + matMinMax[5,1] + " , " + matMinMax[6,1] + " , " + matMinMax[7,1]);

		return matMinMax;

	}

	// Update is called once per frame
	void Update () {
		
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		float time;

		int[] emg = thalmicMyo.emg;
		double[] emgDouble = new double[emg.Length];

		for(int i = 0; i < emg.Length; i++){
			emgDouble[i] = Convert.ToDouble(emg[i]);
		}
			
		if(!isTime){
			startTime = Time.time;
			isTime = true;
		}else{
			time = Time.time;

			if(time - startTime > 0.5){
				isTime = false;
				currentGesture = classifyGesture(getMaxAndMin(emgData));
				globalVariables.currentGesture = currentGesture;
				Debug.Log("Gesture: " + currentGesture);
				emgData.Clear();
			}else{
				emgData.Add(emgDouble);
			}


		}

	
	}


}
