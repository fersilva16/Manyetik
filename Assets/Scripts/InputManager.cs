using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  public static event Action<InputAction.CallbackContext> Movement;
  public static event Action<InputAction.CallbackContext> Jump;
  public static event Action<InputAction.CallbackContext> Invert;
  public static event Action<InputAction.CallbackContext> Interact;
  public static event Action<InputAction.CallbackContext> Menu;

  private GameInputs inputs;

  private void OnEnable()
  {
    if (inputs == null)
    {
      inputs = new GameInputs();

      inputs.Player.Enable();
    }

    inputs.Player.Movement.started += OnMovement;
    inputs.Player.Movement.canceled += OnMovement;
    inputs.Player.Jump.performed += OnJump;
    inputs.Player.Invert.performed += OnInvert;
    inputs.Player.Interact.performed += OnInteract;
    inputs.Player.Menu.performed += OnMenu;
  }

  private void OnDisable()
  {
    inputs.Player.Movement.started -= OnMovement;
    inputs.Player.Movement.canceled -= OnMovement;
    inputs.Player.Jump.performed -= OnJump;
    inputs.Player.Invert.performed -= OnInvert;
    inputs.Player.Interact.performed -= OnInteract;
    inputs.Player.Menu.performed -= OnMenu;
  }

  private void OnMovement(InputAction.CallbackContext context) => Movement?.Invoke(context);
  private void OnJump(InputAction.CallbackContext context) => Jump?.Invoke(context);
  private void OnInvert(InputAction.CallbackContext context) => Invert?.Invoke(context);
  private void OnInteract(InputAction.CallbackContext context) => Interact?.Invoke(context);
  private void OnMenu(InputAction.CallbackContext context) => Menu?.Invoke(context);
}
