using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : Character
{
    public Vector3 InitialPosition;
    public Vector2Int matrixPos;
    private void Awake()
    {
        InitialPosition = transform.localPosition;
        characterHP = 1;
    }

}
