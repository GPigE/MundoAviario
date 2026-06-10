using UnityEngine;

public class JaulaScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (GameManager.Instance.PlayerHasKey)
            AbrirJaula();
        else
            GameManager.Instance.NoKeyAlert();
    }
    void AbrirJaula()
    {
        GameManager.Instance.WinLevel();
    }
}
