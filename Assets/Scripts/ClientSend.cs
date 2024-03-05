using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend
{
    
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write("this client has joined the server!");

            SendTCPData(_packet);
        }
    }
    
    public void SendNames(string _name)
    {
        using (Packet _packet = new Packet((int)ClientPackets.sendName))
        {
            _packet.Write(_name);

            SendTCPData(_packet);
        }
    }


    public void ButtonClick(string _msg)
    {
        using(Packet _packet = new Packet((int)ClientPackets.button))       //소켓 통신을 통해 데이터를 전달할 때 온전한 string 형태로 주고 받을 수 없기 때문에 byte의 형태로 바꾸어 packet에 저장한 뒤 보내고 byte 형태로 받은 정보를 다시 재조합하여 string으로 바꾸어 정보를 받기 때문에 이 함수를 이용한다.
        {
            _packet.Write(_msg);

            SendTCPData(_packet);
        }
    }
    #endregion
}
