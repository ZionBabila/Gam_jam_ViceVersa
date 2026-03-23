using UnityEngine;

public class BreakingGrave : MonoBehaviour
{
    public class ImageChanger : MonoBehaviour
    {
        public Sprite targetImage;
        public Sprite Frame1;
        public Sprite Frame2;
        public Sprite Frame3;
        public Sprite Frame4;


        public void ChangeImage()
        {
            targetImage.sprite = Frame1;
        }
    }
}
