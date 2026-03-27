using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        // Sigue la posición del jugador
        transform.position = player.position;
        // No copiamos la rotación, así el arma rota independiente
    }
}