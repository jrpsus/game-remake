using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public Text[] buttonList;

    private string playerSide;
    public int rng;
    private int moveCount;
    public Text scoreText;
    public Text nextText;

    void Awake()

    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount += 1;
        scoreText.text = "" + moveCount;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            ClearThis(0, 1, 2);
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            ClearThis(3, 4, 5);
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            ClearThis(6, 7, 8);
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            ClearThis(0, 3, 6);
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            ClearThis(1, 4, 7);
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            ClearThis(2, 5, 8);
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            ClearThis(0, 4, 8);
        }

        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            ClearThis(2, 4, 6);
        }
        ChangeSides();
    }

    void ChangeSides()
    {
        rng = Random.Range(1, 5);
        if (rng == 1)
        {
            playerSide = "X";
        }
        else if (rng == 2)
        {
            playerSide = "Y";
        }
        else if (rng == 3)
        {
            playerSide = "A";
        }
        else if (rng == 4)
        {
            playerSide = "B";
        }
        nextText.text = playerSide;
    }

    void ClearThis(int space1, int space2, int space3)
    {
        buttonList[space1].text = "";
        buttonList[space2].text = "";
        buttonList[space3].text = "";
        buttonList[space1].GetComponentInParent<Button>().interactable = true;
        buttonList[space2].GetComponentInParent<Button>().interactable = true;
        buttonList[space3].GetComponentInParent<Button>().interactable = true;
        moveCount += 100;
        scoreText.text = "" + moveCount;
    }
    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            buttonList[i].GetComponentInParent<Button>().interactable = true;
        }
        nextText.text = playerSide;
        scoreText.text = "" + moveCount;
    }
}