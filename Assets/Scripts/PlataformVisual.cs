using UnityEngine;
using UnityEngine.UI; // Para la barra de vida
using System.Collections;

public class PlatformVisuals : MonoBehaviour
{
    [SerializeField] private Image healthBarFilled;
    [SerializeField] private SpriteRenderer platformSprite;
    [SerializeField] private Color damagedColor = new Color(0.5f, 0.5f, 0.5f); // Color oscuro

    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeMagnitude = 0.1f;

    private Vector3 originalPos;
    private Color initialColor;

    void Awake()
    {
        originalPos = transform.localPosition;
        // if (platformSprite != null) initialColor = platformSprite.color;
    }

    // Este método lo llamaremos desde el UnityEvent de Health
    public void UpdatePlatformUI(float currentHealth, float maxHealth)
    {
        // Usamos Mathf.Clamp01 para asegurar que el valor esté entre 0 y 1
        float healthPercent = Mathf.Clamp01(currentHealth / maxHealth);

        if (healthBarFilled != null)
        {
            healthBarFilled.fillAmount = healthPercent;
            Debug.Log($"Actualizando Barra UI a: {healthPercent}");
        }
        // 1. Actualizar la barra llena (0 a 1)
        if (healthBarFilled != null)
            healthBarFilled.fillAmount = currentHealth / maxHealth;

        // 2. Oscurecer el color gradualmente
        if (platformSprite != null)
            platformSprite.color = Color.Lerp(damagedColor, initialColor, currentHealth / maxHealth);

        // 3. Activar el temblor
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}