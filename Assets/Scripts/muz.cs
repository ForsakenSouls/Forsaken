using UnityEngine;
using System.Collections;

public class muz : MonoBehaviour
{
    public GameObject lvlsound;
    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevel == 0 && !GameState.music)
            Destroy(transform.gameObject);
        GameState.music = false;
        DontDestroyOnLoad(transform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
