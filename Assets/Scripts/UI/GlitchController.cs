using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public enum GlitchType
{
    Short,
    Long,
    NormalReturn
}

public class GlitchController : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public UnityEngine.Rendering.Volume glitchVolume;
    public Light2D globalLight;
    public PlayerChange player; // arrastra tu Player aquí

    private Color originalColor;
    private UniversalAdditionalCameraData camData;

    void Start()
    {
        originalColor = globalLight.color;
        camData = mainCamera.GetComponent<UniversalAdditionalCameraData>();
        camData.renderPostProcessing = false;
    }

    public void TriggerGlitch(GlitchType type)
    {
        StartCoroutine(GlitchRoutine(type));
    }

    private IEnumerator GlitchRoutine(GlitchType type)
    {
        // Activar glitch visual
        camData.renderPostProcessing = true;

        // Cambiar payasos a forma diabólica
        EnemyAI[] clowns = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
        foreach (EnemyAI clown in clowns)
        {
            if (clown != null) clown.SetDiabolicForm(true);
        }

        // Cambiar jugador
        if (player != null) player.SetDiabolicForm(true);

        // Configuración según tipo de glitch
        float glitchTime = 1f;
        float extraPlayerTime = 0f;
        bool keepEnemiesLonger = false;

        switch (type)
        {
            case GlitchType.Short:
                glitchTime = 1f;
                extraPlayerTime = 0.5f; // jugador dura un poco más
                break;

            case GlitchType.Long:
                glitchTime = 2f;
                extraPlayerTime = 2f; // jugador dura más
                keepEnemiesLonger = true; // enemigos también duran más
                break;

            case GlitchType.NormalReturn:
                glitchTime = 1.5f;
                extraPlayerTime = 0f; // todos vuelven rápido
                break;
        }

        // Espera duración base
        yield return new WaitForSeconds(glitchTime);

        // Apagar glitch visual
        camData.renderPostProcessing = false;
        globalLight.color = originalColor;

        // Devolver payasos a normal (o mantenerlos más tiempo si es Long)
        if (!keepEnemiesLonger)
        {
            foreach (EnemyAI clown in clowns)
            {
                if (clown != null) clown.SetDiabolicForm(false);
            }
        }
        else
        {
            yield return new WaitForSeconds(1f); // tiempo extra para enemigos
            foreach (EnemyAI clown in clowns)
            {
                if (clown != null) clown.SetDiabolicForm(false);
            }
        }

        // Devolver jugador después de su tiempo extra
        if (extraPlayerTime > 0f)
        {
            yield return new WaitForSeconds(extraPlayerTime);
        }

        if (player != null) player.SetDiabolicForm(false);
    }
}