using UnityEngine;
using System.Collections;

public class PlayerDead : FlightOnDead
{
	void Start (){}
	
	// if player dead 
	public override void OnDead (GameObject killer)
	{
		// if player dead call GameOver in GameManager
		GameManager game = (GameManager)GameObject.FindObjectOfType (typeof(GameManager));
		game.GameOver ();
		base.OnDead (killer);
	}
}
