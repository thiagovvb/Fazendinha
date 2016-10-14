using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class perfilManager : MonoBehaviour {

    public Dropdown dp;
    
	// Use this for initialization
	void Start () {

        System.IO.Directory.CreateDirectory("profiles");

        if (!System.IO.File.Exists("./profiles/profilelist"))
        {
            System.IO.File.Create("./profiles/profilelist");
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
}
