using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputInfinite : MonoBehaviour {

	public CarControllerInfinite carController;

	IEnumerator Start ()
	{
		yield return new WaitForSeconds (.3f);
		carController = GameObject.FindObjectOfType<CarControllerInfinite> ();
	}

	public void Gas ()
	{
		carController.Acceleration ();
	}

	public void Brake ()
	{
		carController.Brake ();
	}

	public void ReleaseGasBrake ()
	{
		carController.GasBrakeRelease ();
	}
}
