using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject simonSaysManager;
    [SerializeField] private GameObject modelBehaviour;

    private void Awake()
    {
        simonSaysManager = GameObject.Find("SimonSaysManager");
        modelBehaviour = GameObject.Find("ModelTarget");
    }
}
