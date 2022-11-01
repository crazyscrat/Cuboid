using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _distance;
    private float _speed;
    private Vector3 _startPos;

    private Transform _transform;

    public void SetParam(float speed, float distance, Vector3 startPos)
    {
        _startPos = startPos;
        _speed = speed;
        _distance = distance;
        _transform = transform;

        StartCoroutine(MovingCo());
    }

    public void UpdateParam(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }
    
    IEnumerator MovingCo()
    {
        while (_transform.position.z - _startPos.z < _distance)
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
