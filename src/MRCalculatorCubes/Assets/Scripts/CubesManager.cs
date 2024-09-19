using System;
using System.Collections.Generic;
using UnityEngine;

public class CubesManager : MonoBehaviour
{

    private GameObject _cubesPrefab;
    private List<GameObject> _cubes = new List<GameObject>();
    private GameObject _cube;

    private void Start()
    {
        _cubesPrefab = Resources.Load<GameObject>("Prefabs/Cube");
    }

    public void SpawnCubes(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (_cubes.Count >= 30)
            {
                return;
            }
            _cube = Instantiate(_cubesPrefab, transform.position, Quaternion.identity);
            _cubes.Add(_cube);
        }
    }

    public void ClearCubes()
    {
        for(int i = 0; i < _cubes.Count; i++)
            Destroy(_cubes[i]);
        _cubes.Clear();
    }
}
