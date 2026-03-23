using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;

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

    public void OnRestartClick()
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
}