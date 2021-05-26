using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2 : MonoBehaviour
{
    public char[,] white = new char[,] { { 'W', 'W', 'W' }, { 'W', 'W', 'W' }, { 'W', 'W', 'W' } };
    public char[,] yellow = new char[,] { { 'Y', 'Y', 'Y' }, { 'Y', 'Y', 'Y' }, { 'Y', 'Y', 'Y' } };
    public char[,] blue = new char[,] { { 'B', 'B', 'B' }, { 'B', 'B', 'B' }, { 'B', 'B', 'B' } };
    public char[,] red = new char[,] { { 'R', 'R', 'R' }, { 'R', 'R', 'R' }, { 'R', 'R', 'R' } };
    public char[,] green = new char[,] { { 'G', 'G', 'G' }, { 'G', 'G', 'G' }, { 'G', 'G', 'G' } };
    public char[,] orange = new char[,] { { 'O', 'O', 'O' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } };

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                white[i, j] = GameObject.Find("GameController").GetComponent<Game>().white[i, j];
                red[i, j] = GameObject.Find("GameController").GetComponent<Game>().red[i, j];
                yellow[i, j] = GameObject.Find("GameController").GetComponent<Game>().yellow[i, j];
                green[i, j] = GameObject.Find("GameController").GetComponent<Game>().green[i, j];
                orange[i, j] = GameObject.Find("GameController").GetComponent<Game>().orange[i, j];
                blue[i, j] = GameObject.Find("GameController").GetComponent<Game>().blue[i, j];
            }
        }
        Destroy(GameObject.Find("GameController"));
        GameObject.Find("CubeMap").GetComponent<Map>().mapUpdate();
    }
}

