using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation & Visuals (PSB Ready)")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform visualsContainer;

    // References for both possible scripts
    private PlayerTopPart topMovement;
    private PlayerBottomPart bottomMovement;

    void Awake()
    {
        // Try to get both components. One will be true, the other will be null.
        topMovement = GetComponent<PlayerTopPart>();
        bottomMovement = GetComponent<PlayerBottomPart>();

        if (anim == null) anim = GetComponentInChildren<Animator>();
        if (visualsContainer == null) visualsContainer = transform.Find("UpperBody"); 
    }

    void Update()
    {
        Transform currentTransform = null;
        Transform currentMovePoint = null;
        bool isCurrentlyDead = false;

        // Check which script exists on this GameObject and pull its data
        if (topMovement != null)
        {
            currentTransform = topMovement.transform;
            currentMovePoint = topMovement.movePoint;
            isCurrentlyDead = PlayerTopPart.isDead;
        }
        else if (bottomMovement != null)
        {
            currentTransform = bottomMovement.transform;
            currentMovePoint = bottomMovement.movePoint;
            // Assuming PlayerBottomPart also has a static isDead variable
            isCurrentlyDead = PlayerBottomPart.isDead; 
        }

        // Safety check to prevent errors
        if (anim == null || visualsContainer == null || currentMovePoint == null || isCurrentlyDead) return;

        UpdateAnimations(currentTransform, currentMovePoint);
    }

    // A reusable method for animations regardless of top or bottom
    void UpdateAnimations(Transform playerTransform, Transform movePoint)
    {
        // Check if the player is moving based on distance to movePoint
        bool isMoving = Vector3.Distance(playerTransform.position, movePoint.position) > 0.05f;

        if (isMoving)
        {
            Vector3 direction = (movePoint.position - playerTransform.position).normalized;

            // Horizontal Movement
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isJumping", false);

                // Flip player visuals based on direction
                if (direction.x > 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 0, 0); 
                }
                else if (direction.x < 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 180, 0); 
                }
            }
            // Vertical Movement
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", true);
            }
        }
        else
        {
            // Stop animations when movement is done
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }
}