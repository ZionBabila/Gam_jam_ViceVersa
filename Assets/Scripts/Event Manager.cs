using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static int Harts = 3;

    void Start()
    {
        Harts = 3;
    }
    void Update()
    {
        if (Harts<0)
        {
            StartCoroutine(WaitAndReload());
        }
    }

    private IEnumerator WaitAndReload()
    {
        PlayerTopPart.isDead = true;
        PlayerBottomPart.isDead = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
