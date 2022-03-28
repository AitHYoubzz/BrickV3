using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GénérerBricks : MonoBehaviour
{   float positionX = -12;
    float positionY = 5;
    public GameObject brickPrefab;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j< 8; j++)
            {
                Instantiate(brickPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
                positionX += 3.25f;
            }
            positionY -= 0.85f;
            positionX = -12;
        }
    }

}
