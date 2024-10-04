using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeypadBackground background;
    private Combination combination;
    private List<int> buttonsEntered;

    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        ResetButtonEntries();
    }

    public void RegisterButtonClick(int buttonValue)
    {
        // print("Keypad recieved button value " + buttonValue);
        buttonsEntered.Add(buttonValue);
        print(String.Join(", ", buttonsEntered));
    }

    public void TryToUnlock()
    {
        if (IsCorrectCombination())
            Unlock();
        else
            FailToUnlock();

        ResetButtonEntries();
    }

    private bool IsCorrectCombination()
    {
        if(HaveNoButtonsBeenClicked())
            return false;

        if(IsCombinationIncorrectLength())
            return false;

        return CheckCombination();
    }

    private bool CheckCombination()
    {
        for (int buttonIndex = 0; buttonIndex < buttonsEntered.Count; buttonIndex++)
        {
            if(!IsCorrectButton(buttonIndex))
                return false;
        }
        return true;
    }

    private bool HaveNoButtonsBeenClicked()
    {
        return buttonsEntered.Count == 0;
    }

    private bool IsCombinationIncorrectLength()
    {
        return buttonsEntered.Count != combination.GetCombinationLength();
    }

    private bool IsCorrectButton(int buttonIndex)
    {
        if(IsWrongEntry(buttonIndex))
            return false;
        return true;
        
    }

    private bool IsWrongEntry(int buttonIndex)
    {
        if(buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex))
            return false;
        return true;
    }

    private void Unlock()
    {
        print("Unlocked");
        background.HideUnlockButton();
        background.ChangeToSuccessColor();
    }

    private void FailToUnlock()
    {
        print("Failed");
        background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }

    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.33f);
        background.ChangeToDefaultColor();
    }

    private void ResetButtonEntries()
    {
        buttonsEntered = new List<int>();
    }
}
