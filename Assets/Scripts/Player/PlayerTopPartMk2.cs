using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerTopPartMK2 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    private bool isInputPressed = false;
    public static bool isDead = false;

    [Header("Animation & Visuals (PSB Ready)")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform visualsContainer;

    void Awake()
    {
        if (anim == null) anim = GetComponentInChildren<Animator>();
        if (visualsContainer == null) visualsContainer = transform.Find("UpperBody"); 
    }

    void Start()
    {
        isDead = false;
        if (movePoint != null) movePoint.parent = null;
    }

    void Update()
    {
        if (isDead) return;

        Movement();
        UpdateAnimations();
    }

    void Movement()
    {
        if (movePoint == null) return;

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

    void UpdateAnimations()
    {
        if (anim == null || visualsContainer == null || movePoint == null) return;

        bool isMoving = Vector3.Distance(transform.position, movePoint.position) > 0.05f;

        if (isMoving)
        {
            Vector3 direction = (movePoint.position - transform.position).normalized;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isJumping", false);

                if (direction.x > 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 0, 0); 
                }
                else if (direction.x < 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 180, 0); 
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", true);
            }
        }
        else
        {
            // הסקריפט מכבה את המשתנים מיד כשהשחקן עוצר
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage") && isDead == false)
        {
            StartCoroutine(WaitAndReload());
        }
    }

    private IEnumerator WaitAndReload()
    {
        isDead = true;
        PlayerBottomPart.isDead = true; 
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}