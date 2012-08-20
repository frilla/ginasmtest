using UnityEngine;
using System.Collections;

public class PawnController : MonoBehaviour
{
	
	protected Pawn pawn;

	protected float moveTimer { get; set; }
	
	// Use this for initialization
	protected virtual void Start ()
	{
		pawn = gameObject.GetComponent<Pawn> ();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if (pawn.isEnemy && pawn.isCurrentEnemy) 
		{
			moveTimer = 0.0f;
		}
	}
}
