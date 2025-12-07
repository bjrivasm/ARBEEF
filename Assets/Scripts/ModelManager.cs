using System.Collections;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    [SerializeField] private AnimationsManager animManager;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float timeBetweenModels = 0.5f;

    private void Awake()
    {
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ActivateModel(GameObject obj)
    {
        obj.SetActive(true);
        if (animManager.fresangreBody.gameObject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.Fresangre;
        }
        else if (animManager.plataNOBody.gameObject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.PlataNO;
        }
        gameManager.StartSpeaking();
        /*else if (animManager.kiwiBody.gameoBject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.Kiwi;
        }
        else if (animManager.racimoUvasBody.gameoBject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.RacimoUvas;
        }
        else if (animManager.trozoCarneBody.gameoBject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.TrozoCarne;
        }*/
    }

    public void DisableModel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void CallActivateModelTimer(GameObject obj)
    {
        StartCoroutine(ActivateModelTimer(obj));
    }

    public void CallDisableModelTimer(GameObject obj)
    {
        StartCoroutine(DisableModelTimer(obj));
    }

    private IEnumerator DisableModelTimer(GameObject obj)
    {
        if(obj.activeSelf)
        {
            yield return new WaitForSeconds(timeBetweenModels);
            obj.SetActive(false);
        }
    }

    private IEnumerator ActivateModelTimer(GameObject obj)
    { 
        yield return new WaitForSeconds(timeBetweenModels);
        obj.SetActive(true);
        if (animManager.fresangreBody.gameObject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.Fresangre;
        }
        else if (animManager.plataNOBody.gameObject.activeInHierarchy)
        {
            animManager.currentCharacter = AnimationsManager.CharacterID.PlataNO;
        }
        gameManager.StartSpeaking();
    }
}
