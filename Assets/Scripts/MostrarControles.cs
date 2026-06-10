using UnityEngine;
using UnityEngine.InputSystem;

public class MostrarControles : MonoBehaviour
{
    void Update()
    {
        var kb = Keyboard.current;
        if (kb.aKey.wasPressedThisFrame
        || kb.dKey.wasPressedThisFrame
        || kb.aKey.wasReleasedThisFrame
        || kb.dKey.wasReleasedThisFrame)
            Destroy(gameObject);
    }
}
