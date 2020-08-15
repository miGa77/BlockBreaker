using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // configuration parameters
    [SerializeField] float screenWidthUWU = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    // cached references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            float ballPosInUnitsX = theBall.transform.position.x;
            return ballPosInUnitsX;
        }
        else
        {
            float mousePosInUnitsX = Input.mousePosition.x / Screen.width * screenWidthUWU;
            return mousePosInUnitsX;
        }
    }
}
