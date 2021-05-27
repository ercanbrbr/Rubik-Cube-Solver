using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;
    public GameObject target;
    float speed = 200f;

    void Update()
    {
        Swipe();
        Drag();
    }
    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }
    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
                UpdatePieces(new string[] {"f", "l", "b", "r" });
                GameObject.Find("GameController2").GetComponent<Game2>().LeftSwipe();
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
                UpdatePieces(new string[] {"f", "r", "b", "l" });
                GameObject.Find("GameController2").GetComponent<Game2>().RightSwipe();
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
                UpdatePieces(new string[] { "r", "u", "l", "d" });
                GameObject.Find("GameController2").GetComponent<Game2>().UpLeftSwipe();
            }
            else if (UpRightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);
                UpdatePieces(new string[] { "f", "u", "b", "d" });
                GameObject.Find("GameController2").GetComponent<Game2>().UpRightSwipe();
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
                UpdatePieces(new string[] { "f", "d", "b", "u" });
                GameObject.Find("GameController2").GetComponent<Game2>().DownLeftSwipe();
            }
            else if (DownRightSwipe(currentSwipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
                UpdatePieces(new string[] { "r", "d", "l", "u" });
                GameObject.Find("GameController2").GetComponent<Game2>().DownRightSwipe();
            }
            GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
        }
    }
    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }
    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }
    //Her parça, hangi tarafta olduğu bilgisini tutuyor. Bu fonksiyon rotasyon yaptıktan sonra, bu bilgileri güncelliyor.
    void UpdatePieces(string [] deneme)
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Pieces"))
        {
            for (int i = 0; i < cube.GetComponent<Piece>().tags.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cube.GetComponent<Piece>().tags[i] == deneme[j])
                    {
                        cube.GetComponent<Piece>().tags[i] = deneme[(j + 1) % 4];
                        break;
                    }
                }
            }
        }
    }
}
