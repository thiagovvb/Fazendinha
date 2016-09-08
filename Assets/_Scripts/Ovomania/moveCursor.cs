using UnityEngine;
using System.Collections;

public class moveCursor : MonoBehaviour {

	public GameObject myo = null;
	private float startPos;
	private float myoStartPos;
	private int pos;
	private bool posSet;
	private float[] positions;

	// Update is called once per frame

	void Start(){

		startPos = transform.position.x;
		posSet = false;
		positions = new float[4];
		positions[0] = 2.655f;
		positions[1] = 1.401f;
		positions[2] = 0.060f;
		positions[3] = -1.038f;
		pos = 0;

	}

	void Update () {

		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if(!posSet){
			myoStartPos = myo.transform.localRotation.eulerAngles.y;
			posSet = true;
		}

		float tanPos = myo.transform.localRotation.eulerAngles.y;

		if((tanPos - myoStartPos) > 10){
			Debug.Log("Direita");

			++pos;
			if(pos >= 4) --pos;

			transform.position = new Vector3(positions[pos], transform.position.y, transform.position.z);

			posSet = false;

		}else if((tanPos - myoStartPos) < -10){
			Debug.Log("Esquerda");


			--pos;
			if(pos < 0) ++pos;

			transform.position = new Vector3(positions[pos], transform.position.y, transform.position.z);


			posSet = false;
		}

		globalVariables.activeBox = pos;

	}

}
