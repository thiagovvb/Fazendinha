using UnityEngine;
using System.Collections;

public class Synapse {

	private Neuron outNeuron {get; set;}
	private Neuron inNeuron {get; set;}
	private double weight {get; set;}

	public Synapse(Neuron n1, Neuron n2, double weight){

		outNeuron = n1;
		inNeuron = n2;
		this.weight = weight;

	}

	public Neuron getOutNeuron(){
		return outNeuron;
	}

	public Neuron getInNeuron(){
		return inNeuron;
	}

	public double getWeight(){
		return weight;
	}

}
