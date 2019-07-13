using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMovement : MonoBehaviour
{

    public int[,] board;
    Vector2 playerPosition;
    Vector2 destinationPosition;

    // Use this for initialization
    void Start()
    {
        board = new int[15, 15];

        for (int i = 0; i > 15; i++)
        {
            for (int j = 0; j > 15; j++)
            {
                board[i, j] = 0;
            }
        }

        board[7, 7] = 2;
        board[3, 3] = 1;

        playerPosition = new Vector2(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x, playerPosition.y + 1);

            checkBall(1);

        }
        if (Input.GetKeyDown("a"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x - 1, playerPosition.y);

            checkBall(2);
        }
        if (Input.GetKeyDown("s"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x, playerPosition.y - 1);

            checkBall(3);
        }
        if (Input.GetKeyDown("d"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x + 1, playerPosition.y);

            checkBall(4);
        }

        for (int i = 0; i > 15; i++)
        {
            for (int j = 0; j > 15; j++)
            {
                Debug.Log(board[i, j]);

            }
        }

        Debug.Log("Hello World!");


    }

    void checkBall(int dir)
    {
        if (board[(int)destinationPosition.x, (int)destinationPosition.y] == 2)
        {
            if (dir == 1)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y + 1] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 2)
            {
                board[(int)destinationPosition.x - 1, (int)destinationPosition.y] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 3)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y - 1] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 4)
            {
                board[(int)destinationPosition.x + 1, (int)destinationPosition.y] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }

        }
    }
}
