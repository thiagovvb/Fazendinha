using UnityEngine;
using System.Collections;

public class TestNeuralN : MonoBehaviour {

	// Use this for initialization
	void Start () {

        /*double[] inputV = {1,0};
		double[] inputH = {0,0,0};
		double[] outputV = {0,0};
		NeuralNetwork n = new NeuralNetwork(3);
		n.addInputLayer(2,inputV);
		n.addHiddenLayer(3, inputH);
        n.addOutputLayer(2,outputV);

        Layer l = n.getOutputLayer();
		l.getNeuron(0).toString();
		l.getNeuron(1).toString();*/

        Dataset d1 = new Dataset("bancoFinal.csv");
		//Dataset d2 = new Dataset("treinamento_programa.csv");
		Dataset d2 = new Dataset("bancoFinal.csv");

		Classifier c = new Classifier(d1);

		c.openDataset();
		c.setupNetwork(8, new int[2]{8,2});
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
