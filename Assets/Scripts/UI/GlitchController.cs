using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class GlitchController : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public UnityEngine.Rendering.Volume glitchVolume; // arrastra tu objeto Post Process (Volume)
    public Light2D globalLight; // arrastra tu Global Light 2D
    public PlayerChange player;

    private Color originalColor;
    private UniversalAdditionalCameraData camData;


    void Start()
    {
        // Guardamos el color original de la luz
        originalColor = globalLight.color;

        // Aseguramos que el efecto glitch esté apagado al inicio
        camData = mainCamera.GetComponent<UniversalAdditionalCameraData>();
        camData.renderPostProcessing = false; // apagado al inicio

    }

    public void TriggerGlitch()
    {
        StartCoroutine(GlitchRoutine());
    }

    private IEnumerator GlitchRoutine()
{
    // Activar glitch
    camData.renderPostProcessing = true;

    // Cambiar todos los payasos activos a su forma diabólica
    EnemyAI[] clowns = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
    foreach (EnemyAI clown in clowns)
    {
        clown.SetDiabolicForm(true);
    }

    // Cambiar también al jugador
    if (player != null)
    {
        player.SetDiabolicForm(true);
    }

    // Esperar 1 segundo (duración del glitch global)
    yield return new WaitForSeconds(1f);

    // Desactivar glitch visual
    camData.renderPostProcessing = false;
    globalLight.color = originalColor;

    // Devolver payasos a su forma normal
    foreach (EnemyAI clown in clowns)
    {
        clown.SetDiabolicForm(false);
    }

    // ⚡ Aquí no devolvemos al jugador todavía
    // Espera extra para que el contraste se note
    yield return new WaitForSeconds(0.5f); // medio segundo más, ajusta a tu gusto

    // Ahora sí devolvemos al jugador
    if (player != null)
    {
        player.SetDiabolicForm(false);
    }
}

}