using UnityEngine;
using System.Collections;
using System;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MyoRawData : MonoBehaviour {

	public GameObject myo = null;
	private int i;
	public int state;

	private Pose _lastPose = Pose.Unknown;

	// Use this for initialization
	void Start () {
		
		i = 0;
		state = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		ThalmicHub hub = ThalmicHub.instance;

		// Access the ThalmicMyo script attached to the Myo object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		int[] emg = thalmicMyo.emg;
		//print(thalmicMyo.pose);

		if (thalmicMyo.pose != _lastPose) {
			if(thalmicMyo.pose != Pose.Rest ){
				//ExtendUnlockAndNotifyUserAction(thalmicMyo);
				print("Pose! " + i++);
			}
		}
		/*if((Math.Abs(emg[0]) > 50
			|| Math.Abs(emg[1]) > 50
			|| Math.Abs(emg[2]) > 50
			|| Math.Abs(emg[3]) > 50
			|| Math.Abs(emg[4]) > 50
			|| Math.Abs(emg[5]) > 50
			|| Math.Abs(emg[6]) > 50
			|| Math.Abs(emg[7]) > 50 ) && state == 0)
		{

			print("Começou gesto");
			state = 1;

		}

		if((Math.Abs(emg[0]) < 30
			&& Math.Abs(emg[1]) < 30
			&& Math.Abs(emg[2]) < 30
			&& Math.Abs(emg[3]) < 30
			&& Math.Abs(emg[4]) < 30
			&& Math.Abs(emg[5]) < 30
			&& Math.Abs(emg[6]) < 30
			&& Math.Abs(emg[7]) < 30) && state == 1 )
		{

			print("Terminou gesto");
			state = 0;

		}*/

		/*print(thalmicMyo.emg[0] + 
			" ; " + thalmicMyo.emg[1] + 
			" ; " + thalmicMyo.emg[2] + 
			" ; " + thalmicMyo.emg[3] + 
			" ; " + thalmicMyo.emg[4] + 
			" ; " + thalmicMyo.emg[5] + 
			" ; " + thalmicMyo.emg[6] + 
			" ; " + thalmicMyo.emg[7] );
		*/
	}

	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;

		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}

		myo.NotifyUserAction ();
	}

}
