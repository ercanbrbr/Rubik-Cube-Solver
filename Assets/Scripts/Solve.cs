using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Solve : MonoBehaviour
{
    GameObject cube;
    bool check = true;
    public void Start()
    {
        cube = GameObject.Find("GameController2");
        
    }
    public void whiteCross() 
    {
        /*while (check(Side(Down))!=true)
        {
            //çözdür
        }*/
        firstLayer();
    }
    void firstLayer()
    {
        /*while (true)
        {

        }*/
        secondLayer();
    }
    void secondLayer()
    {
        yellowLayer();
    }
    void yellowLayer()
    {
        while (cube.GetComponent<Game2>().check(cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up)) == false && check == true) //All Yellow
        {
            //Overlapping Squares
            if (control(new int[] { 1, 2, 3, 4, 5, 6, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up) || control(new int[] { 0, 1, 3, 4, 5, 7, 8 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up)) 
            {
                rightSune();
            }
            //Sign Bottom
            else if (control(new int[] { 0, 1, 2, 3, 4, 5, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                rightSune();
            }
            //Sign Left
            else if (control(new int[] { 1, 2, 3, 4, 5, 7, 8 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(rswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //rightSune();
            }
            //Sign Right
            else if (control(new int[] { 0, 1, 3, 4, 5, 6, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
                //rightSune();
            }
            //Sign Top
            else if (control(new int[] { 1, 3, 4, 5, 6, 7, 8 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //rightSune();
            }
            //Fish Corrent
            else if (control(new int[] { 1, 3, 4, 5, 6, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                print(cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2]+" dene ");
                if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] == cube.GetComponent<Game2>().Up)
                    rightSune();
                else
                {
                    StartCoroutine(lSune());
                }
            }
            //Fish Bot Right
            else if (control(new int[] { 1, 3, 4, 5, 7, 8 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                /*if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] == cube.GetComponent<Game2>().Up)
                    rightSune();
                StartCoroutine(lSune());*/
            }
            //Fish Top Left
            else if (control(new int[] { 0, 1, 3, 4, 5, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(rswipe(4));
                /*GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
                if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] == cube.GetComponent<Game2>().Up)
                    rightSune();
                StartCoroutine(lSune());*/
            }
            //Fish Top Right
            else if (control(new int[] { 1, 2, 3, 4, 5, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                /*GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
                GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
                if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] == cube.GetComponent<Game2>().Up)
                    rightSune();
                StartCoroutine(lSune());*/
            }
            //Cross
            else if (control(new int[] { 1, 3, 4, 5, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] != cube.GetComponent<Game2>().Up)
                {   
                    rightSune();
                }
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
            }
            //Hook Top Left
            else if (control(new int[] { 1, 3, 4 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                hook();
            }
            //Hook Top Right
            else if (control(new int[] { 1, 4, 5 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(rswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
                //hook();
            }
            //Hook Bot Left
            else if (control(new int[] { 3, 4, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //hook();
            }
            //Hook Bot Right
            else if (control(new int[] { 4, 6, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //hook();
            }
            //Bar Horizontal
            else if (control(new int[] { 3, 4, 5 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                bar();
            }
            //Bar Vertical
            else if (control(new int[] { 1, 4, 7 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up), cube.GetComponent<Game2>().Up))
            {
                StartCoroutine(lswipe(4));
                //GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
                //bar();
            }
            //Lonely Square
            else
            {
                hook();
            }
        }
        if (cube.GetComponent<Game2>().check(cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Up)))
        {
            thirdLayer();
        }
    }
    void thirdLayer()
    {
        while (check == true && !control(new int[] { 0, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front), cube.GetComponent<Game2>().Front))
        {
            //Her Yüzün Üçüncü Katı Aynı İse
            if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] &&
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 2] &&
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 2] &&
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 2])
            {
                print("all pieces");
                cube.GetComponent<Game2>().moveList += " U ";
                GameObject.Find("Cube").GetComponent<Rotations>().up();

            }
            else if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 2])
            {
                if (control(new int[] { 0, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back), cube.GetComponent<Game2>().Back))
                {
                    PLL();
                }
                else
                {
                    cube.GetComponent<Game2>().moveList += " U ";
                    GameObject.Find("Cube").GetComponent<Rotations>().up();
                }
            }
            //Her Yüzün Üçüncü Katının Köşeleri Aynı İse
            else if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] &&
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 2] &&
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 2] &&
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 2])
            {
                print("all edges");
                cube.GetComponent<Game2>().moveList += " U ";
                GameObject.Find("Cube").GetComponent<Rotations>().up();
            }
            else if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] ||
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 2] ||
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 2] ||
                cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 2])
            {
                print("one edges");
                if (control(new int[] { 0, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back), cube.GetComponent<Game2>().Back))
                {
                    PLL();
                }
                else
                {
                    cube.GetComponent<Game2>().moveList += " U ";
                    GameObject.Find("Cube").GetComponent<Rotations>().up();
                }
            }
            else
            {
                PLL();
            }
        } 
        thirdlayerPart2();
    }
    void thirdlayerPart2()
    {
        if ((cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Left)[0, 2] ||
            cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 0] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] && cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 1] == cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Right)[0, 2]) && 
                !control(new int[] { 0, 1, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back), cube.GetComponent<Game2>().Back))
        {
            StartCoroutine(rswipe(5));
        }
        else
        {
            if (control(new int[] { 0, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back), cube.GetComponent<Game2>().Back))
            {
                if (control(new int[] { 0, 1, 2 }, cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Back), cube.GetComponent<Game2>().Back))
                {
                    if (cube.GetComponent<Game2>().Side(cube.GetComponent<Game2>().Front)[0, 1] == cube.GetComponent<Game2>().Left)
                    {
                        threePieceClockwise();
                    }
                    else
                        threePieceCounterClockwise();
                }
                else
                {
                    threePieceClockwise();
                    thirdLayer();
                }
            }
            else
            {
                cube.GetComponent<Game2>().moveList += " U ";
                GameObject.Find("Cube").GetComponent<Rotations>().up();
                thirdlayerPart2();
            }
        }
    }
    void hook()
    {
        cube.GetComponent<Game2>().moveList += " F  U  R  U'  R'  F' ";
        GameObject.Find("Cube").GetComponent<Rotations>().front();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().front(false);
    }
    void bar()
    {
        cube.GetComponent<Game2>().moveList += " F  R  U  R'  U'  F' ";
        GameObject.Find("Cube").GetComponent<Rotations>().front();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().front(false);
    }
    void rightSune()
    {
        cube.GetComponent<Game2>().moveList += " R  U  R'  U  R  U  U  R' ";
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
    }
    void leftSune()
    {
        cube.GetComponent<Game2>().moveList += " L'  U'  L  U'  L'  U  U  L ";
        GameObject.Find("Cube").GetComponent<Rotations>().left(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().left();
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().left(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().left();
    }
    void PLL()
    {
        cube.GetComponent<Game2>().moveList += " R'  F  R'  B  B  R  F'  R'  B  B  R  R ";
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().front();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().back();
        GameObject.Find("Cube").GetComponent<Rotations>().back();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().front(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().back();
        GameObject.Find("Cube").GetComponent<Rotations>().back();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().right();

    }
    void threePieceClockwise()
    {
        cube.GetComponent<Game2>().moveList += " R  R  U  R  U  R'  U'  R'  U'  R'  U  R' ";
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
    }
    void threePieceCounterClockwise()
    {
        cube.GetComponent<Game2>().moveList += " R  U'  R  U  R  U  R  U'  R'  U'  R  R ";
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right(false);
        GameObject.Find("Cube").GetComponent<Rotations>().up(false);
        GameObject.Find("Cube").GetComponent<Rotations>().right();
        GameObject.Find("Cube").GetComponent<Rotations>().right();
    }
    IEnumerator lSune()
    {
        check = false;
        cube.GetComponent<Game2>().moveList += " RS ";
        GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
        yield return new WaitForSeconds(1);
        leftSune();
        check = true;
        yellowLayer();
    }
    IEnumerator rswipe(int a)
    {
        check = false;
        cube.GetComponent<Game2>().moveList += " RS ";
        GameObject.Find("Cube").GetComponent<RotateBigCube>().doRightSwipe();
        yield return new WaitForSeconds(1);
        check = true;
        if (a == 1)
            whiteCross();
        else if (a == 2)
            firstLayer();
        else if (a == 3)
            secondLayer();
        else if (a == 4)
            yellowLayer();
        else
            thirdlayerPart2();
    }
    IEnumerator lswipe(int a)
    {
        check = false;
        cube.GetComponent<Game2>().moveList += " LS ";
        GameObject.Find("Cube").GetComponent<RotateBigCube>().doLeftSwipe();
        yield return new WaitForSeconds(1);
        check = true;
        if (a == 1)
            whiteCross();
        else if (a == 2)
            firstLayer();
        else if (a == 3)
            secondLayer();
        else if (a == 4)
            yellowLayer();
        else
            thirdLayer();
    }
    bool control(int[] a, char[,] list, char c)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (list[Convert.ToInt32(a[i]) / 3, a[i] % 3] != c)
            {
                return false;
            }
        }
        return true;
    }
}
