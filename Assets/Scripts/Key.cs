using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public Image interactionText;
    private float interactionDistance = 5.0f;

    private Transform playerTransform;
    public static bool keyPickedUp = false;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
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
        keyPickedUp = true;
    }

}
