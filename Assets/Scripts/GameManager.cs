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

    private Vector3 plataNOInitialPos;
    private Quaternion plataNOInitialRot;

    private Vector3 fresangreInitialPos;
    private Quaternion fresangreInitialRot;

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

        plataNOInitialPos = plataNOGO.transform.localPosition;
        plataNOInitialRot = plataNOGO.transform.localRotation;

        fresangreInitialPos = fresangreGO.transform.localPosition;
        fresangreInitialRot = fresangreGO.transform.localRotation;

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

        plataNOGO.transform.localPosition = plataNOInitialPos;
        plataNOGO.transform.localRotation = plataNOInitialRot;

        // Reset Fresangre
        fresangreGO.transform.localPosition = fresangreInitialPos;
        fresangreGO.transform.localRotation = fresangreInitialRot;

        animManager.PlayIdle(); // Opcional, para evitar que siga corriendo
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

    public IEnumerator RunAwayRandom()
    {
        Transform characterRig = null;

        if (plataNOGO.activeInHierarchy && animManager.currentCharacter == AnimationsManager.CharacterID.PlataNO)
            characterRig = animManager.plataNOBody.transform;
        else if (fresangreGO.activeInHierarchy && animManager.currentCharacter == AnimationsManager.CharacterID.Fresangre)
            characterRig = animManager.fresangreBody.transform;
        else
        {
            Debug.LogWarning("No hay rig activo para RunAwayRandom");
            yield break;
        }

        float speed = 3f;
        float rotateSpeed = 5f;
        float duration = 6f;

        Vector3 randomDir = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;

        Quaternion targetRot = Quaternion.LookRotation(randomDir);

        animManager.PlayRunning();
        animManager.PlayExpressions();
        DisableButtons();

        while (Quaternion.Angle(characterRig.rotation, targetRot) > 1f)
        {
            characterRig.rotation = Quaternion.Slerp(characterRig.rotation, targetRot, rotateSpeed * Time.deltaTime);
            yield return null;
        }

        float t = 0f;
        while (t < duration)
        {
            characterRig.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            t += Time.deltaTime;
            yield return null;
        }

        animManager.PlayIdle();
    }

}
