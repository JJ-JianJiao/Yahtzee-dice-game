using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Player : MonoBehaviour
public class Player
{
    public bool[] selectedCombs;
    public int firstPair;
    public int secondPair;
    public int threeValues;
    public int fourValues;
    public int fiveValues;
    public bool smallStraight;
    public bool largeStraight;
    public int[] dicesResult;
    public int[] structureDicesResult;

    public int[] keepDices;

    public bool[] currentCombos;
    public bool secondRoll;
    public bool firstRoll;

    Color turnTextColor;

    public Color TurnTextColor { get => turnTextColor; set => turnTextColor = value; }

    public Player() {
        //playerTurnTextColor = Color.red;
        //Test Selected Combos
        //selectedCombs = new bool[6] { true, true, true, true, false, true };





        selectedCombs = new bool[6] { false, false, false, false, false, false };
        firstPair = -1;
        secondPair = -1;
        threeValues = -1;
        fourValues = -1;
        fiveValues = -1;
        smallStraight = false;
        largeStraight = false;
        dicesResult = new int[5] { -1, -1, -1, -1, -1 };
        keepDices = new int[5] { -1, -1, -1, -1, -1 };
        structureDicesResult = new int[6] { 0, 0, 0, 0, 0, 0 };

        currentCombos = new bool[6] { false, false, false, false, false, false };

        secondRoll = false;
        firstRoll = false;
    }

    public void RollDices() {

        for (int i = 0; i < dicesResult.Length; i++)
        {
            dicesResult[i] = Random.Range(0, 6);
        }


        //LargeStraight Test Case
        //dicesResult = new int[5] { 0, 1, 2, 3, 4 };


        //Small straight test
        //dicesResult = new int[5] { 1, 1, 2, 3, 4 };
        //dicesResult = new int[5] { 0, 1, 2, 3, 5 };


        //dicesResult = new int[5] { 1, 2, 3, 4, 5 };
    }

    public void RollDices(int[] keepDices) {

        for (int i = 0; i < keepDices.Length; i++)
        {
            if (keepDices[i] == -1)
            {

                dicesResult[i] = Random.Range(0, 6);

            }
            else {
                dicesResult[i] = keepDices[i];


            }
        }
    }

    public void AnalyzeDices() {

        for (int i = 0; i < dicesResult.Length; i++)
        {
            if (dicesResult[i] == 0)
            {
                structureDicesResult[0]++;
            }
            else if (dicesResult[i] == 1)
            {
                structureDicesResult[1]++;
            }
            else if (dicesResult[i] == 2)
            {
                structureDicesResult[2]++;
            }
            else if (dicesResult[i] == 3)
            {
                structureDicesResult[3]++;
            }
            else if (dicesResult[i] == 4)
            {
                structureDicesResult[4]++;
            }
            else if (dicesResult[i] == 5)
            {
                structureDicesResult[5]++;
            }
        }

    }


    public void AnalyzeStructure() {

        if ((structureDicesResult[0] == 0 && structureDicesResult[1] == 1 && structureDicesResult[2] == 1 && structureDicesResult[3] == 1 && structureDicesResult[4] == 1 && structureDicesResult[5] == 1)
            ||
            (structureDicesResult[5] == 0 && structureDicesResult[0] == 1 && structureDicesResult[1] == 1 && structureDicesResult[2] == 1 && structureDicesResult[3] == 1 && structureDicesResult[4] == 1)
            )
        {

            largeStraight = true;

        }
        else if ((structureDicesResult[0] > 0 && structureDicesResult[1] > 0 && structureDicesResult[2] > 0 && structureDicesResult[3] > 0)
            || (structureDicesResult[1] > 0 && structureDicesResult[2] > 0 && structureDicesResult[3] > 0 && structureDicesResult[4] > 0)
            || (structureDicesResult[2] > 0 && structureDicesResult[3] > 0 && structureDicesResult[4] > 0 && structureDicesResult[5] > 0)
            )
        {

            smallStraight = true;
            if (structureDicesResult[0] == 2)
            {
                firstPair = 0;
            }
            else if (structureDicesResult[1] == 2) {
                firstPair = 1;
            }
            else if (structureDicesResult[2] == 2)
            {
                firstPair = 2;
            }
            else if (structureDicesResult[3] == 2)
            {
                firstPair = 3;
            }
            else if (structureDicesResult[4] == 2)
            {
                firstPair = 4;
            }
            else if (structureDicesResult[5] == 2)
            {
                firstPair = 5;
            }
        }
        else {

            for (int i = 0; i < structureDicesResult.Length; i++)
            {
                if (structureDicesResult[i] == 2)
                {

                    if (firstPair == -1)
                    {

                        firstPair = i;
                    }
                    else
                    {

                        secondPair = i;
                        break;

                    }

                }
                else if (structureDicesResult[i] == 3)
                {

                    threeValues = i;

                }
                else if (structureDicesResult[i] == 4)
                {

                    fourValues = i;
                    break;
                }
                else if (structureDicesResult[i] == 5) {

                    fiveValues = i;
                    break;

                }
            }

        }

    }


    public void AnalyzeCombos() {

        if (largeStraight == true)
        {
            currentCombos[5] = true;
            currentCombos[4] = true;
        }
        else if (smallStraight == true)
        {
            currentCombos[4] = true;
        }
        else if (threeValues != -1 && firstPair != -1)
        {
            currentCombos[3] = true;
            currentCombos[0] = true;
            currentCombos[1] = true;
        }
        else if (fourValues != -1)
        {

            currentCombos[2] = true;
            currentCombos[1] = true;

        }
        else if (fiveValues != -1)
        {

            currentCombos[2] = true;
            currentCombos[1] = true;

        }
        else if (threeValues != -1)
        {

            currentCombos[1] = true;

        }
        else if (firstPair != -1 && secondPair != -1) {

            currentCombos[0] = true;

        }



    }

    public void InitalNewRoll() {

        firstPair = -1;
        secondPair = -1;
        threeValues = -1;
        fourValues = -1;
        fiveValues = -1;
        smallStraight = false;
        largeStraight = false;
        dicesResult = new int[5] { -1, -1, -1, -1, -1 };
        structureDicesResult = new int[6] { 0, 0, 0, 0, 0, 0 };

        currentCombos = new bool[6] { false, false, false, false, false, false };

        secondRoll = false;
        firstRoll = false;

        keepDices = new int[5] { -1, -1, -1, -1, -1 };
    }


    public void InitialSecondRoll() {
        structureDicesResult = new int[6] { 0, 0, 0, 0, 0, 0 };
        currentCombos = new bool[6] { false, false, false, false, false, false };
        firstPair = -1;
        secondPair = -1;
        threeValues = -1;
        fourValues = -1;
        fiveValues = -1;
        smallStraight = false;
        largeStraight = false;
    }


    public string DisplayDiceResults() {

        string dicceResuiltStr = null;
        for (int i = 0; i < dicesResult.Length; i++)
        {
            dicceResuiltStr += dicesResult[i] + 1 + " ";
        }

        return dicceResuiltStr;
    }

    public string DisplayKeepsDiceResults()
    {

        string keepDiceResuiltStr = null;
        for (int i = 0; i < keepDices.Length; i++)
        {
            //if (dicesResult[i] != -1)
            if (keepDices[i] != -1)
            {
                keepDiceResuiltStr += keepDices[i] + 1 + " ";
                //keepDiceResuiltStr += dicesResult[i] + 1 + " ";
            }
            else
            {
                keepDiceResuiltStr +=  " null ";
            }
        }

        return keepDiceResuiltStr;
    }


    public string DisplayDIceStructure() {

        string diceResuiltStructureStr = null;
        for (int i = 0; i < structureDicesResult.Length; i++)
        {
            diceResuiltStructureStr += structureDicesResult[i] + " ";
        }

        return diceResuiltStructureStr;

    }


    public string DisplayComboElements() {

        string combosElems = null;
        combosElems += "firstPair = " + (firstPair == -1 ? " null" : firstPair.ToString()) + "; ";
        combosElems += "secondPair = " + (secondPair == -1 ? " null" : secondPair.ToString()) + "; ";
        combosElems += "threeValues = " + (threeValues == -1 ? " null" : threeValues.ToString()) + "; ";
        combosElems += "fourValues = " + (fourValues == -1 ? " null" : fourValues.ToString()) + "; ";
        combosElems += "fiveValues = " + (fiveValues == -1 ? " null" : fiveValues.ToString()) + "; ";
        combosElems += "smallStraight = " + (smallStraight ? " True" : " False") + "; ";
        combosElems += "largeStraight = " + (largeStraight ? " True" : " False");
        return combosElems;
    }


    public string DisplayCurrentCombos()
    {
        string currentCombosStr = null;
        if (currentCombos[0])
        {
            currentCombosStr += "<Two Pair> ";
        }
        if (currentCombos[1]) {
            currentCombosStr += "<Three of Kind> ";
        }
        if (currentCombos[2])
        {
            currentCombosStr += "<Four of Kind> ";
        }
        if (currentCombos[3])
        {
            currentCombosStr += "<Full House> ";
        }
        if (currentCombos[4])
        {
            currentCombosStr += "<Small Straight> ";
        }
        if (currentCombos[5])
        {
            currentCombosStr += "<Large Straight>";
        }

        return currentCombosStr==null?"null": currentCombosStr;

    }
}
