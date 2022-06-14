using UnityEngine;
using Photon.Pun;
public class GameController : MonoBehaviourPun
{
[SerializeField]public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
        spawnPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    void spawnPlayer()
    {
        
            float RandomPosx = Random.Range(Screen.safeArea.x/8, Screen.safeArea.x);
        float RandomPosy = Random.Range(Screen.safeArea.y/8, Screen.safeArea.y);
        PhotonNetwork.Instantiate(player.name, new Vector2( RandomPosx, player.transform.position.y), Quaternion.identity);
        
    }
    
   
}
