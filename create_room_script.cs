using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class create_room_script : MonoBehaviourPunCallbacks
{
    public InputField nomeDaSala;
    //[SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CriarSalaBt()
    {
        PhotonNetwork.CreateRoom(nomeDaSala.text, new RoomOptions{MaxPlayers = 4});
    }
    public void adentrarSalaBt()
    {
     PhotonNetwork.JoinRoom(nomeDaSala.text);
    }
    public override void OnJoinedRoom()
    {
     PhotonNetwork.LoadLevel(2);
        

    }
    /*void SpawnPlayer()
    {
        float RandomPos = Random.Range(2, 2);
        PhotonNetwork.Instantiate(player.name, new Vector2(player.transform.position.x * RandomPos, player.transform.position.y), Quaternion.identity);
    }*/
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("deu ruim bicho" + returnCode + "a mensagem" + message);
    }
}
