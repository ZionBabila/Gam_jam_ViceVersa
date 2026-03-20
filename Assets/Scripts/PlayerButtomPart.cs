using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerButtomPart : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.upArrowKey.wasPressedThisFrame) transform.Translate(Vector3.down);
        if (Keyboard.current.downArrowKey.wasPressedThisFrame) transform.Translate(Vector3.up);
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) transform.Translate(Vector3.left);
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) transform.Translate(Vector3.right);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


