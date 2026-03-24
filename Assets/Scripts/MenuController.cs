using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject about;

    void Start()
    {
        Menu.SetActive(false);
    }
    public void OnSettingsClick()
    {
        Debug.Log("settings work!");
        Menu.SetActive(true);
    }

    public void OnCloseClick()
    {
        Debug.Log("close work!");
        Menu.SetActive(false);
    }

    public void OnRstartClick()
    {
        Debug.Log("restart work!");
        StartCoroutine(WaitAndReload());
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
    }
}
    

    