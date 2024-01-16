using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttoner : MonoBehaviour
{
    public GameObject number;
    int[] buttonNum = new int[2];
    public int numberAmountCount = 0;
    public int valueInt;

    Vector2 place = new Vector2(7, 2);//the spawn position for the number
    
    public void Button1()//these things spawn the prefab thing with the correct value
    {
        buttonNum[numberAmountCount] = '1';
        numberAmountCount++;
    }
    public void Button2()
    {
        buttonNum[numberAmountCount] = '2';
        numberAmountCount++;
    }
    public void Button3()
    {
        buttonNum[numberAmountCount] = '3';
        numberAmountCount++;
    }
    public void Button4()
    {
        buttonNum[numberAmountCount] = '4';
        numberAmountCount++;
    }
    public void Button5()
    {
        buttonNum[numberAmountCount] = '5';
        numberAmountCount++;
    }
    public void Button6()
    {
        buttonNum[numberAmountCount] = '6';
        numberAmountCount++;
    }
    public void Button7()
    {
        buttonNum[numberAmountCount] = '7';
        numberAmountCount++;
    }
    public void Button8()
    {
        buttonNum[numberAmountCount] = '8';
        numberAmountCount++;
    }
    public void Button9()
    {
        buttonNum[numberAmountCount] = '9';
        numberAmountCount++;
    }
    public void Button0()
    {
        buttonNum[numberAmountCount] = '0';
        numberAmountCount++;
    }
    public void Enter()
    {
        Debug.Log(buttonNum[0]);
        if (numberAmountCount == 1)
        {
            valueInt = buttonNum[0];
        }
        else if (numberAmountCount == 2)
        {
            valueInt = buttonNum[1] * 10 + buttonNum[0];
        }
        number.GetComponent<Drag>().value = valueInt;
        Instantiate(number, place, Quaternion.identity);
    }
}
