using UnityEngine;
using UnityEngine.UI;

public class FullScreenLogic : MonoBehaviour
{
    public Toggle toggle;
    
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn =false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarpantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        //en el deploy hay que desmarcar el capture single screen y el resizable window

    }
}
