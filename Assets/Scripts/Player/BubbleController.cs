using UnityEngine;

public class BubbleController : MonoBehaviour
{
   public float Speed;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * Speed * Time.fixedDeltaTime);

        //transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.World);
    }

}
