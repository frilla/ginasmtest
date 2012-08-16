using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
	
	public static FightManager instance;
	
	public int EnemiesPerRound;
	
	public void Awake()
	{
		FightManager.instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		Instantiate(Resources.Load("Gina"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( PawnManager.instance.SpawnedEnemyCount < EnemiesPerRound )
		{
			Instantiate(Resources.Load("Enemy"), new Vector3(200f, 0f, 0f), Quaternion.identity);
		}
	}
}
