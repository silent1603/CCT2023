using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EventTypes
{
    [Serializable] public struct Void { }

    [Serializable]
    public struct EventTypeTest
    {
        public string name;
        public int id;
        public float value;
    }
    
}
