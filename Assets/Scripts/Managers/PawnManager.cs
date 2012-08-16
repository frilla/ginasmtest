using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnManager : MonoBehaviour {
	
	public static PawnManager instance;
	
	public List<Pawn> Pawns; 
	public int SpawnedEnemyCount;
	
	// Use this for initialization
	void Start () 
	{
		instance = this;
		GameEventManager.OnPawnSpawned += OnPawnSpawned;
		SpawnedEnemyCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnPawnSpawned(Pawn pawn)
	{
		Debug.Log("PawnManager OnPawnSpawned");
		Pawns.Add(pawn);
		if( pawn.isEnemy )
		{
			SpawnedEnemyCount++;
		}
	}
}
