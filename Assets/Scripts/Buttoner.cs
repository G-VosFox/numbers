using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttoner : MonoBehaviour
{
    public GameObject number;

    Vector2 place = new Vector2(7, 2);
    public void Button1()//these things spawn the prefab thing with the correct value
    {
        number.GetComponent<Drag>().value = 1;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button2()
    {
        number.GetComponent<Drag>().value = 2;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button3()
    {
        number.GetComponent<Drag>().value = 3;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button4()
    {
        number.GetComponent<Drag>().value = 4;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button5()
    {
        number.GetComponent<Drag>().value = 5;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button6()
    {
        number.GetComponent<Drag>().value = 6;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button7()
    {
        number.GetComponent<Drag>().value = 7;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button8()
    {
        number.GetComponent<Drag>().value = 8;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button9()
    {
        number.GetComponent<Drag>().value = 9;
        Instantiate(number, place, Quaternion.identity);
    }
    public void Button0()
    {
        number.GetComponent<Drag>().value = 0;
        Instantiate(number, place, Quaternion.identity);
    }
}
