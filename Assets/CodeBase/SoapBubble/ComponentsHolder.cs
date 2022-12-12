﻿using UnityEngine;

namespace CodeBase.SoapBubble
{
    public class ComponentsHolder
    {
        public GameObject GameObject;
        public Transform Transform;
        public float Speed;
        public float Radius;


        public ComponentsHolder(Bubble bubble)
        {
            GameObject = bubble.gameObject;
            Transform = bubble.transform;
        }
    }
}