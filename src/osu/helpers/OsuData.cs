using OsuParsers.Database;
using OsuParsers.Decoders;
using Osussist.src.utils;

namespace Osussist.src.osu.helpers
{
    public class OsuData
    {
        private Logger logger = Logger.LoggingInstance;
        private OsuProcess ProcessManager { get; set; }
        public OsuDatabase Database { get; private set; }
        private string DatabaseMD5 { get; set; }

        public OsuData(OsuProcess processManager)
        {
            ProcessManager = processManager;
            DatabaseMD5 = "";
            UpdateDatabase();
        }

        public void UpdateDatabase()
        {
            string md5String = OsuCrypto.GetMD5String(File.ReadAllBytes(ProcessManager.GameFolder + "osu!.db"));
            if (DatabaseMD5 != md5String)
            {
                DatabaseMD5 = md5String;
                Database = DatabaseDecoder.DecodeOsu(ProcessManager.GameFolder + "osu!.db");
            }
        }
    }
}
