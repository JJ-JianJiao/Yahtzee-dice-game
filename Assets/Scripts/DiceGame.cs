using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceGame : MonoBehaviour
{

    public AI player1;
    public AI player2;

    public bool debugMode;

    public PlayerCombos[] p1Combos;
    public PlayerCombos[] p2Combos;


    public Image[] dicesImage;
    public Sprite[] diceSprites;
    public Button rollButton;
    public Text PlayerText;
    public GameObject debugToggle;
    public Button[] keepButtons;
    public bool[] UIKeepsDices;
    public Button AIDebugSubBtn;
    public Toggle[] p1DebugCombos;
    public Toggle[] p2DebugCombos;

    //public Buton AISubmitBtn;

    public bool IsWin;

    public GameObject MessagePanel;

    public bool AI_1;
    public bool AI_2;

    public bool IsShowAISecondRoll;
    public bool IsSHowAIKeeps;
    public bool IsShowAICurrentCombos;
    //private bool AIShowKeeps;

    public bool AI_DebugSubmit;

    public bool isMessagePanel;


    public int playerTurn;


    public float rollDiceAnimationStamp;
    public float rollDiceAnimationRate;

    bool rollAni;
    private bool onRollBtnClick;



    // Start is called before the first frame update
    void Start()
    {
        IsShowAISecondRoll = true;
        IsSHowAIKeeps = true;
        IsShowAICurrentCombos = true;

        //Sprite aaa = Resources.Load<Sprite>("UIMask");
        //Sprite aaa = Resources.Load<Sprite>("UIMask");

        //Sprite aa =Resources.Load("Resources/unity_builtin_extra/UIMask", typeof(Sprite)) as Sprite;

            //Resources.Load<Sprite>("suit_life_meter_2")

        //AIShowKeeps = false;

        UIKeepsDices = new bool[5] { false,false,false,false,false };
        onRollBtnClick = false;
        rollAni = false;

        rollDiceAnimationStamp = -1;
        rollDiceAnimationRate = 0.5f;


        isMessagePanel = false;

        AI_1 = false;
        AI_2 = false;


        AI_DebugSubmit = false;


        debugMode = debugToggle.GetComponent<Toggle>().isOn;



        //debugMode = true;


        player1 = new AI();
        player1.TurnTextColor = Color.red;
        player2 = new AI();
        player2.TurnTextColor = Color.blue;

        playerTurn = 1;

        PlayerText.text = "Player 1";
        PlayerText.color = player1.TurnTextColor;
    }

    // Update is called once per frame
    void Update()
    {


        if (debugMode == true)
        {


            if (AI_1 == true && playerTurn == 1)
            {
                ShowAIDebugSubmitAndRollBtns();
            }
            else if (AI_2 == true && playerTurn == 2)
            {

                ShowAIDebugSubmitAndRollBtns();
            }
            else
            {

                HideAIDebugSubmitAndRollBtns();
            }

        }
        //else {

        //    if (AI_1 == true && playerTurn == 1)
        //    {
        //        rollButton.gameObject.SetActive(false);
        //    }
        //    else if (AI_2 == true && playerTurn == 2)
        //    {

        //        rollButton.gameObject.SetActive(false);
        //    }
        //    else
        //    {

        //        rollButton.gameObject.SetActive(true);
        //    }


        //}


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }
        DisplayCurrentSelectedCombo(player1, p1Combos);
        DisplayCurrentSelectedCombo(player2, p2Combos);

        //if (Input.GetKeyUp(KeyCode.Space)){

        //    AIContinue();
        
        //}


        //if (IsWin == false && onRollBtnClick == true && debugMode == false) {
        if (IsWin == false && onRollBtnClick == true) {
            RollDiceAnimation(playerTurn);
        }
        //if (IsWin == false && (AI_1 == true || AI_2 == true))
        if (IsWin == false)
        {
            if (debugMode == true)
            {

                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    ManualDiceImage(0);
                }
                if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    ManualDiceImage(1);
                }
                if (Input.GetKeyUp(KeyCode.Alpha3))
                {
                    ManualDiceImage(2);
                }
                if (Input.GetKeyUp(KeyCode.Alpha4))
                {
                    ManualDiceImage(3);
                }
                if (Input.GetKeyUp(KeyCode.Alpha5))
                {
                    ManualDiceImage(4);
                }
            }

            if (AI_1 && playerTurn == 1)
            {
                //ShowAIDebugSubmitAndRollBtns();
                if (player1.AITurnEnd == false)
                {

                    if (player1.firstRoll == false)
                    {
                        Debug.Log("AI - 1 is working - first Roll");
                        DisplayCurrentCombosStatus(p1Combos);
                        //DisplayCurrentSelectedCombo(player1, p1Combos);
                        player1.InitalNewRoll();


                        if (debugMode == false)
                        {
                            player1.RollDices();

                            ReAssignDicesImages(player1.dicesResult);

                            //DisplayerKeepButtons();

                            Debug.Log("AI_1 " + " dices:" + player1.DisplayDiceResults());

                            player1.AnalyzeDices();


                            Debug.Log("AI_1 " + " dices structure:" + player1.DisplayDIceStructure());

                            player1.AnalyzeStructure();

                            Debug.Log("AI_1 " + " dices combo elements:" + player1.DisplayComboElements());

                            player1.AnalyzeCombos();

                            Debug.Log("AI_1 " + " dices combo are:" + player1.DisplayCurrentCombos());

                            player1.ChooseCombo();
                            //SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);


                            //PrepareAnimation();
                            //RollDiceAnimation(1);



                        }
                        else if (debugMode == true)
                        {

                            if (AI_DebugSubmit == true)
                            {

                                AI_DebugSubmit = false;

                                player1.dicesResult = ManualDiceResults();

                                ReAssignDicesImages(player1.dicesResult);

                                //DisplayerKeepButtons();

                                Debug.Log("AI_1 " + " dices:" + player1.DisplayDiceResults());

                                player1.AnalyzeDices();


                                Debug.Log("AI_1 " + " dices structure:" + player1.DisplayDIceStructure());

                                player1.AnalyzeStructure();

                                Debug.Log("AI_1 " + " dices combo elements:" + player1.DisplayComboElements());

                                player1.AnalyzeCombos();

                                Debug.Log("AI_1 " + " dices combo are:" + player1.DisplayCurrentCombos());

                                player1.ChooseCombo();
                                //SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);
                            }

                        }


                    }
                    else if (player1.secondRoll == false && player1.firstRoll == true)
                    {

                        Debug.Log("AI - 1 is working - second Roll");
                        player1.InitialSecondRoll();
                        HideCurrentCombosOptions(player1, p1Combos);
                        DisplayCurrentSelectedCombo(player1, p1Combos);

                        if (debugMode == false)
                        {

                            Debug.Log("Waiting for Player Approvel");
                            //if (IsSHowAIKeeps == true)
                            if (true)
                            {
                                //AIPause();
                                ReAssignAIDicesImages(player1.keepDices);
                                Debug.Log("Show What AI Keeps");

                                //if (IsShowAISecondRoll == true)
                                if (true)
                                {
                                    AIPause();
                                    player1.RollDices(player1.keepDices);

                                    Debug.Log("AI " + " new result: " + player1.DisplayDiceResults());
                                    ReAssignDicesImages(player1.dicesResult);

                                    InitialKeepButtons();
                                    player1.AnalyzeDices();
                                    Debug.Log("AI " + " new dices structure:" + player1.DisplayDIceStructure());

                                    player1.AnalyzeStructure();
                                    Debug.Log("AI " + "  new dices combo elements:" + player1.DisplayComboElements());

                                    player1.AnalyzeCombos();
                                    Debug.Log("AI " + " new dices combo are:" + player1.DisplayCurrentCombos());
                                    //if (IsShowAICurrentCombos == true) {

                                    player1.ChooseCombo();
                                    //}

                                    
                                }
                            }
                            //SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);
                            //DisplayCurrentCombosOptions(player1, p1Combos);
                        }
                        else if (debugMode == true)
                        {
                            int a = 3;

                            if (player1.AIShowKeeps == false)
                            {
                                ReAssignAIDicesImages(player1.keepDices);
                                player1.AIShowKeeps = true;
                            }

                            if (AI_DebugSubmit == true)
                            {

                                AI_DebugSubmit = false;
                                player1.dicesResult = ManualDiceResults();
                                Debug.Log("AI " + " new result: " + player1.DisplayDiceResults());
                                ReAssignDicesImages(player1.dicesResult);

                                InitialKeepButtons();
                                player1.AnalyzeDices();
                                Debug.Log("AI " + " new dices structure:" + player1.DisplayDIceStructure());

                                player1.AnalyzeStructure();
                                Debug.Log("AI " + "  new dices combo elements:" + player1.DisplayComboElements());

                                player1.AnalyzeCombos();
                                Debug.Log("AI " + " new dices combo are:" + player1.DisplayCurrentCombos());

                                player1.ChooseCombo();
                                //SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);
                                //DisplayCurrentCombosOptions(player1, p1Combos);
                            }


                        }
                    }
                }
                else
                {

                    SycSelectedCombos(player1, p1Combos);

                    IsWin = CheckWin(p1Combos);
                    SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);


                    HideKeepButtons();
                    //DisplayCurrentCombosOptions(player1, p1Combos);
                    ChangePlayer();

                    HideAIDebugSubmitAndRollBtns();

                }
            }
            else if (AI_2 == true && playerTurn == 2)
            {
                //ShowAIDebugSubmitAndRollBtns();
                if (player2.AITurnEnd == false)
                {
                    if (player2.firstRoll == false)
                    {
                        Debug.Log("AI - 2 is working - first Roll");
                        DisplayCurrentCombosStatus(p2Combos);
                        player2.InitalNewRoll();


                        if (debugMode == false)
                        {
                            player2.RollDices();

                            ReAssignDicesImages(player2.dicesResult);

                            //DisplayerKeepButtons();

                            Debug.Log("AI_2 " + " dices:" + player2.DisplayDiceResults());

                            player2.AnalyzeDices();


                            Debug.Log("AI_2 " + " dices structure:" + player2.DisplayDIceStructure());

                            player2.AnalyzeStructure();

                            Debug.Log("AI_2 " + " dices combo elements:" + player2.DisplayComboElements());

                            player2.AnalyzeCombos();

                            Debug.Log("AI_2 " + " dices combo are:" + player2.DisplayCurrentCombos());

                            player2.ChooseCombo();
                            //SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);
                        }
                        else if (debugMode == true)
                        {

                            if (AI_DebugSubmit == true)
                            {

                                AI_DebugSubmit = false;

                                player2.dicesResult = ManualDiceResults();


                                ReAssignDicesImages(player2.dicesResult);

                                //DisplayerKeepButtons();

                                Debug.Log("AI_2 " + " dices:" + player2.DisplayDiceResults());

                                player2.AnalyzeDices();


                                Debug.Log("AI_2 " + " dices structure:" + player2.DisplayDIceStructure());

                                player2.AnalyzeStructure();

                                Debug.Log("AI_2 " + " dices combo elements:" + player2.DisplayComboElements());

                                player2.AnalyzeCombos();

                                Debug.Log("AI_2 " + " dices combo are:" + player2.DisplayCurrentCombos());

                                player2.ChooseCombo();
                                //SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);

                            }

                        }

                    }
                    else if (player2.secondRoll == false && player2.firstRoll == true)
                    {

                        Debug.Log("AI - 2 is working - second Roll");


                        //int a = 3;

                        //if (player2.AIShowKeeps == false)
                        //{
                        //    ReAssignAIDicesImages(player2.keepDices);
                        //    player2.AIShowKeeps = true;
                        //}


                        player2.InitialSecondRoll();
                        HideCurrentCombosOptions(player2, p2Combos);
                        DisplayCurrentSelectedCombo(player2, p2Combos);
                        if (debugMode == false)
                        {

                            Debug.Log("Waiting for Player Approvel");
                            if (IsSHowAIKeeps == true)
                            {
                                ReAssignAIDicesImages(player2.keepDices);
                                Debug.Log("Show What AI Keeps");
                                if (IsShowAISecondRoll == true)
                                {
                                    AIPause();

                                    player2.RollDices(player2.keepDices);

                                    Debug.Log("AI 2 " + " new result: " + player2.DisplayDiceResults());
                                    ReAssignDicesImages(player2.dicesResult);

                                    InitialKeepButtons();
                                    player2.AnalyzeDices();
                                    Debug.Log("AI 2 " + " new dices structure:" + player2.DisplayDIceStructure());

                                    player2.AnalyzeStructure();
                                    Debug.Log("AI 2 " + "  new dices combo elements:" + player2.DisplayComboElements());

                                    player2.AnalyzeCombos();
                                    Debug.Log("AI 2 " + " new dices combo are:" + player2.DisplayCurrentCombos());

                                    player2.ChooseCombo();
                                    //SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);

                                    //DisplayCurrentCombosOptions(player2, p2Combos);
                                }
                            }

                        }
                        else if (debugMode == true)
                        {

                            if (player2.AIShowKeeps == false)
                            {
                                ReAssignAIDicesImages(player2.keepDices);
                                player2.AIShowKeeps = true;
                            }

                            if (AI_DebugSubmit == true)
                            {

                                AI_DebugSubmit = false;
                                player2.dicesResult = ManualDiceResults();
                                Debug.Log("AI 2 " + " new result: " + player2.DisplayDiceResults());
                                ReAssignDicesImages(player2.dicesResult);

                                InitialKeepButtons();
                                player2.AnalyzeDices();
                                Debug.Log("AI 2 " + " new dices structure:" + player2.DisplayDIceStructure());

                                player2.AnalyzeStructure();
                                Debug.Log("AI 2 " + "  new dices combo elements:" + player2.DisplayComboElements());

                                player2.AnalyzeCombos();
                                Debug.Log("AI 2 " + " new dices combo are:" + player2.DisplayCurrentCombos());

                                player2.ChooseCombo();
                                //SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);

                                //DisplayCurrentCombosOptions(player2, p2Combos);



                            }

                        }

                    }

                }
                else
                {

                    SycSelectedCombos(player2, p2Combos);
                    IsWin = CheckWin(p2Combos);
                    SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);
                    HideKeepButtons();
                    //DisplayCurrentCombosOptions(player2, p2Combos);
                    ChangePlayer();

                    HideAIDebugSubmitAndRollBtns();


                }

            }
        }
        else if(IsWin == true && isMessagePanel == false && (AI_1 == true || AI_2 == true)) {
            ChangePlayer();
            if (playerTurn == 1)
            {
                string winMessage = "Player 1 Win";
                ShowMessagePanel(winMessage);
            }
            else {

                string winMessage = "Player 2 Win";

                ShowMessagePanel(winMessage);
            }
            //Debug.Log("hah")
        
        
        }
        //}


    }

    private void SycSelectedCombos(AI player, PlayerCombos[] pCombos)
    {
        for (int i = 0; i < player.selectedCombs.Length; i++)
        {
            if (player.selectedCombs[i] == true && pCombos[i].selected == false) {

                pCombos[i].SetSelected(true);
            }
        }
    }

    public void RollDices() {

        if (!IsWin)
        {



            //Debug.Log("Click Roll Btn");
            if (playerTurn == 1 && player1.firstRoll == false && AI_1 == false)
            {

                rollDiceAnimationStamp = Time.time;
                rollAni = true;
                onRollBtnClick = true;

                PlayerRollDice(player1, p1Combos, "player1", 1);
                /*
                //ResetPlaysSelectedCombos(p1Combos);

                DisplayCurrentCombosStatus(p1Combos);
                player1.InitalNewRoll();

                if (debugMode == false)
                {
                    player1.RollDices();

                    ReAssignDicesImages(player1.dicesResult);
                }
                else {
                    for (int i = 0; i < player1.dicesResult.Length; i++)
                    {
                        player1.dicesResult = ManualDiceResults();
                    }


                }

                #region Debug Test player1 dicesResult
                Debug.Log("player1 dices:" + player1.DisplayDiceResults());
                #endregion

                player1.AnalyzeDices();

                #region Debug Test player1 dicesStructure
                Debug.Log("player1 dices structure:" + player1.DisplayDIceStructure());
                #endregion


                player1.AnalyzeStructure();

                #region Debug Test player1 combo elements
                Debug.Log("player1 dices combo elements:" + player1.DisplayComboElements());
                #endregion


                player1.AnalyzeCombos();

                #region Debug Test player1 current combos
                Debug.Log("player1 dices combo are:" + player1.DisplayCurrentCombos());
                #endregion

                for (int i = 0; i < p1Combos.Length; i++)
                {
                    if (p1Combos[i].GetSelected() == false && player1.currentCombos[i] == true)
                    {

                        p1Combos[i].buttonReference.gameObject.SetActive(true);

                    }
                    else if (p1Combos[i].GetSelected() == true) {

                        p1Combos[i].buttonReference.gameObject.SetActive(true);

                    }
                }

                DisplayerKeepButtons();
                player1.firstRoll = true;
                */

            }
            else if (playerTurn == 2 && player2.firstRoll == false && AI_2 == false)
            {

                rollDiceAnimationStamp = Time.time;
                rollAni = true;
                onRollBtnClick = true;

                PlayerRollDice(player2, p2Combos, "player2", 1);
                //DisplayCurrentCombosStatus(p2Combos);
                //player2.InitalNewRoll();

                //if (debugMode == false)
                //{
                //    player2.RollDices();

                //    ReAssignDicesImages(player2.dicesResult);
                //}
                //else
                //{
                //    for (int i = 0; i < player1.dicesResult.Length; i++)
                //    {
                //        player2.dicesResult = ManualDiceResults();
                //    }


                //}

                //#region Debug Test player2 dicesResult
                //Debug.Log("player2 dices:" + player2.DisplayDiceResults());
                //#endregion

                //player2.AnalyzeDices();

                //#region Debug Test player1 dicesStructure
                //Debug.Log("player2 dices structure:" + player2.DisplayDIceStructure());
                //#endregion


                //player2.AnalyzeStructure();

                //#region Debug Test player2 combo elements
                //Debug.Log("player2 dices combo elements:" + player2.DisplayComboElements());
                //#endregion


                //player2.AnalyzeCombos();

                //#region Debug Test player2 current combos
                //Debug.Log("player2 dices combo are:" + player2.DisplayCurrentCombos());
                //#endregion

                //for (int i = 0; i < p2Combos.Length; i++)
                //{
                //    if (p2Combos[i].GetSelected() == false && player2.currentCombos[i] == true)
                //    {

                //        p2Combos[i].buttonReference.gameObject.SetActive(true);

                //    }
                //    else if (p2Combos[i].GetSelected() == true)
                //    {

                //        p2Combos[i].buttonReference.gameObject.SetActive(true);

                //    }
                //}
                //DisplayerKeepButtons();
                //player2.firstRoll = true;

            }
            else if (playerTurn == 1 && player1.firstRoll == true && player1.secondRoll == false && AI_1 == false)
            {
                rollDiceAnimationStamp = Time.time;
                rollAni = true;
                onRollBtnClick = true;

                PlayerSecondRollDice(player1, p1Combos, "Player 1");
                //player1.keepDices = ManualKeepDices(player1.dicesResult);

                //player1.NeedReroll();

                //Debug.Log("Player 1 keeps: " + player1.DisplayKeepsDiceResults());

                //player1.RollDices(player1.keepDices);

                //Debug.Log("Player 1 new result: " + player1.DisplayDiceResults());

                //ReAssignDicesImages(player1.dicesResult);

                //InitialKeepButtons();

                //player1.AnalyzeDices();

                //Debug.Log("player1 " + " dices structure:" + player1.DisplayDIceStructure());

                //player1.AnalyzeStructure();
                //Debug.Log("player1 " + " dices combo elements:" + player1.DisplayComboElements());

                //player1.AnalyzeCombos();
                //Debug.Log("player1 " + " dices combo are:" + player1.DisplayCurrentCombos());

                //DisplayCurrentCombosOptions(player1, p1Combos);


                //DisplayRollButton(player1);
                //player1.secondRoll = true;


            }
            else if (playerTurn == 2 && player2.firstRoll == true && player2.secondRoll == false && AI_2 == false)
            {
                rollDiceAnimationStamp = Time.time;
                rollAni = true;
                onRollBtnClick = true;
                PlayerSecondRollDice(player2, p2Combos, "Player 2");
            }
            else if (rollButton.GetComponentInChildren<Text>().text == "Done")
            {

                ChangePlayer();
                InitialKeepButtons();
                if (playerTurn == 1)
                {

                    DisplayRollButton(player1);
                }
                else if (playerTurn == 2)
                {

                    DisplayRollButton(player2);
                }


            }

        }
    }

    private void DisplayRollButton(AI currentPlayer) {

        if (currentPlayer.firstRoll == false) {
            rollButton.GetComponentInChildren<Text>().text = "Roll Dice";
        }
        else {

            rollButton.GetComponentInChildren<Text>().text = "Done";
        }

        
    }


    private void DisplayCurrentCombosOptions(AI player, PlayerCombos[] playerCombos) {

        for (int i = 0; i < playerCombos.Length; i++)
        {
            if (playerCombos[i].GetSelected() == false && player.currentCombos[i] == true)
            {

                playerCombos[i].buttonReference.gameObject.SetActive(true);

            }
            //else if (playerCombos[i].GetSelected() == true)
            //{

            //    playerCombos[i].buttonReference.gameObject.SetActive(true);

            //}
        }


    }

    private void DisplayCurrentSelectedCombo(AI player, PlayerCombos[] playerCombos)
    {

        for (int i = 0; i < playerCombos.Length; i++)
        {
            if (playerCombos[i].GetSelected() == true)
            {

                playerCombos[i].buttonReference.gameObject.SetActive(true);

            }
        }


    }


    private void HideCurrentCombosOptions(AI player, PlayerCombos[] playerCombos) {

        for (int i = 0; i < playerCombos.Length; i++)
        {
            if (playerCombos[i].GetSelected() == false && player.currentCombos[i] == true)
            {

                playerCombos[i].buttonReference.gameObject.SetActive(true);

            }
            else
            {

                playerCombos[i].buttonReference.gameObject.SetActive(false);

            }
        }

    }

    private int[] ManualKeepDices(int[] originalDices)
    {
        int[] keepDices = originalDices;
        for (int i = 0; i < keepButtons.Length; i++)
        {
            if (keepButtons[i].GetComponentInChildren<Text>().text == "Roll") {

                keepDices[i] = -1;
            
            }
        }

        return keepDices;
    }

    private void DisplayCurrentCombosStatus(PlayerCombos[] combos)
    {
        foreach (PlayerCombos combo in combos)
        {
            if (!combo.GetSelected()) {

                combo.buttonReference.gameObject.SetActive(false);
            
            }
        }
    }

    public void SelectCombo(int index) {
        string winMessage = null;
        //Color winColor;
        if (rollButton.GetComponentInChildren<Text>().text == "Done") {

            rollButton.GetComponentInChildren<Text>().text = "Roll Dice";

        }
        if (playerTurn == 1)
        {
            p1Combos[index].SetSelected(true);
            player1.selectedCombs[index] = true;
            IsWin = CheckWin(p1Combos);
            winMessage = "Player 1 Win";
            SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);
            //p1Combos[index].buttonReference.GetComponentInChildren<Text>().text = "Done";
            //winColor = player1.TurnTextColor;
            //HidePlayerCombo(p1Combos);

            //ChangePlayer();            

        }
        else if (playerTurn == 2) {
            p2Combos[index].SetSelected(true);
            player2.selectedCombs[index] = true;
            IsWin = CheckWin(p2Combos);
            //HidePlayerCombo(p2Combos);
            //p1Combos[index].buttonReference.GetComponentInChildren<Text>().text = "Done";
            //ChangePlayer();
            //winColor = player2.TurnTextColor;
            winMessage = "Player 2 Win";
            SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);
        }
        if (!IsWin)
        {
            ChangePlayer();
            InitialKeepButtons();
        }
        else {

            ShowMessagePanel(winMessage);


        }

    }

    public void ShowMessagePanel(string winMessage) {

        isMessagePanel = true;
        MessagePanel.SetActive(true);
        MessagePanel.SendMessage("GetWinMessage", winMessage);
    }

    private bool CheckWin(PlayerCombos[] combos)
    {
        int count = 0;
        for (int i = 0; i < combos.Length; i++)
        {
            if (combos[i].GetSelected()) {
                count++;
            }
        }
        if (count == 6)
        {

            return true;
        }
        else
            return false;
    }

    private void ChangePlayer()
    {
        if (playerTurn == 1)
        {
            HidePlayerCombo(p1Combos);
            playerTurn = 2;
            PlayerText.text = "Player 2";
            player1.InitalNewRoll();
            player1.AITurnEnd = false;
            PlayerText.color = player2.TurnTextColor;

        }
        else if (playerTurn == 2) {
            HidePlayerCombo(p2Combos);
            playerTurn = 1;
            PlayerText.text = "Player 1";
            player2.InitalNewRoll();
            player2.AITurnEnd = false;
            PlayerText.color = player1.TurnTextColor;
            
        }
    }

    public void ReAssignDicesImages(int[] dicesResult) {

        for (int i = 0; i < dicesResult.Length; i++)
        {
            dicesImage[i].sprite = diceSprites[dicesResult[i]];
        }  
    
    }

    public void ReAssignAIDicesImages(int[] dices)
    {

        for (int i = 0; i < dices.Length; i++)
        {
            if (dices[i] != -1)
            {
                dicesImage[i].sprite = diceSprites[dices[i]];
            }
            else {
                dicesImage[i].sprite = null;
                //dicesImage[i].gameObject.SetActive(false);

            }
        }

    }


    public void ResetPlaysSelectedCombos(PlayerCombos[] playerCombos) {

        foreach (PlayerCombos playerCombo in playerCombos)
        {
            playerCombo.SetSelected(false);
            playerCombo.buttonReference.gameObject.SetActive(false);
        }

    
    }

    public void HidePlayerCombo(PlayerCombos[] playerCombos) {

        foreach (PlayerCombos player in playerCombos)
        {
            if (player.GetSelected() == false)
            {
                player.buttonReference.gameObject.SetActive(false);
            }
        }

    }

    public void SwitchDebugMode() {

        if (debugMode == true)
        {

            debugToggle.GetComponent<Toggle>().isOn = false;
            debugMode = false;
            HideDebugCombos(p1DebugCombos);
            HideDebugCombos(p2DebugCombos);
            if ((player1.firstRoll == true || player2.firstRoll == true) && rollButton.GetComponentInChildren<Text>().text == "Roll Dice")
            {

                DisplayerKeepButtons();

            }

        }
        else
        {
            debugToggle.GetComponent<Toggle>().isOn = true;
            debugMode = true;
            ShowDebugCombos(p1DebugCombos);
            ShowDebugCombos(p2DebugCombos);

            SycCurrentComboToDebugCombos(p1DebugCombos, p1Combos);
            SycCurrentComboToDebugCombos(p2DebugCombos, p2Combos);
            if (player1.firstRoll == true || player2.firstRoll == true)
            {

                HideKeepButtons();

            }

            
        }




        Debug.Log("DebugMode status: " + debugMode);

    }

    public void ShowDebugCombos(Toggle[] toggles) {

        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].gameObject.SetActive(true);
        }
    
    }

    public void HideDebugCombos(Toggle[] toggles)
    {

        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].gameObject.SetActive(false);
        }

    }

    public void ManualDiceImage(int imgIndex) {



        int index = -1;
        for (int i = 0; i < diceSprites.Length; i++)
        {
            //if (dicesImage[i].gameObject.activeSelf == false) {
            //    dicesImage[i].gameObject.SetActive(true);
            //}
            if (diceSprites[i] == dicesImage[imgIndex].sprite)
            {

                index = i;
                break;

            }
        }

        index++;
        if (index >= diceSprites.Length)
        {

            index = 0;

        }

        dicesImage[imgIndex].sprite = diceSprites[index];

    }

    public int[] ManualDiceResults() {

        int[] manualResults = new int[5];

        for (int i = 0; i < dicesImage.Length; i++)
        {
            for (int j = 0; j < diceSprites.Length; j++)
            {
                if (dicesImage[i].sprite == diceSprites[j]) {

                    manualResults[i] = j;
                
                }
            }
        }
        return manualResults;    
    }

    public void DisplayerKeepButtons() {

        for (int i = 0; i < keepButtons.Length; i++)
        {
            keepButtons[i].gameObject.SetActive(true);
        }
    
    
    }

    public void HideKeepButtons()
    {

        for (int i = 0; i < keepButtons.Length; i++)
        {
            keepButtons[i].gameObject.SetActive(false);
        }


    }

    public void InitialKeepButtons() {

        for (int i = 0; i < keepButtons.Length; i++)
        {
            keepButtons[i].gameObject.SetActive(false);
            keepButtons[i].GetComponentInChildren<Text>().text = "Roll";
            dicesImage[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void KeepDiceToggle(int index) {



        if (keepButtons[index].GetComponentInChildren<Text>().text == "Roll") {

            keepButtons[index].GetComponentInChildren<Text>().text = "Keep";
            dicesImage[index].GetComponent<Image>().color = new Color(1,1,1,30/255.0f);

        } else if (keepButtons[index].GetComponentInChildren<Text>().text == "Keep") {

            keepButtons[index].GetComponentInChildren<Text>().text = "Roll";
            dicesImage[index].GetComponent<Image>().color = Color.white;
        }

    
    }

    public void PlayerRollDice(AI player, PlayerCombos[] playerCombos, string playerName, int rollTimes) {

        //ResetPlaysSelectedCombos(p1Combos);

        DisplayCurrentCombosStatus(playerCombos);
        player.InitalNewRoll();

        if (debugMode == false)
        {

            player.RollDices();

            //if(debugMode == true)
            //    ReAssignDicesImages(player.dicesResult);


            DisplayerKeepButtons();
        }
        else
        {
            HideKeepButtons();
            //for (int i = 0; i < player.dicesResult.Length; i++)
            //{
            player.dicesResult = ManualDiceResults();
            //}


        }

        #region Debug Test player1 dicesResult
        Debug.Log(playerName  + " dices:" + player.DisplayDiceResults());
        #endregion

        player.AnalyzeDices();

        #region Debug Test player1 dicesStructure
        Debug.Log(playerName  + " dices structure:" + player.DisplayDIceStructure());
        #endregion


        player.AnalyzeStructure();

        #region Debug Test player1 combo elements
        Debug.Log(playerName  + " dices combo elements:" + player.DisplayComboElements());
        #endregion


        player.AnalyzeCombos();

        #region Debug Test player1 current combos
        Debug.Log(playerName  + " dices combo are:" + player.DisplayCurrentCombos());
        #endregion

        //if(debugMode == true)
            //DisplayCurrentCombosOptions(player, playerCombos);
        //for (int i = 0; i < playerCombos.Length; i++)
        //{
        //    if (playerCombos[i].GetSelected() == false && player.currentCombos[i] == true)
        //    {

        //        playerCombos[i].buttonReference.gameObject.SetActive(true);

        //    }
        //    else if (playerCombos[i].GetSelected() == true)
        //    {

        //        playerCombos[i].buttonReference.gameObject.SetActive(true);

        //    }
        //}
        DisplayRollButton(player1);

        //DisplayerKeepButtons();
        if (rollTimes == 1)
        {
            player.firstRoll = true;
        }
        else if (rollTimes == 2) {
            player.secondRoll = true;

        }


    }

    public void PlayerSecondRollDice(AI player, PlayerCombos[] playerCombos, string playerName) {


        player.InitialSecondRoll();
        HideCurrentCombosOptions(player, playerCombos);
        if (debugMode == false)
        {
            player.keepDices = ManualKeepDices(player.dicesResult);

            for (int i = 0; i < player.keepDices.Length; i++)
            {
                if (player.keepDices[i] != -1)
                {
                    UIKeepsDices[i] = true;
                }
            }


            player.NeedReroll();

            Debug.Log(playerName + " keeps: " + player.DisplayKeepsDiceResults());

            player.RollDices(player.keepDices);

            
        }
        else
        {

            //for (int i = 0; i < player.dicesResult.Length; i++)
            //{
            player.dicesResult = ManualDiceResults();
            //}


        }
        Debug.Log(playerName + " new result: " + player.DisplayDiceResults());
        
        if(debugMode == true)
            ReAssignDicesImages(player.dicesResult);

        InitialKeepButtons();

        player.AnalyzeDices();

        Debug.Log(playerName + " new dices structure:" + player.DisplayDIceStructure());

        player.AnalyzeStructure();
        Debug.Log(playerName + " new dices combo elements:" + player.DisplayComboElements());

        player.AnalyzeCombos();
        Debug.Log(playerName + "  new dices combo are:" + player.DisplayCurrentCombos());

        //if (debugMode == true)
            //DisplayCurrentCombosOptions(player, playerCombos);


        DisplayRollButton(player);
        player.secondRoll = true;

        
    }

    public void PlayAgain() {


        isMessagePanel = false;
        int[] origianlDicesNum = new int[] { 0, 1, 2, 3, 4 };
        player1 = new AI();
        player1.TurnTextColor = Color.red;
        player2 = new AI();
        player2.TurnTextColor = Color.blue;
        playerTurn = 1;
        PlayerText.text = "Player 1";
        PlayerText.color = player1.TurnTextColor;
        ReAssignDicesImages(origianlDicesNum);
        for (int i = 0; i < p1Combos.Length; i++)
        {
            p1Combos[i].Inital();
            p2Combos[i].Inital();
        }
        HideCurrentCombosOptions(player1, p1Combos);
        HideCurrentCombosOptions(player2, p2Combos);
        MessagePanel.SetActive(false);
        IsWin = false;

        for (int i = 0; i < p1DebugCombos.Length; i++)
        {
            p1DebugCombos[i].isOn = false;
            p2DebugCombos[i].isOn = false;

        }
    }


    public void AI1Toggle(int value) {

        switch (value)
        {
            case 1:
                AI_1 = true;
                break;
            case 0:
                AI_1 = false;
                break;
        }

    }


    public void AI2Toggle(int value)
    {
        switch (value)
        {
            case 1:
                AI_2 = true;
                break;
            case 0:
                AI_2 = false;
                break;
        }

    }


    public void SubmitAIDebug() {

        AI_DebugSubmit = true;
    
    
    }


    public void HideRollDice() {

        rollButton.gameObject.SetActive(false);


    }

    public void DisplayRollDice()
    {

        rollButton.gameObject.SetActive(true);


    }


    public void PrepareAnimation() {

        rollDiceAnimationStamp = Time.time;
        rollAni = true;
        onRollBtnClick = true;

    }

    public void RollDiceAnimation(int playerTurn) {
        //rollDiceAnimationStamp = Time.time;


        if (rollAni && Time.time < rollDiceAnimationStamp + rollDiceAnimationRate)
        {
            HideRollDice();
            for (int i = 0; i < 5; i++)
            {
                if (UIKeepsDices[i] == false)
                {
                    int randomValue = UnityEngine.Random.Range(0, 6);
                    //dieValue[i] = randomValue;
                    dicesImage[i].sprite = diceSprites[randomValue];
                }
            }
        }
        else {
            DisplayRollDice();
            rollAni = false;
            onRollBtnClick = false;
            if (playerTurn == 1)
            {
                ReAssignDicesImages(player1.dicesResult);
                DisplayCurrentCombosOptions(player1, p1Combos);

                UIKeepsDices = new bool[5] { false, false, false, false, false };
            }
            else if (playerTurn == 2) {

                ReAssignDicesImages(player2.dicesResult);
                DisplayCurrentCombosOptions(player2, p2Combos);

                UIKeepsDices = new bool[5] { false, false, false, false, false };
            }
        }

    }

    public void SycCurrentComboToDebugCombos(Toggle[] toggles, PlayerCombos[] combos) {

        for (int i = 0; i < combos.Length; i++)
        {
            if (combos[i].GetSelected() == true)
            {

                toggles[i].isOn = true;


            }
            else {

                toggles[i].isOn = false;

            }

        }
        
    
    }
    public void SycDebugCombosToCurrentCombo(int index)
    {
        switch (index)
        {
            case 1:
                if (p1DebugCombos[0].isOn)
                {
                    p1Combos[0].SetSelected(true);
                    player1.selectedCombs[0] = true;
                }
                else {
                    p1Combos[0].SetSelected(false);
                    player1.selectedCombs[0] = false;
                    p1Combos[0].buttonReference.gameObject.SetActive(false);
                }
                break;
            case -1:
                if (p2DebugCombos[0].isOn)
                {
                    p2Combos[0].SetSelected(true);
                    player2.selectedCombs[0] = true;
                }
                else
                {
                    p2Combos[0].SetSelected(false);
                    player2.selectedCombs[0] = false;
                    p2Combos[0].buttonReference.gameObject.SetActive(false);

                }
                break;
            case 2:
                if (p1DebugCombos[1].isOn)
                {
                    p1Combos[1].SetSelected(true);
                    player1.selectedCombs[1] = true;
                }
                else
                {
                    p1Combos[1].SetSelected(false);
                    player1.selectedCombs[1] = false;
                    p1Combos[1].buttonReference.gameObject.SetActive(false);

                }
                break;
            case -2:
                if (p2DebugCombos[1].isOn)
                {
                    p2Combos[1].SetSelected(true);
                    player2.selectedCombs[1] = true;
                }
                else
                {
                    p2Combos[1].SetSelected(false);
                    player2.selectedCombs[1] = false;
                    p2Combos[1].buttonReference.gameObject.SetActive(false);

                }
                break;
            case 3:
                if (p1DebugCombos[2].isOn)
                {
                    p1Combos[2].SetSelected(true);
                    player1.selectedCombs[2] = true;
                }
                else
                {
                    p1Combos[2].SetSelected(false);
                    player1.selectedCombs[2] = false;
                    p1Combos[2].buttonReference.gameObject.SetActive(false);

                }
                break;
            case -3:
                if (p2DebugCombos[2].isOn)
                {
                    p2Combos[2].SetSelected(true);
                    player2.selectedCombs[2] = true;
                }
                else
                {
                    p2Combos[2].SetSelected(false);
                    player2.selectedCombs[2] = false;
                    p2Combos[2].buttonReference.gameObject.SetActive(false);

                }
                break;
            case 4:
                if (p1DebugCombos[3].isOn)
                {
                    p1Combos[3].SetSelected(true);
                    player1.selectedCombs[3] = true;
                }
                else
                {
                    p1Combos[3].SetSelected(false);
                    player1.selectedCombs[3] = false;
                    p1Combos[3].buttonReference.gameObject.SetActive(false);

                }
                break;
            case -4:
                if (p2DebugCombos[3].isOn)
                {
                    p2Combos[3].SetSelected(true);
                    player2.selectedCombs[3] = true;
                }
                else
                {
                    p2Combos[3].SetSelected(false);
                    player2.selectedCombs[3] = false;
                    p2Combos[3].buttonReference.gameObject.SetActive(false);

                }
                break;
            case 5:
                if (p1DebugCombos[4].isOn)
                {
                    p1Combos[4].SetSelected(true);
                    player1.selectedCombs[4] = true;
                }
                else
                {
                    p1Combos[4].SetSelected(false);
                    player1.selectedCombs[4] = false;
                    p1Combos[4].buttonReference.gameObject.SetActive(false);

                }
                break;
            case -5:
                if (p2DebugCombos[4].isOn)
                {
                    p2Combos[4].SetSelected(true);
                    player2.selectedCombs[4] = true;
                }
                else
                {
                    p2Combos[4].SetSelected(false);
                    player2.selectedCombs[4] = false;
                    p2Combos[4].buttonReference.gameObject.SetActive(false);

                }
                break;
            case 6:
                if (p1DebugCombos[5].isOn)
                {
                    p1Combos[5].SetSelected(true);
                    player1.selectedCombs[5] = true;
                }
                else
                {
                    p1Combos[5].SetSelected(false);
                    player1.selectedCombs[5] = false;
                    p1Combos[5].buttonReference.gameObject.SetActive(false);

                }
                break;
            case -6:
                if (p2DebugCombos[5].isOn)
                {
                    p2Combos[5].SetSelected(true);
                    player2.selectedCombs[5] = true;
                }
                else
                {
                    p2Combos[5].SetSelected(false);
                    player2.selectedCombs[5] = false;
                    p2Combos[5].buttonReference.gameObject.SetActive(false);

                }
                break;
            default:
                break;
        }

        //DisplayCurrentSelectedCombo(player1,p1Combos);
        //DisplayCurrentSelectedCombo(player2,p2Combos);
    }

    public void ShowAIDebugSubmitAndRollBtns() {

        rollButton.gameObject.SetActive(false);
        AIDebugSubBtn.gameObject.SetActive(true );
    
    
    }

    public void HideAIDebugSubmitAndRollBtns()
    {

        rollButton.gameObject.SetActive(true);
        AIDebugSubBtn.gameObject.SetActive(false);


    }


    public void AIContinue() {

        //if (AI_1 == true || AI_2 == true)
        //{
        //    if (IsSHowAIKeeps == false)
        //    {

        //        IsSHowAIKeeps = true;

        //    }
        //    else if (IsShowAISecondRoll == false)
        //    {

        //        IsShowAISecondRoll = true;

        //    }
        //    //else {

        //    //    IsShowAICurrentCombos = true;
            
        //    //}
        //}

    }


    public void AIPause()
    {

        //if (AI_1 == true || AI_2 == true)
        //{
        //    IsShowAISecondRoll = false;
        //    IsSHowAIKeeps = false;
        //    IsShowAICurrentCombos = false;
        //}
    }
}

[System.Serializable]
public class PlayerCombos
{
    public bool selected = false;
    public Button buttonReference;

    public bool GetSelected()
    {
        return selected;
    }

    public void SetSelected(bool value)
    {
        selected = value;
        if (value)
        {
            buttonReference.GetComponentInChildren<Text>().text = "Done";
            buttonReference.interactable = false;
        }
        else {

            buttonReference.GetComponentInChildren<Text>().text = "Select";
            buttonReference.interactable = true;
        }
    }

    public void Inital() {

        selected = false;
        buttonReference.GetComponentInChildren<Text>().text = "Select";
        buttonReference.interactable = true;
    }
}

