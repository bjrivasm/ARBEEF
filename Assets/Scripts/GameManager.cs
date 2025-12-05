using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Other references")]
    [SerializeField] private GameObject simonSaysManager;
    [SerializeField] private SimonSays simonSays;
    [SerializeField] private AnimationsManager animManager;

    [Header("Character references")]
    [SerializeField] private GameObject plataNOGO;
    [SerializeField] private GameObject plataNOButtons;
    [SerializeField] private GameObject fresangreGO;
    [SerializeField] private GameObject fresangreButtons;
    /*[SerializeField] private GameObject racimoUvasGO;
    [SerializeField] private GameObject racimoUvasButtons;
    [SerializeField] private GameObject trozoCarneGO;
    [SerializeField] private GameObject trozoCarneButtons;*/

    [Header("Variables")]
    [SerializeField] private int speakingTime = 8;

    private void Start()
    {
        //plataNOGO = GameObject.Find("BEEF AR PlataNO");
        //plataNOButtons = GameObject.Find("PlataNO 3D Buttons");
        //fresangreGO = GameObject.Find("BEEF AR Fresangre");
        //fresangreButtons = GameObject.Find("Fresangre 3D Buttons");

        plataNOButtons.SetActive(false);
        fresangreButtons.SetActive(false);

        plataNOGO.SetActive(false);
        fresangreGO.SetActive(false);

        // simonSaysManager = GameObject.Find("SimonSaysManager");
        // simonSays = simonSaysManager.GetComponent<SimonSays>();
        simonSaysManager.SetActive(false);
        // animManager = GameObject.Find("AnimationsManager").GetComponent<AnimationsManager>();
    }

    private IEnumerator Speak()
    {
        DisableButtons();
        animManager.PlayIdle();
        animManager.PlaySpeaking();
        yield return new WaitForSeconds(speakingTime);
        animManager.PlayEyeblink();
        simonSaysManager.SetActive(true);
        EnableButtons();
        StartCoroutine(simonSays.PlaySimonSays());
    }

    public void DisableButtons()
    {
        plataNOButtons.SetActive(false);
        fresangreButtons.SetActive(false);
    }

    public void EnableButtons()
    {
        plataNOButtons.SetActive(true);
        fresangreButtons.SetActive(true);
    }

    public void StartSpeaking()
    {
        StartCoroutine(Speak());
    }
}
