using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Player
{
    public bool AITurnEnd;
    public bool AIShowKeeps;

    public AI() {

        AIShowKeeps = false;
        AITurnEnd = false;
    
    }

    public void ChooseCombo() {

        if (largeStraight == true)
        {

            CaseLargeStraight();

        }
        else if (smallStraight == true)
        {

            CaseSmallStraight();

        }
        else if (threeValues != -1 && firstPair != -1)
        {

            CaseFullHouse();

        }
        else if (fourValues != -1)
        {

            CaseFourOfKind();

        }
        else if (threeValues != -1)
        {

            CaseThreeOfKind();

        }
        else if (firstPair != -1 && secondPair != -1)
        {

            CaseTwoPair();

        }
        else if (fiveValues != -1)
        {

            CaseFiveValues();

        }
        else if (firstPair != -1 && secondPair == -1)
        {


            CaseOnlyPair();

        }
        else {

            AllSingle();
        
        }


    }


    public void CaseLargeStraight()
    {
        if (selectedCombs[5] == false)
        {

            selectedCombs[5] = true;
            Debug.Log("AI choose LargeStraight! ------" + DisplayDiceResults());
            EndTurn();
        }
        else {

            if (firstRoll == false)
            {
                if (selectedCombs[4] == false)
                {

                    selectedCombs[4] = true;
                    Debug.Log("AI choose SmallStraight! ------" + DisplayDiceResults());
                    EndTurn();

                }
                else if (selectedCombs[3] == false || selectedCombs[2] == false ||
                    selectedCombs[1] == false || selectedCombs[0] == false) {

                    keepDices = new int[5] { 2, -1, -1, -1, -1 };

                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for FullHouse, three Kind, four kind, two Pair");




                    NeedReroll();

                }

            }
            else if (firstRoll == true && secondRoll == false) {

                if (selectedCombs[5] == false)
                {

                    selectedCombs[5] = true;

                }
                else {
                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose nothing!");

                }
                EndTurn();
            }            
        }


    }
    public void CaseSmallStraight()
    {
        if (secondRoll == false && firstRoll == false)
        {

            if (selectedCombs[5] == false)
            {

                if (structureDicesResult[0] > 0 &&
                    structureDicesResult[1] > 0 &&
                    structureDicesResult[2] > 0 &&
                    structureDicesResult[3] > 0
                    )
                {
                    keepDices = new int[5] { 0, 1, 2, 3, -1 };

                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");

                    NeedReroll();
                }
                else if (structureDicesResult[1] > 0 &&
                    structureDicesResult[2] > 0 &&
                    structureDicesResult[3] > 0 &&
                    structureDicesResult[4] > 0
                    )
                {
                    keepDices = new int[5] { 1, 2, 3, 4, -1 };

                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");

                    NeedReroll();
                }
                else if (structureDicesResult[2] > 0 &&
                    structureDicesResult[3] > 0 &&
                    structureDicesResult[4] > 0 &&
                    structureDicesResult[5] > 0
                    )
                {
                    keepDices = new int[5] { 2, 3, 4, 5, -1 };

                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");

                    NeedReroll();
                }

            }
            else if (selectedCombs[4] == true)
            {

                if (selectedCombs[3] == false || selectedCombs[2] == false || selectedCombs[1] == false
                    || selectedCombs[0] == false)
                {

                    if (firstPair > 0)
                    {

                        keepDices = new int[] { firstPair, firstPair, -1, -1, -1 };

                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for FullHouse, three Kind, four kind, two Pair");
                        NeedReroll();

                    }
                    else if (firstPair <= 0)
                    {

                        keepDices = new int[] { 2, -1, -1, -1, -1 };

                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for FullHouse, three Kind, four kind, two Pair");
                        NeedReroll();

                    }

                }


            }
            else if (selectedCombs[4] == false)
            {

                selectedCombs[4] = true;

                Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Small Straight!(frist roll)");
                EndTurn();
            }

        }
        else if (secondRoll == false && firstRoll == true) {

            if (selectedCombs[4] == false)
            {
                selectedCombs[4] = true;
                Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Small Straight!(second Roll)");
            }
            else {

                Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose nothing");

            }
            EndTurn();
        
        }
    }


    public void CaseFullHouse()
    {
        if (selectedCombs[3] == false)
        {

            selectedCombs[3] = true;

            Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Full House!(frist or second roll)");
            EndTurn();

        }
        else {

            if (secondRoll == false && firstRoll == true)
            {
                if (selectedCombs[1] == false)
                {
                    selectedCombs[1] = true;

                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Three Kind!(second roll)");
                    EndTurn();
                }
                else if (selectedCombs[0] == false)
                {

                    selectedCombs[0] = true;
                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Two Pair!(second roll)");
                    EndTurn();
                }
                else {
                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose nothing");
                    EndTurn();

                }
            }
            else if (firstRoll == false && secondRoll == false) {

                if (selectedCombs[1] == false)
                {

                    selectedCombs[1] = true;

                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Three Kind!(first roll)");
                    EndTurn();

                }
                else if (selectedCombs[0] == false)
                {

                    selectedCombs[0] = true;
                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose Two Pair!(first roll)");
                    EndTurn();

                }
                else if (selectedCombs[2] == false)
                {

                    keepDices = new int[] { threeValues, threeValues, threeValues, -1, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for four kind");

                    NeedReroll();

                }
                else if (selectedCombs[5] == false)
                {

                    if (Mathf.Abs(threeValues - firstPair) == 5)
                    {

                        keepDices = new int[] { threeValues, -1, -1, -1, -1 };
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                        NeedReroll();
                    }
                    else
                    {

                        keepDices = new int[] { threeValues, firstPair, -1, -1, -1 };
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                        NeedReroll();
                    }


                }
                else if (selectedCombs[4] == false) {

                    if (Mathf.Abs(threeValues - firstPair) > 3)
                    {

                        keepDices = new int[] { threeValues, -1, -1, -1 ,-1};
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                        NeedReroll();
                    }
                    else {

                        keepDices = new int[] {threeValues, firstPair, -1, -1, -1 };
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                        NeedReroll();
                    }

                }
            
            }       
        
        }

    }


    public void CaseFourOfKind()
    {
        if (selectedCombs[2] == false)
        {

            selectedCombs[2] = true;
            Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose four of kind!(first or second roll)");
            EndTurn();
        }
        else {

            if (secondRoll == false && firstRoll == true)
            {
                if (selectedCombs[1] == false)
                {

                    selectedCombs[1] = true;
                    Debug.Log("Result is [" + DisplayDiceResults() + "], AI choose four of kind!(second roll)");
                    EndTurn();

                }
                else {
                    EndTurn();
                }
            }
            else if (firstRoll == false && secondRoll == false) {

                if (selectedCombs[1] == false || selectedCombs[3] == false)
                {

                    keepDices = new int[] { fourValues, fourValues, fourValues, -1, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for full house, three kind");
                    NeedReroll();
                }
                else if (selectedCombs[0] == false)
                {

                    int singleValue = GetSingleValue("fourKind");

                    keepDices = new int[] { fourValues, fourValues, singleValue, -1, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for two pair");
                    NeedReroll();
                }
                else if (selectedCombs[4] == false)
                {

                    int singleValue = GetSingleValue("fourKind");

                    if (Mathf.Abs(fourValues - singleValue) > 3)
                    {

                        keepDices = new int[] { fourValues, -1, -1 ,- 1, -1 };
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                        NeedReroll();
                    }
                    else
                    {


                        keepDices = new int[] { fourValues, singleValue, -1, -1 ,-1};
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                        NeedReroll();
                    }

                }
                else if (selectedCombs[5] == false) {

                    int singleValue = GetSingleValue("fourKind");/////////


                    if (Mathf.Abs(fourValues - singleValue) == 5)
                    {

                        keepDices = new int[] { fourValues, -1, -1, -1, -1 };
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                        NeedReroll();
                    }
                    else
                    {
                        keepDices = new int[] { fourValues, singleValue, -1, -1, -1};
                        Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                        NeedReroll();
                    }

                }

            
            }
        
        
        }

    }



    public void CaseThreeOfKind()
    {
        if (secondRoll == false && firstRoll == true) //second roll
        {

            if (selectedCombs[1] == false)
            {

                selectedCombs[1] = true;
                Debug.Log("AI choose Three of Kind! ------" + DisplayDiceResults());

                EndTurn();
            }
            else {

                EndTurn();

            }

        }
        else if (secondRoll == false && firstRoll == false) { //first roll

            if (selectedCombs[3] == false)
            {

                int singleValue = GetSingleValue("threeKind");
                keepDices = new int[] { threeValues, threeValues, threeValues, singleValue, -1 };
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for full house");
                NeedReroll();
            }
            else if (selectedCombs[2] == false)
            {

                keepDices = new int[] { threeValues, threeValues, threeValues, -1, -1 };
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for four kind");
                NeedReroll();

            }
            else if (selectedCombs[0] == false)
            {

                int singleValue = GetSingleValue("threeKind");
                keepDices = new int[] { threeValues, threeValues, singleValue, -1, -1 };
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for two pair");
                NeedReroll();
            }
            else if (selectedCombs[5] == false)
            {

                keepDices = LookForLargeStraight("threeKind");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                NeedReroll();

            }
            else if (selectedCombs[4] == false) {

                keepDices = LookForSmallStraight("threeKind");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                NeedReroll();

            }       
        
        }

    }


    public void CaseTwoPair()
    {
        if (firstRoll == true && secondRoll == false)
        {

            if (selectedCombs[0] == false)
            {

                selectedCombs[0] = true;

                Debug.Log("AI choose Two Pair! ------" + DisplayDiceResults());
                EndTurn();
            }
            else {


                EndTurn();
            }
        }
        else if (secondRoll == false && firstRoll == false)
        {

            if (selectedCombs[0] == false)
            {

                if (selectedCombs[3] == false || selectedCombs[1] == false)
                {

                    keepDices = new int[] { firstPair, secondPair, firstPair, secondPair, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + "for three kind or Full house");
                    NeedReroll();

                }
                else
                {


                    selectedCombs[0] = true;
                    Debug.Log("AI choose Two Pair! ------" + DisplayDiceResults() + " first roll");
                    EndTurn();

                }


            }
            else if (selectedCombs[0] == true)
            {

                if (selectedCombs[3] == false)
                {

                    keepDices = new int[] { firstPair, secondPair, firstPair, secondPair, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for full house");
                    NeedReroll();

                }
                else if (selectedCombs[2] == false || selectedCombs[1] == false)
                {

                    keepDices = new int[] { firstPair, firstPair, -1, -1, -1 };
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for three/four Kind");
                    NeedReroll();

                }
                else if (selectedCombs[5] == false)
                {

                    keepDices = LookForLargeStraight("twoPair");
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                    NeedReroll();


                }
                else if (selectedCombs[4] == false)
                {


                    keepDices = LookForSmallStraight("twoPair");
                    Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                    NeedReroll();

                }


            }

        }
        
    }
    public void CaseFiveValues()
    {
        if (secondRoll == false && firstRoll == true)
        {

            if (selectedCombs[2] == false)
            {

                selectedCombs[2] = true;

                Debug.Log("AI choose four of Kind! ------" + DisplayDiceResults() + " second Roll");

                EndTurn();

            }
            else if (selectedCombs[1] == false)
            {

                selectedCombs[1] = true;

                Debug.Log("AI choose three of Kind! ------" + DisplayDiceResults() + " second Roll");

                EndTurn();

            }
            else {

                EndTurn();

            }

        }
        else if (firstRoll == false && secondRoll == false) {

            if (selectedCombs[2] == false)
            {
                Debug.Log("AI choose four of Kind! ------" + DisplayDiceResults() + " first Roll");

                selectedCombs[2] = true;
                EndTurn();

            }
            else if (selectedCombs[3] == false)
            {

                keepDices = new int[5] { fiveValues, fiveValues, fiveValues, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for FullHouse");
                NeedReroll();

            }
            else if (selectedCombs[1] == false)
            {

                selectedCombs[1] = true;
                Debug.Log("AI choose three of Kind! ------" + DisplayDiceResults() + " first Roll");

                EndTurn();

            }
            else if (selectedCombs[0] == false)
            {
                keepDices = new int[5] { fiveValues, fiveValues, -1, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for two Pair");
                NeedReroll();
            }
            else if (selectedCombs[4] == false || selectedCombs[5] == false) {

                keepDices = new int[5] { fiveValues, -1, -1, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large/small straight");
                NeedReroll();


            }

        }

    }
    public void CaseOnlyPair()
    {
        if (secondRoll == false && firstRoll == false)
        {

            if (selectedCombs[3] == false)
            {

                int singleValue = GetSingleValue("onlyOnePair");
                keepDices = new int[5] { firstPair, firstPair, singleValue, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for full house");
                NeedReroll();
            }
            else if (selectedCombs[2] == false || selectedCombs[1] == false)
            {
                keepDices = new int[5] { firstPair, firstPair, -1, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for threeKind or fourKind");
                NeedReroll();
            }

            else if (selectedCombs[0] == false)
            {
                int singleValue = GetSingleValue("onlyOnePair");
                keepDices = new int[5] { firstPair, firstPair, singleValue, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for two Pair");
                NeedReroll();
            }
            else if (selectedCombs[5] == false)
            {

                keepDices = LookForLargeStraight("onePair");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                NeedReroll();
            }
            else if (selectedCombs[4] == false)
            {


                keepDices = LookForSmallStraight("onePair");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                NeedReroll();

            }

        }
        else {

            EndTurn();
        
        }

    }
    public void AllSingle()
    {
        if (secondRoll == false && firstRoll == false)
        {

            if (selectedCombs[4] == false)
            {

                keepDices = LookForSmallStraight("allSingle");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for small straight");
                NeedReroll();

            }
            else if (selectedCombs[5] == false)
            {

                keepDices = LookForLargeStraight("allSingle");
                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for large straight");
                NeedReroll();

            }
            else
            {

                int singleValue = GetSingleValue("allSingle");

                keepDices = new int[5] { singleValue, -1, -1, -1, -1 };

                Debug.Log("AI " + " keeps: " + DisplayKeepsDiceResults() + " for others all except LR/SS");
                NeedReroll();
            }

        }

        else {


            EndTurn();
        }

    }
    public void NeedReroll()
    {

        firstRoll = true;
        firstPair = -1;
        secondPair = -1;
        threeValues = -1;
        fourValues = -1;
        fiveValues = -1;
        smallStraight = false;
        largeStraight = false;
        structureDicesResult = new int[6] { 0, 0, 0, 0, 0, 0 };

        currentCombos = new bool[6] { false, false, false, false, false, false };

    }


    private int GetSingleValue(string type)
    {
        int singleValue = -1;

        if (type == "fourKind" || type == "threeKind" || type == "onlyOnePair")
        {
            for (int i = 0; i < structureDicesResult.Length; i++)
            {
                if (structureDicesResult[i] == 1)
                {

                    singleValue = i;


                }
            }

        }
        else if (type == "allSingle") {


            singleValue = 4;


        }

        return singleValue;
    }


    public void EndTurn()
    {
        AIShowKeeps = false;
        AITurnEnd = true;
        //BroadcastMessage("ChangePlayer");

    }


    private int[] LookForSmallStraight(string type)
    {
        int[] keeps = { -1, -1, -1, -1, -1 };

        //Three of Kind keeps dices for Large straight
        if (type == "threeKind" || type == "twoPair")
        {
            int a = -1;
            int b = -1;
            int c = -1;
            for (int i = 0; i < structureDicesResult.Length; i++)
            {
                if (structureDicesResult[i] != 0)
                {

                    if (a == -1)
                    {

                        a = i;

                    }
                    else if (b == -1)
                    {

                        b = i;

                    }
                    else if (c == -1)
                    {

                        c = i;

                    }

                }
            }

            if (c - a < 4)
            {
                keeps[0] = a;
                keeps[1] = b;
                keeps[2] = c;
            }
            else if (c - a == 4)
            {

                keeps[0] = c;
                keeps[1] = b;
            }
            else if (c - a == 5)
            {

                if (b >= 3)
                {
                    keeps[0] = c;
                    keeps[1] = b;
                }
                else
                {
                    keeps[0] = a;
                    keeps[1] = b;
                }

            }

        }
        else if (type == "allSingle")
        {
            if (structureDicesResult[2] == 0)
            {

                keeps[0] = 3;
                keeps[1] = 4;
                keeps[2] = 5;

            }
            else if (structureDicesResult[3] == 0)
            {


                keeps[0] = 0;
                keeps[1] = 1;
                keeps[2] = 2;

            }

        }
        else if (type == "onePair") {
            int index = 0;
            for (int i = 0; i < structureDicesResult.Length; i++)
            {
                if (structureDicesResult[i] > 0) {

                    keeps[index] = i;
                    index++;
                }
            }

            if (keeps[2] - keeps[0] <= 3)
            {

                keeps[3] = -1;

            }
            else if (keeps[3] - keeps[1] <= 3)
            {
                keeps[0] = -1;
            }
            else {

                keeps[2] = -1;
                keeps[3] = -1;
            }

        }
        return keeps;
    }

    private int[] LookForLargeStraight(string type)
    {
        int[] keeps = { -1, -1, -1, -1, -1 };

        //Three of Kind keeps dices for Large straight
        if (type == "threeKind" || type == "twoPair")
        {
            int a = -1;
            int b = -1;
            int c = -1;
            for (int i = 0; i < structureDicesResult.Length; i++)
            {
                if (structureDicesResult[i] != 0)
                {

                    if (a == -1)
                    {

                        a = i;

                    }
                    else if (b == -1)
                    {

                        b = i;

                    }
                    else if (c == -1)
                    {

                        c = i;

                    }

                }
            }

            if (Math.Abs(c - a) == 5)
            {

                keeps[0] = a;
                keeps[1] = b;

            }
            else
            {

                keeps[0] = a;
                keeps[1] = b;
                keeps[2] = c;

            }
        }
        else if (type == "allSingle")
        {
            if (structureDicesResult[2] == 0)
            {

                keeps[0] = 3;
                keeps[1] = 4;
                keeps[2] = 5;
                keeps[3] = 1;

            }
            else if (structureDicesResult[3] == 0)
            {


                keeps[0] = 0;
                keeps[1] = 1;
                keeps[2] = 2;
                keeps[3] = 4;

            }

        }
        else if (type == "onePair") {
            int max = -1;
            int min = 10;
            int index = 0;
            for (int i = 0; i < dicesResult.Length; i++) 
            {
                if(max < dicesResult[i])
                {
                    max = dicesResult[i];
                }
                if (min > dicesResult[i]) {
                    min = dicesResult[i];
                }
            }
            if (max - min == 5)
            {

                for (int i = 1; i < structureDicesResult.Length; i++)
                {
                    if (structureDicesResult[i] > 0)
                    {

                        keeps[index] = i;
                        index++;

                    }

                }

            }
            else {

                //for (int i = 1; i < structureDicesResult.Length; i++)
                for (int i = 0; i < structureDicesResult.Length; i++)
                {
                    if (structureDicesResult[i] > 0)
                    {

                        keeps[index] = i;
                        index++;

                    }

                }


            }
        }
        return keeps;
    }
}
