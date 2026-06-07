using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool PlayerHasKey = false;
    [SerializeField] private GameObject keyCounter;
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
    public void GrantPlayerKey()
    {
        PlayerHasKey = true;
        keyCounter.SetActive(true);
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
