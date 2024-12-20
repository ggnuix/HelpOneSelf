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
                //��̬��������
                GameObject obj = new GameObject();
                //�޸Ķ�������Ϊ����
                obj.name = typeof(T).ToString(); ;
                //��̬���ؽű�
                instance =  obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

   
}
