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
    [SerializeField] private GameObject trozoCarneGO;
    [SerializeField] private GameObject trozoCarneButtons;

    private Vector3 plataNOInitialPos;
    private Quaternion plataNOInitialRot;

    private Vector3 fresangreInitialPos;
    private Quaternion fresangreInitialRot;

    private Vector3 trozoCarneInitialPos;
    private Quaternion trozoCarneInitialRot;

    private bool targetIsVisible;
    private Coroutine speakCoroutine;
    private Coroutine runAwayCoroutine;
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

        trozoCarneInitialPos = trozoCarneGO.transform.localPosition;
        trozoCarneInitialRot = trozoCarneGO.transform.localRotation;

        plataNOButtons.SetActive(false);
        fresangreButtons.SetActive(false);

        plataNOGO.SetActive(false);
        fresangreGO.SetActive(false);
        trozoCarneGO.SetActive(false);

        // simonSaysManager = GameObject.Find("SimonSaysManager");
        // simonSays = simonSaysManager.GetComponent<SimonSays>();
        simonSaysManager.SetActive(false);
        // animManager = GameObject.Find("AnimationsManager").GetComponent<AnimationsManager>();
    }

    private IEnumerator Speak()
    {
        int difficulty = 1;
        GameObject currentCharacterGO = plataNOGO;
        if (animManager.currentCharacter == AnimationsManager.CharacterID.PlataNO)
        {
            difficulty = 1;
            currentCharacterGO = plataNOGO;
        }
        else if (animManager.currentCharacter == AnimationsManager.CharacterID.Fresangre)
        {
            difficulty = 2;
            currentCharacterGO = fresangreGO;
        }
        else if (animManager.currentCharacter == AnimationsManager.CharacterID.TrozoCarne)
        {
            difficulty = 3;
            currentCharacterGO = trozoCarneGO;
        }

        DisableButtons();
        animManager.PlayIdle();
        if (animManager.currentCharacter == AnimationsManager.CharacterID.PlataNO || animManager.currentCharacter == AnimationsManager.CharacterID.Fresangre)
        {
            animManager.PlaySpeaking();
            yield return new WaitForSeconds(speakingTime);
            animManager.PlayEyeblink();
        }


        if (!simonSaysManager.activeSelf && targetIsVisible)
        {
            simonSaysManager.SetActive(true);
            EnableButtons();
            StartCoroutine(simonSays.PlaySimonSays(currentCharacterGO, difficulty));
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

        trozoCarneGO.transform.localPosition = trozoCarneInitialPos;
        trozoCarneGO.transform.localRotation = trozoCarneInitialRot;

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

        if (runAwayCoroutine != null)
        {
            StopCoroutine(runAwayCoroutine);
            runAwayCoroutine = null;
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

    public void StartRunAway()
    {
        if (runAwayCoroutine != null)
        {
            StopCoroutine(runAwayCoroutine);
            runAwayCoroutine = null;
        }

        runAwayCoroutine = StartCoroutine(RunAwayRandom());
    }

    public IEnumerator RunAwayRandom()
    {
        Transform characterRig = null;

        if (plataNOGO.activeInHierarchy && animManager.currentCharacter == AnimationsManager.CharacterID.PlataNO)
            characterRig = animManager.plataNOBody.transform;
        else if (fresangreGO.activeInHierarchy && animManager.currentCharacter == AnimationsManager.CharacterID.Fresangre)
            characterRig = animManager.fresangreBody.transform;
        else if (trozoCarneGO.activeInHierarchy && animManager.currentCharacter == AnimationsManager.CharacterID.TrozoCarne)
            characterRig = animManager.trozoCarneBody.transform;
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

        animManager.PlayExpressions();
        DisableButtons();

        while (Quaternion.Angle(characterRig.rotation, targetRot) > 1f)
        {
            characterRig.rotation = Quaternion.Slerp(characterRig.rotation, targetRot, rotateSpeed * Time.deltaTime);
            yield return null;
        }

        animManager.PlayRunning();

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
