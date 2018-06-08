using UnityEngine;

public class PongPlayer : MonoBehaviour
{

    private float increment = 0.1f;
    private GameObject playerD;
    private GameObject playerG;
    private float mouseSpeed = 10.0f;
    private bool useMouse = false;

    // Use this for initialization
    void Start()
    {
        playerD = GameObject.Find("playerD");
        playerG = GameObject.Find("playerG");
    }

    // Update is called once per frame
    void Update()
    {

        // On ARROWS
        Vector3 pD = playerD.transform.position;
        Vector3 pG = playerG.transform.position;
        increment = increment + 0;
        if (pD.y < 3.3f)
            if (Input.GetKey(KeyCode.UpArrow)) { playerD.transform.Translate(0, increment, 0); }
        if (pD.y > -3.3f)
            if (Input.GetKey(KeyCode.DownArrow)) { playerD.transform.Translate(0, -increment, 0); }

        if (pG.y < 3.3f)
            if (Input.GetKey(KeyCode.W)) { playerG.transform.Translate(0, increment, 0); }
        if (pG.y > -3.3f)
            if (Input.GetKey(KeyCode.S)) { playerG.transform.Translate(0, -increment, 0); }
        //End On Arrows ################


        //On MOUSE
        if (Input.GetMouseButtonDown(0))
        {
            useMouse = true;
            ResetPlayers();
        }
        if (Input.GetMouseButtonUp(0))
        {
            useMouse = false;
            ResetPlayers();
        }
        if (useMouse == true)
        {
            playerD.transform.Translate(0, Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime, 0);
            playerG.transform.Translate(0, Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime, 0);
            playerD.transform.position = new Vector3(playerD.transform.position.x, Mathf.Clamp(playerD.transform.position.y, -3.3f, 3.3f), playerD.transform.position.z);
            playerG.transform.position = new Vector3(playerG.transform.position.x, Mathf.Clamp(playerG.transform.position.y, -3.3f, 3.3f), playerG.transform.position.z);
        }
        //End OnMouse ####################


    }//End Update ########################


    private void ResetPlayers()
    {
        playerD.transform.position = new Vector3(playerD.transform.position.x, 0, playerD.transform.position.z);
        playerG.transform.position = new Vector3(playerG.transform.position.x, 0, playerG.transform.position.z);
    }
}
