using UnityEngine;
using System.Collections;

public class RotTest : MonoBehaviour {

	public GameObject myo = null;
	
	// Update is called once per frame
	void Update () {

		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		float angle = Mathf.Tan(myo.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad);

		Debug.Log("Y = " + angle);

	}
}
