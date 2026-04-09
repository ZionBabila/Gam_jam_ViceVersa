using UnityEngine;

public class GhostAnimationEvents : MonoBehaviour
{
    [Header("Settings")]
    // The large collider for the sound trigger
    public Collider2D soundTriggerCollider; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // double check if it's the player and if the collider is touching the sound trigger
        if (other.CompareTag("Player") && other.IsTouching(soundTriggerCollider))
        {
            AudioManager.ghostSound = true;
        }
    }
}