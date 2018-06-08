using UnityEngine;
using UnityEngine.UI;

public class PongBall : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private GameObject playerD;
    private GameObject playerG;
    private Text TextD;
    private Text TextG;
    private int scoreD;
    private int scoreG;
    private bool isOut = false;
    private bool scoreUpdated = false;
    private bool gameOver = false;

    private enum PongDirection
    {
        NW, NE, SW, SE
    }; private PongDirection pongDir;

    // Properties
    public int ScoreG { get; set; }
    public int ScoreD { get; set; }



    // Use this for initialization
    void Start()
    {
        speed = 5.0f;
        ScoreD = 0;
        ScoreG = 0;
        pongDir = (PongBall.PongDirection)UnityEngine.Random.Range(0, 4);
        playerD = GameObject.Find("playerD");
        playerG = GameObject.Find("playerG");
        TextD = GameObject.Find("Canvas/TextD").GetComponent<Text>();
        TextG = GameObject.Find("Canvas/TextG").GetComponent<Text>();
        TextD.text = "Player D";
        TextG.text = "Player G";
        Debug.Log("Click and Drag to use your Mouse (one Player). Else, use W/S keys (left Player) and Up/Down arrows (right Player)");
    }

    // Update is called once per frame
    void Update()
    {

        // Pong velocity
        transform.Translate(direction * speed * Time.deltaTime);

        // Define Pong Directions
        if (pongDir == PongDirection.NE) { direction = new Vector3(1, 1, 0); }
        if (pongDir == PongDirection.NW) { direction = new Vector3(-1, 1, 0); }
        if (pongDir == PongDirection.SE) { direction = new Vector3(1, -1, 0); }
        if (pongDir == PongDirection.SW) { direction = new Vector3(-1, -1, 0); }


        // Flip direction ###############################
        Vector3 p = transform.position;
        Vector3 pD = playerD.transform.position;
        Vector3 pG = playerG.transform.position;

        if (p.y > 4.25f)
        {
            if (pongDir == PongDirection.NW)
                ChangePongDirection(PongDirection.SW);
            if (pongDir == PongDirection.NE)
                ChangePongDirection(PongDirection.SE);
        }
        if (p.y < -4.25f)
        {
            if (pongDir == PongDirection.SW)
                ChangePongDirection(PongDirection.NW);
            if (pongDir == PongDirection.SE)
                ChangePongDirection(PongDirection.NE);
        }
        if ((p.x > 7.5f && p.x < 8.2f) && (p.y < pD.y + 1.1f && p.y > pD.y - 1.1f))
        {
            if (pongDir == PongDirection.NE)
                ChangePongDirection(PongDirection.NW);
            if (pongDir == PongDirection.SE)
                ChangePongDirection(PongDirection.SW);
        }
        if ((p.x < -7.5f && p.x > -8.2f) && (p.y < pG.y + 1.1f && p.y > pG.y - 1.1f))
        {
            if (pongDir == PongDirection.NW)
                ChangePongDirection(PongDirection.NE);
            if (pongDir == PongDirection.SW)
                ChangePongDirection(PongDirection.SE);
        }
        //End Flip direction ###############################


        // Change color
        if (p.x < -8.25f || 8.25f < p.x)
            GetComponent<SpriteRenderer>().color = Color.red;
        else
            GetComponent<SpriteRenderer>().color = Color.white;


        // Out of terrain
        if (p.x < -9.2f || 9.2f < p.x)
            isOut = true;

        if (isOut == true && scoreUpdated == false)
        {
            // Score
            if (p.x < 0)
            {
                ScoreD++;
                scoreUpdated = true;
            }
            else
            {
                ScoreG++;
                scoreUpdated = true;
            }
            DisplayScore();

            if (ScoreD >= 5 || ScoreG >= 5)
            {
                Debug.Log("PlayerG: " + ScoreG + " ; PlayerD: " + ScoreD + " ; ---> Une nouvelle partie ? (space)");
                gameOver = true;
            }
            else
            {
                Debug.Log("PlayerG: " + ScoreG + " ; PlayerD: " + ScoreD + " ; ---> La partie continue");
            }
        }

        if (isOut == true)
        {
            ReinitForNextSet();
        }

        if (gameOver == true)
        {
            Time.timeScale = 0.0f;

            if (Input.GetKey(KeyCode.Space))
            {
                ReinitForNextMatch();
            }
        }

        // Increment / Decrement PongBall speed
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            speed = speed + 0.2f;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (speed > 5)
            {
				speed = speed - 0.2f;
            }
        }



    }//EndUpdate

    private void ChangePongDirection(PongDirection _direction)
    {
        pongDir = _direction;
    }

    private void ReinitForNextSet()
    {
        pongDir = (PongBall.PongDirection)UnityEngine.Random.Range(0, 4);
        transform.position = Vector3.zero;
        scoreUpdated = false;
        isOut = false;
    }

    private void ReinitForNextMatch()
    {
        // Reinit for an other match
        Time.timeScale = 1.0f;
        Debug.Log("Partie en cours...");
        ScoreD = 0;
        ScoreG = 0;
        gameOver = false;
        DisplayScore();
    }

    private void DisplayScore()
    {
        TextD.text = ScoreD.ToString();
        TextG.text = ScoreG.ToString();
    }
}
