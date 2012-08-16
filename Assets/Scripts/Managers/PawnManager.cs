using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnManager : MonoBehaviour {
	
	public List<Pawn> Pawns; 
	
	// Use this for initialization
	void Start () {
		GameEventManager.OnPawnSpawned += OnPawnSpawned;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnPawnSpawned(Pawn pawn)
	{
		Debug.Log("PawnManager OnPawnSpawned");
		Pawns.Add(pawn);
	}
}
