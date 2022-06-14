using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Analog;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviourPun
{
    PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        


        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("NaveP1");
        }
        else if (view.IsMine == false)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("NaveP2");
        }
    }
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            processInput();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Ended && view.IsMine)
        {
            PhotonNetwork.Instantiate("tiro", transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "damage" && collision.gameObject.GetPhotonView().IsMine == false)
        {
            PhotonNetwork.Disconnect();

            PhotonNetwork.Destroy(this.gameObject);

            SceneManager.LoadSceneAsync(0);

        }
    }
    private void processInput()
    {
        float speed = 2*Time.deltaTime;
        float movementx = joystick.horizontal;
        float movementy = joystick.vertical;
        transform.position += new Vector3(movementx * speed, movementy * speed, 0);
        //transform.Translate (new Vector3(movementx * speed, movementy * speed, 0));
        if (Input.touchCount > 1)
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            
            Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

            transform.up = direction;
        }
        

    }
}
