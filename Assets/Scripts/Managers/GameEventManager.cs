using UnityEngine;
using System.Collections;

public static class GameEventManager {
	
	public delegate void GameEvent();
	
	public static event GameEvent GameStart, GameOver;
	
	public delegate void PawnEvent(Pawn pawn);
	
	public static event PawnEvent 	OnPawnSpawned, OnPawnDestroyed, 
									OnCurrentEnemySet, OnCurrentEnemyUnset, 
									OnAttackStateStart, OnAttackStateEnd,
									OnPawndead;
	
	public delegate void GameObjectEvent( GameObject gameObject );
	
	public static event GameObjectEvent OnGameObjectSpawned, OnGameObjectDestroyed;
	
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
	
	public static void CurrentEnemySet(Pawn pawn)
	{
		if( OnCurrentEnemySet != null )
		{
			OnCurrentEnemySet(pawn);
		}
	}
	
	public static void CurrentEnemyUnset(Pawn pawn)
	{
		if( OnCurrentEnemyUnset != null )
		{
			OnCurrentEnemyUnset(pawn);
		}
	}
	
	public static void AttackStateStart(Pawn pawn)
	{
		if( OnAttackStateStart != null )
		{
			OnAttackStateStart(pawn);
		}
	}
	
	public static void AttackStateEnd(Pawn pawn)
	{
		if( OnAttackStateEnd != null )
		{
			OnAttackStateEnd(pawn);
		}
	}
	
	public static void PawnDead(Pawn pawn)
	{
		if( OnPawndead != null )
		{
			OnPawndead(pawn);
		}
	}
}


