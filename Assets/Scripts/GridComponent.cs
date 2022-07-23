using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridComponent : MonoBehaviour
{

    public TextMeshProUGUI buttonText;
    public Button button;

    private GameController gameCotroller;
    public void SetComponent()
    {
        buttonText.text = gameCotroller.GetPlayerSide();
        button.interactable = false;
        gameCotroller.EndTurn();

    }

    public void SetGameControllerReference(GameController controller)
    {
        gameCotroller = controller;
    }
}