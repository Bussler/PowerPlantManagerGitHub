using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Kraftwerk : MonoBehaviour {

    public float stromErzeugung;
    public static float stromPerMinute=0;

    public bool canKohle;
    public bool canOil;
    public bool canUran;

    private float time=0;

    public int level;
    public int winLevel;
    public float stromToNextLevel;
    public float levelCapVorher;
    public float LevelFactor;

    public float cost;
    public bool hasInstantiated= false;
    public GameObject levelUpButtons;
    private CameraScript cs;

    public GameObject prefabOil;
    public GameObject prefabAtom;
    private float kohleBonus = 3;
    private float oelBonus = 4;
    private float uranBonus = 6;
	// Use this for initialization
	void Start () {
        cs = FindObjectOfType<CameraScript>();
        levelCapVorher = stromToNextLevel;
        Debug.Log((int)(this.transform.position.x));
        this.transform.localScale *= (cs.getScale().x);

    }
	
	// Update is called once per frame
	void Update () {
        if (!hasInstantiated)
        {
            CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z)] = this.gameObject;
            hasInstantiated = true;
        }
        //Debug.Log(CameraScript.grid[(int)(this.transform.position.x), (int)(this.transform.position.z)].name);
        time = time + Time.deltaTime;
        if (time >= REsourceManager.timeIntervall)
        {
            generateStrom();
            time = 0;
        }
        if (stromToNextLevel <= 0)
        {
            level++;

            if (level>=winLevel)
            {
                //winscene
                // Application.Quit();
                SceneManager.LoadScene(3);
            }

           levelCapVorher *= LevelFactor;
            stromToNextLevel = levelCapVorher;
            stromErzeugung += 1;
            levelUpButtons.SetActive(true); 
        }

        //berechnen des stromPerMinute, um zu berechnen, wie viel strom reduziert werden muss, wenn dieser im REsourcemanager 0 erreicht
        //yea, I know its ugly but I wanted to implement this fast and its not like we produced the best code ever in this project, so here we go
        if (canKohle==false&&canOil==false&&canUran==false)
        {
            stromPerMinute = stromErzeugung;
        }
        else
        {
            if (canKohle && canOil && canUran)
            {
                stromPerMinute = kohleBonus + oelBonus + uranBonus + stromErzeugung;
            }
            else
            {
                if (canKohle && canOil)
                {
                    stromPerMinute = kohleBonus + oelBonus + stromErzeugung;
                }
                else
                {
                    if (canKohle && canUran)
                    {
                        stromPerMinute = kohleBonus + uranBonus + stromErzeugung;
                    }
                    else
                    {
                        if (canUran && canOil)
                        {
                            stromPerMinute =oelBonus + uranBonus + stromErzeugung;
                        }
                        else
                        {
                            if (canUran)
                            {
                                stromPerMinute = uranBonus + stromErzeugung;
                            }
                            if (canOil)
                            {
                                stromPerMinute = oelBonus + stromErzeugung;
                            }
                            if (canKohle)
                            {
                                stromPerMinute = kohleBonus + stromErzeugung;
                            }
                        }
                    }
                }
            }
        }

        

	}

    public void generateStrom()
    {
        if (canKohle)
        {
            GenerateStromfromKohle();
        }
        if (canUran)
        {
            GenerateStromfromUran();
        }
        if (canOil)
        {
            GenerateStromfromOil();
        }
        GenerateStromNormal();


    }

    public void GenerateStromNormal()
    {
        REsourceManager.strom += stromErzeugung;
        stromToNextLevel -= stromErzeugung;
     
    }

    public void GenerateStromfromUran()
    {
        
        if (REsourceManager.Uran >= cost)
        {
            REsourceManager.strom += uranBonus;
            stromToNextLevel -= uranBonus;
            REsourceManager.Uran -= cost;
        }
    }
    public void GenerateStromfromOil()
    {
        if (REsourceManager.Oil >= cost)
        {
            REsourceManager.strom += oelBonus;
            stromToNextLevel -= oelBonus;
            REsourceManager.Oil -= cost;
        }
    }
    public void GenerateStromfromKohle()
    {
            if (REsourceManager.Kohle >= cost)
            {
            REsourceManager.strom += kohleBonus;
            stromToNextLevel -= kohleBonus;
            REsourceManager.Kohle -= cost;
        }
    }
    
    public void LevelUps(int typ) {
        Debug.Log(typ);
        levelUpButtons.SetActive(false);
        if (typ == 0){
            if (canKohle){
                kohleBonus += 1;
            }
            else{
                canKohle = true;
            }
        }else if (typ == 1){
            if (canOil){
                oelBonus += 1;
            }
            else{
                canOil = true;
                GameObject kw = Instantiate(prefabOil, new Vector3(cs.planeSize / cs.size * 6 + cs.planeSize/cs.size/2, 1, cs.planeSize / cs.size * 6 - cs.planeSize/cs.size/2), Quaternion.identity );
                kw.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
                kw.SetActive(true);
                GameObject g = CameraScript.grid[13, 11];
                if (g != null){
                    Destroy(g);
                }

                CameraScript.grid[13, 11] = kw;
            }
        }
        else if(typ == 2){
            if (canUran){
                uranBonus += 1;
            }
            else{
                canUran = true;
                GameObject kw = Instantiate(prefabAtom, new Vector3(cs.planeSize / cs.size * 7 + (cs.planeSize/cs.size/2 -0.05f), 1, cs.planeSize / cs.size * 5 - cs.planeSize/cs.size/2), Quaternion.identity );
                kw.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
                kw.SetActive(true);
                GameObject g = CameraScript.grid[15, 9];
                if (g != null){
                    Destroy(g);
                }
                CameraScript.grid[15, 9] = kw;
            }
        }
    }
}
