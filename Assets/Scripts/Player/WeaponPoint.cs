using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponPoint : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
         mouseWorld.z = 0f;
        
        Vector2 direction = mouseWorld - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        // Limitar a 120° (−60 a 60)
        float clampedAngle = Mathf.Clamp(angle, -60f, 60f);

        transform.rotation = Quaternion.Euler(0f, 0f, clampedAngle);

    }
}
