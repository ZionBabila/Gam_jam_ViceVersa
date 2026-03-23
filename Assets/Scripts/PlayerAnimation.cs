using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator anim;

    // References to the movement scripts
    private PlayerTopPart topMovement;
    private PlayerBottomPart bottomMovement;

    void Awake()
    {
        // Get the movement scripts attached to this GameObject
        topMovement = GetComponent<PlayerTopPart>();
        bottomMovement = GetComponent<PlayerBottomPart>();

        if (anim == null) anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Transform currentTransform = null;
        Transform currentMovePoint = null;
        bool isCurrentlyDead = false;

        // Check which script is active and pull its data
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
            isCurrentlyDead = PlayerBottomPart.isDead; 
        }

        // Safety check to prevent errors
        if (anim == null || currentMovePoint == null || isCurrentlyDead) return;

        UpdateAnimations(currentTransform, currentMovePoint);
    }

    void UpdateAnimations(Transform playerTransform, Transform movePoint)
    {
        // Check if the player is currently moving
        bool isMoving = Vector3.Distance(playerTransform.position, movePoint.position) > 0.05f;

        if (isMoving)
        {
            Vector3 direction = (movePoint.position - playerTransform.position).normalized;

            // Horizontal Movement (Walking) - No flipping applied
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isJumping", false);
            }
            // Vertical Movement (Jumping)
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", true);
            }
        }
        else
        {
            // Stop animations when player reaches the target point
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }
}