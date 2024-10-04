using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadBackground : MonoBehaviour
{
    public GameObject unlockButton;
    public Image backgroundImage;

    public void HideUnlockButton()
    {
        unlockButton.SetActive(false);
    }

    public void ChangeToSuccessColor()
    {
        backgroundImage.color = Color.green;
    }

    public void ChangeToFailedColor()
    {
        backgroundImage.color = Color.red;
    }

    public void ChangeToDefaultColor()
    {
        backgroundImage.color = Color.grey;
    }
}
