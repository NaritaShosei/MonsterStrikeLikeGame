using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public  class PlayerBase : MonoBehaviour
{
    [SerializeField] CharacterMode _characterMode;
    [SerializeField] float _power;
    [SerializeField] float _maxPower;
    Rigidbody2D _rb2d;
    Vector2 _startPos;
    Vector2 _endPos;
    enum CharacterMode
    {
        reflection, //”½ŽË
        penetration //ŠÑ’Ê
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }
    void Flick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
        }
        if (Input.GetMouseButtonUp(0))
        {
            _endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = Vector2.ClampMagnitude((_startPos - _endPos), _maxPower);
            _rb2d.AddForce(force * _power, ForceMode2D.Impulse);
        }
    }
}