using UnityEngine;
using System.Collections;

public class PawnController : MonoBehaviour {
	
	protected Pawn pawn;
	
	// Use this for initialization
	void Start () {
		pawn = gameObject.GetComponent<Pawn>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
