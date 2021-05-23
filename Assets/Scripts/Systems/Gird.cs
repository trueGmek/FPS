using Player;
using UnityEngine;

namespace Systems {
    /*
     1.first read this or you are HUGELY WASTING YOUR TIME:
     http: //stackoverflow.com/a/35891919/294884
     
     NOTE - as of 2016, the clowns at Unity have forgotten to include
     a preload scene as a built-in concept in Unity projects.
     Obviously, every single project needs a preload scene.
     
     Until they have a brain fart and finally add a preload scene
     to Unity projects, just add one yourself.
     
     The entire point of the preload scene is simply to hold
     any persistent things like sound effects, which you need to
     access everywhere.It's that simple. Couldn't be easier.
     There's nothing more to it than that.
     
     2.have your preload scene, say "_preload"
     
     3.have one GameObject, say "_app", in that scene.
     put a script on "_app" with DontDestroyOnLoad
     
     4.in the example, put your classes
     Voiceover, Sfx, Music, Scoring on "_app"
     
     ************ NOTE ************
     
     The >>>ONLY POINT<<< of using Grid is to save you typing
     >>>ONE<<< LINE OF CODE.Honestly in 99% of cases it's easier
     just to type the >>>ONE<<< line of code.Read:
     http: //stackoverflow.com/a/35891919/294884
    */

    static class Grid {
        public static InputManager InputManager;

        static Grid() {
            GameObject g = SafeFind("__app");

            InputManager = (InputManager) SafeComponent(g, "InputManager");
        }

        private static GameObject SafeFind(string s) {
            GameObject g = GameObject.Find(s);
            if (g == null) Woe("GameObject " + s + "  not on _preload.");
            return g;
        }

        private static Component SafeComponent(GameObject g, string s) {
            Component c = g.GetComponent(s);
            if (c == null) Woe("Component " + s + " not on _preload.");
            return c;
        }

        private static void Woe(string error) {
            Debug.Log(">>> Cannot proceed... " + error);
            Debug.Log(">>> It is very likely you just forgot to launch");
            Debug.Log(">>> from scene zero, the _preload scene.");
        }
    }
}