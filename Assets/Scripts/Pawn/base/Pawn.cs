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
	
	private Pawn _currentEnemy;
	public Pawn currentEnemy 
	{ 
		get 
		{ 
			return _currentEnemy; 
		}
		
		set
		{
			if( _currentEnemy != value )
			{
				if( _currentEnemy )
				{
					_currentEnemy.isLocked = false;
					GameEventManager.CurrentEnemyUnset(_currentEnemy);
				}
				
				_currentEnemy = value;
				
				if( _currentEnemy )
				{
					GameEventManager.CurrentEnemySet(_currentEnemy);
				}
			}
		}
	}
		
	public bool isCurrentEnemy { get; set; }
	
	private PawnState _pawnState;
	public PawnState pawnState 
	{ 
		get 
		{
			return _pawnState;
		}
		set
		{
			if( value != _pawnState )
		    {
		        if( Pawn.IsAttackState(_pawnState) && !Pawn.IsAttackState(pawnState) )
		        {
		            if(currentEnemy)
		            {
		                currentEnemy = null;
		            }
		        }
		                
		        if( Pawn.IsAttackState(_pawnState) && !Pawn.IsAttackState(pawnState) )
		        {
		            GameEventManager.AttackStateEnd(this);
		        }
		        
		        _pawnState = pawnState;
		        
		        if( Pawn.IsAttackState(pawnState) )
		        {
		            GameEventManager.AttackStateStart(this);
		        }
		    }
		}
	}
	
	
	public static bool IsAttackState( PawnState pawnState )
	{
	    bool result = false;
	    if( pawnState == PawnState.Attack || 
	        pawnState == PawnState.AttackDizzy ||
	        pawnState == PawnState.Counter ||
	        pawnState == PawnState.MoveToAttack ||
	        pawnState == PawnState.AttackSpecialA ||
	        pawnState == PawnState.AttackSpecialB
	       )
	    {
	        result = true;
	    }
	    return result;
	}
		
	
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
		lastReceivedHitTime += Time.deltaTime;
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
	
	static string[] attackTypeStrings = 
    {
		@"Normal",
	    @"Counter",
	    @"Dizzy",
	    @"Quick",
	    @"SpecialA0",
	    @"SpecialA1",
	    @"SpecialB0",
	    @"SpecialB1",
	    @"None"
    };
	
	
	public static string GetAttackTypeString( AttackType attackType )
	{
	    return attackTypeStrings[(int)attackType];
	}
	
	static Color[] attackTypeColors =
	{
	    Color.red,
	    Color.green,
	    Color.blue,
	    Color.yellow,
	    Color.magenta,
	    Color.gray,
	    Color.cyan,
	    Color.black,
	    Color.white
	};
			
	public static Color GetAttackTypeColor( AttackType attackType )
	{
	    return attackTypeColors[(int)attackType];
	}
	
	static int[] attackTypeScore = 
	{
	    10,
	    15,
	    5,
	    10,
	    15,
	    15,
	    20,
	    20,
	    0
	};
	
	public static int GetAttackTypeScore( AttackType attackType )
	{
	    return attackTypeScore[(int)attackType];
	}
	
	public static bool IsAttackTypeSpecialA( AttackType attackType )
	{
	    bool result = false;
	    if( attackType >= AttackType.SpecialA0 && attackType <= AttackType.SpecialA1 )
	    {
	        result = true;
	    }
	    return result;
	}
	
	public static bool IsAttackTypeSpecialB( AttackType attackType )
	{
	    bool result = false;
	    if( attackType >= AttackType.SpecialB0 && attackType <= AttackType.SpecialB1 )
	    {
	        result = true;
	    }
	    return result;
	}
	
	public static bool IsAttackTypeSpecial( AttackType attackType )
	{
	    bool result = false;
	    if( Pawn.IsAttackTypeSpecialA(attackType) || Pawn.IsAttackTypeSpecialB(attackType) )
	    {
	        result = true;
	    }
	    return result;
	}
	
	public static bool IsAttackTypeSpecial0( AttackType attackType )
	{
	    bool result = false;
	    if( attackType == AttackType.SpecialA0 || attackType == AttackType.SpecialB0 )
	    {
	        result = true;
	    }
	    return result;
	}
	
	public static bool IisAttackTypeSpecial1( AttackType attackType )
	{
	    bool result = false;
	    if( attackType == AttackType.SpecialA1 || attackType == AttackType.SpecialB1 )
	    {
	        result = true;
	    }
	    return result;
	}
	
	
	public Vector3 GetAttackPositionFromPos( Vector3 fromPosition )
	{
	    float pawnAttackPositionOffset = 20.0f;
	    Vector3 attackPosition = transform.position;
	    if( fromPosition.x < transform.position.x )
	    {
	        //attack from the left
	        attackPosition.x -= pawnAttackPositionOffset;
	    }
	    else 
	    {
	        //attack from the left
	        attackPosition.x += pawnAttackPositionOffset;
	    }
	    return attackPosition;
	}

	public void applyDamage( int damage )
	{
	    if( hp > 0 )
	    {
	        int effectiveDamage = damage - defense;
	        hp = hp - effectiveDamage;
	        hp = Mathf.Max(hp, 0);
	        
	        if( hp <= 0 )
	        {
				GameEventManager.PawnDead(this);
	        }
	    }
	}
}
