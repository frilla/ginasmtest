using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {
	
	public int hpMax;
	public bool isEnemy;

	// Use this for initialization
	protected virtual void Start () 
	{
		GameEventManager.PawnSpawned(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
