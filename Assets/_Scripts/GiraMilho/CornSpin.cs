using UnityEngine;
using System.Collections;

public class CornSpin : MonoBehaviour {

	public GameObject myo = null;
	private float startAngle;

	// Use this for initialization
	void Start () {
	
		startAngle = myo.transform.localRotation.eulerAngles.z;

	}
	
	// Update is called once per frame
	void Update () {
	
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		Quaternion q = Quaternion.Euler(2*myo.transform.localRotation.eulerAngles.z - startAngle,90,90);
		transform.localRotation = q;

	}
}
