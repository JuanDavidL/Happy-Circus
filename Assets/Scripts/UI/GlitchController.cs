using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class GlitchController : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public UnityEngine.Rendering.Volume glitchVolume; // arrastra tu objeto Post Process (Volume)
    public Light2D globalLight; // arrastra tu Global Light 2D

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

        //globalLight.color = Color.red;

        // Cambiar todos los payasos activos a su forma diabólica
        Clowns2[] clowns = FindObjectsByType<Clowns2>(FindObjectsSortMode.None);
        foreach (Clowns2 clown in clowns)
        {
            clown.SetDiabolicForm(true);
        }

        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Desactivar glitch
        camData.renderPostProcessing = false;
        globalLight.color = originalColor;

        // Devolver payasos a su forma normal
        foreach (Clowns2 clown in clowns)
        {
            clown.SetDiabolicForm(false);
        }
    }
}