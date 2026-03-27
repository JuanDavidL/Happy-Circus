using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrAlJuego()
    {
        SceneManager.LoadScene("NataliaScene");
    }


    public void IrAlMenuprincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
