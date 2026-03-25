using UnityEngine;

public class GhostAnimationEvents : MonoBehaviour
{
    public void PlayGhostSoundEvent()
    {
        AudioManager.ghostSound = true;
    }
}