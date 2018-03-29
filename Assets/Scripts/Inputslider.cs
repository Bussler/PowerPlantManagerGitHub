using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputslider : MonoBehaviour {

    public Stadt obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change()
    {
        obj.ChangeInputStrom(this.GetComponent<Slider>().value*10);
    }

    public void Drop()
    {
        switch (FindObjectOfType<Dropdown>().value)
        {

            case 0:
                obj.type = Stadt.ResourceType.Kohle;
                break;

            case 1:
                obj.type = Stadt.ResourceType.Oil;
                break;

            case 2:
                obj.type = Stadt.ResourceType.Uran;
                break;

            case 3:
                obj.type = Stadt.ResourceType.Metall;
                break;


        }

    }



}
