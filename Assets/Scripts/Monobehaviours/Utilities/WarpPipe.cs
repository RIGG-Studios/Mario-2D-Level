using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPipe : MonoBehaviour
{
    public Transform pipeExit;
    public void Teleport(GameObject teleportObject)
    {
        teleportObject.transform.position = pipeExit.position;
    }
}
