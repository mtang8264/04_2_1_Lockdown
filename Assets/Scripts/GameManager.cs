using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro response;

    public Node currentNode;
    public int currentLine;
    public int currentChar;
    public bool doneLine;
    public bool doneNode;
    public int selection;

    [Header("Insidental")]
    public SpriteRenderer bg;
    public Animator bgAnim;
    public Animator rbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool boxin = false;
        response.text = null;
        if(!doneLine)
        {
            currentChar++;
            if(currentChar == currentNode.lines[currentLine].Length)
            {
                doneLine = true;
            }
        }
        else
        {
            SoundManager.me.StopClick();
            currentChar = currentNode.lines[currentLine].Length;
            if(doneNode)
            {
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    selection++;
                }
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    selection--;
                }
                if(selection < 0)
                {
                    selection = currentNode.responses.Length - 1;
                }
                if(selection >= currentNode.responses.Length)
                {
                    selection = 0;
                }

                string temp = "";
                Debug.Log("box in");
                for (int i = 0; i < currentNode.responses.Length; i ++)
                {
                    if(selection == i)
                    {
                        temp += "<color=#ffffff>*";
                    }
                    else
                    {
                        temp += "<color=#aaaaaa>•";
                    }
                    temp += currentNode.responses[i].line + "</color>" + '\n';
                }
                response.text = temp;
                boxin = temp != "" ? true : false;
            }
        }

        text.text = currentNode.lines[currentLine].Substring(0, currentChar);

        if(Input.GetKeyDown(KeyCode.Return) && rbox.GetCurrentAnimatorStateInfo(0).IsName("Enter") == false)
        {
            Next();
        }

        if (currentNode.lines.Length == currentLine + 1)
        {
            doneNode = true;
        }

        rbox.SetBool("In", boxin);
    }

    private void Next()
    {
        if(!doneLine)
        {
            doneLine = true;
        }
        else if(doneLine && !doneNode)
        {
            currentLine++;
            currentChar = 0;
            doneLine = false;
        }
        else if(doneLine && doneNode)
        {
            currentLine = 0;
            currentChar = 0;
            doneLine = false;
            doneNode = false;
            if (currentNode.overrideNode != null)
            {
                currentNode = currentNode.overrideNode;
            }
            else
            {
                currentNode = currentNode.responses[selection].result;
            }
            Command(currentNode.command);
        }
    }

    private void Command(string c)
    {
        if(c == "wake")
        {
            bgAnim.Play("FadeIn");
            SoundManager.me.music.Play();
        }
        else if (c == "Fail")
        {
            bgAnim.Play("FadeOut");
            SoundManager.me.music.Stop();
        }
    }
}
