using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public TMP_InputField inputFieldNumber1;
    public TMP_InputField inputFieldNumber2;
    public TMP_Dropdown operationDropdown;
    public TMP_Text resultText;
    public Button calculateButton;

    void Start()
    {
        calculateButton.onClick.AddListener(Calculate);
    }

    void Calculate()
    {
        float number1;
        float number2;
        if (float.TryParse(inputFieldNumber1.text, out number1) && 
            float.TryParse(inputFieldNumber2.text, out number2))
        {
            string operation = operationDropdown.options[operationDropdown.value].text;
            float result = 0;
            
            switch (operation)
            {
                case "Add":
                    result = number1 + number2;
                    break;
                case "Subtract":
                    result = number2 - number1;
                    break;
                case "Multiply":
                    result = number1 * number2;
                    break;
                case "Divide":
                    if (number1 != 0)
                    {
                        result = number2 / number1;
                    }
                    else
                    {
                        resultText.text = "Cannot divide by zero";
                        return;
                    }
                    break;
                case "Percentage":
                    result = (number2 / 100) * number1;
                    break;
                case "Remainder":
                    if (number2 != 0)
                    {
                        result = number2 % number1;
                    }
                    else
                    {
                        resultText.text = "Cannot divide by zero";
                        return;
                    }
                    break;
            }
            
            resultText.text = "Result: " + result.ToString();
        }
        else
        {
            resultText.text = "Invalid input";
        }
    }
}
