using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class perfilManager : MonoBehaviour {

    public Dropdown dp;
	public Text tx;
    
	// Use this for initialization
	void Start () {

		System.IO.FileStream fs = null;
       
		if(!System.IO.Directory.Exists("profiles")) 
			System.IO.Directory.CreateDirectory("profiles");

        if (!System.IO.File.Exists("./profiles/profilelist"))
        {
			fs = System.IO.File.Create("./profiles/profilelist");
			fs.Close();
		}


        dp.ClearOptions();
        UpdateList();

	}
	
	public void UpdateList() {

        string[] lines = System.IO.File.ReadAllLines("./profiles/profilelist");

        dp.ClearOptions();

        for(int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split('-');
            dp.options.Add(new Dropdown.OptionData(values[0] + " " + values[1]));

        }

	}

	public static void UpdateVariables(){
		File.WriteAllText("./profiles/" + globalVariables.activeProfile,
			globalVariables.eggSpeed + "-" +
			globalVariables.cornSpeed + "-" + 
			globalVariables.stoneSpeed + "-" + 
			globalVariables.milhosQuota + "-" +
			globalVariables.frutasQuota + "-" +
			globalVariables.ovosQuota);
	}


	public void LoadProfileBtn(){

		string[] tokens = dp.options[dp.value].text.Split(' ');
		string[] lines = System.IO.File.ReadAllLines("./profiles/" + tokens[0] + "-" + tokens[1]);
		globalVariables.activeProfile = tokens[0] + "-" + tokens[1];
		Debug.Log("Tokens: " + tokens[0] + " " + tokens[1]);
		tx.text = "Bem vindo(a), " + tokens[0];

		tokens = lines[0].Split('-');
	
		globalVariables.eggSpeed = float.Parse(tokens[0]);
		globalVariables.cornSpeed = float.Parse(tokens[1]);
		globalVariables.stoneSpeed = float.Parse(tokens[2]);

		globalVariables.milhosQuota = int.Parse(tokens[3]);
		globalVariables.frutasQuota = int.Parse(tokens[4]);
		globalVariables.ovosQuota = int.Parse(tokens[5]);

		Debug.Log("ACTIVE = " + globalVariables.activeProfile);

		Debug.Log(tokens[3] + " " + tokens[4] + " " + tokens[5]);

	}

}
