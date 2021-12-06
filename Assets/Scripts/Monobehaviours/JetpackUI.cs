using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackUI : MonoBehaviour
{
    public Slider jetpackBar;
    public PlayerMovementOp1 playerLogic;

    void Update()
    {
        jetpackBar.value = (playerLogic.jetpackFuel / playerLogic.maxJetpackFuel);
    }
}
