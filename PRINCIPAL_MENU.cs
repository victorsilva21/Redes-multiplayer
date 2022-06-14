using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class PRINCIPAL_MENU : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject ConnectedScreen, DisconnectedScreen, connectingScreen;
    // Start is called before the first frame update
    void Start()
    {
        ConnectedScreen.SetActive(false);
        DisconnectedScreen.SetActive(false);
        connectingScreen.SetActive(false);
    }
    public void ConectBt()
    {
        PhotonNetwork.ConnectUsingSettings();
        connectingScreen.SetActive(true);
        ConnectedScreen.SetActive(false);
        DisconnectedScreen.SetActive(false);
    }
    
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        ConnectedScreen.SetActive(true);
        connectingScreen.SetActive(false);
        StartCoroutine(carregarCena());
        

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
    DisconnectedScreen.SetActive(true);
        connectingScreen.SetActive(false);
    }
    
    
    IEnumerator carregarCena()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("criar_sala");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
 * public class sala
 * {
 * 
 * public InputField CriarSala, EntrarSala;
 * Public Void CreateSalaBt()
 * {
 * PhotonNetwork.CreateRoom(CreateRoom.text,null, null new RoomOptions{4},null);
 * }
 * public void joinSalaBt()
 * {
 * PhotonNetwork.JoinRoom(JoinRoom.Text, null);
 * }
 * public override onjoinroom()
 * {
 * scenemanager.loadscene(1);
 * }
 * public override onjoinroomfailed(short returncode, stride message)
 * {
 * Debug.Log("sala falhou" + ReturnCode + "message" + message);
 * }
 * 
 * 
 * 
 * 
 * 
 * }
 */
