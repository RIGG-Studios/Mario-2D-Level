using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerMovement
{
    void Move(MoveDirections moveDirection);

    public enum MoveDirections
    {
        Left,
        Right,
        Jump,
    }
}
