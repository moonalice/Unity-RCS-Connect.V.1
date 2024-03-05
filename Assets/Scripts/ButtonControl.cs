using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    ClientSend clientSend = new ClientSend();
    public void OnButtonClick()
    {
        Debug.Log("Button is clicked");
        clientSend.ButtonClick("button click");
    }
}
