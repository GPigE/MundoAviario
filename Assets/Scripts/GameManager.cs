using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool PlayerHasKey = false;
    void Awake()
    {
        VerifySingleton();
    }
    private void VerifySingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void NoKeyAlert()
    {
        Debug.Log("necesitas la llave w");
    }
    public void WinLevel()
    {
        Debug.Log("ganaste :D!!!!!");
    }
}
