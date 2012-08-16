using UnityEngine;
using System.Collections;

public static class GameEventManager {
	
	public delegate void GameEvent();
	
	public static event GameEvent GameStart, GameOver;
	
	public delegate void PawnEvent(Pawn pawn);
	
	public static event PawnEvent OnPawnSpawned, OnPawnDestroyed;
	
	public static void TriggerGameStart(){
		if( GameStart != null ){
			GameStart();
		}
	}
	
	public static void TriggerGameOver(){
		if( GameOver != null ){
			GameOver();
		}
	}
	
	public static void PawnSpawned(Pawn pawn)
	{
		if( OnPawnSpawned != null )
		{
			OnPawnSpawned(pawn); 
		}
	}
	
	public static void PawnDestroyed(Pawn pawn)
	{
		if( OnPawnDestroyed != null )
		{
			OnPawnDestroyed(pawn); 
		}
	}
}


