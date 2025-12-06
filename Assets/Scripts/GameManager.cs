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

    private bool targetIsVisible;
    private Coroutine speakCoroutine;
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

        if (!simonSaysManager.activeSelf && targetIsVisible)
        {
            simonSaysManager.SetActive(true);
            EnableButtons();
            StartCoroutine(simonSays.PlaySimonSays());
        }
    }

    public void OnFound()
    {
        targetIsVisible = true;
    }

    public void OnLost()
    {
        targetIsVisible = false;

        if (speakCoroutine != null)
        {
            StopCoroutine(speakCoroutine);
            speakCoroutine = null;
        }

        simonSaysManager.SetActive(false);
        DisableButtons();
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
        if (speakCoroutine != null)
        {
            StopCoroutine(speakCoroutine);
        }

        speakCoroutine = StartCoroutine(Speak());
    }
}
