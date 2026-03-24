using UnityEngine;
using System.Collections;

public class RedHitTop : MonoBehaviour
{
    public static bool Red = false;
    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }

    void Update()
    {
        red();
    }

    private void red()
    {
        if (Red == true)
        {
            StartCoroutine(FlashRed());
        }
    }

    // Color The Player Red at Hit
    IEnumerator FlashRed()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
        Red = false;
    }
}
