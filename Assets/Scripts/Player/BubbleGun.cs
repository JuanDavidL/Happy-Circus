using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleGun : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Camera cam;
    public Transform spawner;
    public GameObject BubblePrefab;
    public Transform player; // referencia al jugador para flip


    private GameManagerUX gameManagerUX;
    private optionsLogic LogicaPause;
    private AudioManager audioManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerUX = GameObject.Find("GameManager").GetComponent<GameManagerUX>();
        LogicaPause = GameObject.Find("ActivadorPausa").GetComponent<optionsLogic>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
  
    }

    void Update()
    {
        RotateTowardMouse();
        CheckFireing();
    }

    private void RotateTowardMouse()
    {
        // Posición del mouse en mundo
        Vector3 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorld.z = 0;

        // Dirección hacia el mouse
        Vector2 direction = mouseWorld - transform.position;

        // Ángulo en grados
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

         // 🔑 Limitar el ángulo entre -90° y 90°
        angle = Mathf.Clamp(angle, -90f, 90f);


        // Rotación del arma
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        
    }

    private void CheckFireing()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (!LogicaPause.paused)
            {
                if (GameManagerUX.Instance.HasAmmo() )
                {

                    
                    audioManager.PlaySFX(audioManager.shoot);
                    GameObject bullet = Instantiate(BubblePrefab, spawner.position, transform.rotation);
                    Destroy(bullet, 3f);

                    // Restar una burbuja en el GameManager
                    GameManagerUX.Instance.UpdateBubbles(-1); // con la Instancia verificamos que solo haya uno en la escena.
                }
                else
                {
                    Debug.Log("Sin munición!");

                }                
            }


            


            //gameManagerUX.UpdateBubbles(-1);  si quiero usarlo asi tendria que declaralo arriba y en el star buscar el componente
            

            


        }
    }


}