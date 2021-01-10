using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(fileName = "FactoryInstance", menuName = "ScriptableObjects/FactoryConfig", order = 1)]
    public class FactoryConfig : ScriptableObject
    {
        protected static FactoryConfig instance;
        public void OnEnable()
        {
            if (instance != default)
                Debug.Log("Possible Multple FactoryCofigs found");
            else
                instance = this;
        }
        public static FactoryConfig Instance => instance;

        [SerializeField] protected BaseCoreFactory coreFactory;
        public static ICoreFactory CoreFactory => Instance.coreFactory;
    }
}
