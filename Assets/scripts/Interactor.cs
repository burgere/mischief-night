using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.InputSystem.InputAction;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private int collidersFound;
    [SerializeField] private PromptUI promptUI;

    private Interactable interactable;

    private PlayerController playerController;

    private readonly Collider[] colliders = new Collider[3];

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.playerControls.Land.Interact.performed += handleInteractionPressed;
    }

    private void handleInteractionPressed(CallbackContext context)
    {
        if (interactable != null)
        {
            interactable.Interact(this);
            HideUI();
        }
    }

    private void HideUI()
    {
        interactable = null;
        if (promptUI.IsDisplayed) promptUI.Close();
    }

    private void Update()
    {
        collidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        if (collidersFound > 0)
        {
            interactable = colliders[0].GetComponent<Interactable>();
            if (interactable != null)
            {
                if (!promptUI.IsDisplayed) promptUI.SetUp(interactable.InteractionPrompt);
            }
        }
        else
        {
            HideUI();
        }
    }
}
