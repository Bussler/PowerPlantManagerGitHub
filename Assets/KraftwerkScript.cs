using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraftwerkScript : RessourceUser
{		

	void Start ()
	{
		setRessource("energy", 50, 100, 20);
		
	}
	
	void Update () {
		TryGainRessources();
	}
}
