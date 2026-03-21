using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerTopPart : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private bool isInputPressed = false;
    public static bool isDead = false;
    public static Vector3 previousPosition;
    public static bool Hit = false;

    void Start()
    {
        isDead = false;
        movePoint.parent = null;
        previousPosition = transform.position;
        Hit = false;
    }

    void Update()
    {
        if (isDead == true)
        {
            return;
        }
        Movement();


         if(PlayerBottomPart.Hit == true)
        {
            transform.position = previousPosition;
            movePoint.position = previousPosition;
            PlayerBottomPart.Hit = false;
        }
    }

    // Player Movment Control
    void Movement()
    { 
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (moveX == 0f && moveY == 0f)
            {
                isInputPressed = false;
            }

            if (isInputPressed == false)
            {
                if (Mathf.Abs(moveX) == 1f)
                {
                    isInputPressed = true;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(moveX, 0f, 0f), .2f, whatStopsMovement))
                    {
                        previousPosition = movePoint.position;
                        movePoint.position += new Vector3(moveX, 0f, 0f);
                    }
                }
                else if (Mathf.Abs(moveY) == 1f)
                {
                    isInputPressed = true; 

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, moveY, 0f), .2f, whatStopsMovement))
                    {
                        previousPosition = movePoint.position;
                        movePoint.position += new Vector3(0f, moveY, 0f);
                    }
                }
            }
        }
    }

    // Damage System
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage") && isDead == false)
        {
            EventManager.Harts -= 1;
            Hit = true;
            transform.position = previousPosition;
            movePoint.position = previousPosition;
        }
    }
}
