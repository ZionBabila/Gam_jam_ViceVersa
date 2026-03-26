using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;

    //Sounds and Variables
    public AudioClip ouch;

    public AudioClip click;
    public AudioClip ghost;
    public AudioClip winLevel;
    public AudioClip loseLevel;
    public AudioClip hitFirst;
    public AudioClip hitSecond;
    public AudioClip hitLast;

    public static bool OuchSound = false;
    public static bool hitFirstSound = false;
    public static bool hitSecondSound = false;
    public static bool hitLastSound = false;
    public static bool clickSound = false;
    public static bool ghostSound = false;
    public static bool winLevelSound = false;

    public static bool loseLevelSound = false;



    void Start()
    {
        source = GetComponent<AudioSource>();
        OuchSound = false;
        hitFirstSound = false;
        hitSecondSound = false;
        hitLastSound = false;
        clickSound = false;
        ghostSound = false;
        winLevelSound = false;
    }

    void Update()
    {
        Ouch();
        Click();
        Ghost();
        WinLevel();
        HitFirst();
        HitSecond();
        HitLast();
        LoseLevel();

    }

    private void Ouch()
    {
        if (OuchSound == true)
        {
            source.PlayOneShot(ouch);
            OuchSound = false;
        }
    }
    private void Click()
    {
        if (clickSound == true)
        {
            source.PlayOneShot(click);
            clickSound = false;
        }
    }
    private void Ghost()
    {
        if (ghostSound == true)
        {
            source.PlayOneShot(ghost);
            ghostSound = false;
        }
    }
    private void WinLevel()
    {
        if (winLevelSound == true)
        {
            source.PlayOneShot(winLevel);
            winLevelSound = false;
        }
    }
    private void LoseLevel()
    {
        if (loseLevelSound == true)
        {
            source.PlayOneShot(loseLevel);
            loseLevelSound = false;
        }
    }
    private void HitFirst()
    {
        if (hitFirstSound == true)
        {
            source.PlayOneShot(hitFirst);
            hitFirstSound = false;
        }
    }
    private void HitSecond()
    {
        if (hitSecondSound == true)
        {
            source.PlayOneShot(hitSecond);
            hitSecondSound = false;
        }
    }
    private void HitLast()
    {
        if (hitLastSound == true)
        {
            source.PlayOneShot(hitLast);
            hitLastSound = false;
        }
    }
}
