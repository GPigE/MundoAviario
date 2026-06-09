using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform objetivo; 
    [Header("Configuración")]
    public float suavizado = 0.3f; 
    public Vector3 offset = new Vector3(0, 0, -10); 

    private Vector3 velocidadActiva = Vector3.zero;

    void LateUpdate()
    {
        if (objetivo == null) return;

        
        Vector3 posicionObjetivo = objetivo.position + offset;

       
        transform.position = Vector3.SmoothDamp(transform.position, posicionObjetivo, ref velocidadActiva, suavizado);
    }
}