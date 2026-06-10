using UnityEngine;

public class LlaveConteo : MonoBehaviour
{
    void Start()
    {
        if (!GameManager.Instance.PlayerHasKey)
            gameObject.SetActive(false);
    }
}
