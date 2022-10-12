using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration = 2f;
    
    [SerializeField]
    private float _delay = 2f;
    
    private UnityEngine.Color _startColor;
    private UnityEngine.Color _nextColor;
    private Renderer _renderer;

    private float _currentTime;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }
    
    void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = _currentTime / _recoloringDuration;
        var currentColor = UnityEngine.Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
        
        if (progress >= _delay)
        {
            _currentTime = 0f;
            GenerateNextColor();
        }
    }
}
