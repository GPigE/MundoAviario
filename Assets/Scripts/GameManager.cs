using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool PlayerHasKey = false;
    [SerializeField] private GameObject KeyIndicator;
    [SerializeField] private GameObject PantallaGanador;
    [SerializeField] private GameObject PantallaPerdedor;
    [SerializeField] private GameObject BotonMenuPrincipal;
    [SerializeField] private GameObject PantallaPausa;

    void Awake()
    {
        Instance = this;

        KeyIndicator = GameObject.FindGameObjectWithTag("KeyIndicator");
        PantallaGanador = GameObject.FindGameObjectWithTag("PantallaGanador");
        PantallaPerdedor = GameObject.FindGameObjectWithTag("PantallaPerdedor");
        BotonMenuPrincipal = GameObject.FindGameObjectWithTag("BotonMenuPrincipal");
        PantallaPausa = GameObject.FindGameObjectWithTag("PantallaPausa");

        PantallaGanador.SetActive(false);
        PantallaPerdedor.SetActive(false);
        BotonMenuPrincipal.SetActive(false);
        PantallaPausa.SetActive(false);
    }
    public void NoKeyAlert()
    {
        Debug.Log("necesitas la llave w");
    }
    public void WinLevel()
    {
        Debug.Log("ganaste :D!!!!!");
        PantallaGanador.SetActive(true);
        BotonMenuPrincipal.SetActive(true);
    }
    public void LoseLevel()
    {
        Debug.Log("perdiste w :c");
        PantallaPerdedor.SetActive(true);
        BotonMenuPrincipal.SetActive(true);
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
    }
    public void RenaudarJuego()
    {
        PantallaPausa.SetActive(false);
        PlayerController.canMove = true;
    }
}
