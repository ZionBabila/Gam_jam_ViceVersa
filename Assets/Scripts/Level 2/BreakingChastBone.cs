using UnityEngine;

public class BreakingChastBone : MonoBehaviour

{
    public SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
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
                AudioManager.crackBones1 = true;
            }
            else if (currentFrame == 2)
            {
                spriteRenderer.sprite = frame2;
                AudioManager.crackBones2 = true;
            }
            else if (currentFrame == 3)
            {
                spriteRenderer.sprite = frame3;
                AudioManager.crackBones3 = true;
            }
          
            else if (currentFrame == 4)
            {
                AudioManager.crackBones4 = true;
                if (ObjectToSpawn != null)
                {
                    Instantiate(ObjectToSpawn, transform.position, transform.rotation);

                }
                Destroy(gameObject);
            }

        }
    }
}
