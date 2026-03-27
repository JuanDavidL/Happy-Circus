using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusicVolume ()
    {
        float volume = musicSlider.value;
        //mixer.SetFloat("music", volume);
        // para que fuera posible llamarlo le dimos clic encima al parametro que queriamos llamar y seleccionamos Expose, y salio una flechita,
        //le cambiamos el nombre a music y es el que estamos llamando en "music"

        mixer.SetFloat("music", Mathf.Log10(volume)*20);
        //porque el slider va de 0 a 1 osea 0,001 ... , es logaritmico, pero en el mixer los valores cmabian a lineales
        //debemos cambiar el valo minimo a 0,0001

        PlayerPrefs.SetFloat("musicVolume", volume);

        
    }


    public void SetSFXVolume ()
    {
        float volume = SFXSlider.value;
        //mixer.SetFloat("music", volume);
        // para que fuera posible llamarlo le dimos clic encima al parametro que queriamos llamar y seleccionamos Expose, y salio una flechita,
        //le cambiamos el nombre a music y es el que estamos llamando en "music"

        mixer.SetFloat("sfx", Mathf.Log10(volume)*20);
        //porque el slider va de 0 a 1 osea 0,001 ... , es logaritmico, pero en el mixer los valores cmabian a lineales
        //debemos cambiar el valo minimo a 0,0001

        PlayerPrefs.SetFloat("SFXVolume", volume);

        
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();

        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }


}
