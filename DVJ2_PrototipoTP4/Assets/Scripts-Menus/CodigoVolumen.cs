using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoVolumen : MonoBehaviour
{
    public Slider slider;
    public Image imageMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }
    private void Update()
    {
        //print("El volumen es: "+slider.value);
    }
    public void ChangeSlider()
    {
        PlayerPrefs.SetFloat("volumenAudio", slider.value);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }
    // Update is called once per frame
    public void RevisarSiEstoyMute()
    {
        if (slider.value == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
}