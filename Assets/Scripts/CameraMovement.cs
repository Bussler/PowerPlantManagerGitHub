using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

	private bool cameraSwitchDone = false;
	private Quaternion topDownRotation;
	private Camera camera;
	private float cameraStartSize;
	
	public GameObject toRotation;
	public bool isIsometric = false;
	public float bewegungsGeschwindigkeitTopDown;
	public float bewegungsGeschwindigkeitIsometric;
	public float zoomGeschwindigkeitTopDown;

	// Use this for initialization
	void Start() {
		//Fixe Rotation, für die Transistion zwischen den Modi genutzt wird
		topDownRotation = transform.rotation;
		//Camercomponent speichern
		camera = this.GetComponent<Camera>();
	}

	private void Update() {
		//Bei F1 wird zwischen isometrischer und TopDown View gewechselt
		if (Input.GetKeyDown(KeyCode.F1)){
			if (isIsometric){
				isIsometric = false;
				cameraSwitchDone = false;
			}
			else{
				cameraSwitchDone = false;
				isIsometric = true;
			}
		}

		//Sind wir TopDown oder Isometrisch?
		if (!isIsometric){
			//sind wir bei der Standard 
			if (transform.rotation.x == topDownRotation.x){
				//TopDown 
				//Bewegung
				//W A S D für die Bewegung, aktuell ist keine Drehung möglich in Top Down
				//Aktuelle Grenzen nach links und oben 5 EInheiten, nach rechts und unten 20 -> gleichermaßen in alle Richtungen
				if (Input.GetKey(KeyCode.W)){
					if (transform.position.z < 20){
						transform.Translate(0, bewegungsGeschwindigkeitTopDown * Time.deltaTime, 0);
					}
				}
				else if (Input.GetKey(KeyCode.S)){
					if (transform.position.z > -5){
						transform.Translate(0, -bewegungsGeschwindigkeitTopDown * Time.deltaTime, 0);
					}
				}

				if (Input.GetKey(KeyCode.D)){
					if (transform.position.x < 20){
						transform.Translate(bewegungsGeschwindigkeitTopDown * Time.deltaTime, 0, 0);
					}
				}
				else if (Input.GetKey((KeyCode.A))){
					if (transform.position.x > -5){
						transform.Translate(-bewegungsGeschwindigkeitTopDown * Time.deltaTime, 0, 0);
					}
				}

				//Zoom
				//Q = reinzoomen, E = rauszoomen
				if (Input.GetKey((KeyCode.E))){
					if (transform.position.y > 3.0f){
						transform.Translate(0, 0, zoomGeschwindigkeitTopDown * Time.deltaTime);
					}
				}
				else if (Input.GetKey((KeyCode.Q))){
					if (transform.position.y < 25){
						transform.Translate(0, 0, -zoomGeschwindigkeitTopDown * Time.deltaTime);
					}
				}
			}
			else{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, topDownRotation, 100f*Time.deltaTime);
			}
		}
		else{
			//wir müssen checken, ob wir uns fertig rotiert haben, dann dürfen wir uns bewegen
			if (transform.rotation.x == toRotation.transform.rotation.x){
				cameraSwitchDone = true;
			}
			//Sind wir fertig rotiert?
			if (cameraSwitchDone){
				//Steuerung: W nach vorner, S nach Hinten, A(ohne Objekt) um sich selbst nach links drehen, S(ohne Objekt) um sich selbst nach rechts drehen
				//Steuerung: Q nach unten drehen, E nach oben rotieren, A(mit fokussiertem Objekt) um das Objekt ach links drehen, D(mit fokussiertem Objekt) um das Objekt nach rechts drehen
				if (Input.GetKey(KeyCode.W)){
					//Boundaries für y Koordinaten
					if (transform.position.y < 3.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, 3.0f, transform.position.z), transform.rotation );
					}else if (transform.position.y > 25.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, 25.0f, transform.position.z), transform.rotation );
					}
					//Boundaries für x Koordinaten
					if (transform.position.x < -5){
						transform.SetPositionAndRotation(new Vector3(-5, transform.position.y, transform.position.z), transform.rotation );
					}else if (transform.position.x > 25){
						transform.SetPositionAndRotation(new Vector3(25.0f, transform.position.y, transform.position.z), transform.rotation );
					}
					//Boundaries für z Koordinaten
					if (transform.position.z < -5){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, -5.0f), transform.rotation );
					}else if (transform.position.z > 25.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 25.0f), transform.rotation );
					}
					
					transform.Translate(Vector3.forward*Time.deltaTime*bewegungsGeschwindigkeitIsometric);
					
				}else if (Input.GetKey(KeyCode.S)){
					//Boundaries für y Koordinaten
					if (transform.position.y < 3.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, 3.0f, transform.position.z), transform.rotation );
					}else if (transform.position.y > 25.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, 25.0f, transform.position.z), transform.rotation );
					}
					//Boundaries für x Koordinaten
					if (transform.position.x < -5){
						transform.SetPositionAndRotation(new Vector3(-5, transform.position.y, transform.position.z), transform.rotation );
					}else if (transform.position.x > 25){
						transform.SetPositionAndRotation(new Vector3(25.0f, transform.position.y, transform.position.z), transform.rotation );
					}
					//Boundaries für z Koordinaten
					if (transform.position.z < -5){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, -5.0f), transform.rotation );
					}else if (transform.position.z > 25.0f){
						transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 25.0f), transform.rotation );
					}
					transform.Translate(Vector3.forward*Time.deltaTime*-bewegungsGeschwindigkeitIsometric);
				}
				
				
				if (Input.GetKey(KeyCode.A)){
					//Haben wir den Marker irgendwo aktiv = was ausgewählt?
					if (ManageCanvas.umrandungGesetzt){
						//ja -> Kamer um die Position des Markers rotieren
						camera.transform.LookAt(ManageCanvas.makierungsPosition);
						transform.RotateAround(ManageCanvas.makierungsPosition.position, new Vector3(0, 1,0), -60f*Time.deltaTime);
					}
					else{
						transform.Rotate(new Vector3(0, 1, 0), -60 * Time.deltaTime, Space.World);
					}
				}else if (Input.GetKey((KeyCode.D))){
					if (ManageCanvas.umrandungGesetzt){
						camera.transform.LookAt(ManageCanvas.makierungsPosition);
						transform.RotateAround(ManageCanvas.makierungsPosition.position, new Vector3(0, 1,0), 60f*Time.deltaTime);
					}
					else{
						transform.Rotate(new Vector3(0, 1, 0), 60 * Time.deltaTime, Space.World);
					}
				}
				
				
				if (Input.GetKey(KeyCode.E)){
					if (((int)transform.rotation.eulerAngles.x) >= 310 && ((int)transform.rotation.eulerAngles.x <= 312)){
						transform.rotation = Quaternion.Euler(new Vector3(310, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
					}
					else{
						transform.Rotate(Vector3.left, 60*Time.deltaTime);	
					}
				}
				else if (Input.GetKey((KeyCode.Q))){
					if (((int)transform.rotation.eulerAngles.x) >= 87 && ((int)transform.rotation.eulerAngles.x <= 89)){
						transform.rotation = Quaternion.Euler(new Vector3(87, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
					}
					else{
						transform.Rotate(Vector3.left, -60*Time.deltaTime);	
					}
				}
			}
			//nicht fertig rotiert, dann wenn nicht fertig rotiert, und wir noch nicht die richtige Rotation haben, zur richtigen Position rotieren
			else if(!cameraSwitchDone && transform.rotation.x != toRotation.transform.rotation.x){
				transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation.transform.rotation, 100f*Time.deltaTime);
			}
		}
	}
}
