using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Net;

public class Drag : MonoBehaviour
{
    public int value = 1;
    public int newValue;
    public int bigAmount = 0;
    public int smallAmount;
    public int bigValue;
    public int smallValue;
    Vector3 screenPoint;
    Vector3 offset;
    Vector2 smallSpot;
    Vector2 bigSpot;
    public TMP_Text showValue;
    public GameObject number;

    private void Update()
    {
        showValue.text = "" + value;//show the correct value
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);//alllows you to drag number without snapping to the middle

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);//get rellative mouse position
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset; //mouse position + the offset
        transform.position = curPosition;//place it correctly
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && value > 10 && value < 100 && value != 20 && value != 30 && value != 40 && value != 50 && value != 60 && value != 70 && value != 80 && value != 90)
        {
            HowManyTen();

            bigSpot = new(transform.position.x - 1, transform.position.y);
            bigValue = bigAmount * 10;

            smallSpot = new(transform.position.x + 1, transform.position.y);
            smallValue = smallAmount;

            value = bigValue;
            Instantiate(number, bigSpot, Quaternion.identity);

            value = smallValue;
            Instantiate(number, smallSpot, Quaternion.identity);

            Destroy(gameObject);
        }
        else if (Input.GetMouseButtonDown(1) && value > 100 && value < 1000 && value != 200 && value != 300 && value != 400 && value != 500 && value != 600 && value != 700 && value != 800 && value != 900)
        {
            HowManyHunderd();

            bigSpot = new(transform.position.x - 1, transform.position.y);
            bigValue = bigAmount * 100;

            smallSpot = new(transform.position.x + 1, transform.position.y);
            smallValue = smallAmount;

            value = bigValue;
            Instantiate(number, bigSpot, Quaternion.identity);

            value = smallValue;
            Instantiate(number, smallSpot, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Number"))
        {
            newValue = value + collision.gameObject.GetComponent<Drag>().value;//value of new num
            Vector2 midPoint = (transform.position + collision.transform.position) / 2;//position of new num

            value = newValue;//change value to outcome calculation
            Instantiate(number, midPoint, Quaternion.identity);//spawn new number

            Destroy(collision.gameObject);//destroy the old ones
            Destroy(gameObject);
        }
    }
    private void HowManyTen()
    {
        smallAmount = value;
        while (smallAmount > 10)
        {
            bigAmount++;
            smallAmount -= 10;
        }
    }
    private void HowManyHunderd()
    {
        smallAmount = value;
        while (smallAmount > 100)
        {
            bigAmount++;
            smallAmount -= 100;
        }
    }
}

