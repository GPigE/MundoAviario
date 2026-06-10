using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool PlayerHasKey = false;
    [SerializeField] private GameObject KeyIndicator;
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
    public void GrantKey()
    {
        Instance.PlayerHasKey = true;
        KeyIndicator.SetActive(true);
    }
}
