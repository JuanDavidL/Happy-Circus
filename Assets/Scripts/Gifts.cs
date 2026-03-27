using UnityEngine;

public class Gifts : MonoBehaviour
{
    public int Bubblegift;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            GameManagerUX.Instance.UpdateBubbles(Bubblegift);
            Destroy(gameObject);
        }
    }
}
