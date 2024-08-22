using UnityEngine;
using UnityEngine.UI;

public class VibrateButton : MonoBehaviour
{
    public Sprite Image1; // Assign your first sprite (e.g., ass.dic) in the inspector
    public Sprite Image2; // Assign your second sprite in the inspector
    private Sprite CheckImage;

    private void Start()
    {
        CheckImage = Image1; // Initially set CheckImage to Image1
        GetComponent<Image>().sprite = CheckImage; // Set the initial image on the button
    }

    public void OnButtonClick()
    {
        Image buttonImage = GetComponent<Image>();

        if (CheckImage == Image1)
        {
            CheckImage = Image2; // Toggle to Image2
        }
        else
        {
            CheckImage = Image1; // Toggle back to Image1
        }

        buttonImage.sprite = CheckImage; // Apply the toggled image to the button
    }
}
