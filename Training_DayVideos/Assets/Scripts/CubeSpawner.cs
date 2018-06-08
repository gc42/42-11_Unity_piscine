using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeSpawner : MonoBehaviour
{
    public float minDelay;
    public float maxDelay;
    private float playTime = 0;
    public static float MidPrecision = 0;
    public static int counter = 0;

    public List<GameObject> cubes = new List<GameObject>(3);
    //private GameObject          cube;


    // Update is called once per frame
    void Update()
    {
        float delay = Random.Range(minDelay, maxDelay);
        int randomNumber = Random.Range(0, 3);
        string cubeTag = "";


        switch (randomNumber)
        {
            case 0:
                cubeTag = "a(Clone)"; break;
            case 1:
                cubeTag = "s(Clone)"; break;
            case 2:
                cubeTag = "d(Clone)"; break;
        }



        playTime += Time.deltaTime;
        if (playTime > delay)
        {
            //if (GameObject.FindGameObjectWithTag(cubeTag) == false)
            if (GameObject.Find(cubeTag) == null)
            {
                NewCube(cubes[randomNumber], randomNumber);
                playTime = 0;
            }
        }
    }


    private void NewCube(GameObject cubeType, int randomNumber)
    {
        float x = 0.0f;

        switch (randomNumber)
        {
            case 0:
                x = -3.0f; break;
            case 1:
                x = 0.0f; break;
            case 2:
                x = 3.0f; break;
        }
        Vector3 position = new Vector3(x, 7.56f, 0);
        Instantiate(cubeType, position, Quaternion.identity);

        //return myClone;
    }



}
