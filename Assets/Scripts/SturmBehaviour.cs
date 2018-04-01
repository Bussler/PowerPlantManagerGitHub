using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturmBehaviour : MonoBehaviour {

    public float dangerLevel;
    private float timeActive;//var for measuring active time
    public float duration;//active time
    private float time=0;

	// Use this for initialization
	void Start () {
        Renderer r = gameObject.GetComponent<Renderer>();
        Color materialColor = r.material.color;
        r.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, 0.5f);//changing alpha value to 0.4, therefore making it transparent
	}
	
	// Update is called once per frame
	void Update () {
        timeActive = timeActive + Time.deltaTime;
        if (timeActive>=duration)
        {
            this.gameObject.SetActive(false);
            timeActive = 0;
        }

        time = time + Time.deltaTime;
        if (time>=REsourceManager.timeIntervall)
        {
            //do danger stuff here
            if (REsourceManager.strom>=dangerLevel)
            {
                REsourceManager.strom -= dangerLevel;
            }
            if (REsourceManager.Oil >= dangerLevel)
            {
                REsourceManager.Oil-= dangerLevel;
            }
            if (REsourceManager.Uran >= dangerLevel)
            {
                REsourceManager.Uran -= dangerLevel;
            }
            if (REsourceManager.Uran >= dangerLevel)
            {
                REsourceManager.Uran -= dangerLevel;
            }
            time = 0;
        }

	}
}
