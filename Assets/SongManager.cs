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

    private int ongoingSong;
    private int noteIndex;

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

        ongoingSong = -1;
    }
    
    void SelectSong(int index) {
        if (index >= 0 && index < this.songs.Count) {
            this.ongoingSong = index;
            this.noteIndex = 0;
        }
    }

    bool PlayNote(Note note) {
        if (ongoingSong != -1) {
            // if there is an ongoing song
            var song = this.songs[ongoingSong];
            if (song[noteIndex] == note) {
                // correct
                noteIndex++;
                if (noteIndex >= song.Count) {
                    // song completed
                    ongoingSong = -1;
                    return true;
                }
            } else {
                // wrong, reset index
                noteIndex = 0;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update() { }
}
