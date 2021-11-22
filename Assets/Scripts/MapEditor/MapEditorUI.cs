using System;
using UnityEngine;

namespace Game
{
    public class MapEditorUI : MonoBehaviour
    {
        public Action SaveMap1Event;
        public Action SaveMap2Event;
        public Action SaveMap3Event;
        public Action ClearEditorEvent;
        
        
        public void SaveMap1()
        {
            SaveMap1Event?.Invoke();
        }
        
        public void SaveMap2()
        {
            SaveMap2Event?.Invoke();
        }
        
        public void SaveMap3()
        {
            SaveMap3Event?.Invoke();
        }
        
        public void ClearEditor()
        {
            ClearEditorEvent?.Invoke();
        }
    }
}