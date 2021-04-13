using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfiguration", menuName = "AIV/Sound")]
[ShowOdinSerializedPropertiesInInspector]
public class SoundSettingsData : ScriptableObject, ISerializationCallbackReceiver
{

    public Dictionary<string, float> SoundTable = new Dictionary<string, float>();

    [SerializeField, HideInInspector]
    private SerializationData serializationData;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        UnitySerializationUtility.DeserializeUnityObject(this, ref this.serializationData);
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        UnitySerializationUtility.SerializeUnityObject(this, ref this.serializationData);
    }
}
