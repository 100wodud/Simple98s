using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomData 
{
    public string name { get; set; }
    public DateTime DateTime;

    public CustomData(string _name)
    {
        name = _name;
        DateTime = DateTime.Now;
    }
}
