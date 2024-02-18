using UnityEngine;
using TMPro;
using System.Linq;
// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderBoard
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;

        // Make changes to this section according to how you're storing the player's score:
        // ------------------------------------------------------------
        [SerializeField] private SceneManagerScript _totalTimeScript;

        private float Score => _totalTimeScript.totalTimer;
        // ------------------------------------------------------------

        private void Start()
        {
            LoadEntries();
        }

        private void LoadEntries()
        {
            // Q: How do I reference my own leaderboard?
            // A: Leaderboards.<NameOfTheLeaderboard>

            Leaderboards.SpinToUnknown.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";

                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                {
                    int hour = entries[i].Score / 3600;
                    int remainingSeconds = entries[i].Score % 3600;
                    int minute = remainingSeconds / 60;
                    int seconds = remainingSeconds % 60;
                    string tempText = hour + "h " + minute + "m " + seconds + "s.";


                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {tempText}";
                }

            });
        }


        public void UploadEntry()
        {
            Leaderboards.SpinToUnknown.UploadNewEntry(_usernameInputField.text, (int)Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
    }
}