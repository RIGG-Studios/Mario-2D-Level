using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    void Move(MoveDirections moveDirection);

    public enum MoveDirections
    {
        Left,
        Right,
        Jump,
        Any,
    }
}
