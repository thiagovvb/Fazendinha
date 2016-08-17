using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public Transform ovoBranco;
	private Vector3[] positions;
	private Quaternion defaultQuaternion;
	private float startTime;

	// Use this for initialization
	void Start () {
		
		defaultQuaternion = Quaternion.Euler(new Vector3(90,-90,0));

		startTime = Time.time;

		positions = new Vector3[4];

		positions[0] = new Vector3(2.65f, 3.13f, -6.06f);
		positions[1] = new Vector3(1.32f, 3.13f, -6.06f);
		positions[2] = new Vector3(0.13f, 3.13f, -6.06f);
		positions[3] = new Vector3(-1.14f, 3.13f, -6.06f);
	}
	
	// Update is called once per frame
	void Update () {
	
		int num;
		if(Time.time - startTime > 1){
			for(int i = 0; i < 4; i++){

				num = Random.Range(0,100);
				if(num >= 80 && num <= 100){
					Instantiate(ovoBranco,positions[i],defaultQuaternion);
				}

			}
			startTime = Time.time;
		}

	}
}
