using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerControls playerControls;
    public NavMeshAgent agent;

    public Animator animator;
    public float speed = 6f;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Update()
    {
        Vector3 move = playerControls.Land.Move.ReadValue<Vector3>();
        if (move.magnitude > 0.1f)
        {
            animator.SetInteger("Direction", (int)GetDirection(move));
            agent.Move(move * speed * Time.deltaTime);
        }
        else
        {
            animator.SetInteger("Direction", (int)MovementDirection.idle);
        }
    }

    MovementDirection GetDirection(Vector3 move)
    {
        if (move.x != 0)
        {
            return move.x < 0 ? MovementDirection.left : MovementDirection.right;
        }
        if (move.z != 0)
        {
            return move.z < 0 ? MovementDirection.backward : MovementDirection.forward;
        }
        return MovementDirection.forward;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}

enum MovementDirection
{
    forward,
    backward, 
    left,
    right,
    idle
}