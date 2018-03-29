using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {

    public MeshRenderer renderer;
    public float time;
    private float ran;
    private float add=0.02f;
	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        time = time + Time.deltaTime;
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + add * Time.deltaTime, renderer.material.mainTextureOffset.y + 0.2f * Time.deltaTime);
        if (time > 5)
        {
            ran = Random.Range(-0.1f, 0.1f);
            if (ran > 0)
            {
                add = 0.2f;
            }
            else
            {
                add = -0.2f;
            }
            time = 0;
        }
	}
}
