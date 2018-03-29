using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public int size = 10;
    public int planeSize;
    int currWidth, currHeight;
    float fieldSize;
    public LayerMask mask;
    static public GameObject[,] grid;

	// Use this for initialization
	void Start () {
        grid = new GameObject[planeSize * 2, planeSize * 2];
	}
    public Vector3 getScale() {
        return new Vector3((float)(planeSize / size), (float)(planeSize / size), (float)(planeSize / size));
    }
  

        public Vector3 getPositionofObject() {
        int usedWidth = currWidth;
        int usedHeight = currHeight;

        Vector3 Position = new Vector3(usedWidth * fieldSize + fieldSize/2, 1, usedHeight * fieldSize - fieldSize/2);

        return Position;
    }
    public void raycast() {
        RaycastHit pos_hit, obj_hit;
        Ray pos_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray obj_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(pos_ray.origin, pos_ray.direction, out pos_hit, 100.0f, mask.value);
        //Physics.Raycast(pos_ray.origin, pos_ray.direction, out obj_hit, 100.0f);

        if (pos_hit.transform != null)
        {
            // Debug.Log("Hit :" + pos_hit.point.ToString() + pos_hit.transform.tag);
            fieldSize = planeSize / size;

            currWidth = (int)(pos_hit.point.x / fieldSize);
            currHeight = (int)(pos_hit.point.z / fieldSize) + 1;

            if (pos_hit.transform.gameObject.tag.Equals("Plane"))
            {
                Debug.Log(currWidth + "," + currHeight + pos_hit.transform.gameObject.name);
            }



        }
    }
        // Update is called once per frame
        void Update()
    {
      
        if (Input.GetMouseButtonDown(0)&&!MouseHover.isOver)
        {

            raycast();
        }
    }
}
