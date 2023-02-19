using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float valorSlider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.7f);
        AudioListener.volume = slider.value;
    }

    public void cambiosSlider(float valor)
    {
        valorSlider= valor;
        PlayerPrefs.SetFloat("volumenAudio", valorSlider);
        AudioListener.volume= slider.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
