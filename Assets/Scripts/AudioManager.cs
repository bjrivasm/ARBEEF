using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Musica")]
    public AudioSource musicSource;

    [Header("SFX")]
    public AudioSource simonUpSFX;
    public AudioSource simonRightSFX;
    public AudioSource simonLeftSFX;
    public AudioSource simonDownSFX;

    private void Start()
    {
        if (!musicSource.isPlaying)
            musicSource.Play();
    }

    public void PlaySimonUpSFX()
    {
        simonUpSFX.Play();
    }

    public void PlaySimonRightSFX()
    {
        simonRightSFX.Play();
    }

    public void PlaySimonLeftSFX()
    {
        simonLeftSFX.Play();
    }

    public void PlaySimonDownSFX()
    {
        simonDownSFX.Play();
    }
}
