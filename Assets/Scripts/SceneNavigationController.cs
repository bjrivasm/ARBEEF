using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour
{
    public void OnClickPlay()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
        AdManager.instance.ShowAd();
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Cerrando la app...");
    }

    public void PreviousScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index > 0)
            SceneManager.LoadScene(index - 1);
    }
}
