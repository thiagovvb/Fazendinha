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
        nome.text = "";
        sobrenome.text = "";
        sw.Close();
    }

}
