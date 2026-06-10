using System;
using NUnit.Framework;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool PlayerHasKey = false;
    [SerializeField] private GameObject KeyIndicator;
    [SerializeField] private GameObject PantallaGanador;
    [SerializeField] private GameObject PantallaPerdedor;
    [SerializeField] private GameObject BotonRegresar;
    [SerializeField] private GameObject BotonContinuar;
    [SerializeField] private GameObject PantallaPausa;
    [SerializeField] private GameObject Timer;
    public static bool IsGameOver = false;
    private TextMeshProUGUI timertmp;
    public float SecsTillLose = 50;

    void Awake()
    {
        IsGameOver = false;
        Instance = this;

        KeyIndicator = GameObject.FindGameObjectWithTag("KeyIndicator");
        PantallaGanador = GameObject.FindGameObjectWithTag("PantallaGanador");
        PantallaPerdedor = GameObject.FindGameObjectWithTag("PantallaPerdedor");
        BotonContinuar = GameObject.FindGameObjectWithTag("BotonContinuar");
        BotonRegresar = GameObject.FindGameObjectWithTag("BotonRegresar");
        PantallaPausa = GameObject.FindGameObjectWithTag("PantallaPausa");
        Timer = GameObject.FindGameObjectWithTag("Timer");

        timertmp = Timer.GetComponent<TextMeshProUGUI>();

        PantallaGanador.SetActive(false);
        PantallaPerdedor.SetActive(false);
        BotonContinuar.SetActive(false);
        BotonRegresar.SetActive(false);
        PantallaPausa.SetActive(false);
    }
    void Start()
    {
        SecsTillLose = 30;
    }
    void Update()
    {
        SecsTillLose -= Time.deltaTime;
        timertmp.text = Math.Truncate(SecsTillLose).ToString();

        if (SecsTillLose <= 0)
            LoseLevel();
    }
    public void NoKeyAlert()
    {
        Debug.Log("necesitas la llave w");
    }
    public void WinLevel()
    {
        IsGameOver = true;
        Debug.Log("ganaste :D!!!!!");
        PantallaGanador.SetActive(true);
        BotonContinuar.SetActive(true);
        BotonRegresar.SetActive(true);
    }
    public void LoseLevel()
    {
        IsGameOver = true;
        PlayerController.canMove = false;
        Debug.Log("perdiste w :c");
        PantallaPerdedor.SetActive(true);
        BotonContinuar.SetActive(true);
        BotonRegresar.SetActive(true);
    }
    public void GrantKey()
    {
        Instance.PlayerHasKey = true;
        KeyIndicator.SetActive(true);
    }
    public void LeaveScene()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void PausarJuego()
    {
        PantallaPausa.SetActive(true);
        PlayerController.canMove = false;
        BotonContinuar.SetActive(true);
        BotonRegresar.SetActive(true);
    }
    public void RenaudarJuego()
    {
        if (IsGameOver)
            return;

        PantallaPausa.SetActive(false);
        PlayerController.canMove = true;
        BotonContinuar.SetActive(false);
        BotonRegresar.SetActive(false);
    }
}
