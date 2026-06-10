using UnityEngine;

public class LlaveScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        GameManager.Instance.GrantKey();
        Destroy(gameObject);
    }
}
