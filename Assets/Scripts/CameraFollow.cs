using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;




    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = target.position + offset;

        // bloquear rotación
        transform.rotation = Quaternion.identity;
    }


}
