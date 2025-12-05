using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelBehaviour : MonoBehaviour
{
    // [SerializeField] private GameObject obj;

    public void ActivateModel(GameObject obj) 
    { 
        obj.SetActive(true);
    }

    public void DisableModel(GameObject obj) 
    { 
        obj.SetActive(false);
    }
}
