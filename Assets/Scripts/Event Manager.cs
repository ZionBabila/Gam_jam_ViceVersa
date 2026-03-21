using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static int Harts = 3;
    public GameObject Hart1;
    public GameObject Hart2;
    public GameObject Hart3;


    void Start()
    {
        Harts = 3;
    }

    void Update()
    {
        HartUi();

        //Command to restart
        if (Harts<1)
        {
            StartCoroutine(WaitAndReload());
        }
    }

    //Visual representation of the hits
    void HartUi()
    {
        if (Harts < 3)
        {
            Destroy(Hart1);
        }

        if (Harts < 2)
        {
            Destroy(Hart2);
        }

        if (Harts < 1)
        {
            Destroy(Hart3);
        }
    }

    // Restart System
    private IEnumerator WaitAndReload()
    {
        PlayerTopPart.isDead = true;
        PlayerBottomPart.isDead = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
