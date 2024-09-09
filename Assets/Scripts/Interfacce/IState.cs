using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public int Id { get; }
    public object GetValue();
}
