using UnityEditor;
using UnityEngine;

namespace MarchingSquaresDemo
{

    [CustomEditor(typeof(LevelGenerator))]
    public class LevelGeneratorInspector : Editor
    {

        #region Fields

        private LevelGenerator _levelGenerator;

        #endregion

        #region Events

        private void OnEnable()
        {

            _levelGenerator = (LevelGenerator) target;

        }

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            
            if(GUILayout.Button("Generate level"))
            {

                _levelGenerator.GenerateLevel();

            };

        }

        #endregion

    }

}