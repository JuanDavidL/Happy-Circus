using UnityEngine;
using UnityEngine.Events; // Para disparar efectos como el Post-Processing

public class Health : MonoBehaviour
{
    [Header("Configuracion Vida")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private string poolTag; // "Enemigo", "Bala", etc.
    [SerializeField] private bool isPlayer = false;

    private float currentHealth;

    // Eventos (Sonido, Partículas, Post-Processing)
    public UnityEvent<float, float> onDamageWithValues;
    public UnityEvent onDamage;
    public UnityEvent onDeath;

    void OnEnable()
    {
        // Reset de vida al salir del Pool
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"Daño recibido. Vida actual: {currentHealth}/{maxHealth}");
        onDamageWithValues?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        onDeath?.Invoke();

        if (isPlayer)
        {
            Debug.Log("GAME OVER");
            GameManagerUX.Instance.GameOVer();
        }
        else
        {
            // Devolver al pooler
            ObjectPoolling.Instance.ReturnPoolObject(poolTag, gameObject);
        }
    }
}