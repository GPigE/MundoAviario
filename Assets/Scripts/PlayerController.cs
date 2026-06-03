using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private static readonly int DirectionYHash = Animator.StringToHash("directionY");
    private static readonly int DirectionXHash = Animator.StringToHash("directionX");
    public static float directionX = 0;
    public static float directionY = 0;
    public static float sprintMod = 2;
    private Animator animator;
    private Rigidbody2D rb2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ReadMovementKeys();
        animator.SetFloat(DirectionXHash, directionX);
        animator.SetFloat(DirectionYHash, directionY);
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    private static void ReadMovementKeys()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.aKey.wasPressedThisFrame) directionX = -1;
        else if (kb.dKey.wasPressedThisFrame) directionX = 1;
        else if (kb.aKey.wasReleasedThisFrame) directionX = kb.dKey.isPressed ? 1 : 0;
        else if (kb.dKey.wasReleasedThisFrame) directionX = kb.aKey.isPressed ? -1 : 0;

        if (kb.wKey.wasPressedThisFrame) directionY = 1;
        else if (kb.sKey.wasPressedThisFrame) directionY = -1;
        else if (kb.wKey.wasReleasedThisFrame) directionY = kb.sKey.isPressed ? -1 : 0;
        else if (kb.sKey.wasReleasedThisFrame) directionY = kb.wKey.isPressed ? 1 : 0;

        if (kb.leftShiftKey.wasPressedThisFrame) sprintMod = 2;
        else if (kb.leftShiftKey.wasReleasedThisFrame) sprintMod = 1;
    }
    private void MovePlayer()
    {
        rb2d.linearVelocity = new Vector2(directionX * 2 * sprintMod, directionY * 2 * sprintMod);
    }
}