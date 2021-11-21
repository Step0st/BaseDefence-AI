using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class ZombieSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _zombie;
        [SerializeField] private Transform _parent;
        private int _repeatTime;
        private int _spawningTime;
        private GameObject _clone;
        
        private void Start()
        {
            StartCoroutine(RandomSpawn());
        }
        
        IEnumerator RandomSpawn()
        {
            while (true)
            {
                _repeatTime = Random.Range(8, 15);
                _spawningTime = Random.Range(1, 4);
                yield return new WaitForSeconds(_spawningTime);
                _clone = Instantiate(_zombie, this.transform.position, Quaternion.identity,_parent);
                _clone.SetActive(true);
                yield return new WaitForSeconds(_repeatTime);
                _clone.SetActive(false);
            }
        }
    }
}