using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isocam : MonoBehaviour{

	private Camera camera;

	private float cameraStartSize;

	public float zoomSpeed;
	// Use this for initialization
	void Start () {
		camera = this.GetComponent<Camera>();
		camera.orthographicSize = cameraStartSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.E)){
			if (camera.orthographicSize > 0){
				camera.orthographicSize = (camera.orthographicSize - zoomSpeed)*Time.deltaTime;
			}
		}else if (Input.GetKey((KeyCode.Q))){
			if (camera.orthographicSize < 20){
				camera.orthographicSize = (camera.orthographicSize + zoomSpeed) * Time.deltaTime;
			}
		}
	}
}
