using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("--------AudioSource---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------AudioSource---------")]
    
    public AudioClip background;
    public AudioClip shoot;
    public AudioClip deathClown;
    public AudioClip collectGift;
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public AudioClip Risita;
 

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip); // esto hace que al llamar cualquier audio desde otro scrip suene
        //llamamos al efecto desde otro script y accedo a el desde el Audiomanager audiomanager, en el video lo hacen con tag pero podemos hacerlo con componente como venimos haviendolo
        // en el escrip que lo llmamemos lo hacemos asi: audiomanager.PlaySFX(audiomamnger.nombredelaudio)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
