using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Note {
    C, Csharp, D,
    Dsharp, E, F,
    Fsharp, G, Gsharp,
    A, Asharp,
}

public class SongManager : MonoBehaviour {
    private List<List<Note>> songs;
    // Start is called before the first frame update
    void Start() {
        songs = new List<List<Note>>();

        var littlestar = new List<Note> {
            Note.C, Note.C, Note.G, Note.G,
            Note.A, Note.A, Note.G,
            Note.F, Note.F, Note.E, Note.E,
            Note.D, Note.D, Note.C
        };
        songs.Add(littlestar);

        var maryHadALittleLamb = new List<Note> {
            Note.E, Note.D, Note.C, Note.D,
            Note.E, Note.E, Note.E,
            Note.D, Note.D, Note.D,
            Note.E, Note.G, Note.G
        };
        songs.Add(maryHadALittleLamb);

        var odeToJoy = new List<Note> {
            Note.E, Note.E, Note.F, Note.G,
            Note.G, Note.F, Note.E, Note.D,
            Note.C, Note.C, Note.D, Note.E,
            Note.E, Note.D, Note.D
        };
        songs.Add(odeToJoy);

        Debug.Log($"Loaded {songs.Count} songs");
    }

    // Update is called once per frame
    void Update() { }
}
