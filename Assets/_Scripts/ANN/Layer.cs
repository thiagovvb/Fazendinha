using UnityEngine;
using System.Collections;

public class Layer {

	private Neuron[] neurons;
	private int type; // 0 = Input layer, 1 = Hidden Layer, 2 = Output Layer
	private int size;
	private int i;

	public Layer(int type, int size){

		this.type = type;
		this.size = size;
		neurons = new Neuron[size];
		i = 0;

	}

	public void addNeuron(Neuron n){
		neurons[i++] = n;
	}

	public Neuron getNeuron(int i){
		return neurons[i];
	}

	public void addNeuron(IActivationFunction af, double bias, int nSynapses, double input = 0){

		neurons[i++] = new Neuron(af, type, bias, nSynapses, input);

	}

	public bool isFull(){

		return i < size;

	}

	public int getSize(){
		return size;
	}

}
