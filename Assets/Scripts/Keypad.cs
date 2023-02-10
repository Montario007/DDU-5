using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private int maxLength = 3;

    private string Answer = "487";
     
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
        }
        else
        {
            Ans.text = "Invalid";
        }
    }   
}
