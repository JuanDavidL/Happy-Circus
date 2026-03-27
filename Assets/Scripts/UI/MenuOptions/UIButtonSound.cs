using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.buttonHover);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.buttonClick);
    }
}

