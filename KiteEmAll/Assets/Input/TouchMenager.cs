using UnityEngine;
using UnityEngine.InputSystem;

public class TouchMenager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction activeAbility1;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        activeAbility1 = playerInput.actions["ActiveAbility1"];
    }

    private void OnEnable()
    {
        activeAbility1.performed += ActiveAbility1Pressed;
    }

    private void OnDisable()
    {
        activeAbility1.performed -= ActiveAbility1Pressed;
    }

    private void ActiveAbility1Pressed(InputAction.CallbackContext context)
    {
        bool value = context.ReadValueAsButton();
        Debug.Log(value);
    }
}
