using UnityEngine;
using System.Collections;

public class PawnAI : Pawn {

	// Use this for initialization
	protected override void Start () 
	{
		isEnemy = true;
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
