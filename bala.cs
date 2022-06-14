using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bala : MonoBehaviourPun
{
    SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up/2);
        if(image.isVisible == false)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
