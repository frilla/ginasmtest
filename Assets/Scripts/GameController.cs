using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private PawnPlayer playerPawn;
	private PawnPlayerController playerController;
	private GameObject mc;

	// Use this for initialization
	void Start () 
	{
		GameEventManager.OnPawnSpawned += OnPawnSpawned;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( mc != null )
		{
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) {
					Vector3 touchPos = touch.position;
					touchPos.z = -Camera.main.transform.localPosition.z;
					Vector3 worldPos = Camera.main.ScreenToWorldPoint (touchPos);
					
					Debug.Log(worldPos.ToString());
					
					float distance = Vector3.Distance (worldPos, mc.transform.position);
					Debug.Log(distance.ToString());
					if( distance < 200.0f )
					{
						Debug.Log("adfadfafds");
//						Rigidbody rb = mc.GetComponent<Rigidbody>();
//						rb.AddForce(0f, 50f, 0f, ForceMode.Impulse);
					}
				}
			}
		}
	}
	
	public void OnPawnSpawned(Pawn pawn)
	{
		if( !pawn.isEnemy )
		{
			playerPawn = pawn.GetComponent<PawnPlayer>();
			if( playerPawn )
			{
				mc = playerPawn.gameObject;
				Debug.Log("Found player pawn component");
			}
			playerController = pawn.GetComponent<PawnPlayerController>();
			if( playerController )
			{
				Debug.Log("Found player controller component");
			}
		}
	}
}
