using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchLevels : MonoBehaviour
{
    public void LaunchLevel(int i)
    {
        switch (i)
        {
            case 1:
                SceneManager.LoadScene("MundoAviaro");
                return;
            default:
                return;
        }
    }
}
