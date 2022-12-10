using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMager : MonoBehaviour
{
    SceneStateController m_SceneStateController=new SceneStateController();

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
        UnityEngine.Random.seed = (int) DateTime.Now.Ticks;
    }

    // Start is called before the first frame update
    void Start()
    {
     m_SceneStateController.SetState(new StartState(m_SceneStateController),""); 
    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateController.StateUpdate();
    }
}
