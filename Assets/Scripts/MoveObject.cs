using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private string poolTag;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // if (transform.position.x < playerTransform.position.x - 15f)
        // {
        //     ObjectPoolling.Instance.ReturnPoolObject(poolTag, gameObject);
        // }
    }
}
