using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private int maxLength = 3;
    [SerializeField] private float displayTime = 2.0f;
    [SerializeField] private GameObject uiImage;
    [SerializeField] private Animator myAnimationController;
    [SerializeField] private float delay = 4.0f;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioSource wrong;
    
    private string Answer = "784";
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
            button.Play();
        }
    }
    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            keypadUnlocked = false;
            door.Play();
            myAnimationController.SetBool("open", false);
            StartCoroutine(OpenDoorWithDelay());
        }
        else
        {
            Ans.text = "Invalid";
            timeLeft = displayTime;
            wrong.Play();
        }
    }
    private IEnumerator OpenDoorWithDelay()
    {
        yield return new WaitForSeconds(delay);
        uiImage.SetActive(false);
        CharacterController characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        characterController.enabled = true;
        win();
    }
    public void win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}