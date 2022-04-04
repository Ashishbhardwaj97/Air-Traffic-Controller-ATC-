using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementFixMaxMinRot : MonoBehaviour
{
    #region Private References      
    [SerializeField, Range(0.0f, 1.0f)]
    private float _lerpRate;
    private float _xRotation;
    private float _yYRotation;
    #endregion

    float val;
    public float minRotation = -10f;
    public float maxRotation = 10f;
    
    #region Private Methods
    private void Rotate(float xMovement, float yMovement)
    {
        _xRotation += xMovement;
        _yYRotation += yMovement;
    }
    #endregion


    #region Unity CallBacks
    void Start()
    {
        InputManager.MouseMoved += Rotate;
    }

    void Update()
    {
        _xRotation = Mathf.Lerp(_xRotation, 0, _lerpRate);
        _yYRotation = Mathf.Lerp(_yYRotation, 0, _lerpRate);

        transform.eulerAngles += new Vector3(-_yYRotation, _xRotation, 0);

        if (_yYRotation < 0 && transform.eulerAngles.x > maxRotation && transform.eulerAngles.x < 270)
        {
            transform.eulerAngles = new Vector3(maxRotation - 0.001f, transform.eulerAngles.y, 0);
        }
        else if (_yYRotation > 0 && (transform.eulerAngles.x - 360) <= minRotation && (transform.eulerAngles.x - 360) > -300)
        {

            transform.eulerAngles = new Vector3(minRotation + 0.001f, transform.eulerAngles.y, 0);
        }
    }

    void OnDestroy()
    {
        InputManager.MouseMoved -= Rotate;
    }
    #endregion
}
