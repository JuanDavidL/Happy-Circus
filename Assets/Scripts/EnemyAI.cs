using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState { Entering, Erratic, Attacking }
    public EnemyState currentState;

    [Header("Configuración de Movimiento")]
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float erraticSpeed = 2f;
    [SerializeField] private float erraticRange = 1.5f;
    [SerializeField] private float waitTime = 4f;
    [SerializeField] private string poolTag = "Enemy";

    private Transform playerTransform;
    private float stopXPosition = 6f;
    private Vector3 startPos;
    private float timer;

    void OnEnable()
    {
        currentState = EnemyState.Entering;
        timer = 0;

        GameObject player = GameObject.FindGameObjectWithTag("Point");
        if (player != null) playerTransform = player.transform;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Entering: MoveToEntry(); break;
            case EnemyState.Erratic: MoveErraticly(); break;
            case EnemyState.Attacking: AttackPlatform(); break;
        }
    }

    void MoveToEntry()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        float relativeStopX = playerTransform != null ? playerTransform.position.x + stopXPosition : stopXPosition;

        if (transform.position.x <= relativeStopX)
        {
            startPos = transform.position;
            currentState = EnemyState.Erratic;
        }
    }

    void MoveErraticly()
    {
        timer += Time.deltaTime;

        // Movimiento Senoidal
        float offset = Mathf.Sin(Time.time * erraticSpeed) * erraticRange;
        transform.position = new Vector3(transform.position.x, startPos.y + offset, 0);

        if (timer >= waitTime) currentState = EnemyState.Attacking;
    }

    void AttackPlatform()
    {
        if (playerTransform == null) return;

        // Persecución directa
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * (speed * 1.5f) * Time.deltaTime);

        // Distancia de ataque
        if (Vector2.Distance(transform.position, playerTransform.position) < 0.8f)
        {
            // IMPACTO:
            // playerTransform.GetComponent<PlatformHealth>()?.TakeDamage(10);

            ObjectPoolling.Instance.ReturnPoolObject(poolTag, gameObject);
        }
    }
}