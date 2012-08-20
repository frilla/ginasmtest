using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour 
{
	public enum PawnState
	{
		Idle = 0,
	    MoveToAttack,
	    Attack,
	    AttackDizzy,
	    AttackSpecialA,
	    AttackSpecialB,
	    ReceiveHit,
	    ReceiveHitDead,
	    Counter,
	    CounterMiss,
	    None
	}

	public enum PawnSubState
	{    
	    Attack_Start = 0,
	    Attack_Hit,
	    
	    Counter_Start,
	    Counter_Hit,
	    
	    None,
	} 

	//////////
	//please change attackTypeStrings & attackTypeColors if you change this enum
	public enum AttackType
	{
	    Normal = 0,
	    Counter,
	    Dizzy,
	    Quick,
	    SpecialA0,
	    SpecialA1,
	    SpecialB0,
	    SpecialB1,
	    None
	} 
	
	public int hpMax;
	public int hp { get; set; }
	
	public bool isEnemy { get; set; }

	public int damageMelee;
	public int defense;
    

	public bool shouldFlipFacingDirection { get; set; }
	
	public Pawn currentEnemy { get; set; }
	public bool isCurrentEnemy { get; set; }
	
	public PawnState pawnState { get; set; }
	public PawnSubState pawnSubState { get; set; }

	public float lastReceivedHitTime { get; set; }
	
	//locked in anim with other pawn, means should not play dead anim even if hp == 0
	public bool isLocked { get; set; }
	
	// Use this for initialization
	protected virtual void Start () 
	{
		GameEventManager.PawnSpawned(this);
		hp = hpMax;
		
		GameEventManager.OnCurrentEnemySet += OnCurrentEnemySet;
		GameEventManager.OnCurrentEnemyUnset += OnCurrentEnemyUnset;
	}
	
	protected virtual void OnDestroy()
	{
		GameEventManager.OnCurrentEnemySet -= OnCurrentEnemySet;
		GameEventManager.OnCurrentEnemyUnset -= OnCurrentEnemyUnset;
	}
		
	// Update is called once per frame
	protected virtual void Update () 
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
	
	public void OnCurrentEnemySet(Pawn pawn)
	{
		isCurrentEnemy = true;
	}
	
	public void OnCurrentEnemyUnset(Pawn pawn)
	{
		isCurrentEnemy = false;
	}
}
