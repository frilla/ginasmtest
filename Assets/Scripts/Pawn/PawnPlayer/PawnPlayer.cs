using UnityEngine;
using System.Collections;

public class PawnPlayer : Pawn {

	// Use this for initialization
	protected override void Start () 
	{
		isEnemy = false;
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
