using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dictional : MonoBehaviour
{
    void TestDictionary()
    {
        var students = new Dictionary<int, StudenetName>()
        {
            { 111,new StudenetName{FirstName="Sachin",LastName="Karnik",ID=211} },
            { 112,new StudenetName{FirstName="Dina",LastName="Salimzianova",ID=317} },
            { 113,new StudenetName{FirstName="Andy",LastName="Ruth",ID=198} }
        };

        foreach( var index in Enumerable.Range(111,3))
        {
            Debug.Log($"Student {index}is{students[index].FirstName} {students[index].FirstName}");
        }
    }
    private void Start()
    {
        TestDictionary();
    }

    class StudenetName
    { 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ID { get; set; }
    }

    
}
