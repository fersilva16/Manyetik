using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  [Header("Events")]
  [SerializeField]
  private UnityEvent<InputAction.CallbackContext> Movement;

  [SerializeField]
  private UnityEvent<InputAction.CallbackContext> Jump;

  [SerializeField]
  private UnityEvent<InputAction.CallbackContext> Invert;

  [SerializeField]
  private UnityEvent<InputAction.CallbackContext> Interact;

  [SerializeField]
  private UnityEvent<InputAction.CallbackContext> Menu;

  public GameInputs inputs;

  private void OnEnable()
  {
    if (inputs == null)
    {
      inputs = new GameInputs();

      inputs.Player.Enable();
    }

    inputs.Player.Movement.started += Movement.Invoke;
    inputs.Player.Movement.canceled += Movement.Invoke;
    inputs.Player.Jump.performed += Jump.Invoke;
    inputs.Player.Invert.performed += Invert.Invoke;
    inputs.Player.Interact.performed += Interact.Invoke;
    inputs.Player.Menu.performed += Menu.Invoke;
  }

  private void OnDisable()
  {
    inputs.Player.Movement.started -= Movement.Invoke;
    inputs.Player.Movement.canceled -= Movement.Invoke;
    inputs.Player.Jump.performed -= Jump.Invoke;
    inputs.Player.Invert.performed -= Invert.Invoke;
    inputs.Player.Interact.performed -= Interact.Invoke;
    inputs.Player.Menu.performed -= Menu.Invoke;
  }
}
