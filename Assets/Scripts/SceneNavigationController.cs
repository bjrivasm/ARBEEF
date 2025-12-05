using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneNavigationController : MonoBehaviour
{
    public float duration = 0.2f;
    private bool pressed = false;

    public void OnClickPlay(Button button)
    {
        if (!pressed) StartCoroutine(ScaleButton(button.transform, () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }));
    }

    public void OnClickExit(Button button)
    {
        if (!pressed) StartCoroutine(ScaleButton(button.transform, () =>
        {
            Application.Quit();
        }));
    }

    public void PreviousScene() { 
        int escenaActual = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(escenaActual - 1);
    }

    IEnumerator ScaleButton(Transform button, System.Action callback)
    {
        pressed = true;
        Vector3 original = button.localScale;
        Vector3 target = original * 0.85f;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            float scale = Mathf.SmoothStep(1f, 0.85f, t);
            button.localScale = original * scale;
            yield return null;
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            float scale = Mathf.SmoothStep(0.85f, 1f, t);
            button.localScale = original * scale;
            yield return null;
        }

        callback?.Invoke();
    }
}
