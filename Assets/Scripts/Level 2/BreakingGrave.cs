using UnityEngine;

public class BreakingGrave : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public GameObject ObjectToSpawn;
    private void Start()
    {
        currentFrame = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentFrame++;

            if (currentFrame == 1)
            {
                spriteRenderer.sprite = frame1;
                AudioManager.hitFirstSound = true;
            }
            else if (currentFrame == 2)
            {
                spriteRenderer.sprite = frame2;
                AudioManager.hitSecondSound = true;
            }
            else if (currentFrame == 3)
            {
                spriteRenderer.sprite = frame3;
                AudioManager.hitSecondSound = true;
            }
            else if (currentFrame == 4)
            {
                spriteRenderer.sprite = frame4;
                AudioManager.hitSecondSound = true;
            }
            else if (currentFrame == 5)
            {
                if (ObjectToSpawn != null)
                {
                    AudioManager.hitLastSound = true;
                    Instantiate(ObjectToSpawn, transform.position, transform.rotation);

                }
                Destroy(gameObject);
            }

        }
    }
}