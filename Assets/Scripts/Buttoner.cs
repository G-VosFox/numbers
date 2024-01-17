using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttoner : MonoBehaviour
{
    public GameObject number;
    readonly int[] buttonNum = new int[10];
    public int numberAmountCount = 0;
    public int valueInt;
    public bool minus = false;

    Vector2 place = new(7, 2);//the spawn position for the number

    private void Start()
    {
        number.GetComponent<Drag>().value = 0;
        numberAmountCount = 0;
    }
    public void Button1()//these things spawn the prefab thing with the correct value
    {
        buttonNum[numberAmountCount] = 1;
        numberAmountCount++;
    }
    public void Button2()
    {
        buttonNum[numberAmountCount] = 2;
        numberAmountCount++;
    }
    public void Button3()
    {
        buttonNum[numberAmountCount] = 3;
        numberAmountCount++;
    }
    public void Button4()
    {
        buttonNum[numberAmountCount] = 4;
        numberAmountCount++;
    }
    public void Button5()
    {
        buttonNum[numberAmountCount] = 5;
        numberAmountCount++;
    }
    public void Button6()
    {
        buttonNum[numberAmountCount] = 6;
        numberAmountCount++;
    }
    public void Button7()
    {
        buttonNum[numberAmountCount] = 7;
        numberAmountCount++;
    }
    public void Button8()
    {
        buttonNum[numberAmountCount] = 8;
        numberAmountCount++;
    }
    public void Button9()
    {
        buttonNum[numberAmountCount] = 9;
        numberAmountCount++;
    }
    public void Button0()
    {
        buttonNum[numberAmountCount] = 0;
        numberAmountCount++;
    }
    public void Min()
    {
        if (minus == false)
        {
            minus = true;
        }
        else if (minus == true)
        {
            minus = false;
        }
    }
    public void Enter()
    {
        if (numberAmountCount == 1)
        {
            valueInt = buttonNum[0];
        }
        else if (numberAmountCount == 2)
        {
            valueInt = buttonNum[0] * 10 + buttonNum[1];
        }
        else if (numberAmountCount == 3)
        {
            valueInt = buttonNum[0] * 100 + buttonNum[1] * 10 + buttonNum[2];
        }
        else if (numberAmountCount == 4)
        {
            valueInt = buttonNum[0] * 1000 + buttonNum[1] * 100 + buttonNum[2] * 10 + buttonNum[3];
        }

        if (minus == true)
        {
            valueInt = -valueInt;
        }
        number.GetComponent<Drag>().value = valueInt;
        Instantiate(number, place, Quaternion.identity);
        numberAmountCount = 0;
        valueInt = 0;
        minus = false;
    }
}
