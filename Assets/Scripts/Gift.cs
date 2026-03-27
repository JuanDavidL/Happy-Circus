using UnityEngine;
using System.Collections;

public class Gift : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    private SpriteRenderer sprite;

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

        ObjectPoolling.Instance.ReturnPoolObject("Regalo", gameObject);
    }
}