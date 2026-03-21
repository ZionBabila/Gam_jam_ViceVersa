using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static int Harts = 3;

    // Update is called once per frame
    void Update()
    {
        if (Harts<0)
        {
            PlayerTopPart.isDead = true;
            PlayerBottomPart.isDead = true;
        }
    }
}
