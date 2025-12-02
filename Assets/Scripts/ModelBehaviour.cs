using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelBehaviour : MonoBehaviour
{
    public void ActivateModel(GameObject obj) { 
        obj.SetActive(true);
    }

    public void DisableModel(GameObject obj) { 
        obj.SetActive(false);
    }

    public void PickRandomColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f,1f), 
            Random.Range(0f,1f));
    }

    public void RotateGameObject(GameObject obj)
    {
        obj.transform.Rotate(Vector3.up, 5);

    }

    public void ChangeScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        Debug.Log("Cambiando escena");
    }

    public void ExitScene()
    {
        Application.Quit();
        Debug.Log("Cerrando juego..");
    }
}
