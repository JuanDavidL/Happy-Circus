using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gift : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    private SpriteRenderer sprite;

    public int Bubblegift;


    void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ExpirationTimer());
    }

    IEnumerator ExpirationTimer()
    {
        yield return new WaitForSeconds(lifeTime * 0.7f); // Espera el 70% del tiempo

        // Parpadeo
        float blinkTimer = 0;
        while (blinkTimer < lifeTime * 0.3f)
        {
            sprite.enabled = !sprite.enabled; // Apaga/Prende el sprite
            yield return new WaitForSeconds(0.1f);
            blinkTimer += 0.1f;
        }

        ObjectPoolling.Instance.ReturnPoolObject("Gift", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            GameManagerUX.Instance.UpdateBubbles(Bubblegift);
            //Destroy(gameObject);
            //Destroy(collision.gameObject);
            Debug.Log("Si colisiona con reaglo");
            ObjectPoolling.Instance.ReturnPoolObject("Gift", gameObject);
        }
    }
}