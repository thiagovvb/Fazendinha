using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

	public void LoadProfileBtn(){

		string[] tokens = dp.options[dp.value].text.Split(' ');
		string[] lines = System.IO.File.ReadAllLines("./profiles/" + tokens[0] + "-" + tokens[1]);
		globalVariables.activeProfile = tokens[0] + "-" + tokens[1];
		tx.text = "Perfil Selecionado: " + tokens[0] + " " + tokens[1];


		tokens = lines[0].Split('-');
	
		globalVariables.eggSpeed = float.Parse(tokens[0]);
		globalVariables.cornSpeed = float.Parse(tokens[1]);
		globalVariables.stoneSpeed = float.Parse(tokens[2]);

		Debug.Log("ACTIVE = " + globalVariables.activeProfile);

		Debug.Log(tokens[0] + " " + tokens[1] + " " + tokens[2]);

	}

}
