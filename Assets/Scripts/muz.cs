using UnityEngine;
using System.Collections;

public class muz : MonoBehaviour
{
    public GameObject lvlsound;

    // Use this for initialization
    void Start()
    {
        var lvlsoundGO = GameObject.Find("lvlsound");
        if (lvlsoundGO == null)
        {
            lvlsoundGO = Instantiate(lvlsound);
            lvlsoundGO.name = "lvlsound";
        }
        DontDestroyOnLoad(lvlsoundGO);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
