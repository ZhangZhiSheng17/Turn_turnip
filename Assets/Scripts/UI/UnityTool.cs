
    using System.Collections.Generic;
    using UnityEngine;

    public static class UnityTool
    {
        public static GameObject Game(string name)
        {
            GameObject obj = null;
            if (name!=null)
            {
                obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
                if (obj==null)
                {
                    return null;
                }
            }
            return obj;
        }
        
        public static GameObject FindGameObject(string GameObjectName)
        {
            GameObject pTmpGameObj = GameObject.Find(GameObjectName);
            if(pTmpGameObj==null)
            {
                Debug.LogWarning("场景中不存在");
                return null;
            }
            return pTmpGameObj;
        }

        public static List<GameObject> FindChildGameObject(GameObject map)
        {
            List<GameObject> m_listmap=new List<GameObject>();
            Transform[] father = map.GetComponentsInChildren<Transform>();
            foreach (var item in father)
            {
                m_listmap.Add(item.gameObject);
            }

            return m_listmap;
        }
        public static GameObject FindChildGameObject(GameObject Container, string gameobjectName)
        {
            if (Container == null)
            {
              Debug.Log("木有为空");
                return null;
            }
            Transform pGameObjectTF=null;
            if (Container.name == gameobjectName)
            {
                pGameObjectTF=Container.transform;
            }
            else
            {
                Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)			
                {            
                    if (child.name == gameobjectName)
                    {
                        if (pGameObjectTF == null)
                        {
                            pGameObjectTF=child;
                        }
                    }
                }
            }
            if(pGameObjectTF==null)			
            {
               Debug.Log("找不到");
                return null;
            }
		
            return pGameObjectTF.gameObject;			
        }
    }
