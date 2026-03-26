using UnityEngine;

public class GhostScare : MonoBehaviour
{
    [Header("References")]
    public float ResetAnimation = 1f; // Reference to the ResetAnimation script
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            AudioManager.booSound = true;
            if (animator != null)
            {
                animator.SetBool("boo", true);
                Invoke("RessetBoo", ResetAnimation); // Reset the boo animation after 1 second
            }
        


            Debug.Log("Ghost Scare Triggered!");
        }
    }
    private void RessetBoo()
    {
        if (animator != null)
        {
            animator.SetBool("boo", false);
        }
    }
}
