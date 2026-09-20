using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    
    // Input variables
    
    // Input system
    private InputSystem_Actions inputSystem;
    
    // Teleport
    private InputAction teleportAction;
    
    // Move forward (local)
    private InputAction moveForwardLocalAction;
    // Move backward (local)
    private InputAction moveBackwardLocalAction;
    // Turn clockwise
    private InputAction rotateClockwiseAction;
    // Turn Counter-Clockwise
    private InputAction rotateCounterClockwiseAction;
    
    // Move forward (world)
    private InputAction moveForwardWorldAction;
    // Move backward (world)
    private InputAction moveBackwardWorldAction;
    // Move right (world)
    private InputAction moveRightWorldAction;
    // Move left (world)
    private InputAction moveLeftWorldAction;
    
    // Turbo
    private InputAction turboAction;
    
    public override void MakeDecisions()
    {
        if (turboAction.IsPressed())
        {
            // Faster Movement is used
            if (moveForwardLocalAction.IsPressed())
            {
                controlledPawn.MoveForwardLocalTurbo();
            }

            if (moveBackwardLocalAction.IsPressed())
            {
                controlledPawn.MoveBackwardLocalTurbo();
            }

            if (rotateClockwiseAction.IsPressed())
            {
                controlledPawn.RotateClockwiseTurbo();
            }

            if (rotateCounterClockwiseAction.IsPressed())
            {
                controlledPawn.RotateCounterClockwiseTurbo();
            }
        }
        else
        {
            // Normal Movement is used
            if (moveForwardLocalAction.IsPressed())
            {
                controlledPawn.MoveForwardLocal();
            }

            if (moveBackwardLocalAction.IsPressed())
            {
                controlledPawn.MoveBackwardLocal();
            }

            if (rotateClockwiseAction.IsPressed())
            {
                controlledPawn.RotateClockwise();
            }

            if (rotateCounterClockwiseAction.IsPressed())
            {
                controlledPawn.RotateCounterClockwise();
            }
        }

        // World Space Movement
        if (moveForwardWorldAction.WasPressedThisFrame())
        {
            controlledPawn.MoveForwardWorld();
        }

        if (moveBackwardWorldAction.WasPressedThisFrame())
        {
            controlledPawn.MoveBackwardWorld();
        }

        if (moveRightWorldAction.WasPressedThisFrame())
        {
            controlledPawn.MoveRightWorld();
        }

        if (moveLeftWorldAction.WasPressedThisFrame())
        {
            controlledPawn.MoveLeftWorld();
        }
        
        // Teleportation
        if (teleportAction.WasPressedThisFrame())
        {
            controlledPawn.Teleport();
        }
    }
    
    public override void Start()
    {
        inputSystem = new InputSystem_Actions();
        teleportAction = inputSystem.Player.Teleport;
        moveForwardLocalAction = inputSystem.Player.MoveForwardLocal;
        moveBackwardLocalAction = inputSystem.Player.MoveBackwardLocal;
        rotateClockwiseAction = inputSystem.Player.RotateClockwise;
        rotateCounterClockwiseAction = inputSystem.Player.RotateCounterClockwise;
        moveForwardWorldAction = inputSystem.Player.MoveForwardWorld;
        moveBackwardWorldAction = inputSystem.Player.MoveBackwardWorld;
        moveRightWorldAction = inputSystem.Player.MoveRightWorld;
        moveLeftWorldAction = inputSystem.Player.MoveLeftWorld;
        turboAction = inputSystem.Player.Turbo;
        inputSystem.Enable();
    }
    
    public override void Update()
    {
        MakeDecisions();
    }

    public override void OnDisable()
    {
        inputSystem.Disable();
    }
}
