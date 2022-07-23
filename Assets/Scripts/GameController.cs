using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Player
{
    public Image panel;
    public TextMeshProUGUI text;
    public Button button;

}
[System.Serializable]
public class PlayerColor
{

    public Color panelColor;
    public Color textColor;
}


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI[] buttonList;
    private string playerSide;
    public GameObject gameover;
    public TextMeshProUGUI gameoverText;
    private int moveCount;
    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject starI;

   // private string computerSide;
    public bool playerMove;
    public float delay;
 //   private int value;



    void Awake()
    {

        SetGameControllerRerefenceOnButtons();
        gameover.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;

    }
    //void Update()
    //{
    //    if (playerMove == false)
    //    {
    //        Debug.Log()
    //        EndTurn(); 
    //    }

    //}


    void SetGameControllerRerefenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {

            buttonList[i].GetComponentInParent<GridComponent>().SetGameControllerReference(this);
        }

    }

    public void SetSartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
           // computerSide = "O";
            SetPlayerColors(playerX, playerO);
        }
        else if (playerSide == "O")
        {
          //  computerSide = "X";
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoarddInteractable(true);
        SetPlayerButton(false);
        starI.SetActive(false);
    }


    public string GetPlayerSide()
    {
        Debug.Log("PlayerSide Tiene el valor de :" + playerSide);
        return playerSide;

    }

   // public string GetComputerSide()
   // {
    //    return computerSide;
    //}

    public void EndTurn()
    {

       
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {

            GameOver(playerSide);

        }

        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {

            GameOver(playerSide);

        }

        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {

            GameOver(playerSide);

        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {

            GameOver(playerSide);

        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {

            GameOver(playerSide);

        }

        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {

            GameOver(playerSide);

        }

        else if (buttonList[5].text == playerSide && buttonList[4].text == playerSide && buttonList[3].text == playerSide)
        {

            GameOver(playerSide);

        }

        else if (buttonList[8].text == playerSide && buttonList[7].text == playerSide && buttonList[6].text == playerSide)
        {

            GameOver(playerSide);

        }
        else
        {
            if (moveCount >= 8)
            {
                GameOver("draw");

            }
            else
            {
                Debug.Log("moveCount En changeSides: "+ moveCount);
                moveCount++;
                ChangeSides();
            }
        }


     
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {

        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;

    }



    void GameOver(string winningPlayer)
    {

        SetBoarddInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("Fin del Juego");
            SetPlayerColorInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Ganador");
        }


        restartButton.SetActive(true);



    }

    void ChangeSides()
    {
        Debug.Log("----------------------------------");
        Debug.Log("playerSide estatus : " + playerSide);
        Debug.Log("playerMove estatus : " + playerMove);
        playerSide = (playerSide == "X") ? "O" : "X";
        Debug.Log("playerSide ternario ejecutado : "+ playerSide);
        playerMove = (playerMove == true) ? false : true;
        Debug.Log("playerMove ternario ejecutado : " + playerMove);
        if (playerSide == "X")
        {
            if (playerMove == true)
            {
                SetPlayerColors(playerX, playerO);

            }
            else
            {
                SetPlayerColors(playerO, playerX);

            }
        }

    }

    void SetGameOverText(string value)
    {
        gameover.SetActive(true);
        gameoverText.text = value;


    }

    public void RestarGame()
    {

        moveCount = 0;
        gameover.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButton(true);
        SetPlayerColorInactive();
        starI.SetActive(true);
        playerMove = true;
        delay = 10;


        for (int i = 0; i < buttonList.Length; i++)
        {

            buttonList[i].text = "";

        }
        SetPlayerColors(playerX, playerO);
        restartButton.SetActive(false);


    }

    void SetBoarddInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }

    }

    void SetPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;

    }

    void SetPlayerColorInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.panel.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.panel.color = inactivePlayerColor.textColor;
    }
}