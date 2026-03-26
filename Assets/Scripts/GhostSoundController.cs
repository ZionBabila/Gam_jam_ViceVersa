using UnityEngine;

public class GhostAnimationEvents : MonoBehaviour
{
    [Header("Settings")]
    // גוררים לכאן מה-Inspector את הקוליידר הגדול של הסאונד
    public Collider2D soundTriggerCollider; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // בדיקה כפולה: האם זה השחקן? והאם הקוליידר שלי הוא זה שמיועד לסאונד?
        if (other.CompareTag("Player") && other.IsTouching(soundTriggerCollider))
        {
            AudioManager.ghostSound = true;
            Debug.Log("Sound Trigger Activated!");
        }
    }
}