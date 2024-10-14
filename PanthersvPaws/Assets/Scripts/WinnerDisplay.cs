using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour
{
    public Image winnerImage;
    public Sprite PantherSprite;
    public Sprite PawSprite;
    public Sprite TieSprite;
    public Sprite BlankSprite;
    public void Reset()
    {
        Show(MarkerType.None);
    }
    public void Show(MarkerType markerType)
    {
         if (markerType == MarkerType.Paw)
            winnerImage.sprite = PawSprite;
        else if (markerType == MarkerType.Panther)
            winnerImage.sprite = PantherSprite;
        else if (markerType == MarkerType.Tie)
            winnerImage.sprite = TieSprite;
        else
            winnerImage.sprite = BlankSprite;
    }
}
