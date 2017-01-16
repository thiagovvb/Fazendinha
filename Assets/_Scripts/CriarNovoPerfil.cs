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

		System.IO.FileStream fs = System.IO.File.Create("./profiles/" + nome.text + "-" + sobrenome.text);
		fs.Close();
		sw = File.AppendText("./profiles/" + nome.text + "-" + sobrenome.text);
		sw.WriteLine("1-1-2-30-30-30");
		sw.Close();

		nome.text = "";
		sobrenome.text = "";


    }

}
