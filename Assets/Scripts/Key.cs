using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public Image interactionText;
    public float interactionDistance = 5.0f;
    [SerializeField] private AudioSource key;
    [SerializeField] private AudioSource voice;
    [SerializeField] private float delay = 4.0f;
    private Transform playerTransform;
    private CharacterController characterController;
    private bool wasCharacterControllerEnabled;
    public static bool keyPickedUp = false;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = playerTransform.GetComponent<CharacterController>();
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q) && keyPickedUp == false)
            {
                key.Play();
                voice.Play();
                keyPickedUp = true;
                wasCharacterControllerEnabled = characterController.enabled;
                characterController.enabled = false;
                StartCoroutine(keypickup());
            }
        }

        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
    private IEnumerator keypickup()
    {
        yield return new WaitForSeconds(delay);
        PickUp();
        interactionText.gameObject.SetActive(false);
        characterController.enabled = wasCharacterControllerEnabled;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
