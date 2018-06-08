using UnityEngine;
using System.Collections;

public static class ExtensionMethod
{
    public static Object CreateNewPlayer(this Object thisObj, Object original, string name, float move, float jump)
    {
        GameObject go = Object.Instantiate(original) as GameObject;
        go.GetComponent<PlayerScript>().jumpPower  = jump;
        go.GetComponent<PlayerScript>().movePower  = move;
        go.GetComponent<PlayerScript>().playerName = name;

        return go;
    }
}
