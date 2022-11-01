using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Transform _spawner;
    [SerializeField] private View _view;

    private float _cooldown = .5f;
    private float _speed = 10f;
    private float _distance = 20f;

    private List<Cube> _cubes = new List<Cube>(100);
    private Coroutine _coroutine;

    private void Start()
    {
        _view.Init(this);
        
        for (int i = 0; i < 50; i++)
        {
            SpawnCube();
        }

        _coroutine = StartCoroutine(SpawnerCo());
    }

    Cube SpawnCube()
    {
        Cube cube = Instantiate(_prefabCube, _spawner);
        _cubes.Add(cube);
        return cube;
    }

    IEnumerator SpawnerCo()
    {
        float time = 0;
        
        while (true)
        {
            time += Time.deltaTime;
            if (time >= _cooldown)
            {
                Cube cube = _cubes.FirstOrDefault(c => !c.isActiveAndEnabled);
                if (cube == null)
                {
                   cube = SpawnCube();
                }

                cube.transform.position = _spawner.position;
                cube.gameObject.SetActive(true);
                cube.SetParam(_speed, _distance, _spawner.position);
                time = 0;
            }

            yield return null;
        }
    }

    void UpdateParamCubes()
    {
        foreach (Cube cube in _cubes)
        {
            if (cube.gameObject.activeInHierarchy)
            {
                cube.UpdateParam(_speed, _distance);
            }
        }
    }
    
    public void SetSpeed(float speed)
    {
        _speed = speed;
        UpdateParamCubes();
    }
    
    public void SetDistance(float distance)
    {
        _distance = distance;
        UpdateParamCubes();
    }
    
    public void SetCooldown(float cooldown)
    {
        _cooldown = cooldown;
    }
    
    private void OnDestroy()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);
    }
}
