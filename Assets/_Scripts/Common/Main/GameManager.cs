using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame.Events;
namespace CommonGame
{
    [DefaultExecutionOrder(-10)]
    public class GameManager : MonoBehaviour
    {
       
        public LevelLoadChannelSO _loadChannel;
        private void Start()
        {
            _loadChannel.RaiseLoadLast();

        }
    }



}




public class SingletonMB<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<T>();
            return instance;
        }
        set
        {
            instance = value;
        }
    }



}
