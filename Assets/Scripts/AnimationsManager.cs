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

    public enum CharacterID
    {
        PlataNO,
        Fresangre
    }

    public CharacterID currentCharacter;

    [Header("PlataNO animators")]
    public Animator plataNOBody;
    public Animator plataNOFace;

    [Header("Fresangre animators")]
    public Animator fresangreBody;
    public Animator fresangreFace;

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
        }
    }

    public void PlayRunning()
    {
        switch (currentCharacter)
        {
            case CharacterID.PlataNO:
                plataNOBody.SetTrigger("isRunning");
                break;
            case CharacterID.Fresangre:
                fresangreBody.SetTrigger("isRunning");
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
        return currentCharacter == CharacterID.PlataNO ? plataNOBody : fresangreBody;
    }

    public Animator GetFaceAnimator()
    {
        return currentCharacter == CharacterID.PlataNO ? plataNOFace : fresangreFace;
    }

}