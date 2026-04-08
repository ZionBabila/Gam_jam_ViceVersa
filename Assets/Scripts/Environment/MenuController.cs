using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject about;
    public GameObject WinMenu;
    public GameObject tutorialMenu;
    public GameObject tutorialMenuX;
    public GameObject tutorialMenu2;
    public GameObject tutorialMenuX2;
    public static bool winM = false;

    void Start()
    {
        // Added null checks to avoid errors if the object is missing in the scene
        if (Menu != null) 
            Menu.SetActive(false);
            
        if (WinMenu != null) 
            WinMenu.SetActive(false);
            
        // Reset win state to prevent the menu from appearing immediately in a new scene
        winM = false;
    }

    private void Update()
    {
        Win();
    }

    //Opening Scene
    public void OnaboutClick()
    {
        if (about != null)
        {
            about.SetActive(true);
            AudioManager.clickSound = true;
        }
    }
    public void OnstartClick()
    {
        StartCoroutine(LoadLevel1());
        AudioManager.clickSound = true;
    }
    private IEnumerator LoadLevel1()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Tutorial");
    }


    //Tutorial
    public void OnExitTutorial()
    {
        AudioManager.clickSound = true;
        tutorialMenu.SetActive(false);
        tutorialMenuX.SetActive(false);
    }
    public void OnExitTutorial2()
    {
        AudioManager.clickSound = true;
        tutorialMenu2.SetActive(false);
        tutorialMenuX2.SetActive(false);
    }


    //Level 3
    public void Win()
    {
        // Check if winM is true AND the WinMenu object actually exists in this scene
        if (winM)
            //&& WinMenu != null
        {
            Debug.Log("winnnn!");
            WinMenu.SetActive(true);
        }
    }
    public void OnContinueClick()
    {
        StartCoroutine(Continueload());
        AudioManager.clickSound = true;
    }
    private IEnumerator Continueload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Opening");
    }


    //Side Menu
    public void OnSettingsClick()
    {
        // Check if Menu exists before trying to activate it
        if (Menu != null)
        {
            Menu.SetActive(true);
            AudioManager.clickSound = true;
        }
    }
    public void OnRstartClick()
    {
        StartCoroutine(WaitAndReload());
        AudioManager.clickSound = true;
    }
    private IEnumerator WaitAndReload()
    {
        PlayerTopPart.isDead = true;
        PlayerBottomPart.isDead = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnCloseClick()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
            AudioManager.clickSound = true;
        }
    }
}