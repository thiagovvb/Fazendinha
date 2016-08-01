using UnityEngine;
using System.Collections;

public class Sigmoid : IActivationFunction{

	public double compute(float v){

		return 1/(1 + Mathf.Exp(-v));

	}

}

public class NeuralNetwork{

	private Layer[] layers;
	private int k;
	private IActivationFunction af;
	private Random rnd;

	public NeuralNetwork(int n){
		k = 0;
		layers = new Layer[n];
		af = new Sigmoid();
		rnd = new Random();
	}

	public Layer getOutputLayer(){
		return layers[k-1];
	}

    public Layer getInputLayer()
    {
        return layers[0];
    }

    public Layer getHiddenLayer(int i)
    {
        return layers[i];
    }

	public void addOutputLayer(int n, double[] bias){

		Layer l = new Layer(2, n);

		for(int i = 0; i < n; i++){

			Neuron temp = new Neuron(af, 2, bias[i], layers[k-1].getSize(), 0);

			for(int j = 0; j < layers[k-1].getSize(); j++){
				
				Synapse s = new Synapse(layers[k-1].getNeuron(j), temp , Random.Range(-10.0f, 10.0f));
				temp.addSynapse(s);

			}

			l.addNeuron(temp);

		}

		layers[k++] = l;

	}

	public void addHiddenLayer(int n, double[] bias){

		Layer l = new Layer(1, n);

		for(int i = 0; i < n; i++){

			Neuron temp = new Neuron(af, 1, bias[i], layers[k-1].getSize(), 0);

			for(int j = 0; j < layers[k-1].getSize(); j++){

				Synapse s = new Synapse(layers[k-1].getNeuron(j), temp , Random.Range(-10.0f, 10.0f));
				temp.addSynapse(s);

			}

			l.addNeuron(temp);

		}

		layers[k++] = l;

	}

	public void addInputLayer(int n, double[] value){

		Layer l = new Layer(0, n);

		for(int i = 0; i < n; i++){

			Neuron temp = new Neuron(af, 0, 0, 0, value[i]);

			l.addNeuron(temp);

		}

		layers[k++] = l;

	}

    public void train(Dataset ds)
    {

        int nDistinct = ds.getDistinctClasses();
        Debug.Log("nDistinct = " + nDistinct);
        Debug.Log("Length Layers = " + layers.Length);
        Debug.Log("Output size = " + getOutputLayer().getSize());

        //Matrix to store the output node's output value
        double[] outputOutput = new double[getOutputLayer().getSize()];

        //Matrix to store the output node's deltas
        double[] outputDeltas = new double[getOutputLayer().getSize()];

        //Matrix to store the hidden layer's output value
        double[,] hiddenOutput = new double[layers.Length - 2, getHiddenLayer(1).getSize()];

        //Matrix to store the hidden layer's deltas
        double[,] hiddenDeltas = new double[layers.Length - 2, getHiddenLayer(1).getSize()];

        //Vector to store the input from the dataset
        double[] input = new double[getInputLayer().getSize()];

        double[] expectedOutput = new double[getOutputLayer().getSize()];

        for (int line = 0; line < ds.getNLines(); line++)
        {

            for(int i = 0; i < input.Length; i++)
            {
                input[i] = ds.getValue(line, i);
                getInputLayer().getNeuron(i).setInput(input[i]);

                //Debug.Log("Input " + line + " " + i + " " + input[i]);
                
            }

            //Debug.Log("Expected: " + ds.getValueClass(line));

            for(int i = 0; i < expectedOutput.Length; i++)
            {
                if (i == ds.getValueClass(line))
                {
                    expectedOutput[i] = 1;
                }
                else expectedOutput[i] = 0;
                
            }

            for (int i = 0; i < getOutputLayer().getSize(); i++)
            {
                //Calculating the output node's output
                outputOutput[i] = getOutputLayer().getNeuron(i).getOutput();
                outputDeltas[i] = outputOutput[i] * (1 - outputOutput[i]) * (outputOutput[i] - expectedOutput[i]);


                Debug.Log("Output = " + outputOutput[i] + " expectedOutput = " + expectedOutput[i] + " outputDelta = " + outputDeltas[i]);
                //Debug.Log("Expected = " + ds.getValueClass(i));
            }

            for (int i = 0; i < k - 2; i++)
            {
                for (int j = 0; j < getHiddenLayer(1).getSize(); j++)
                {
                    //Debug.Log(" i = " + i + " j = " + j);
                    // Calculating the hiddeen node's output
                    hiddenOutput[i, j] = getHiddenLayer(i + 1).getNeuron(j).getOutput();
                }
            }

        }

    }

}
