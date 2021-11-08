using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public ShipMovementSystem shipMovement { get => GetComponent<ShipMovementSystem>(); }
    private void Awake()
    {
        characterHP = 3;
    }
}
