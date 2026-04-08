using UnityEngine;

public class TopPartAnimation : MonoBehaviour
{
    [Header("References Needed for Animation")]
    public Transform movePoint; // האנימציה צריכה לדעת לאן השחקן זז כדי לחשב כיוון

    [Header("Animation & Visuals (PSB Ready)")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform visualsContainer;

    void Awake()
    {
        // מוצא את רכיבי האנימציה אוטומטית אם לא שמו אותם ב-Inspector
        if (anim == null) anim = GetComponentInChildren<Animator>();
        if (visualsContainer == null) visualsContainer = transform.Find("UpperBody");
    }

    void Update()
    {
        // קורא לפונקציית האנימציה בכל פריים
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        // אם חסר אחד הרכיבים, אל תעשה כלום כדי למנוע שגיאות
        if (anim == null || visualsContainer == null || movePoint == null) return;

        // בודק אם השחקן נמצא בתנועה (המרחק מהיעד גדול מ-0.05)
        bool isMoving = Vector3.Distance(transform.position, movePoint.position) > 0.05f;

        if (isMoving)
        {
            // מחשב את כיוון התנועה
            Vector3 direction = (movePoint.position - transform.position).normalized;

            // תנועה אופקית (ימינה/שמאלה)
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isJumping", false);

                // סיבוב הדמות לפי הכיוון
                if (direction.x > 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (direction.x < 0)
                {
                    visualsContainer.eulerAngles = new Vector3(0, 180, 0);
                }
            }
            // תנועה אנכית (למעלה/למטה)
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", true);
            }
        }
        else // השחקן עומד במקום
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }
}