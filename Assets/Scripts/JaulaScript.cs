using UnityEngine;

public class JaulaScript : MonoBehaviour
{
    private static readonly int IsFredHash = Animator.StringToHash("IsFred");

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (GameManager.Instance.PlayerHasKey)
            AbrirJaula();
        else
            GameManager.Instance.NoKeyAlert();
    }
    async void AbrirJaula()
    {
        GetComponent<Animator>().SetBool(IsFredHash, true);
        await Awaitable.WaitForSecondsAsync(2f, destroyCancellationToken);
        GameManager.Instance.WinLevel();
    }
}
