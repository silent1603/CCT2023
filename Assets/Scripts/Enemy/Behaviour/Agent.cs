using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : MonoBehaviour
{
    private AgentMover agentMover;

    private Vector2 movementInput;

    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    private void Update()
    {
        agentMover.MovementInput = movementInput;
        AnimateCharacter();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {

    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        //TODO: attack
    }

    private void Awake()
    {
        agentMover = GetComponent<AgentMover>();
    }

    private void AnimateCharacter()
    {

    }

    

}
