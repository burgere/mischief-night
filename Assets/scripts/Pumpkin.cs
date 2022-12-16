using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour, Interactable
{
    private Animator animator;
    [SerializeField] private string prompt;
    string Interactable.InteractionPrompt => prompt;

    private PlayerControls controls;

    bool Interactable.Interact(Interactor interactor)
    {
        animator.SetBool("activated", true);
        return true;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        controls = new PlayerControls();

        prompt = $"Press the Action Button, my dude.";
    }
}
