using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class EditorWindowCloser
    {
        static EditorWindowCloser()
        {
            EditorApplicationInternal.globalEventHandler += GlobalEvent;
        }

        private static void GlobalEvent()
        {
            var current = Event.current;
            var keyCode = current.keyCode;

            if ( keyCode != KeyCode.Escape ) return;

            var focusedWindow = EditorWindow.focusedWindow;

            if ( focusedWindow == null ) return;
            if ( focusedWindow.docked ) return;

            focusedWindow.Close();
        }
    }
}