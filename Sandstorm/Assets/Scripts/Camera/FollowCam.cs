using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;


    private void Start()
    {
        player = GetComponent<GameObject>();
    }

    private void Update()
    {
        if (player != null)
        {
            Debug.Log("Player not found");
        }

        else
        {
           
        }
    }


}
