using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuBehaviour : MonoBehaviour {

    public GameObject menu;
    public AudioSource audio;
    public Slider aSlider;

	public void openMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    public void muteSound()
    {
        audio.mute = !audio.mute;
    }

    public void volume()
    {
        audio.volume = aSlider.value;
    }

    public void exit()
    {
        Application.Quit();
    }

}
