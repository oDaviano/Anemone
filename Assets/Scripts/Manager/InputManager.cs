using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerClassBase<InputManager>
{
    [SerializeField] private InputMode _InputMode = InputMode.GameOnly;
  //  [SerializeField] private bool _CursorVisibility = false;


    public override void InitializeManagerClass() {    }
    
    
    
}
