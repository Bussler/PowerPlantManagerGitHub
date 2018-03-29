using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageScript : RessourceUser
{
	public SettlementType type = SettlementType.village;
	public int happyness = 50;
	private float lastHappynessChange = 0;
	public int timeBetweenHappynessChanges = 60;
	public ProducerScript[] producers;
	
	public VillageScript(SettlementType type)
	{
		this.type = type;
	}

	public void init()
	{
		if (type == SettlementType.village)
		{
			producers = new ProducerScript[3];
			producers[0] = new ProducerScript(ProducerType.residents);
		} else if (type == SettlementType.village)
		{
			producers = new ProducerScript[5];
			producers[0] = new ProducerScript(ProducerType.residents, 3);
		}
	}

	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
		TryGainRessources();
		if (Time.time > lastHappynessChange + timeBetweenHappynessChanges)
		{
			if (getRessource("energy") < 30)
			{
				happyness -= 5;
			}
		}
	}
}

public enum SettlementType
{
	village, city
}
