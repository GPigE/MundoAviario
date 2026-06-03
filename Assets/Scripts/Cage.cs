using UnityEngine;

public class Cage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance.PlayerHasKey == false) { GameManager.Instance.NoKeyAlert(); return; }

        GameManager.Instance.PlayerHasKey = false;
        GameManager.Instance.WinLevel();
    }
}
