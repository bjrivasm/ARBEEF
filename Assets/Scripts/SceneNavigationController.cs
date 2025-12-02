using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour
{
    public void NextScene()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }

    public void CloseApp()
    {
        Application.Quit();
        Debug.Log("Cerrando app");
    }

    public void PreviousScene()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual - 1);
    }
}
