using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class REsourceManager : MonoBehaviour {

    static public float strom;//vorhandener Strom
    static public float usedStrom;//benutzter strom

    static public  float Metall;
    static public  float Oil;
    static public  float Uran;
    static  public float Kohle;
	public bool showParticles = ManageCanvas.spawnParticles;
	
    public Text textMetall;
    public Text textKohle;
    public Text textOil;
    public Text textStrom;
    public Text textUran;
    public Text textUsedStrom;
    public Text timer;

    public static float timeIntervall=1;
    private float time = 0;

    public float stoppuhr = 600.0f;//10 min
    private float timeStoppuhr = 0;

    public GameObject[] Städte = new GameObject[4];



    // Update is called once per frame
    void Update () {

        //caps
        if (strom>=99)
        {
            strom = 99;
        }
        if (Metall>=99)
        {
            Metall = 99;
        }
        if (Oil >= 99)
        {
            Oil = 99;
        }
        if (Uran>=99)
        {
            Uran = 99;
        }
        if (Kohle>=99)
        {
            Kohle = 99;
        }

        //subtrakting the usedstrom from strom
        time = time + Time.deltaTime;
        if (time >= timeIntervall) //checked ob die vorgegebene zeit vorbei ist
        {
            if (strom-usedStrom<0)
            {
                strom = 0;
                //TODO zufaelliges Ressourcenkraftwerk input so weit runterregeln, dass wieder auf null liegt
                //-> z.b. auf ein zufaelliges kraftwerk im 2d array zugreifen: Methode schreiben, die nach 
                //parameteruebergabe so lange zufaellige kraftwerke auswaehlt und deren inputstrom absenkt, bis
                //paramter strom gespart wurde
            }
            else
            {
                strom -= usedStrom;
            }
            
            time = 0;
        }

        textMetall.text =""+ (int) Metall;
        textOil.text = ""+ (int)  Oil;
        textStrom.text = "" + (int) strom;
        textUran.text = "" + (int) Uran;
        textKohle.text = "" + (int) Kohle;
        textUsedStrom.text = "" +(int) usedStrom;

        ManageCanvas.spawnParticles = showParticles;
    }

    private void FixedUpdate()
    {
        timeStoppuhr = timeStoppuhr + Time.deltaTime;
        if (timeStoppuhr>=1)
        {
            for (int i=0;i<Städte.Length;i++)
            {
                if (Städte[i].GetComponent<Stadt>().istAngeschlossen==false)//stadt ist noch nicht angeschlossen, also wird weniger zeit gegeben
                {
                    stoppuhr -= 0.5f;
                }
            }


            stoppuhr -= 1.0f;
            timeStoppuhr = 0;
        }

        timer.text = "Time left: " + stoppuhr;
        if (stoppuhr<=0)
        {
            //lose scene
            SceneManager.LoadScene(2);
        }
    }


}


