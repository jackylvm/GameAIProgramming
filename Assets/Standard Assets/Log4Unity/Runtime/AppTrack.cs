using System;
using UnityEditor;
using UnityEngine;

namespace MS.Log4Unity
{
    public class AppTrack
    {
        public static event Action<AppEvent> handleAppEvent;

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        private static void OnEditorLaunch()
        {
            EditorApplication.playModeStateChanged += (state) =>
            {
                if (state == PlayModeStateChange.ExitingEditMode)
                {
                    var appEvent = new AppEvent()
                    {
                        eventType = AppEventType.ExitingEditMode,
                    };
                    DispatchAppEvent(appEvent);
                }
            };
        }

#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnSessionLaunch()
        {
            Application.quitting += OnSessionQuit;
            var appEvent = new AppEvent()
            {
                eventType = AppEventType.Launch,
            };
            DispatchAppEvent(appEvent);
        }

        private static void OnSessionQuit()
        {
            var appEvent = new AppEvent()
            {
                eventType = AppEventType.Quit,
            };
            DispatchAppEvent(appEvent);
        }

        private static void DispatchAppEvent(AppEvent evt)
        {
            if (handleAppEvent != null)
            {
                handleAppEvent(evt);
            }
        }
    }
}