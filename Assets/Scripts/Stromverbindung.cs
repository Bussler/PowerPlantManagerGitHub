using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stromverbindung : MonoBehaviour {
    public bool hasStrom;
    private bool oben;
    private bool unten;
    private bool links;
        private bool rechts;
    public LayerMask mask;
    public CameraScript cs;
    public bool hasChecked;


    List<Pair> helperList = new List<Pair>();
   

	// Use this for initialization
	void Start () {

        //cs = FindObjectOfType<CameraScript>();
        
        foreach(Stromverbindung s in FindObjectsOfType<Stromverbindung>())
        {
            s.hasChecked = false;
        }
        //Debug.Log(""+CheckStrom());
        //hasStrom = CheckStrom();
        hasStrom = RecSuchen((int)transform.position.x,(int)transform.position.z);
        stromUpdaten((int)transform.position.x, (int)transform.position.z);

        if (hasStrom && name != "Gaskraftwerk 0(Clone)" && name != "Atomkraftwerk(Clone)")
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        hasChecked = false;
        

    }
	
	// Update is called once per frame
	void Update () {
        
        if (hasStrom && name != "Gaskraftwerk 0(Clone)" && name != "Atomkraftwerk(Clone)")
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    public void UpdateModel()
    {


    }

    public bool CheckStrom()
    {
        hasChecked=true;
       // Debug.Log("CheckStrom");
        //Debug.Log(this.transform.position.x + "," + this.transform.position.z);
        if(CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)] .GetComponent<Kraftwerk>())
            {
                hasStrom = true;   
                return true;
                
            }
            
        }
        if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)].GetComponent<Kraftwerk>())
            {
                hasStrom = true;
                return true;
            }
        }
        if (CameraScript.grid[(int)(this.transform.position.x ), (int)(this.transform.position.z-2)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z - 2)].GetComponent<Kraftwerk>())
            {
                hasStrom = true;
                return true;
            }
        }
        if (CameraScript.grid[(int)(this.transform.position.x ), (int)(this.transform.position.z+2)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)].GetComponent<Kraftwerk>())
            {
                hasStrom = true;
                return true;
                
            }

        }
        if (CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>())
            {
                if((CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().hasStrom == true))
                {
                    return true;
                }else
                if (CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().hasChecked == false)
                {
                    if (CameraScript.grid[(int)(this.transform.position.x + 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().CheckStrom() == true)
                    {
                        hasStrom = true;
                        return true;
                    }
                }
            }
        }
            if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)] != null)
            {
                if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>())
                {
                if ((CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().hasStrom == true))
                {
                    return true;
                }
                else
                if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().hasChecked == false)
                {
                    if (CameraScript.grid[(int)(this.transform.position.x - 2), (int)(this.transform.position.z)].GetComponent<Stromverbindung>().CheckStrom() == true)
                {
                    hasStrom = true;
                        return true;
                }
                }
            }

            if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)] != null)
            {
                if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)].GetComponent<Stromverbindung>()) {

                    if ((CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)].GetComponent<Stromverbindung>().hasStrom == true))
                    {
                        return true;
                    }else
                    if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)].GetComponent<Stromverbindung>().hasChecked == false)
                    {
                        
                       
                        if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z + 2)].GetComponent<Stromverbindung>().CheckStrom() == true)
                        {
                            hasStrom = true;
                            return true;
                        }
                    }
                }
            }
        }
        if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z - 2)] != null)
        {
            if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z - 2)].GetComponent<Stromverbindung>())
            {
                if ((CameraScript.grid[(int)(this.transform.position.x ), (int)(this.transform.position.z-2)].GetComponent<Stromverbindung>().hasStrom == true))
                {
                    return true;
                }
                else
                if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z - 2)].GetComponent<Stromverbindung>().hasChecked == false)
                {
                    if (CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z - 2)].GetComponent<Stromverbindung>().CheckStrom() == true)
                    {
                        hasStrom = true;
                        return true;
                    }
                }
            }
        }
        Debug.Log("keine verbindung");
            return false;
        
    }


    public bool RecSuchen(int x, int y)
    {
        //stromkraftwerk suchen
        if (CameraScript.grid[x, y + 2]!=null&&CameraScript.grid[x,y+2].GetComponent<Kraftwerk>()) {
            return true;
        }
        else
        {
            if (CameraScript.grid[x, y-2] != null && CameraScript.grid[x, y - 2].GetComponent<Kraftwerk>())
            {
                return true;
            }
            else
            {
                if (CameraScript.grid[x+2, y] != null && CameraScript.grid[x+2, y].GetComponent<Kraftwerk>())
                {
                    return true;
                }
                else
                {
                    if (CameraScript.grid[x-2, y] != null && CameraScript.grid[x - 2, y].GetComponent<Kraftwerk>())
                    {
                        return true;
                    }
                }
            }
        }

        //aktives kraftwerk suchen
        if (CameraScript.grid[x, y + 2] != null && CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>()&& CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasStrom==true)
        {
            return true;
        }
        else
        {
            if (CameraScript.grid[x, y - 2] != null && CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>()&& CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasStrom == true)
            {
                return true;
            }
            else
            {
                if (CameraScript.grid[x + 2, y] != null && CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>()&& CameraScript.grid[x+2, y ].GetComponent<Stromverbindung>().hasStrom == true)
                {
                    return true;
                }
                else
                {
                    if (CameraScript.grid[x - 2, y] != null && CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>()&& CameraScript.grid[x-2, y ].GetComponent<Stromverbindung>().hasStrom == true)
                    {
                        return true;
                    }
                }
            }
        }

        //stromleitung suchen und zu arraylist hinzufuegen
        if (CameraScript.grid[x, y + 2] != null && CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>()&& CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasChecked==false)
        {
            CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().RecSuchen(x,y+2);

            Pair pair = new Pair(x, y + 2);
            CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasChecked = true;
            helperList.Add(pair);

        }
        
            if (CameraScript.grid[x, y - 2] != null && CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>()&& CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasChecked==false)
            {
            CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().RecSuchen(x, y - 2);

            Pair pair = new Pair(x, y - 2);
                CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasChecked = true;
                helperList.Add(pair);
            }
            
                if (CameraScript.grid[x+2, y ] != null && CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>()&& CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>().hasChecked==false)
                {
                CameraScript.grid[x+2, y].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x+2, y ].GetComponent<Stromverbindung>().RecSuchen(x+2, y );

                Pair pair = new Pair(x+2,y);
                    CameraScript.grid[x+2, y].GetComponent<Stromverbindung>().hasChecked = true;
                    helperList.Add(pair);
                }
                
                    if (CameraScript.grid[x-2, y ] != null && CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>()&& CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>().hasChecked==false)
                    {
                         CameraScript.grid[x-2, y ].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x-2, y].GetComponent<Stromverbindung>().RecSuchen(x-2, y);

                         Pair pair = new Pair(x-2, y);
                        CameraScript.grid[x-2, y].GetComponent<Stromverbindung>().hasChecked = true;
                        helperList.Add(pair);
                    }


        if (helperList.Count-1>=0)//es sind noch moegliche evrbindungen vorhanden
        {
            Pair current = helperList[helperList.Count - 1];//taking next possible element
            helperList.RemoveAt(helperList.Count - 1);//removing
            return RecSuchen(current.getX(), current.getY());
        }

        return false;//TODO
    }

    void stromUpdaten(int x, int y)
    {
        if (CameraScript.grid[x, y + 2] != null && CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>() && CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasChecked == false)
        {
            CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().RecSuchen(x, y + 2);
            CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasChecked = true;


            if (CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().hasStrom == true)
            {
                CameraScript.grid[x, y + 2].GetComponent<Stromverbindung>().stromUpdaten(x, y + 2);
            }
    

        }


        if (CameraScript.grid[x, y - 2] != null && CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>() && CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasChecked == false)
        {
            CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().RecSuchen(x, y - 2);
            CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasChecked = true;

            if (CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().hasStrom==true)
            {
                CameraScript.grid[x, y - 2].GetComponent<Stromverbindung>().stromUpdaten(x,y-2);
            }
            
        }

        if (CameraScript.grid[x + 2, y] != null && CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>() && CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>().hasChecked == false)
        {
            CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>().RecSuchen(x + 2, y);
            CameraScript.grid[x + 2, y].GetComponent<Stromverbindung>().hasChecked = true;


            if (CameraScript.grid[x+2, y].GetComponent<Stromverbindung>().hasStrom == true)
            {
                CameraScript.grid[x+2, y].GetComponent<Stromverbindung>().stromUpdaten(x+2, y);
            }
    

        }

        if (CameraScript.grid[x - 2, y] != null && CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>() && CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>().hasChecked == false)
        {
            CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>().hasStrom = CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>().RecSuchen(x - 2, y);
            CameraScript.grid[x - 2, y].GetComponent<Stromverbindung>().hasChecked = true;

            if (CameraScript.grid[x-2, y].GetComponent<Stromverbindung>().hasStrom == true)
            {
                CameraScript.grid[x-2, y].GetComponent<Stromverbindung>().stromUpdaten(x-2, y);
            }
    

        }
    }

    private void OnDestroy()
    {
        
    }
}
