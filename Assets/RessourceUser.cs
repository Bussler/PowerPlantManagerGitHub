using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceUser : MonoBehaviour {
	public Dictionary<string, int> currRessources = new Dictionary<string, int>();
	public Dictionary<string, int> maxRessourceCapacity = new Dictionary<string, int>();
	public Dictionary<string, int> ressourceGainPerMinute = new Dictionary<string, int>();
	public Dictionary<string, int> ressorceConsumption = new Dictionary<string, int>();
	public Dictionary<string, int> receivedRessources = new Dictionary<string, int>();
	public float lastGainTime = 0f;
	private int timeBetweenEnergyGains = 10;
	// public int energyConsumption = 0;
	public int currentlyReceivedEnergy = 0;

	public void TryGainRessources()
	{
		
		if (Time.time > lastGainTime + timeBetweenEnergyGains)
		{
			foreach (string res in ressourceGainPerMinute.Keys)
			{
				if (ressourceGainPerMinute.ContainsKey(res))
					if (ressourceGainPerMinute[res] > 0)
					{
						currRessources[res] += ressourceGainPerMinute[res] / 60 * timeBetweenEnergyGains;
						print("Gained " + ressourceGainPerMinute[res] * timeBetweenEnergyGains / 60 + " energy");
						if (currRessources[res] > maxRessourceCapacity[res])
							currRessources[res] = maxRessourceCapacity[res];
					}
			}
			lastGainTime = Time.time;
		}
	}

	public void setRessource(String res, int curr, int maxCapac, int gain)
	{
		currRessources[res] = curr;
		maxRessourceCapacity[res] = maxCapac;
		ressourceGainPerMinute[res] = gain;
	}

	public int getRessource(String res)
	{
		if (currRessources.ContainsKey(res))
		{
			return currRessources[res];
		}

		return 0;
	}
}
