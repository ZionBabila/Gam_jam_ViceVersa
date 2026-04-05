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

    public void OnSettingsClick()
    {
        // Check if Menu exists before trying to activate it
        if (Menu != null)
        {
            Debug.Log("Settings work!");
            Menu.SetActive(true);
            AudioManager.clickSound = true;
        }
    }

    public void OnCloseClick()
    {
        if (Menu != null)
        {
            Debug.Log("Close work!");
            Menu.SetActive(false);
            AudioManager.clickSound = true;
        }
    }

    public void OnRstartClick()
    {
        Debug.Log("Restart work!");
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

    public void OnstartClick()
    {
        StartCoroutine(LoadLevel1());
        AudioManager.clickSound = true;
    }

    private IEnumerator LoadLevel1()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Yoav");
    }

    public void OnaboutClick()
    {
        if (about != null)
        {
            about.SetActive(true);
            AudioManager.clickSound = true;
        }
    }

    public void Win()
    {
        // Check if winM is true AND the WinMenu object actually exists in this scene
        if (winM && WinMenu != null)
        {
            WinMenu.SetActive(true);
            Debug.Log("WinMenu is now active");
        }
    }

    public void OnContinue()
    {
        StartCoroutine(Continueload());
        AudioManager.clickSound = true;
    }

    public void OnExitTutorial()
    {       
            tutorialMenu.SetActive(false);
            tutorialMenuX.SetActive(false);
    }

    private IEnumerator Continueload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Opening");
    }
}