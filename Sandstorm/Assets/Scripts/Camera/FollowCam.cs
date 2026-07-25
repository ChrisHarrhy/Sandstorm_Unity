using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset; //Vector3(0f, 0f, 5.0f);
    public float smooth = 10.0f;

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
            this.transform.position = player.transform.position - offset;
        }
    }


}
