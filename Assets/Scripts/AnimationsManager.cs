using System.Collections;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{

    public enum CharacterID
    {
        PlataNO,
        Fresangre,
        Kiwi,
        RacimoUvas,
        TrozoCarne
    }

    public CharacterID currentCharacter;


    [Header("PlataNO references")]
    public Animator plataNOBody;
    public Animator plataNOFace;

    [Header("Fresangre references")]
    public Animator fresangreBody;
    public Animator fresangreFace;

    [Header("TrozoCarne references")]
    public Animator trozoCarneBody;
    public Animator trozoCarneHands;

    private void Awake()
    {
        //plataNOBody = GameObject.Find("BEEF AR PlataNO").GetComponent<Animator>();
        //plataNOFace = GameObject.Find("BEEF AR PlataNO face").GetComponent<Animator>();
        //fresangreBody = GameObject.Find("BEEF AR Fresangre").GetComponent<Animator>();
        //fresangreFace = GameObject.Find("BEEF AR Fresangre face").GetComponent<Animator>();
        //GetBodyAnimator();
        //GetFaceAnimator();
    }

    private void Update()
    {
        if (fresangreBody.gameObject.activeInHierarchy)
            currentCharacter = CharacterID.Fresangre;
        else if (plataNOBody.gameObject.activeInHierarchy)
            currentCharacter = CharacterID.PlataNO;
        else if (trozoCarneBody.gameObject.activeInHierarchy)
            currentCharacter = CharacterID.TrozoCarne;
    }

    public void PlayIdle()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetBool("boolAnimDirection", false);
                break;

            case CharacterID.Fresangre:
                fresangreBody.SetBool("boolAnimDirection", false);
                break;

            case CharacterID.TrozoCarne:
                trozoCarneBody.SetBool("boolAnimDirection", false);
                trozoCarneHands.SetBool("boolAnimDirection", false);
                break;

        }
    }

    public void PlayDying()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetTrigger("isDying");
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetTrigger("isDying");
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetTrigger("isDying");
                trozoCarneHands.SetTrigger("isDying");
                break;
        }
    }

    public void PlayRunning()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetBool("isRunning", true);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetBool("isRunning", true);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetBool("isRunning", true);
                trozoCarneHands.SetBool("isRunning", true);
                break;
        }
    }
    public void StopRunning()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetBool("isRunning", false);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetBool("isRunning", false);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetBool("isRunning", false);
                trozoCarneHands.SetBool("isRunning", false);
                break;
        }
    }

    public void PlaySimonUp()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetInteger("direction", 1);
                plataNOBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetInteger("direction", 1);
                fresangreBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetInteger("direction", 1);
                trozoCarneHands.SetInteger("direction", 1);
                trozoCarneBody.SetBool("boolAnimDirection", true);
                trozoCarneHands.SetBool("boolAnimDirection", true);
                break;
        }
    }

    public void PlaySimonLeft()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetInteger("direction", 2);
                plataNOBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetInteger("direction", 2);
                fresangreBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetInteger("direction", 2);
                trozoCarneHands.SetInteger("direction", 2);
                trozoCarneBody.SetBool("boolAnimDirection", true);
                trozoCarneHands.SetBool("boolAnimDirection", true);
                break;
        }
    }

    public void PlaySimonRight()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetInteger("direction", 3);
                plataNOBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetInteger("direction", 3);
                fresangreBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetInteger("direction", 3);
                trozoCarneHands.SetInteger("direction", 3);
                trozoCarneBody.SetBool("boolAnimDirection", true);
                trozoCarneHands.SetBool("boolAnimDirection", true);
                break;
        }
    }

    public void PlaySimonDown()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetInteger("direction", 4);
                plataNOBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetInteger("direction", 4);
                fresangreBody.SetBool("boolAnimDirection", true);
                break;
            case CharacterID.TrozoCarne:
                trozoCarneBody.SetInteger("direction", 4);
                trozoCarneHands.SetInteger("direction", 4);
                trozoCarneBody.SetBool("boolAnimDirection", true);
                trozoCarneHands.SetBool("boolAnimDirection", true);
                break;
        }
    }

    public void PlaySpeaking()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOFace.SetBool("isSpeaking", true);
                break;
            case CharacterID.Fresangre:
                fresangreFace.SetBool("isSpeaking", true);
                break;
        }
    }

    public void PlayEyeblink()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOFace.SetBool("isSpeaking", false);
                break;
            case CharacterID.Fresangre:
                fresangreFace.SetBool("isSpeaking", false);
                break;
        }
    }

    public void PlayExpressions()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOFace.SetTrigger("startSmiling");
                break;
            case CharacterID.Fresangre:
                fresangreFace.SetTrigger("startSmiling");
                break;
        }
    }

    public Animator GetBodyAnimator()
    {
        
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                currentCharacter = CharacterID.PlataNO;
                return plataNOBody;
            case CharacterID.Fresangre:
                currentCharacter = CharacterID.Fresangre;
                return fresangreBody;
            case CharacterID.TrozoCarne:
                currentCharacter = CharacterID.TrozoCarne;
                return trozoCarneBody;
        }
        return plataNOBody;
    }

    public Animator GetFaceAnimator()
    {

        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                return plataNOFace;
            case CharacterID.Fresangre:
                return fresangreFace;
            case CharacterID.TrozoCarne:
                return trozoCarneHands;
        }
        return plataNOBody;
    }

}