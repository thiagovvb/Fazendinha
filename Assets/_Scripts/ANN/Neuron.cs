using UnityEngine;
using System.Collections;

public class Neuron {

	private IActivationFunction af {get; set; } // Neuron's activation function
	private double bias {get; set;} // Theta, or bias of the neuron
	private double input {get; set;} // Usable only if this neuron is on the input layer
	private int type {get; set;} // 0 = input layer, 1 = hidden layer, 2 = output layer
	private int nSynapses {get; set;}
	private Synapse[] inputSynapses; // The output synapses of this node
	private static int i = 0;
	private int id;
	private int synapseCount;


	public Neuron(IActivationFunction af, int type, double bias, int nSynapses, double input){

		this.af = af;
		this.bias = bias;
		this.type = type;
		this.input = input;
		if (nSynapses > 0) inputSynapses = new Synapse[nSynapses];
		this.nSynapses = nSynapses;
		synapseCount = 0;
		id = i++;

	}

    public void setInput(double v)
    {
        input = v;
    }

	public double getOutput(){

		double sum = 0;

		if(type == 0){
			//Debug.Log("Input Neuron " + id);
			//Debug.Log("Returning input " + input);
			return input;
		}

		for(int i = 0; i < synapseCount; i++){

			//Debug.Log("Neuron " + id);
			sum += inputSynapses[i].getWeight() * inputSynapses[i].getOutNeuron().getOutput();
			//Debug.Log("Summed on " + id + " weight = " + inputSynapses[i].getWeight());

		}

		sum += bias;
		//Debug.Log("bias = " + bias);
		//Debug.Log("sum = " + sum);
		//Debug.Log("activate = " + activate(sum));

		//Debug.Log("Neuron " + id + " returning " + sum);

		return activate(sum);

	}

	public void addSynapse(Synapse s){
		inputSynapses[synapseCount++] = s;
	}

	public double activate(double v){

		return af.compute((float)v);

	}

	public int getId(){
		return id;
	}

	public void toString(){
		Debug.Log("Neuron " + id + " recieving: ");
		for(int i = 0; i < synapseCount; i++){
			Debug.Log(inputSynapses[i].getWeight() + " from " + inputSynapses[i].getOutNeuron().getId());
		}

		for(int i = 0; i < synapseCount; i++){

		}

	}

}
