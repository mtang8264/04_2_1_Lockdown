using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hungry && GameManager.meanToGuard)
        {
            text.text = "You were rude to the guard and never managed to eat. You may have one a moral victory against your captures but you died like a mouse trapped in a wall.";
        }
        else if (GameManager.hungry && !GameManager.meanToGuard)
        {
            text.text = "The guard, Hans, was on your side. Unfortunately, that wasn't enought. He tried to get your trial pushed up but you didn't survive on an empty stomach.";
        }
        else if (GameManager.meanToGuard && !GameManager.hungry)
        {
            text.text = "Despite your conditions, you managed to stay relatively healthy. Unfortunately, you were rude towards Hans and it seemed like your paper work just \"Kept disappearing.\" You didn't make it to trial.";
        }
        else
        {
            text.text = "You were healthy enough, and Hans was on your side. You made it with high hopes to your trial. Despite this, you never knew what you were charged for. You had no defense. You were sentanced to death.";
        }
    }
}
