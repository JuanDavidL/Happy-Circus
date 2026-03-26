using UnityEngine;
using UnityEngine.InputSystem;

public class optionsLogic : MonoBehaviour
{
    public  GameObject panelPause;
    private bool panelIsActive;

    public bool paused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            changePaused();
            
        }



    }

 

    void changePaused ()
    {
        if (!paused)
        {
            paused = true;
            panelPause.SetActive(true); // mirar porque no se usa el gameobject aqui
            Time.timeScale = 0;
        }
        else
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        paused= false;
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }
}
