using System;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TextMeshPro _inputField;

    private string actions = "+-/x=";
    private string values = "0123456789";
    
    private int _iter;
    private string _number1 = "";
    private string _number2 = "";
    private string _action = "";
    private double _final_number;
    
    private void Awake()
    {
        _inputField.text = "";
    }

    public void ClearField()
    {
        _iter = 0;
        _final_number = 0;
        _number1 = "";
        _number2 = "";
        _inputField.text = "";
        _action = "";
    }
    
    public void InputField(string value)
    {
        if (_inputField.text == "Error")
        {
            ClearField();
        }
        Debug.Log($"Action: {_action}. Input: {_inputField.text}. Iter: {_iter}. Value: {value}. Contains {values.Contains(value)}");
        if (_action == "" && _inputField.text != "" && _iter != 0 && values.Contains(value))
        {
            ClearField();
        }
        if (_inputField.text != "" && value == "=" && _iter != 0 && _number2 == "")
        {
            return;
        }
        if (_inputField.text == "" && value == "0")
        {
            return;
        }
        if (_inputField.text == "" && actions.Contains(value))
        {
            return;
        }
        if (actions.Contains(value))
        {
            _inputField.text += " ";
            _inputField.text += value;
            _inputField.text += " ";
            if (_action != "" && (_number1 != "" && _number2 != ""))
            {
                Calculate(Convert.ToInt32(_number1), Convert.ToInt32(_number2), _action);
            }
            else
            {
                _action = value;
            }
        }
        else
        {
            _inputField.text += value;
            if(_action == "" && _iter == 0)
                _number1 += value;
            else
            {
                _number2 += value;
            }
        }
    }

    private void Calculate(int number1, int number2, string action)
    {
        if (action == "+")
        {
            _final_number = number1 + number2;
        }
        if (action == "-")
        {
            _final_number = number1 - number2;
        }
        if (action == "x")
        {
            _final_number = number1 * number2;
        }
        if (action == "/")
        {
            if (number2 == 0)
            {
                _inputField.text = "Error";
            }
            else
            {
                _final_number = Math.Round((double)(number1 / number2), 3);
                Debug.Log(_final_number);
            }
        }

        if (_inputField.text != "Error")
        {
            _inputField.text = _final_number.ToString();
            _number1 = _final_number.ToString();
            _iter++;
            _action = "";
        }
        _number2 = "";
    }
    
}
