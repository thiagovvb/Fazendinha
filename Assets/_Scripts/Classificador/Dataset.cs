using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class Dataset {

    private double[,] features;
    private int nFeatures;
    private int nLines;
    private string filename;

    public Dataset(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.LogError("WARNING: File does not exist!");
        }
        this.filename = filename;
    }

    public void openAndLoad()
    {
        string[] lines = File.ReadAllLines(filename);
        string[] values = lines[0].Split(',');

        nFeatures = values.Length;
        nLines = lines.Length; //Discard the first line which is the nominal classification of the variables

        features = new double[nLines,nFeatures];

        for(int i = 0; i < nLines; i++)
        {
            values = lines[i].Split(',');

            for(int j = 0; j < nFeatures; j++)
            {
                double.TryParse(values[j], out features[i,j]);
            }
        }

    }

    public double getValue(int i, int j)
    {
        return features[i, j];
    }

    public int getNLines()
    {
        return nLines;
    }

    public int getNFeatures()
    {
        return nFeatures - 1;
    }

    public int getValueClass(int i)
    {
        return (int) features[i, nFeatures - 1];
    }

	public double[] getSample(int line){

		double[] sample = new double[nFeatures - 1];

		for(int i = 0; i < nFeatures - 1; i++){

			sample[i] = features[line,i];

		}

		return sample;

	}

	public double[] getValueClassVectorized(int index)
	{
		double[] output = new double[getDistinctClasses()];

		for(int i = 0; i < output.Length; i++){
			if( i == (int) features[index, nFeatures - 1] ) output[i] = 1;
			else output[i] = 0;
		}

		return output;
	}

    public int getDistinctClasses()
    {
        ArrayList al = new ArrayList();

        for(int i = 0; i < nLines; i++)
        {
            if (!al.Contains(features[i, nFeatures - 1]))
            {
                al.Add(features[i, nFeatures - 1]);
            }
        }

        return al.Count;
    }

}
