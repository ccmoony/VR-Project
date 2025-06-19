using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Note
{
    C, Csharp, D,
    Dsharp, E, F,
    Fsharp, G, Gsharp,
    A, Asharp, B
}

public class SongManager : MonoBehaviour
{
    private List<List<Note>> songs;

    private int ongoingSong;
    private int noteIndex;

    [SerializeField]
    InfoScreen infoScreen;
    // public static SongManager instance;
    private Dictionary<Note, PianoKey> pianoKeys = new Dictionary<Note, PianoKey>();
    private Dictionary<Note, Color> originalColors = new Dictionary<Note, Color>();
    IEnumerator curCoroutine = null;
    bool enableKey = true;
    // Start is called before the first frame update
    void Start()
    {
        // instance = this;

        songs = new List<List<Note>>();

        var littlestar = new List<Note> {
            Note.C, Note.C, Note.G, Note.G,
            Note.A, Note.A, Note.G,

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

        infoScreen = GetComponentInChildren<InfoScreen>();
        var keys = GetComponentsInChildren<PianoKey>();
        foreach (PianoKey key in keys)
        {
            pianoKeys.Add(key.note, key);
            originalColors.Add(key.note, key.renderer.material.GetColor("_Color"));
        }

    }

    public void SelectSong(int index)
    {
        if (curCoroutine != null)
            StopCoroutine(curCoroutine);
        AllRevert();
        if (index >= 0 && index < this.songs.Count && index != ongoingSong)
        {
            Debug.Log($"Select song: {index}");
            infoScreen.SongMsg(index.ToString());
            curCoroutine = SongDemo(index);
            StartCoroutine(curCoroutine);
            ongoingSong = index;
        }
    }

    public bool PlayNote(Note note)
    {
        Debug.Log(note);
        if (ongoingSong != -1)
        {
            // if there is an ongoing song
            var song = songs[ongoingSong];
            if (enableKey && song[noteIndex] == note)
            {
                // correct
                RevertTargetColor(song[noteIndex]);
                noteIndex++;
                Debug.Log("progress");
                if (noteIndex >= song.Count)
                {
                    // song completed
                    Debug.Log("Complete!");
                    infoScreen.CompleteMsg();
                    ongoingSong = -1;
                    return true;
                }
                SetTargetColor(song[noteIndex]);
            }
            else
            {
                // wrong, reset index
                infoScreen.ErrorMsg();
                RevertTargetColor(song[noteIndex]);
                noteIndex = 0;
                SetTargetColor(song[noteIndex]);
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        var selectSong = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectSong = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectSong = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectSong = 3;
        }

        if (selectSong != -1)
        {
            SelectSong(selectSong - 1);
        }
    }

    private IEnumerator SongDemo(int songID)
    {
        enableKey = false;
        var song = songs[songID];
        for (int i = 0; i <= song.Count; i++)
        {
            if (i >= 1)
                RevertTargetColor(song[i - 1]);
            yield return new WaitForSeconds(0.2f);
            if (i < song.Count)
                SetTargetColor(song[i], Color.green);
            yield return new WaitForSeconds(0.2f);
        }
        noteIndex = 0;
        SetTargetColor(songs[ongoingSong][noteIndex]);
        enableKey = true;
    }

    private void AllRevert()
    {
        foreach (var item in pianoKeys)
        {
            item.Value.renderer.materials[0].color = originalColors[item.Key];
        }
    }

    private void RevertTargetColor(Note target)
    {
        pianoKeys[target].renderer.materials[0].color = originalColors[target];
    }
    private void SetTargetColor(Note target, Color? color = null)
    {
        Color _color = color ?? Color.blue;
        pianoKeys[target].renderer.materials[0].color = _color;
    }
}
