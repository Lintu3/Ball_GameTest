using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public Trigger_Gravity_Right _rightbool1;
    public Trigger_Gravity_Right _rightbool2;
    public Trigger_Gravity_Right _rightbool3;
    public Trigger_Gravity_Right _rightbool4;
    public Trigger_Gravity_Left _leftbool1;
    public Trigger_Gravity_Left _leftbool2;
    public Trigger_Gravity_Left _leftbool3;
    public Trigger_Gravity_Left _leftbool4;
    public Trigger_Gravity_Bottom _bottombool1;
    public Trigger_Gravity_Bottom _bottombool2;
    public Trigger_Gravity_Bottom _bottombool3;
    public Trigger_Gravity_Bottom _bottombool4;
    public Trigger_Gravity_Back _backbool1;
    public Trigger_Gravity_Back _backbool2;
    public Trigger_Gravity_Back _backbool3;
    public Trigger_Gravity_Back _backbool4;
    public Trigger_Gravity_Front _frontbool1;
    public Trigger_Gravity_Front _frontbool2;
    public Trigger_Gravity_Front _frontbool3;
    public Trigger_Gravity_Front _frontbool4;
    public Trigger_Gravity_Top _topbool1;
    public Trigger_Gravity_Top _topbool2;
    public Trigger_Gravity_Top _topbool3;
    public Trigger_Gravity_Top _topbool4;
    public bool movement_bool1;
    public bool movement_bool2;
    public bool movement_bool3;

    // Start is called before the first frame update
    void Start()
    {
        _rightbool1 = _rightbool1.GetComponent<Trigger_Gravity_Right>();
        _rightbool2 = _rightbool2.GetComponent<Trigger_Gravity_Right>();
        _rightbool3 = _rightbool3.GetComponent<Trigger_Gravity_Right>();
        _rightbool4 = _rightbool4.GetComponent<Trigger_Gravity_Right>();

        _leftbool1 = _leftbool1.GetComponent<Trigger_Gravity_Left>();
        _leftbool2 = _leftbool2.GetComponent<Trigger_Gravity_Left>();
        _leftbool3 = _leftbool3.GetComponent<Trigger_Gravity_Left>();
        _leftbool4 = _leftbool4.GetComponent<Trigger_Gravity_Left>();

        _bottombool1 = _bottombool1.GetComponent<Trigger_Gravity_Bottom>();
        _bottombool2 = _bottombool2.GetComponent<Trigger_Gravity_Bottom>();
        _bottombool3 = _bottombool3.GetComponent<Trigger_Gravity_Bottom>();
        _bottombool4 = _bottombool4.GetComponent<Trigger_Gravity_Bottom>();

        _backbool1 = _backbool1.GetComponent<Trigger_Gravity_Back>();
        _backbool2 = _backbool2.GetComponent<Trigger_Gravity_Back>();
        _backbool3 = _backbool3.GetComponent<Trigger_Gravity_Back>();
        _backbool4 = _backbool4.GetComponent<Trigger_Gravity_Back>();

        _frontbool1 = _frontbool1.GetComponent<Trigger_Gravity_Front>();
        _frontbool2 = _frontbool2.GetComponent<Trigger_Gravity_Front>();
        _frontbool3 = _frontbool3.GetComponent<Trigger_Gravity_Front>();
        _frontbool4 = _frontbool4.GetComponent<Trigger_Gravity_Front>();

        _topbool1 = _topbool1.GetComponent<Trigger_Gravity_Top>();
        _topbool2 = _topbool2.GetComponent<Trigger_Gravity_Top>();
        _topbool3 = _topbool3.GetComponent<Trigger_Gravity_Top>();
        _topbool4 = _topbool4.GetComponent<Trigger_Gravity_Top>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rightbool1._bool | _rightbool2._bool || _rightbool3._bool || _rightbool4._bool || _leftbool1._bool || _leftbool2._bool || _leftbool3._bool || _leftbool4._bool) 
        {
            _topbool1._bool = false;
            _topbool2._bool = false;
            _topbool3._bool = false;
            _topbool4._bool = false;
            _bottombool1._bool = false;
            _bottombool2._bool = false;
            _bottombool3._bool = false;
            _bottombool4._bool = false;
            _frontbool1._bool = false;
            _frontbool2._bool = false;
            _frontbool3._bool = false;
            _frontbool4._bool = false;
            _backbool1._bool = false;
            _backbool2._bool = false;
            _backbool3._bool = false;
            _backbool4._bool = false;
            movement_bool1 = true;
            movement_bool2 = false;
            movement_bool3 = false;
        }
        
        if (_topbool1._bool | _topbool2._bool || _topbool3._bool || _topbool4._bool || _bottombool1._bool || _bottombool2._bool || _bottombool3._bool || _bottombool4._bool) 
        {
            _rightbool1._bool = false;
            _rightbool2._bool = false;
            _rightbool3._bool = false;
            _rightbool4._bool = false;
            _leftbool1._bool = false;
            _leftbool2._bool = false;
            _leftbool3._bool = false;
            _leftbool4._bool = false;
            _frontbool1._bool = false;
            _frontbool2._bool = false;
            _frontbool3._bool = false;
            _frontbool4._bool = false;
            _backbool1._bool = false;
            _backbool2._bool = false;
            _backbool3._bool = false;
            _backbool4._bool = false;

            movement_bool1 = false;
            movement_bool2 = true;
            movement_bool3 = false;
        }
        
        if (_frontbool1._bool | _frontbool2._bool || _frontbool3._bool || _frontbool4._bool || _backbool1._bool || _backbool2._bool || _backbool3._bool || _backbool4._bool) 
        {
            _rightbool1._bool = false;
            _rightbool2._bool = false;
            _rightbool3._bool = false;
            _rightbool4._bool = false;
            _leftbool1._bool = false;
            _leftbool2._bool = false;
            _leftbool3._bool = false;
            _leftbool4._bool = false;
            _topbool1._bool = false;
            _topbool2._bool = false;
            _topbool3._bool = false;
            _topbool4._bool = false;
            _bottombool1._bool = false;
            _bottombool2._bool = false;
            _bottombool3._bool = false;
            _bottombool4._bool = false;

            movement_bool1 = false;
            movement_bool2 = false;
            movement_bool3 = true;
        }
    }
}
