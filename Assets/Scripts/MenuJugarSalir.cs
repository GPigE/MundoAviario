using UnityEngine;

public class MenuJugarSalir : MonoBehaviour
{
    public GameObject ArrayLvl;
    public GameObject JugarSalir;
    public void Jugar()
    {
        ArrayLvl.SetActive(true);
        JugarSalir.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
