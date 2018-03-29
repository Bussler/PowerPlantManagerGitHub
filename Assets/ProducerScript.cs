using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerScript : RessourceUser
{
	public int lv;
	public ProducerType type = ProducerType.coalmine;

	public ProducerScript(ProducerType type, int lv = 1)
	{
		this.type = type;
		this.lv = lv;
	}

	public void init()
	{
		if (type == ProducerType.residents)
		{
			setRessource("people", 0, 20, 0);
			ressorceConsumption["energy"] = 20;
		} else if (type == ProducerType.coalmine)
		{
			setRessource("coal", 0, 50, 10);
			ressorceConsumption["energy"] = 20;
			ressorceConsumption["people"] = 5;
		} else if (type == ProducerType.oildrill)
		{
			setRessource("oil", 0, 120, 15);
			ressorceConsumption["energy"] = 20;
			ressorceConsumption["people"] = 5;
		} else if (type == ProducerType.solarplant)
		{
			setRessource("energy", 0, 10, 5);
			ressorceConsumption["people"] = 5;
		}
	}
}

public enum ProducerType {
	residents, coalmine, oildrill, solarplant
}
