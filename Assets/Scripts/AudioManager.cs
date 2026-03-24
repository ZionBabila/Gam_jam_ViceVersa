using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;

    //Sounds and Variables
    public AudioClip ouch;
    public AudioClip hit;
    public static bool OuchSound = false;
    public static bool hitSound = false;
    void Start()
    {
        source = GetComponent<AudioSource>();
        OuchSound = false;
        hitSound = false;
    }

    void Update()
    {
        Ouch();
        Hit();
    }

    private void Ouch()
    {
        if (OuchSound == true)
        {
            source.PlayOneShot(ouch);
            OuchSound = false;
        }
    }
    private void Hit()
    {
        if (hitSound == true)
        {
            source.PlayOneShot(hit);
            hitSound = false;
        }
    }
}
