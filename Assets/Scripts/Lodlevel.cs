using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lodlevel : MonoBehaviour{

	public void ChangeScene(int i) {
		if (i == 0){
			SceneManager.LoadScene(1);
		}
		else{
			Application.Quit();
		}
	}

	public void test() { }
}

