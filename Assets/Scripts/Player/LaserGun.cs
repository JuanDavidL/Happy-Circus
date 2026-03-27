using UnityEngine;
using UnityEngine.InputSystem;

public class LaserGun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
            audioManager.PlaySFX(audioManager.shoot);
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Vector2 shootDirection = firePoint.right; 

        BubbleController pc = proj.GetComponent<BubbleController>();
        if (pc != null)
        {
            //pc.SetDirection(shootDirection);
        }
    }
}   