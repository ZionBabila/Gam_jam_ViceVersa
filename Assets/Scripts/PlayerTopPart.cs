using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerTopPart : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private bool isInputPressed = false;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
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
                        movePoint.position += new Vector3(moveX, 0f, 0f);
                    }
                }
                else if (Mathf.Abs(moveY) == 1f)
                {
                    isInputPressed = true; 

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, moveY, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, moveY, 0f);
                    }
                }
            }
        }
    }
}
