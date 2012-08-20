using UnityEngine;
using System.Collections;

public class PawnAIController : PawnController
{
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		
		if( pawn.currentEnemy )
    	{
        	if( pawn.pawnState == Pawn.PawnState.MoveToAttack )
        	{
				
			}
		}
	}
}
