using UnityEngine;

public class Clowns2 : MonoBehaviour
{
    public Sprite normalClown;
    public Sprite DeadClown;

    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalClown;
       
    }

    public void SetDiabolicForm(bool active)
    {
        spriteRenderer.sprite = active ? DeadClown : normalClown;
    }

    // cuando muere, avisa al GameManager
    // Detecta colisión con proyectiles
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto que chocó es una burbuja
        if (collision.CompareTag("Projectile"))
        {
            Die();
        }
    }

    public void Die()
    {
        GameManagerUX.Instance.RegisterKill();
        Destroy(gameObject);
    }



}
