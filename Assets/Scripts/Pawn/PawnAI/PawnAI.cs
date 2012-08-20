using UnityEngine;
using System.Collections;

public class PawnAI : Pawn 
{
	
	public Color MeshColor;

	// Use this for initialization
	protected override void Start () 
	{
		isEnemy = true;
		base.Start();
		SmoothMoves.BoneAnimation ba = gameObject.GetComponent<SmoothMoves.BoneAnimation>();
		ba.SetMeshColor(MeshColor);
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		facePoint( new Vector3(0f, 0f, 0f) );
	}
}
