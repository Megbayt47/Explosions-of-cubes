﻿using UnityEngine;

public class Detector : MonoBehaviour
{
    private Camera _camera;
    private int _keyLeftMouseButton = 0;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_keyLeftMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    cube.TryExplode();
                }
            }
        }
    }
}