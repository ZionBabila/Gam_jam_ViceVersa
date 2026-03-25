using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject about;
    public GameObject WinMenu;
    public static bool winM = false;


    void Start()
    {
        Menu.SetActive(false);
        WinMenu.SetActive(false);
    }

    private void Update()
    {
        Win();
    }
    public void OnSettingsClick()
    {
        Debug.Log("settings work!");
        Menu.SetActive(true);
        AudioManager.clickSound = true;
    }

    public void OnCloseClick()
    {
        Debug.Log("close work!");
        Menu.SetActive(false);
        AudioManager.clickSound = true;
    }


    public void OnRstartClick()
    {
        Debug.Log("restart work!");
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

    //Load  Level 1
    private IEnumerator LoadLevel1()
    {

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Yoav");
    }

    public void OnaboutClick()
    {
        about.SetActive(true);
        AudioManager.clickSound = true;
    }

    public void Win()
    {
        if (winM)
        {
            WinMenu.SetActive(true);
            Debug.Log("winMenu");
        }
    }

    public void OnContinue()
    {
        StartCoroutine(Continueload());
        AudioManager.clickSound = true;
    }

    private IEnumerator Continueload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Opening");
    }
}
    

    