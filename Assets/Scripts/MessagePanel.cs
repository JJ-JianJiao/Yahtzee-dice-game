using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{
    public Text MessageBoard;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetWinMessage(string msg) {

        MessageBoard.text = msg;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain() {

        cam.SendMessage("PlayAgain");
    }


}
