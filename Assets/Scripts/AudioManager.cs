using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;

    //Sounds and Variables
    public AudioClip ouch;
    public static bool OuchSound = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
        OuchSound = false;
    }

    void Update()
    {
        Ouch();
    }

    private void Ouch()
    {
        if (OuchSound == true)
        {
            source.PlayOneShot(ouch);
            OuchSound = false;
        }
    }
}
