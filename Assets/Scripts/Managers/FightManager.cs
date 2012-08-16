using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
	
	public static FightManager instance;
	
	public void Awake()
	{
		FightManager.instance = this;
	}

	// Use this for initialization
	void Start () {
		Instantiate(Resources.Load("Gina"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
