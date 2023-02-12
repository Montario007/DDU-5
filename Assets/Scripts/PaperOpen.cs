using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperOpen : MonoBehaviour
{
    public Image uiImage;
    public Image interactionText;
    public float interactionDistance = 5.0f;
    private Transform playerTransform;
    private CharacterController characterController;
    private bool wasCharacterControllerEnabled;
    [SerializeField] private AudioSource paper;

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
                paper.Play();
                uiImage.gameObject.SetActive(!uiImage.gameObject.activeSelf);
                if (uiImage.gameObject.activeSelf)
                {
                    wasCharacterControllerEnabled = characterController.enabled;
                    characterController.enabled = false;
                }
                else
                {
                    characterController.enabled = wasCharacterControllerEnabled;
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
