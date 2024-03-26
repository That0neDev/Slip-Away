using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Player Cutomization/Body")]
public class CustomizableBody : ScriptableObject
{
    public Sprite body;
}

[CreateAssetMenu(menuName = "Custom/Player Cutomization/Trail")]
public class CustomizableTrail : ScriptableObject
{
    [System.Serializable] public class SerializableTrail
    {
        public Material trailMaterial;
        public float time;
        public Color color;
    } 

    public SerializableTrail data;
}

[CreateAssetMenu(menuName = "Custom/Player Cutomization/Death Effect")]
public class CustomizableDeath : ScriptableObject
{
    [System.Serializable] public class SerializableParticles
    {
        [Header("General")]
        public float duration;
    }
    public Sprite body;
}