using UnityEngine;
using System.Collections;

using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerUX : MonoBehaviour
{

    public static GameManagerUX Instance; // con esta instancia podemos llamar a este script sin tner que declararlo, el ejmp esta ne el BUuBBLeGun

    [Header("UI References")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Ammo Settings")]
    public int maxBubbles = 10;       // cantidad máxima de burbujas
    public int totalBubbles;

    [Header("Roller Coaster")]
    public int rollerCoasterResistance = 100;

    [Header("UI References")]
    public TMP_Text ammoText;
    public TMP_Text resistanceText;
    public TMP_Text KillCountText;

    [Header("Glitch Settings")]
    private int kills = 0;

    

    public GlitchController glitchController;



    public bool isGameActive;
    public bool paused;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1f;
    }

    void Start()
    {
        totalBubbles = maxBubbles;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void RegisterKill()
    {
        kills++;

        if (kills == 3)
        {
            glitchController.TriggerGlitch(GlitchType.Short);
        }
        else if (kills == 6)
        {
            glitchController.TriggerGlitch(GlitchType.Long);
        }
        else if (kills == 10)
        {
            glitchController.TriggerGlitch(GlitchType.NormalReturn);
        }
    }


    public bool TryShoot()
    {
        if (totalBubbles > 0)
        {
            totalBubbles--;

            return true; // sí puede disparar
        }
        return false; // no hay munición
    }
    public bool HasAmmo()
    {
        return totalBubbles > 0;
    }


    public void UpdateBubbles(int amount)
    {
        totalBubbles = Mathf.Clamp(totalBubbles + amount, 0, maxBubbles); // se usa el math para que no quede en numero negativos
                                                                          // y si tenemos un limite, para que no pase de ahi, es decir si el limite es 10, tenemos 8, y recojemos 5, la cantidad total queda en 10

        ammoText.text = "" + totalBubbles;
    }



    public void GameOVer()
    {
        isGameActive = false;

        // 1. Activar el Canvas de derrota
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        // 2. Pausar el tiempo del juego
        Time.timeScale = 0f;

        // 3. (Opcional) Bloquear el cursor si usas mouse para apuntar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

