using UnityEngine;
using System.Collections;

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;


public class Classifier {

	private Dataset ds;
	private ActivationNetwork network;
	private double[][] input;
	private double[][] output;

	public Classifier(Dataset ds){

		this.ds = ds;

	}

	public void openDataset(){
	
		ds.openAndLoad();

	}

	public double[] compute(double[] inpt){
		return network.Compute(inpt);
	}

	public void setupNetwork(int inputs, int[] config){

		network = new ActivationNetwork(new SigmoidFunction(), inputs, config);

	}

	public int convertToNumerical(double[] inpt){

		for(int i = 0; i < inpt.Length; i++){

			if(Mathf.RoundToInt((float)inpt[i]) == 1) return i;

		}

		return -1;

	}

	public double[] computDataset(Dataset data){
		
		double[][] dataset_m = new double[data.getNLines()][];
		double[] classified = new double[data.getNLines()];
		double[] sample = new double[data.getNFeatures()];

		//Training data assembly
		for(int i = 0; i < data.getNLines(); i++){

			dataset_m[i] = new double[data.getNFeatures()];
			//output[i] = new double[1];
			//Copy input
			for(int j = 0; j < data.getNFeatures(); j++)
				dataset_m[i][j] = data.getValue(i,j);

		}

		dataset_m = normalizeDataset(dataset_m);

		for(int i = 0; i < data.getNLines(); i++){

			for(int j = 0; j < data.getNFeatures(); j++) sample[j] = dataset_m[i][j];

			classified[i] = convertToNumerical(compute(sample));

		}

		return classified;

	}

	public double[][] normalizeDataset(double[][] dataset){

		int xMax = dataset.Length; //360
		int yMax = dataset[0].Length; //16

		double[][] normalizedDataset = new double[xMax][];
		double[] maxValue = new double[yMax];
		double[] minValue = new double[yMax];

		for(int i = 0; i < xMax; i++){
		
			normalizedDataset[i] = new double[yMax];

		}

		for(int i = 0; i < yMax; i++){

			maxValue[i] = dataset[0][i];
			minValue[i] = dataset[0][i];

		}


		for(int i = 0; i < xMax; i++){

			for(int j = 0; j < yMax; j++){
			
				if(dataset[i][j] > maxValue[j]) maxValue[j] = dataset[i][j];
				if(dataset[i][j] < minValue[j]) minValue[j] = dataset[i][j];

			}

		}

		for(int i = 0; i < yMax; i++){

			Debug.Log("Max [ " + i + " ] = " + maxValue[i]);  
			Debug.Log("Min [ " + i + " ] = " + minValue[i]);

		}


		for(int i = 1; i < xMax; i++){

			for(int j = 0; j < yMax; j++){

				normalizedDataset[i][j] = (dataset[i][j] - (maxValue[j] + minValue[j])/2) / ((maxValue[j] - minValue[j])/2);

			}

		}

		return normalizedDataset;

	}

	public void trainBackprop(int nEpochs, double learningRate, double momentum){

		//Matrix containing the input data for each line of the database
		input = new double[ds.getNLines()][];

		//Matrix containing the output data for each line of the database
		output = new double[ds.getNLines()][];

		//Training data assembly
		for(int i = 0; i < ds.getNLines(); i++){
		
			input[i] = new double[ds.getNFeatures()];
			//output[i] = new double[1];
			//Copy input
			for(int j = 0; j < ds.getNFeatures(); j++)
				input[i][j] = ds.getValue(i,j);
			//Copy output
			//output[i][0] = ds.getValueClass(i);
			output[i] = ds.getValueClassVectorized(i);

		}

		input = normalizeDataset(input);

		for(int i = 0; i < ds.getNLines(); i++){
			for(int j = 0; j < ds.getNFeatures(); j++){
				//Debug.Log("i = " + i + " j = " + j + " : " + input[i][j]);
			}
			//Debug.Log("Output for i = " + i + " = " + output[i][0]);
		}

		BackPropagationLearning teacher = new BackPropagationLearning(network);

		teacher.LearningRate = learningRate;
		teacher.Momentum = momentum;

		double error;	

		for(int i = 0; i < nEpochs; i++){
			
			error = teacher.RunEpoch(input,output);
			Debug.Log("error = " + error);

		}

	}

}
