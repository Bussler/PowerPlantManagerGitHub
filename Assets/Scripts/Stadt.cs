using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stadt : MonoBehaviour {


    public enum ResourceType
    {
        Oil,
        Metall,
        Uran,
        Kohle


    }

    public float stadtBonus=1;

    public ResourceType type;
    public float InputStrom;
    public bool istAngeschlossen;
    private float time = 0;

    public float baseProduktion;
    private CameraScript cs;
    private bool hasInstantiated;

    // Use this for initialization
    void Start () {
        cs = FindObjectOfType<CameraScript>();
       
        this.transform.localScale *= (cs.getScale().x);
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasInstantiated)
        {
            CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z)] = this.gameObject;
            hasInstantiated = true;
        }
        time = time + Time.deltaTime;
        if (time >= REsourceManager.timeIntervall) //checked ob die vorgegebene zeit vorbei ist
        {
            generateResource();
            time = 0;
        }

        if (istAngeschlossen == false)
        {
            checkStrom();
        }

    }

    void checkStrom()
    {
        if (CameraScript.grid[(int)transform.position.x,(int)transform.position.z+2]!=null&& CameraScript.grid[(int)transform.position.x, (int)transform.position.z+2].GetComponent<Stromverbindung>()&& CameraScript.grid[(int)transform.position.x, (int)transform.position.z+2].GetComponent<Stromverbindung>().hasStrom==true)
        {
            istAngeschlossen = true;
        }
        if (CameraScript.grid[(int)transform.position.x, (int)transform.position.z-2] != null && CameraScript.grid[(int)transform.position.x, (int)transform.position.z-2].GetComponent<Stromverbindung>() && CameraScript.grid[(int)transform.position.x, (int)transform.position.z-2].GetComponent<Stromverbindung>().hasStrom == true)
        {
            istAngeschlossen = true;
        }
        if (CameraScript.grid[(int)transform.position.x+2, (int)transform.position.z] != null && CameraScript.grid[(int)transform.position.x+2, (int)transform.position.z].GetComponent<Stromverbindung>() && CameraScript.grid[(int)transform.position.x+2, (int)transform.position.z].GetComponent<Stromverbindung>().hasStrom == true)
        {
            istAngeschlossen = true;
        }
        if (CameraScript.grid[(int)transform.position.x-2, (int)transform.position.z] != null && CameraScript.grid[(int)transform.position.x-2, (int)transform.position.z].GetComponent<Stromverbindung>() && CameraScript.grid[(int)transform.position.x-2, (int)transform.position.z].GetComponent<Stromverbindung>().hasStrom == true)
        {
            istAngeschlossen = true;
        }
    }


    public void generateResource() // je nach typ wird die entsprechende Resource generiert
    {
        if (InputStrom != 0)
        {
            switch (type)
            {


                case ResourceType.Oil:
                    REsourceManager.Oil += (10+stadtBonus) * InputStrom/7;
                    break;

                case ResourceType.Kohle:
                    REsourceManager.Kohle += (6+stadtBonus) * InputStrom/7;
                    break;

                case ResourceType.Uran:
                    REsourceManager.Uran += (4+stadtBonus) * InputStrom/7;
                    break;

                case ResourceType.Metall:
                    REsourceManager.Metall += (2+stadtBonus) * InputStrom/7;
                    break;

                default:

                    break;
            }
        }
    }



    public void ChangeInputStrom(float input)
    {
        if (istAngeschlossen==false)//wenn kein strom vorhanden ist, soll strom nicht verändert werden können
        {
            return;
        }

        if (input>InputStrom)//vergrößeren eingabe
        {
            if (REsourceManager.usedStrom+(input-InputStrom)<=REsourceManager.strom)
            {
                REsourceManager.usedStrom += (input - InputStrom);//statische variable aktualisieren
            }
            else
            {
                return;
                //float diff = REsourceManager.strom - REsourceManager.usedStrom;
                //InputStrom = diff;//auf groestmoeglichen strom setzen
                //REsourceManager.usedStrom = REsourceManager.strom;
            }

        }
        else//veerkleinere eingabe
        {
            REsourceManager.usedStrom -= (InputStrom-input);
            
        }
        this.InputStrom = input;//changing input strom according to param
    }
}
