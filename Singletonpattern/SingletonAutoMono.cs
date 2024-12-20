using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAutoMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //动态创建对象
                GameObject obj = new GameObject();
                //修改对象名字为类名
                obj.name = typeof(T).ToString(); ;
                //动态挂载脚本
                instance =  obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

   
}
