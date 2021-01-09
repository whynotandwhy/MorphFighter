using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    [CreateAssetMenu(fileName = "FactoryInstance", menuName = "ScriptableObjects/FactoryConfig", order = 1)]
    public class FactoryConfig : ScriptableObject
    {
        protected FactoryConfig instance;
        public void Awake()
        {
            if (instance != default)
                Debug.Log("Possible Multple FactoryCofigs found" + AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this)));
            else
                instance = this;
        }
        public static FactoryConfig Instance => Instance;

        [SerializeField] protected BaseCoreFactory coreFactory;
        public static ICoreFactory CoreFactory => Instance.coreFactory;
    }
}
