using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

public Transform player;
    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 1, -10);
        transform.position = newPosition;
    }
}
