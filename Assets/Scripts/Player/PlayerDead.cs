using UnityEngine;
using System.Collections;

public class PlayerDead : FlightOnDead
{
	void Start (){}
	
	// if player dead 
	public override void OnDead (GameObject killer)
	{
        // if player dead call GameOver in GameManager
        FlightManager flight = (FlightManager)GameObject.FindObjectOfType (typeof(FlightManager));
        flight.GameOver ();
		base.OnDead (killer);
	}
}
