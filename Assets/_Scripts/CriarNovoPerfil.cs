using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class CriarNovoPerfil : MonoBehaviour {

    public InputField nome;
    public InputField sobrenome;

    public void btnCriar()
    {
        StreamWriter sw = File.AppendText("./profiles/profilelist");
        sw.WriteLine(nome.text + "-" + sobrenome.text);
        sw.Close();

		System.IO.File.Create("./profiles/" + nome.text + sobrenome.text);
		//System.IO.File.WriteAllText("./profiles/" + nome.text + sobrenome.text, "1-1-2");

		nome.text = "";
		sobrenome.text = "";


    }

}
