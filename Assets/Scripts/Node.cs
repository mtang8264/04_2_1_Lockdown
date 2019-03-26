using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Node : ScriptableObject
{
    public string command;
    public string[] lines;
    public Response[] responses;
    public Node overrideNode;
}

[System.Serializable]
public struct Response
{
    public string line;
    public Node result;
}
