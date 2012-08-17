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
	
	public void facePoint(Vector3 point)
	{
		if( point.x > transform.localPosition.x )
		{
			transform.forward = new Vector3(0f, 0f, 1f);
		}
		else
		{
			transform.forward = new Vector3(0f, 0f, -1f);
		}
	}
}
