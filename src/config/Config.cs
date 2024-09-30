using Newtonsoft.Json;
using Osussist.src.config.objects;
using Osussist.src.utils;
using System.Text;
using WindowsInput.Native;

namespace Osussist.src.config
{
    public class Config
    {
        private Logger logger = Logger.LoggingInstance;
        public static string currentConfigFile { get; set; }
        public static Config configInstance { get; set; }
        public static ConfigObject config { get; private set; }
        public static string configFolder { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "./config");

        public Config()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            config = new ConfigObject();
            configInstance = this;
        }

        public bool Load(string fileName)
        {
            string filePath = Path.Combine(configFolder, fileName);

            if (File.Exists(filePath) || Path.GetExtension(filePath).ToLower() != ".json")
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    config = JsonConvert.DeserializeObject<ConfigObject>(json);
                    logger.Info("Utils.Config", "Config file loaded successfully.");
                    currentConfigFile = fileName;
                    return true;
                }
                catch (Exception e)
                {
                    logger.Error("Utils.Config", $"Failed to load config file: {e.Message}");
                    config = new ConfigObject();
                    return false;
                }
            }
            else
            {
                logger.Error("Utils.Config", "Config file does not exist or is not a JSON file.");
                config = new ConfigObject();
                return false;
            }
        }

        public bool Reset(string fileName)
        {
            try
            {
                string filePath = Path.Combine(configFolder, fileName);
                File.Delete(filePath);

                ConfigObject tempConfig = new ConfigObject();
                char[] json = JsonConvert.SerializeObject(tempConfig, Formatting.Indented).ToCharArray();
                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(json));
                logger.Info("Utils.Config", "Config file reset successfully.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error("Utils.Config", $"Failed to reset config file: {e.Message}");
                return false;
            }
        }

        public bool Delete(string fileName)
        {
            try
            {
                string filePath = Path.Combine(configFolder, fileName);
                File.Delete(filePath);
                logger.Info("Utils.Config", "Config file deleted successfully.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error("Utils.Config", $"Failed to delete config file: {e.Message}");
                return false;
            }
        }

        public bool Save(string fileName)
        {
            try
            {
                string filePath = Path.Combine(configFolder, fileName);

                char[] json = JsonConvert.SerializeObject(config, Formatting.Indented).ToCharArray();
                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(json));
                logger.Info("Utils.Config", "Config file saved successfully.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error("Utils.Config", $"Failed to save config file: {e.Message}");
                return false;
            }
        }

        public bool Create(string fileName)
        {
            try
            {
                string filePath = Path.Combine(configFolder, fileName);

                ConfigObject tempConfig = new ConfigObject();
                char[] json = JsonConvert.SerializeObject(tempConfig, Formatting.Indented).ToCharArray();
                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(json));
                logger.Info("Utils.Config", "Config file created successfully.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error("Utils.Config", $"Failed to create config file: {e.Message}");
                return false;
            }
        }

        public static List<string> GetConfigFiles()
        {
            string filePath = Path.Combine(configFolder);

            var allFiles = Directory.GetFiles(filePath);
            List<string> configFiles = new List<string>();
            foreach (string file in allFiles)
            {
                if (Path.GetExtension(file).ToLower() == ".json")
                    configFiles.Add(Path.GetFileName(file));
            }

            return configFiles;
        }
    }
    public class ConfigObject
    {
        // Osu settings
        [JsonProperty("osusettings")]
        public OsuSettings osusettings { get; set; } = new OsuSettings();

        // Aimbot settings
        [JsonProperty("aimbotenabled")]
        public bool aimbotenabled { get; set; } = false;
        [JsonProperty("aimbotsettings")]
        public AimbotConfig aimbotsettings { get; set; } = new AimbotConfig();

        // Relax settings
        [JsonProperty("relaxenabled")]
        public bool relaxenabled { get; set; } = false;
        [JsonProperty("relaxsettings")]
        public RelaxConfig relaxsettings { get; set; } = new RelaxConfig();

        // Keybindings
        [JsonProperty("keybindings")]
        public Keybindings keybindings { get; set; } = new Keybindings();

        // Overrides
        [JsonProperty("overrides")]
        public Overrides overrides { get; set; } = new Overrides();
    }

    public class Overrides
    {
        public bool overrideaimbot { get; set; } = false;
    }

    public class OsuSettings
    {
        public int audiooffset { get; set; } = 0;
    }

    public class Keybindings
    {
        public VirtualKeyCode aimbotkey { get; set; } = VirtualKeyCode.F1;
        public VirtualKeyCode relaxkey { get; set; } = VirtualKeyCode.F2;
        public VirtualKeyCode primarykey { get; set; } = VirtualKeyCode.VK_Z;
        public VirtualKeyCode secondarykey { get; set; } = VirtualKeyCode.VK_X;
    }

    public class AimbotConfig
    {
        public int fovsize { get; set; } = 400;
        public int minarea { get; set; } = 10;
        public int similarity { get; set; } = 0;
        public int smoothing { get; set; } = 100;
        public float strength { get; set; } = 0.07f;
        public int hitobjectradius { get; set; } = 50;
        public int pullawaydistance { get; set; } = 200;
        public bool hardrockenabled { get; set; } = false;
        public MouseAlgorithms algorithm { get; set; } = MouseAlgorithms.Steps;
        public RgbColor cursorcolor { get; set; } = new RgbColor(221, 50, 50);
        public RgbColor targetcolor { get; set; } = new RgbColor(255, 0, 220);
        public VarianceInt movementdelay { get; set; } = new VarianceInt(1, 5);
    }

    public class RelaxConfig
    {
        public bool hardrockenabled { get; set; } = false;
        public float hitscanmultiplier { get; set; } = 0.9f;
        public int hitscanmaxdistance { get; set; } = 30;
        public int hitscanradiusadd { get; set; } = 50;
        public int maxsingletapbpm { get; set; } = 250;
        public PlayStyles playstyle { get; set; } = PlayStyles.Alternate;
    }
}
 