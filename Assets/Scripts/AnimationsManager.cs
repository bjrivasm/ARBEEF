using System.Collections;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    // Fresangre Face
    public const string Fresangre_face_eyeblink = "Fresangre.mouth_Fresangre-face-eyeblink";
    public const string Fresangre_face_keying = "Fresangre.mouth_Fresangre-face-keying";
    public const string Fresangre_face_smiles = "Fresangre.mouth_Fresangre-face-smiles";
    public const string Fresangre_face_speak = "Fresangre.mouth_Fresangre-face-speak";

    // Fresangre
    public const string Fresangre_dying = "rig_Fresangre-dying";
    public const string Fresangre_idle = "rig_Fresangre-idle";
    public const string Fresangre_keying = "rig_Fresangre-keying";
    public const string Fresangre_running = "rig_Fresangre-running";
    public const string Fresangre_simon_down = "rig_Fresangre-simon-down";
    public const string Fresangre_simon_left = "rig_Fresangre-simon-left";
    public const string Fresangre_simon_right = "rig_Fresangre-simon-right";
    public const string Fresangre_simon_up = "rig_Fresangre-simon-up";

    // PlataNO Face
    public const string PlataNO_face_eyeblink = "PlataNO FaceRig_PlataNO-face-eyeblink";
    public const string PlataNO_face_expression_change = "PlataNO FaceRig_PlataNO-face-expression-change";
    public const string PlataNO_face_keying = "PlataNO FaceRig_PlataNO-face-keying";
    public const string PlataNO_face_speak = "PlataNO FaceRig_PlataNO-face-speak";

    // PlataNO
    public const string PlataNO_dying = "rig_PlataNO-dying";
    public const string PlataNO_idle = "rig_PlataNO-idle";
    public const string PlataNO_keying = "rig_PlataNO-keying";
    public const string PlataNO_running = "rig_PlataNO-running";
    public const string PlataNO_simon_down = "rig_PlataNO-simon-down";
    public const string PlataNO_simon_left = "rig_PlataNO-simon-left";
    public const string PlataNO_simon_right = "rig_PlataNO-simon-right";
    public const string PlataNO_simon_up = "rig_PlataNO-simon-up";

    // TrozoCarne hands
    public const string Skeleton_TrozoCarne_hands_dying = "Skeleton_TrozoCarne-hands-dying";
    public const string Skeleton_TrozoCarne_hands_idle = "Skeleton_TrozoCarne-hands-idle";
    public const string Skeleton_TrozoCarne_hands_keying = "Skeleton_TrozoCarne-hands-keying";
    public const string Skeleton_TrozoCarne_hands_running = "Skeleton_TrozoCarne-hands-running";
    public const string Skeleton_TrozoCarne_hands_simon_down = "Skeleton_TrozoCarne-hands-simon-down";
    public const string Skeleton_TrozoCarne_hands_simon_left = "Skeleton_TrozoCarne-hands-simon-left";
    public const string Skeleton_TrozoCarne_hands_simon_right = "Skeleton_TrozoCarne-hands-simon-right";
    public const string Skeleton_TrozoCarne_hands_simon_up = "Skeleton_TrozoCarne-hands-simon-up";

    // TrozoCarne
    public const string TrozoCarne_dying = "rig_TrozoCarne-dying";
    public const string TrozoCarne_idle = "rig_TrozoCarne-idle";
    public const string TrozoCarne_keying_running = "rig_TrozoCarne-keying-running";
    public const string TrozoCarne_simon_down = "rig_TrozoCarne-simon-down";
    public const string TrozoCarne_simon_left = "rig_TrozoCarne-simon-left";
    public const string TrozoCarne_simon_right = "rig_TrozoCarne-simon-right";
    public const string TrozoCarne_simon_up = "rig_TrozoCarne-simon-up";



    public enum CharacterID
    {
        PlataNO,
        Fresangre,
        Kiwi,
        RacimoUvas,
        TrozoCarne
    }

    public CharacterID currentCharacter;

    [SerializeField] private GameObject currentCharacterRigGO;


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
        GetBodyAnimator();
        GetFaceAnimator();
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