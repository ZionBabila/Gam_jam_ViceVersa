using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static int Harts = 3;
    public GameObject Hart1;
    public GameObject Hart2;
    public GameObject Hart3;
    public static bool TopNextLevel = false;
    public static bool BottomNextLevel = false;


    void Start()
    {
        Harts = 3;
        TopNextLevel = false;
        BottomNextLevel = false;
}

    void Update()
    {
        //Command to restart
        if (Harts<1)
        {
            StartCoroutine(WaitAndReload());
        }

        HartUi();
        Level2();
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
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //check for both Players
    void Level2()
    {
        if (TopNextLevel == true && BottomNextLevel == true)
        {
            Debug.Log("win");
            PlayerTopPart.isDead = true;
            PlayerBottomPart.isDead = true;
            StartCoroutine(WaitAndLoad());
        }
    }

    //Load The Level
    private IEnumerator WaitAndLoad()
    {
       
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Yoav - Level2");
    }
}
