using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickSound;

    public void DoSoundOnClick()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}
