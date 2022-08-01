using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickSound, tryAgainMessageBoxSound;

    public void DoSoundOnClick()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }

    public void DoTryAgainSound()
    {
        if (tryAgainMessageBoxSound != null)
        {
            tryAgainMessageBoxSound.Play();
        }
    }
}
