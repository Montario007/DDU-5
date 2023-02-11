using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public Image uiImage;
    public Image interactionText;
    public float interactionDistance = 5.0f;

    private Transform playerTransform;
    private CharacterController characterController;
    private bool wasCharacterControllerEnabled;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = playerTransform.GetComponent<CharacterController>();
        interactionText.gameObject.SetActive(false);
        uiImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= interactionDistance && Key.keyPickedUp && Keypad.keypadUnlocked)
        {
            interactionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                uiImage.gameObject.SetActive(!uiImage.gameObject.activeSelf);
                if (uiImage.gameObject.activeSelf)
                {
                    wasCharacterControllerEnabled = characterController.enabled;
                    characterController.enabled = false;
                }
                else
                {
                    characterController.enabled = wasCharacterControllerEnabled;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
