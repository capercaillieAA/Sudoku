using System.IO;
using Newtonsoft.Json;

namespace Sudoku
{
    enum Difficult
    {
        Easy,
        Medium,
        Hard
    }

    class Settings
    {
        public Difficult Difficult { get; }

        public int Dimension { get; }

        public bool Hints { get; }

        public bool Timer { get; }

        public int SoundVolume { get; }

        public void Save()
        {
            using (var output = new StreamWriter("settings.json"))
                output.WriteLine(JsonConvert.SerializeObject(this));
        }

        public Settings GetSettings()
        {
            using (var input = new StreamReader("settings.json"))
                return JsonConvert.DeserializeObject<Settings>(input.ReadToEnd());
        }
    }
}
