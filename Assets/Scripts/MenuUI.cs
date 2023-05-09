using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
   //private GameObject persistenceManager;
    // Start is called before the first frame update
    void Start()
    {
        //persistenceManager = GameObject.Find("PersistenceManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PersistenceManager.Instance.SavePlayerName();
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
