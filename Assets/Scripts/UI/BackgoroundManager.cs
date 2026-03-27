using UnityEngine;
using System.Collections;



public class BackgoroundManager : MonoBehaviour
{
[Header("Fondos")]
    public GameObject[] backgrounds; // arrastra aquí tus 3 fondos
    private int currentIndex = 0;

    [Header("Tiempo de cambio")]
    public float changeInterval = 20f; // editable en el inspector

    void Start()
    {
        // Activar solo el primer fondo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == currentIndex);
        }

        // Iniciar rutina automática
        StartCoroutine(ChangeBackgroundRoutine());
    }

    private IEnumerator ChangeBackgroundRoutine()
    {
        while (true)
        {
            // Esperar el intervalo definido (ej: 20 segundos)
            yield return new WaitForSeconds(changeInterval);

            // Ocultar fondo actual
            backgrounds[currentIndex].SetActive(false);

            // Cambiar al siguiente fondo
            currentIndex++;
            if (currentIndex >= backgrounds.Length)
                currentIndex = 0; // volver al primero si ya pasaste los 3

            backgrounds[currentIndex].SetActive(true);
        }
    }

}
