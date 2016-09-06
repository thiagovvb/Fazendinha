using UnityEngine;
using System.Collections;

public class RotTest : MonoBehaviour {

	public GameObject myo = null;
	public float startAngle;
	
	// Update is called once per frame

	void Start(){
	
		startAngle = myo.transform.localRotation.eulerAngles.z;
	
	}

	void Update () {

		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		float angle = Mathf.Tan(myo.transform.localRotation.eulerAngles.y * Mathf.Deg2Rad);

		/*Debug.Log("Y = " + angle);

		Quaternion q = Quaternion.Euler(0,0,2f * myo.transform.localRotation.eulerAngles.z - startAngle);
		transform.rotation = q;*/

		float pos = myo.transform.position.x;

		Vector3 newPos = new Vector3(4*angle,  transform.position.y, transform.position.z);

		transform.position = newPos;

	}
}
