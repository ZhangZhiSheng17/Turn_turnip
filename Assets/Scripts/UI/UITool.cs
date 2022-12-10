using UnityEngine;
using UnityEngine.UI;

public static class UITool
{
    private static GameObject m_CanvasObj = null;

    public static void ReleaseCavas()
    {
        m_CanvasObj = null;
    }

    public static GameObject FindUIGameObject(string UIName)
    {
        if (m_CanvasObj==null)
        {
            m_CanvasObj = UnityTool.FindGameObject("Canvas");
        }

        if (m_CanvasObj==null)
        {
            return null;
        }

        return UnityTool.FindChildGameObject(m_CanvasObj, UIName);
    }
    
    
    public static T GetUIComponent<T>(GameObject Container,string UIName) where T : UnityEngine.Component
    {
        GameObject ChildGameObject = UnityTool.FindChildGameObject( Container, UIName);
        if (ChildGameObject == null)
        {
            return null;   
        }
        T tempObj = ChildGameObject.GetComponent<T>();
        if( tempObj == null)
        {
            return null;
        }
        return tempObj;
    }
	
    public static Button GetButton(string BtnName)
    {
        GameObject UIRoot = GameObject.Find("Canvas");
        if(UIRoot==null)
        {
            return null;
        }
        Transform[] allChildren = UIRoot.GetComponentsInChildren<Transform>();
        foreach(Transform child in allChildren)
        {
            if( child.name == BtnName ) 
            {
                Button tmpBtn = child.gameObject.GetComponent<Button>();
                return tmpBtn;
            }	
        }
        
        return null;
    }
    
    public static T GetUIComponent<T>(string UIName) where T : UnityEngine.Component
    {
        GameObject UIRoot = GameObject.Find("Canvas");
        if(UIRoot==null)
        {
            return null;
        }
        return GetUIComponent<T>( UIRoot,UIName); 
    }
    
}