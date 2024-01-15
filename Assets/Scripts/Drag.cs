using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public int value = 1;
    public int newValue;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite0;
    Vector3 screenPoint;
    Vector3 offset;
    public GameObject number;

    private void Update()
    {

        if (value == 1)//to get the corect number on the sprite(prob ganna change later)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (value == 2)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (value == 3)
        {
            spriteRenderer.sprite = sprite3;
        }
        else if (value == 4)
        {
            spriteRenderer.sprite = sprite4;
        }
        else if (value == 5)
        {
            spriteRenderer.sprite = sprite5;
        }
        else if (value == 6)
        {
            spriteRenderer.sprite = sprite6;
        }
        else if (value == 7)
        {
            spriteRenderer.sprite = sprite7;
        }
        else if (value == 8)
        {
            spriteRenderer.sprite = sprite8;
        }
        else if (value == 9)
        {
            spriteRenderer.sprite = sprite9;
        }
        else if (value == 0)
        {
            spriteRenderer.sprite = sprite0;
        }
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Number")
        {
            newValue = value + collision.gameObject.GetComponent<Drag>().value;//value of new num
            Vector2 midPoint = (transform.position + collision.transform.position) / 2;//position of new num

            value = newValue;
            Instantiate(number, midPoint, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

