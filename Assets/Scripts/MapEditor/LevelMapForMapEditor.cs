using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LevelMapForMapEditor : MonoBehaviour
    {
        [SerializeField] private GameObject _wallblock;

        [SerializeField] public Camera _camera;
        
        [SerializeField] private List<Vector3> _borders;
        [SerializeField] private Transform _root;
        
        [SerializeField] private MapEditorUI _buttons;

        [SerializeField] private TerrainForMap _map1;
        [SerializeField] private TerrainForMap _map2;
        [SerializeField] private TerrainForMap _map3;

        private Vector3 _cubeSpawnPos;
        private GameObject _prefab;
        public List<Vector3> TerrainMap;
        
        public void Start()
        {
            _buttons.SaveMap1Event += () =>
            {
                CopyToSO(_map1.WallPoints,TerrainMap);
            };
            
            _buttons.SaveMap2Event += () =>
            {
                CopyToSO(_map2.WallPoints,TerrainMap);
            };
            
            _buttons.SaveMap3Event += () =>
            {
                CopyToSO(_map3.WallPoints,TerrainMap);
            };
            
            _buttons.ClearEditorEvent += () =>
            {
                foreach (Transform child in _root) 
                {
                    Destroy(child.gameObject);
                }
                TerrainMap.Clear();
            };
        }

        private void Update()
        {
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    var _xCoordinate = Mathf.Round(hit.point.x);
                    var _zCoordinate = Mathf.Round(hit.point.z);
                    _cubeSpawnPos = new Vector3(_xCoordinate, 1, _zCoordinate);
                    var prefab = Instantiate(_wallblock, _cubeSpawnPos, Quaternion.identity,_root);
                    WriteEditorMap(_cubeSpawnPos);
                }
            }
        }

        private void WriteEditorMap(Vector3 pos)
        {
            TerrainMap.Add(pos);
        }
        

        public void CopyToSO(List<Vector3> MapToSave,List<Vector3> MapInEditor)
        {
            MapToSave.Clear();
            MapToSave.AddRange(MapInEditor);
            MapToSave.AddRange(_borders);
        }
        
    }
}
