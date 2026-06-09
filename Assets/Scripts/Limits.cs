using UnityEngine;

public class Limits : MonoBehaviour
{
    [Header("Tamaño del Mapa")]
    public float anchoMapa = 40f;
    public float altoMapa = 24f;

    void Start()
    {
        GenerarMuros();
    }

    void GenerarMuros()
    {
        GameObject contenedor = new GameObject("Muros_Invisibles");
        contenedor.transform.parent = this.transform;

        CrearColisionador(contenedor.transform, new Vector2(0, altoMapa / 2f), new Vector2(anchoMapa, 1f));  // Arriba
        CrearColisionador(contenedor.transform, new Vector2(0, -altoMapa / 2f), new Vector2(anchoMapa, 1f)); // Abajo
        CrearColisionador(contenedor.transform, new Vector2(anchoMapa / 2f, 0), new Vector2(1f, altoMapa));  // Derecha
        CrearColisionador(contenedor.transform, new Vector2(-anchoMapa / 2f, 0), new Vector2(1f, altoMapa)); // Izquierda
    }

    void CrearColisionador(Transform padre, Vector2 posicion, Vector2 tamano)
    {
        GameObject muro = new GameObject("Muro_Fisico");
        muro.transform.parent = padre;
        muro.transform.localPosition = posicion;

        BoxCollider2D collider = muro.AddComponent<BoxCollider2D>();
        collider.size = tamano;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(anchoMapa, altoMapa, 0.1f));
    }
}
