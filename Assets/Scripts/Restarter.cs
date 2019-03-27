using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public KeyCode[] keys;
    public static Restarter me;

    private void Awake()
    {
        if(me != null)
        {
            Destroy(gameObject);
        }
        me = this;
        DontDestroyOnLoad(gameObject);  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool re = false;
        for(int i= 0; i < keys.Length; i ++)
        {
            if(Input.GetKeyDown(keys[i]))
            {
                re = true;
            }
        }
        if (re)
            SceneManager.LoadScene(0);

        if(SceneManager.GetActiveScene().buildIndex > 1 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }
}
