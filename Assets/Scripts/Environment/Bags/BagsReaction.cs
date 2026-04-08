using UnityEngine;

public class BagsReaction : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    public Sprite frame1;
    public Sprite frame2;
    private void Start()
    {
        currentFrame = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = frame1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = frame2;
        }
    }
}
