using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Houve uma colisão.");
        print($"{gameObject.transform.parent?.gameObject} colidiu com {collision.transform.parent?.gameObject}");
    }
}
