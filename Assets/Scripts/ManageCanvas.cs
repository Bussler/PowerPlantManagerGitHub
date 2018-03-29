using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManageCanvas : MonoBehaviour {

    public CameraScript cs;

    public GameObject menu1;
    public GameObject StadtMenu;
    
    public ParticleSystem kohleSystem;

    public ParticleSystem atomSystem;

    public ParticleSystem gasSystem;

    public static  bool spawnParticles;

    public static bool umrandungGesetzt = false;

    public static Transform makierungsPosition;
    public GameObject KRAFTWERK;
    //public GameObject Kraftwerk;
    public Vector3 mousePos;
    public GameObject Umrandung;
    GameObject umrandung;
    public LayerMask mask;

    // Use this for initialization
    void Start () {
       umrandung = Instantiate(Umrandung, Vector3.zero, Quaternion.identity);
        umrandung.SetActive(false);
        KRAFTWERK.transform.position = new Vector3(9, 1, 9);
       // SpawnKraftwerk(KRAFTWERK);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("input");
            handleMouseInput(); //method to get mouseinput
        }

    }

    void handleMouseInput()
    {
        Debug.Log("mousehandle");
        if (MouseHover.isOver == true)
        {
            Debug.Log("test3");
            return;
        }
        Debug.Log("test");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("test2");

            

            if (hit.transform.tag.Equals("Plane"))//when clicking on the plane, spawn the normal menu
            {
                Debug.Log("raycasthit");
                //changing the position of the menü
                mousePos = Input.mousePosition;
                menu1.transform.position = mousePos;

                //activating/deactivating the plane
                if (menu1.activeInHierarchy==false)
                {
                    cs.raycast();
                    umrandung.SetActive(true);
                    umrandungGesetzt = true;
                    Vector3 pos = cs.getPositionofObject();
                    umrandung.transform.localScale = cs.getScale();
                    umrandung.transform.SetPositionAndRotation(pos, Quaternion.identity);
                    if (hit.transform.tag.Equals("Plane")) {
                        menu1.SetActive(true);
                    }
                 
                    makierungsPosition = umrandung.transform;

                }
                else
                {
                    menu1.SetActive(false);
                    umrandung.SetActive(false);
                    umrandungGesetzt = false;
                    makierungsPosition = null;
                }

                if (StadtMenu.activeInHierarchy == true)
                {
                    StadtMenu.SetActive(false);
                }

            }
            if (hit.transform.tag.Equals("Stadt"))
            {
                Debug.Log("Stadt");
                mousePos = Input.mousePosition;
                StadtMenu.transform.position = mousePos;
                umrandung.SetActive(true);
                umrandungGesetzt = true;
                Vector3 pos = cs.getPositionofObject();
                umrandung.transform.localScale = cs.getScale();
                umrandung.transform.SetPositionAndRotation(pos, Quaternion.identity);
                makierungsPosition = umrandung.transform;
                if (StadtMenu.activeInHierarchy == false)
                {
                    StadtMenu.SetActive(true);
                }



                if (menu1.activeInHierarchy == true)
                {
                    menu1.SetActive(false);
                }
               
                StadtMenu.transform.GetChild(0).GetComponent<Inputslider>().obj = hit.transform.GetComponent<Stadt>();//giving the city which was selected
                StadtMenu.transform.GetChild(0).GetComponent<Slider>().value = hit.transform.GetComponent<Stadt>().InputStrom/10;//setting slider value
                switch (hit.transform.GetComponent<Stadt>().type)
                {
                    case Stadt.ResourceType.Kohle:
                        StadtMenu.transform.GetChild(1).GetComponent<Dropdown>().value = 0;
                        break;

                    case Stadt.ResourceType.Oil:
                        StadtMenu.transform.GetChild(1).GetComponent<Dropdown>().value = 1;
                        break;

                    case Stadt.ResourceType.Uran:
                        StadtMenu.transform.GetChild(1).GetComponent<Dropdown>().value = 2;
                        break;

                    case Stadt.ResourceType.Metall:
                        StadtMenu.transform.GetChild(1).GetComponent<Dropdown>().value = 3;
                        break;



                }
               
            }



        }

    }
    

    public void SpawnKraftwerk(GameObject GObject)
    {
        Vector3 pos = cs.getPositionofObject();

        if (GObject.GetComponent<Stromverbindung>())
        {
            if (REsourceManager.Metall >= 20)
            {
                REsourceManager.Metall -= 20;
            }
            else
            {
                return;
            }

        }


        if (CameraScript.grid[(int)(pos.x), (int)(pos.z)] == null)
        {
            GameObject kraft = Instantiate(GObject, pos, GObject.transform.rotation);

            CameraScript.grid[(int)(kraft.transform.position.x), (int)(kraft.transform.position.z)] = kraft;

            kraft.transform.localScale *= (cs.getScale().x);
            if (spawnParticles)
            {
                //Wenn das Objekt ein Kohlekraftwerk ist, spawne ein Kohlepartikelsystem etwas darüber
                if (GObject.tag == "Kohle")
                {
                    Instantiate(kohleSystem, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
                }//Wenn das Objekt ein Atomkraftwerk ist, spawne ein Atompartikelsystem etwas darüber
                else if (GObject.tag == "Atom")
                {
                    Instantiate(atomSystem, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
                }//Wenn das Objekt ein Gaskraftwerk ist, spawne ein Gaskraftwerksystem etwas darüber
                else if (GObject.tag == "Gas")
                {
                    Instantiate(gasSystem, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
                }
            }
        }

        menu1.SetActive(false);
        MouseHover.isOver = false;
    }


    public void activateParticles() {
        if (spawnParticles){
            spawnParticles = false;
        }
        else{
            spawnParticles = true;
        }
    }
}
