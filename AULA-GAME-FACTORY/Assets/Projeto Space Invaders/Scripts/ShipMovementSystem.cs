using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementSystem : MonoBehaviour
{
    public float shipSpeed;
    ParticleSystem[] myMovementParticles;
    public bool isMoving;
    public bool isHovering;
    private void Awake()
    {
        shipSpeed = 150;
        myMovementParticles = GetComponentsInChildren<ParticleSystem>();
    }
    void Update()
    {
        ToggleMovementParticles(isMoving && isHovering);
    }

    private void FixedUpdate()
    {
        MovementFunction(Time.fixedDeltaTime);
    }

    void ToggleMovementParticles(bool value)
    {
        foreach (ParticleSystem particleSystem in myMovementParticles)
        {
            if (value)
            {
                if (particleSystem.isStopped)
                {
                    particleSystem.Play();
                }
            }
            else
            {
                if (particleSystem.isPlaying)
                {
                    particleSystem.Stop();
                }
            }
        }
    }

    void MovementFunction(float time)
    {

        Rigidbody2D myBody = GetComponentInChildren<Rigidbody2D>();
        if (myBody == null)
            return;
        float verticalRaw = 0;//Input.GetAxisRaw("Vertical");
        float horizontalRaw = Input.GetAxisRaw("Horizontal");
        isMoving = myBody.velocity != Vector2.zero;
        bool moveVertical = verticalRaw != 0;
        bool moveHorizontal = horizontalRaw != 0;
        isHovering = moveVertical || moveHorizontal;
        myBody.velocity = new Vector2(horizontalRaw, verticalRaw) * shipSpeed * time;
    }
}
