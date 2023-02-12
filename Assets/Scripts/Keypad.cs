using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private int maxLength = 3;
    [SerializeField] private float displayTime = 2.0f;
    [SerializeField] private GameObject uiImage;
    [SerializeField] private Animator myAnimationController;

    private string Answer = "487";
    private float timeLeft;
    public static bool keypadUnlocked = true;

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Ans.text = "";
            }
        }
    }

    public void Number(int number)
    {
        if (Ans.text.Length < maxLength)
        {
            Ans.text += number.ToString();
        }
    }
    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            keypadUnlocked = false;
            uiImage.SetActive(false);
            CharacterController characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
            characterController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            myAnimationController.SetBool("open", false);

        }
        else
        {
            Ans.text = "Invalid";
            timeLeft = displayTime;
        }
    }   
}