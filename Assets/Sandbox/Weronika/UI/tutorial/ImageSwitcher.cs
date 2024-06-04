using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject[] images; // Array of image GameObjects to switch between
    private int currentIndex = 0;

    void Start()
    {
        UpdateImageVisibility();
    }

    public void ShowPreviousImage()
    {
        if (images.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = images.Length - 1;
        }
        UpdateImageVisibility();
    }

    public void ShowNextImage()
    {
        if (images.Length == 0) return;

        currentIndex++;
        if (currentIndex >= images.Length)
        {
            currentIndex = 0;
        }
        UpdateImageVisibility();
    }

    private void UpdateImageVisibility()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == currentIndex);
        }
    }
}
