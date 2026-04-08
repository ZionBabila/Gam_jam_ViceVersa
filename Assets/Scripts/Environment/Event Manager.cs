using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static int Harts = 3;
    public GameObject Hart1;
    public GameObject Hart2;
    public GameObject Hart3;
    private bool isTransitioning = false;

    //portals Check
    public static bool TopOnPortalLevel1 = false;
    public static bool BottomOnPortalLevel1 = false;
    public static bool TopOnPortalLevel2 = false;
    public static bool BottomOnPortalLevel2 = false;
    public static bool TopWin = false;
    public static bool BottomWin = false;



    void Start()
    {
        Harts = 3;
        TopOnPortalLevel1 = false;
        BottomOnPortalLevel1 = false;
        TopOnPortalLevel2 = false;
        BottomOnPortalLevel2 = false;
    }

    void Update()
    {
        if (isTransitioning)
        {
            return; // Skip the rest of the Update if we're transitioning
        }
        //Command to restart
        if (Harts < 1)
        {
            StartCoroutine(WaitAndReload());
        }

        HartUi();
        Level1PortalChek();
        Level2PortalChek();
        win();
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
        AudioManager.loseLevelSound = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Levels Loaders
    //Tutorial
    void Level1PortalChek()
    {
        if (TopOnPortalLevel1 == true && BottomOnPortalLevel1 == true)
        {
            isTransitioning = true; // Set the flag to prevent further updates
            PlayerTopPart.isDead = true;
            PlayerBottomPart.isDead = true;
            StartCoroutine(LoadLevel2());
        }
    }
    private IEnumerator LoadLevel2()
    {
        AudioManager.winLevelSound = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level 2");
    }


    //Level 2
    void Level2PortalChek()
    {
        if (TopOnPortalLevel2 == true && BottomOnPortalLevel2 == true)
        {
            if (!isTransitioning)
            {
                isTransitioning = true; // Set the flag to prevent further updates
            }
            PlayerTopPart.isDead = true;
            PlayerBottomPart.isDead = true;
            StartCoroutine(LoadLevel3());
        }
    }
    private IEnumerator LoadLevel3()
    {
        AudioManager.winLevelSound = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level3");
    }


    //Level3
    void win()
    {
        if (TopWin && BottomWin)
        {
            MenuController.winM = true;
        }
    }
}
