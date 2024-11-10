using Guna.UI2.WinForms;
using OsuParsers.Enums;
using Osussist.src.config;
using Osussist.src.config.objects;
using Osussist.src.osu;
using Osussist.src.utils;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using WindowsInput.Native;
using Osussist.src.cheat;
using Osussist.src.gui;

namespace Osussist.src.gui
{
    public partial class MainGUI : Form
    {
        private int LastConfigIndex;
        private Guna2Elipse Border;
        private AdvancedOptions AdvancedOptions;
        private System.ComponentModel.IContainer components;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Guna2HtmlLabel Title;
        private Guna2Panel MainContent;
        private Guna2Panel Sidepanel;
        private Guna2HtmlLabel TitleLabel;
        private Guna2HtmlLabel SubtitleLabel;
        private Guna2Panel SidepanelButtons;
        private Guna2Elipse SidepanelButtonsBorder;
        private Guna2Panel DragZone2;
        private Guna2Panel DragZone1;
        private Guna2Panel MiniCredits;
        private Guna2Elipse MiniCreditsBorder;
        private Guna2Button AimbotButton;
        private Guna2Button RelaxButton;
        private Guna2Button SpooferButton;
        private Guna2Button ConfigButton;
        private Guna2Button ManiaButton;
        private Guna2Button CatchButton;
        private Guna2Panel Content;
        private Guna2HtmlLabel CreditsTitle;
        private Guna2CirclePictureBox CreditsImage;
        private Guna2Button DiscordButton;
        private Guna2Button WebsiteButton;
        private Guna2Panel AimbotTabPanel;
        private Guna2Panel AimbotTabPanelHeader;
        private Guna2Elipse AimbotTabPanelBorder;
        private Guna2HtmlLabel AimbotTabPanelTitle;
        private Guna2ToggleSwitch AimbotTabPanelSwitch;
        private Guna2HtmlLabel AimbotTabPanelSwitchLabel;
        private Guna2TrackBar AimbotFovSlider;
        private Guna2HtmlLabel FovLabel;
        private Guna2NumericUpDown AimbotFovSliderNumericUpDown;
        private Guna2HtmlLabel SmoothingLabel;
        private Guna2NumericUpDown AimbotSmoothingSliderNumericUpDown;
        private Guna2TrackBar AimbotSmoothingSlider;
        private Guna2HtmlLabel StrengthLabel;
        private Guna2NumericUpDown AimbotStrengthNumericUpDown;
        private Guna2TrackBar AimbotStrengthSlider;
        private Guna2Panel DetectionPanel;
        private Guna2Panel DetectionPanelHeader;
        private Guna2HtmlLabel DetectionPanelTitle;
        private Guna2Elipse DetectionPanelBorder;
        private Guna2HtmlLabel TargetColorLabel;
        private Guna2Button TargetColorButton;
        private Guna2Panel TargetColorPreview;
        private Guna2Panel CursorColorPreview;
        private Guna2HtmlLabel CursorColorLabel;
        private Guna2Button CursorColorButton;
        private Guna2Panel RelaxPanel;
        private Guna2HtmlLabel RelaxPanelSwitchLabel;
        private Guna2ToggleSwitch RelaxPanelSwitch;
        private Guna2Panel RelaxPanelHeader;
        private Guna2HtmlLabel RelaxPanelLabel;
        private Guna2Elipse RelaxPanelBorder;
        private Guna2HtmlLabel PlaystyleComboBoxLabel;
        private Guna2Elipse TimingPanelBorder;
        private Guna2ComboBox PlaystyleComboBox;
        private Guna2HtmlLabel MaxBPMLabel;
        private Guna2NumericUpDown MaxBPMNumeric;
        private Guna2TrackBar MaxBPMSlider;
        private Guna2HtmlLabel AudioOffsetSliderLabel;
        private Guna2NumericUpDown AudioOffsetSliderNumeric;
        private Guna2TrackBar AudioOffsetSlider;
        private Guna2Panel TimingPanel;
        private Guna2Panel TimingPanelHeader;
        private Guna2HtmlLabel TimingPanelLabel;
        private Guna2ComboBox CurrentModsComboBox;
        private Guna2HtmlLabel CurrentModsLabel;
        private Guna2HtmlLabel MaxDistanceLabel;
        private Guna2NumericUpDown MaxDistanceNumeric;
        private Guna2TrackBar MaxDistanceSlider;
        private Guna2NumericUpDown SimilarityNumeric;
        private Guna2TrackBar SimilaritySlider;
        private Guna2HtmlLabel SimilarityLabel;
        private Guna2Button AimbotKeybindSet;
        private Guna2HtmlLabel AimbotKeybindLabel;
        private Guna2HtmlLabel RelaxKeybindLabel;
        private Guna2Button RelaxKeybindSet;
        private Guna2NumericUpDown PullawayNumeric;
        private Guna2TrackBar PullawaySlider;
        private Guna2HtmlLabel PullawayLabel;
        private Guna2Panel SpooferPanel;
        private Guna2Panel SpooferHeader;
        private Guna2HtmlLabel SpooferHeaderLabel;
        private Guna2Elipse SpooferPanelBorder;
        private Guna2Panel SerialsPanel;
        private Guna2Elipse SerialsBorder;
        private Guna2Button CheckSerialsButton;
        private Guna2Button SpoofSerialsButton;
        private Guna2Panel ConfigPanel;
        private Guna2Panel ConfigPanelHeader;
        private Guna2HtmlLabel ConfigPanelHeaderLabel;
        private Guna2Elipse ConfigPanelBorder;
        private Guna2ComboBox ConfigComboBox;
        private Guna2Panel ConfigTable;
        private Guna2Elipse ConfigTableBorder;
        private Guna2Panel ConfigTableHeader;
        private Guna2Elipse ConfigTableHeaderBorder;
        private Guna2Button LocalConfigButton;
        private Guna2Button CloudConfigButton;
        private Guna2Button DeleteConfigButton;
        private Guna2Button ResetConfigButton;
        private Guna2Button LoadConfigButton;
        private Guna2Button SaveConfigButton;
        private Guna2Button CreateConfigButton;
        private Guna2TextBox CreateConfigText;
        private Guna2Button ConfigNameDynamic;
        private Guna2TextBox CpuSerial;
        private Guna2HtmlLabel CpuLabel;
        private Guna2TextBox BaseBoardSerial;
        private Guna2HtmlLabel BaseBoardLabel;
        private Guna2TextBox DiskSerial;
        private Guna2HtmlLabel DiskLabel;
        private Guna2VSeparator Separator;
        private Guna2TextBox MACSerial;
        private Guna2HtmlLabel MacLabel;
        private Guna2HtmlLabel HardrockLabel;
        private Guna2ToggleSwitch HardrockEnabled;
        private Guna2ComboBox MouseAlgorithmCombo;
        private Guna2HtmlLabel MouseMovementAlgoLabel;
        private Guna2Button AdvancedButton;
        private Guna2HtmlLabel HardrockEnabledLabelAA;
        private Guna2ToggleSwitch HardrockEnabledAA;
        private Guna2HtmlLabel SensitivityLabel;
        private Guna2NumericUpDown SensitivityNumeric;
        private Guna2TrackBar SensitivitySlider;
        private Point dragFormPoint;

        public MainGUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.Border = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Sidepanel = new Guna.UI2.WinForms.Guna2Panel();
            this.MiniCredits = new Guna.UI2.WinForms.Guna2Panel();
            this.DiscordButton = new Guna.UI2.WinForms.Guna2Button();
            this.WebsiteButton = new Guna.UI2.WinForms.Guna2Button();
            this.CreditsImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.CreditsTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SidepanelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.CatchButton = new Guna.UI2.WinForms.Guna2Button();
            this.ManiaButton = new Guna.UI2.WinForms.Guna2Button();
            this.ConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.SpooferButton = new Guna.UI2.WinForms.Guna2Button();
            this.RelaxButton = new Guna.UI2.WinForms.Guna2Button();
            this.AimbotButton = new Guna.UI2.WinForms.Guna2Button();
            this.SubtitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DragZone1 = new Guna.UI2.WinForms.Guna2Panel();
            this.MainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.Content = new Guna.UI2.WinForms.Guna2Panel();
            this.DetectionPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SensitivityLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SensitivityNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.SensitivitySlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.MouseAlgorithmCombo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.MouseMovementAlgoLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SimilarityNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.CursorColorPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.SimilaritySlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.CursorColorLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SimilarityLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CursorColorButton = new Guna.UI2.WinForms.Guna2Button();
            this.TargetColorPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.TargetColorLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TargetColorButton = new Guna.UI2.WinForms.Guna2Button();
            this.DetectionPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.DetectionPanelTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TimingPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.HardrockLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.HardrockEnabled = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.MaxDistanceLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MaxDistanceNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.MaxDistanceSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.AudioOffsetSliderLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TimingPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.TimingPanelLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AudioOffsetSliderNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.MaxBPMSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.AudioOffsetSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.MaxBPMNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.MaxBPMLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotTabPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.HardrockEnabledLabelAA = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PullawayNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.HardrockEnabledAA = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.AimbotKeybindLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PullawaySlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.PullawayLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotKeybindSet = new Guna.UI2.WinForms.Guna2Button();
            this.StrengthLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotStrengthNumericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.AimbotStrengthSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.SmoothingLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotSmoothingSliderNumericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.AimbotSmoothingSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.FovLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotFovSliderNumericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.AimbotFovSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.AimbotTabPanelSwitchLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotTabPanelSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.AimbotTabPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.AimbotTabPanelTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RelaxPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.RelaxKeybindLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RelaxKeybindSet = new Guna.UI2.WinForms.Guna2Button();
            this.CurrentModsComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CurrentModsLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PlaystyleComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.PlaystyleComboBoxLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RelaxPanelSwitchLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RelaxPanelSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.RelaxPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.RelaxPanelLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ConfigPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.AdvancedButton = new Guna.UI2.WinForms.Guna2Button();
            this.CreateConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.CreateConfigText = new Guna.UI2.WinForms.Guna2TextBox();
            this.DeleteConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.ResetConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.LoadConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.SaveConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.ConfigTableHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.CloudConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.LocalConfigButton = new Guna.UI2.WinForms.Guna2Button();
            this.ConfigTable = new Guna.UI2.WinForms.Guna2Panel();
            this.ConfigComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ConfigPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.ConfigPanelHeaderLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SpooferPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.CheckSerialsButton = new Guna.UI2.WinForms.Guna2Button();
            this.SpoofSerialsButton = new Guna.UI2.WinForms.Guna2Button();
            this.SerialsPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.MACSerial = new Guna.UI2.WinForms.Guna2TextBox();
            this.MacLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DiskSerial = new Guna.UI2.WinForms.Guna2TextBox();
            this.DiskLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Separator = new Guna.UI2.WinForms.Guna2VSeparator();
            this.BaseBoardSerial = new Guna.UI2.WinForms.Guna2TextBox();
            this.BaseBoardLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CpuSerial = new Guna.UI2.WinForms.Guna2TextBox();
            this.CpuLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SpooferHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.SpooferHeaderLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DragZone2 = new Guna.UI2.WinForms.Guna2Panel();
            this.SidepanelButtonsBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.MiniCreditsBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.AimbotTabPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.DetectionPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RelaxPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.TimingPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SpooferPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SerialsBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ConfigPanelBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ConfigTableBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ConfigTableHeaderBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Sidepanel.SuspendLayout();
            this.MiniCredits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreditsImage)).BeginInit();
            this.SidepanelButtons.SuspendLayout();
            this.MainContent.SuspendLayout();
            this.Content.SuspendLayout();
            this.DetectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimilarityNumeric)).BeginInit();
            this.DetectionPanelHeader.SuspendLayout();
            this.TimingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDistanceNumeric)).BeginInit();
            this.TimingPanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOffsetSliderNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBPMNumeric)).BeginInit();
            this.AimbotTabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PullawayNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotStrengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotSmoothingSliderNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotFovSliderNumericUpDown)).BeginInit();
            this.AimbotTabPanelHeader.SuspendLayout();
            this.RelaxPanel.SuspendLayout();
            this.RelaxPanelHeader.SuspendLayout();
            this.ConfigPanel.SuspendLayout();
            this.ConfigTableHeader.SuspendLayout();
            this.ConfigPanelHeader.SuspendLayout();
            this.SpooferPanel.SuspendLayout();
            this.SerialsPanel.SuspendLayout();
            this.SpooferHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // Border
            // 
            this.Border.BorderRadius = 10;
            this.Border.TargetControl = this;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(3, 2);
            this.Title.TabIndex = 0;
            this.Title.Text = null;
            // 
            // Sidepanel
            // 
            this.Sidepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Sidepanel.Controls.Add(this.MiniCredits);
            this.Sidepanel.Controls.Add(this.SidepanelButtons);
            this.Sidepanel.Controls.Add(this.SubtitleLabel);
            this.Sidepanel.Controls.Add(this.TitleLabel);
            this.Sidepanel.Controls.Add(this.DragZone1);
            this.Sidepanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidepanel.Location = new System.Drawing.Point(0, 0);
            this.Sidepanel.Name = "Sidepanel";
            this.Sidepanel.Size = new System.Drawing.Size(239, 534);
            this.Sidepanel.TabIndex = 0;
            // 
            // MiniCredits
            // 
            this.MiniCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MiniCredits.Controls.Add(this.DiscordButton);
            this.MiniCredits.Controls.Add(this.WebsiteButton);
            this.MiniCredits.Controls.Add(this.CreditsImage);
            this.MiniCredits.Controls.Add(this.CreditsTitle);
            this.MiniCredits.Location = new System.Drawing.Point(11, 54);
            this.MiniCredits.Name = "MiniCredits";
            this.MiniCredits.Size = new System.Drawing.Size(217, 92);
            this.MiniCredits.TabIndex = 4;
            // 
            // DiscordButton
            // 
            this.DiscordButton.BorderRadius = 5;
            this.DiscordButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.discord;
            this.DiscordButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.discord;
            this.DiscordButton.CustomImages.Image = global::Osussist.Properties.Resources.discord;
            this.DiscordButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DiscordButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DiscordButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DiscordButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DiscordButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DiscordButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DiscordButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DiscordButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscordButton.ForeColor = System.Drawing.Color.White;
            this.DiscordButton.Location = new System.Drawing.Point(86, 56);
            this.DiscordButton.Name = "DiscordButton";
            this.DiscordButton.Size = new System.Drawing.Size(104, 29);
            this.DiscordButton.TabIndex = 3;
            this.DiscordButton.Text = "Discord";
            this.DiscordButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DiscordButton.TextOffset = new System.Drawing.Point(23, -1);
            this.DiscordButton.Click += new System.EventHandler(this.DiscordButton_Click);
            // 
            // WebsiteButton
            // 
            this.WebsiteButton.BorderRadius = 5;
            this.WebsiteButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.website;
            this.WebsiteButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.website;
            this.WebsiteButton.CustomImages.Image = global::Osussist.Properties.Resources.website;
            this.WebsiteButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WebsiteButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.WebsiteButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.WebsiteButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.WebsiteButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.WebsiteButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.WebsiteButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.WebsiteButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebsiteButton.ForeColor = System.Drawing.Color.White;
            this.WebsiteButton.Location = new System.Drawing.Point(86, 28);
            this.WebsiteButton.Name = "WebsiteButton";
            this.WebsiteButton.Size = new System.Drawing.Size(104, 27);
            this.WebsiteButton.TabIndex = 2;
            this.WebsiteButton.Text = "Website";
            this.WebsiteButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WebsiteButton.TextOffset = new System.Drawing.Point(23, -1);
            this.WebsiteButton.Click += new System.EventHandler(this.WebsiteButton_Click);
            // 
            // CreditsImage
            // 
            this.CreditsImage.Image = global::Osussist.Properties.Resources.taco;
            this.CreditsImage.ImageRotate = 0F;
            this.CreditsImage.InitialImage = null;
            this.CreditsImage.Location = new System.Drawing.Point(9, 13);
            this.CreditsImage.Name = "CreditsImage";
            this.CreditsImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CreditsImage.Size = new System.Drawing.Size(64, 64);
            this.CreditsImage.TabIndex = 1;
            this.CreditsImage.TabStop = false;
            // 
            // CreditsTitle
            // 
            this.CreditsTitle.BackColor = System.Drawing.Color.Transparent;
            this.CreditsTitle.Enabled = false;
            this.CreditsTitle.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsTitle.Location = new System.Drawing.Point(81, 8);
            this.CreditsTitle.Name = "CreditsTitle";
            this.CreditsTitle.Size = new System.Drawing.Size(115, 21);
            this.CreditsTitle.TabIndex = 0;
            this.CreditsTitle.Text = "Made by Takkeshi";
            // 
            // SidepanelButtons
            // 
            this.SidepanelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SidepanelButtons.Controls.Add(this.CatchButton);
            this.SidepanelButtons.Controls.Add(this.ManiaButton);
            this.SidepanelButtons.Controls.Add(this.ConfigButton);
            this.SidepanelButtons.Controls.Add(this.SpooferButton);
            this.SidepanelButtons.Controls.Add(this.RelaxButton);
            this.SidepanelButtons.Controls.Add(this.AimbotButton);
            this.SidepanelButtons.Location = new System.Drawing.Point(10, 152);
            this.SidepanelButtons.Name = "SidepanelButtons";
            this.SidepanelButtons.Size = new System.Drawing.Size(219, 370);
            this.SidepanelButtons.TabIndex = 2;
            // 
            // CatchButton
            // 
            this.CatchButton.BorderRadius = 15;
            this.CatchButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.CatchButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources._catch;
            this.CatchButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources._catch;
            this.CatchButton.CustomImages.Image = global::Osussist.Properties.Resources._catch;
            this.CatchButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CatchButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CatchButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CatchButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CatchButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CatchButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CatchButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.CatchButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CatchButton.ForeColor = System.Drawing.Color.White;
            this.CatchButton.Location = new System.Drawing.Point(10, 196);
            this.CatchButton.Name = "CatchButton";
            this.CatchButton.Size = new System.Drawing.Size(199, 45);
            this.CatchButton.TabIndex = 5;
            this.CatchButton.Text = "Catch";
            this.CatchButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CatchButton.TextOffset = new System.Drawing.Point(23, -1);
            this.CatchButton.Click += new System.EventHandler(this.CatchButton_Click);
            // 
            // ManiaButton
            // 
            this.ManiaButton.BorderRadius = 15;
            this.ManiaButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ManiaButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.mania;
            this.ManiaButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.mania;
            this.ManiaButton.CustomImages.Image = global::Osussist.Properties.Resources.mania;
            this.ManiaButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ManiaButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ManiaButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ManiaButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ManiaButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ManiaButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ManiaButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ManiaButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManiaButton.ForeColor = System.Drawing.Color.White;
            this.ManiaButton.Location = new System.Drawing.Point(10, 150);
            this.ManiaButton.Name = "ManiaButton";
            this.ManiaButton.Size = new System.Drawing.Size(199, 45);
            this.ManiaButton.TabIndex = 4;
            this.ManiaButton.Text = "Mania";
            this.ManiaButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ManiaButton.TextOffset = new System.Drawing.Point(23, -1);
            this.ManiaButton.Click += new System.EventHandler(this.ManiaButton_Click);
            // 
            // ConfigButton
            // 
            this.ConfigButton.BorderRadius = 15;
            this.ConfigButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ConfigButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.config;
            this.ConfigButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.config;
            this.ConfigButton.CustomImages.Image = global::Osussist.Properties.Resources.config;
            this.ConfigButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ConfigButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ConfigButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigButton.ForeColor = System.Drawing.Color.White;
            this.ConfigButton.Location = new System.Drawing.Point(10, 313);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(199, 45);
            this.ConfigButton.TabIndex = 3;
            this.ConfigButton.Text = "Config";
            this.ConfigButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfigButton.TextOffset = new System.Drawing.Point(23, -1);
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // SpooferButton
            // 
            this.SpooferButton.BorderRadius = 15;
            this.SpooferButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.SpooferButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.spoofer;
            this.SpooferButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.spoofer;
            this.SpooferButton.CustomImages.Image = global::Osussist.Properties.Resources.spoofer;
            this.SpooferButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SpooferButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SpooferButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SpooferButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SpooferButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SpooferButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SpooferButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SpooferButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpooferButton.ForeColor = System.Drawing.Color.White;
            this.SpooferButton.Location = new System.Drawing.Point(10, 104);
            this.SpooferButton.Name = "SpooferButton";
            this.SpooferButton.Size = new System.Drawing.Size(199, 45);
            this.SpooferButton.TabIndex = 2;
            this.SpooferButton.Text = "Spoofer";
            this.SpooferButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SpooferButton.TextOffset = new System.Drawing.Point(23, -1);
            this.SpooferButton.Click += new System.EventHandler(this.SpooferButton_Click);
            // 
            // RelaxButton
            // 
            this.RelaxButton.BorderRadius = 15;
            this.RelaxButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.RelaxButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.relax;
            this.RelaxButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.relax;
            this.RelaxButton.CustomImages.Image = global::Osussist.Properties.Resources.relax;
            this.RelaxButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RelaxButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RelaxButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RelaxButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RelaxButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RelaxButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RelaxButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.RelaxButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelaxButton.ForeColor = System.Drawing.Color.White;
            this.RelaxButton.Location = new System.Drawing.Point(10, 58);
            this.RelaxButton.Name = "RelaxButton";
            this.RelaxButton.Size = new System.Drawing.Size(199, 45);
            this.RelaxButton.TabIndex = 1;
            this.RelaxButton.Text = "Relax";
            this.RelaxButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RelaxButton.TextOffset = new System.Drawing.Point(23, -1);
            this.RelaxButton.Click += new System.EventHandler(this.RelaxButton_Click);
            // 
            // AimbotButton
            // 
            this.AimbotButton.BorderRadius = 15;
            this.AimbotButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.AimbotButton.CustomImages.CheckedImage = global::Osussist.Properties.Resources.aimbot;
            this.AimbotButton.CustomImages.HoveredImage = global::Osussist.Properties.Resources.aimbot;
            this.AimbotButton.CustomImages.Image = global::Osussist.Properties.Resources.aimbot;
            this.AimbotButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AimbotButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AimbotButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AimbotButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AimbotButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AimbotButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AimbotButton.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AimbotButton.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotButton.ForeColor = System.Drawing.Color.White;
            this.AimbotButton.Location = new System.Drawing.Point(10, 12);
            this.AimbotButton.Name = "AimbotButton";
            this.AimbotButton.Size = new System.Drawing.Size(199, 45);
            this.AimbotButton.TabIndex = 0;
            this.AimbotButton.Text = "Aimbot";
            this.AimbotButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AimbotButton.TextOffset = new System.Drawing.Point(23, -1);
            this.AimbotButton.Click += new System.EventHandler(this.AimbotButton_Click);
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleLabel.Enabled = false;
            this.SubtitleLabel.Font = new System.Drawing.Font("Comfortaa", 8F);
            this.SubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.SubtitleLabel.Location = new System.Drawing.Point(7, 28);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(224, 20);
            this.SubtitleLabel.TabIndex = 1;
            this.SubtitleLabel.Text = "We did not have relations with that RAM";
            this.SubtitleLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Enabled = false;
            this.TitleLabel.Font = new System.Drawing.Font("Comfortaa", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.TitleLabel.Location = new System.Drawing.Point(60, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(118, 32);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "氧 Osussist";
            this.TitleLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DragZone1
            // 
            this.DragZone1.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragZone1.Location = new System.Drawing.Point(0, 0);
            this.DragZone1.Name = "DragZone1";
            this.DragZone1.Size = new System.Drawing.Size(239, 32);
            this.DragZone1.TabIndex = 3;
            this.DragZone1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseDown);
            this.DragZone1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseMove);
            this.DragZone1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseUp);
            // 
            // MainContent
            // 
            this.MainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.MainContent.Controls.Add(this.Content);
            this.MainContent.Controls.Add(this.DragZone2);
            this.MainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContent.Location = new System.Drawing.Point(239, 0);
            this.MainContent.Name = "MainContent";
            this.MainContent.Size = new System.Drawing.Size(578, 534);
            this.MainContent.TabIndex = 1;
            // 
            // Content
            // 
            this.Content.Controls.Add(this.TimingPanel);
            this.Content.Controls.Add(this.RelaxPanel);
            this.Content.Controls.Add(this.ConfigPanel);
            this.Content.Controls.Add(this.SpooferPanel);
            this.Content.Controls.Add(this.DetectionPanel);
            this.Content.Controls.Add(this.AimbotTabPanel);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 32);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(578, 502);
            this.Content.TabIndex = 1;
            // 
            // DetectionPanel
            // 
            this.DetectionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.DetectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DetectionPanel.Controls.Add(this.SensitivityLabel);
            this.DetectionPanel.Controls.Add(this.SensitivityNumeric);
            this.DetectionPanel.Controls.Add(this.SensitivitySlider);
            this.DetectionPanel.Controls.Add(this.MouseAlgorithmCombo);
            this.DetectionPanel.Controls.Add(this.MouseMovementAlgoLabel);
            this.DetectionPanel.Controls.Add(this.SimilarityNumeric);
            this.DetectionPanel.Controls.Add(this.CursorColorPreview);
            this.DetectionPanel.Controls.Add(this.SimilaritySlider);
            this.DetectionPanel.Controls.Add(this.CursorColorLabel);
            this.DetectionPanel.Controls.Add(this.SimilarityLabel);
            this.DetectionPanel.Controls.Add(this.CursorColorButton);
            this.DetectionPanel.Controls.Add(this.TargetColorPreview);
            this.DetectionPanel.Controls.Add(this.TargetColorLabel);
            this.DetectionPanel.Controls.Add(this.TargetColorButton);
            this.DetectionPanel.Controls.Add(this.DetectionPanelHeader);
            this.DetectionPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DetectionPanel.Location = new System.Drawing.Point(35, 240);
            this.DetectionPanel.Name = "DetectionPanel";
            this.DetectionPanel.Size = new System.Drawing.Size(507, 228);
            this.DetectionPanel.TabIndex = 1;
            // 
            // SensitivityLabel
            // 
            this.SensitivityLabel.BackColor = System.Drawing.Color.Transparent;
            this.SensitivityLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.SensitivityLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SensitivityLabel.Location = new System.Drawing.Point(289, 95);
            this.SensitivityLabel.Name = "SensitivityLabel";
            this.SensitivityLabel.Size = new System.Drawing.Size(72, 23);
            this.SensitivityLabel.TabIndex = 27;
            this.SensitivityLabel.Text = "Sensitivity";
            // 
            // SensitivityNumeric
            // 
            this.SensitivityNumeric.BackColor = System.Drawing.Color.Transparent;
            this.SensitivityNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SensitivityNumeric.BorderRadius = 5;
            this.SensitivityNumeric.BorderThickness = 0;
            this.SensitivityNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SensitivityNumeric.DecimalPlaces = 1;
            this.SensitivityNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SensitivityNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensitivityNumeric.ForeColor = System.Drawing.Color.White;
            this.SensitivityNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SensitivityNumeric.Location = new System.Drawing.Point(210, 96);
            this.SensitivityNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SensitivityNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            65536});
            this.SensitivityNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.SensitivityNumeric.Name = "SensitivityNumeric";
            this.SensitivityNumeric.Size = new System.Drawing.Size(73, 21);
            this.SensitivityNumeric.TabIndex = 26;
            this.SensitivityNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.SensitivityNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SensitivityNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SensitivityNumeric.ValueChanged += new System.EventHandler(this.SensitivityNumeric_ValueChanged);
            // 
            // SensitivitySlider
            // 
            this.SensitivitySlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SensitivitySlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.SensitivitySlider.Location = new System.Drawing.Point(12, 95);
            this.SensitivitySlider.Maximum = 60;
            this.SensitivitySlider.Minimum = 4;
            this.SensitivitySlider.Name = "SensitivitySlider";
            this.SensitivitySlider.Size = new System.Drawing.Size(192, 23);
            this.SensitivitySlider.TabIndex = 25;
            this.SensitivitySlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SensitivitySlider.Value = 10;
            this.SensitivitySlider.ValueChanged += new System.EventHandler(this.SensitivitySlider_ValueChanged);
            // 
            // MouseAlgorithmCombo
            // 
            this.MouseAlgorithmCombo.BackColor = System.Drawing.Color.Transparent;
            this.MouseAlgorithmCombo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MouseAlgorithmCombo.BorderRadius = 15;
            this.MouseAlgorithmCombo.BorderThickness = 0;
            this.MouseAlgorithmCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MouseAlgorithmCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MouseAlgorithmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MouseAlgorithmCombo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MouseAlgorithmCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MouseAlgorithmCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MouseAlgorithmCombo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseAlgorithmCombo.ForeColor = System.Drawing.Color.White;
            this.MouseAlgorithmCombo.ItemHeight = 30;
            this.MouseAlgorithmCombo.Items.AddRange(new object[] {
            "Steps",
            "Bezier",
            "Linear",
            "Flick"});
            this.MouseAlgorithmCombo.Location = new System.Drawing.Point(12, 53);
            this.MouseAlgorithmCombo.Name = "MouseAlgorithmCombo";
            this.MouseAlgorithmCombo.Size = new System.Drawing.Size(140, 36);
            this.MouseAlgorithmCombo.TabIndex = 24;
            this.MouseAlgorithmCombo.SelectedIndexChanged += new System.EventHandler(this.MouseAlgorithmCombo_SelectedIndexChanged);
            // 
            // MouseMovementAlgoLabel
            // 
            this.MouseMovementAlgoLabel.BackColor = System.Drawing.Color.Transparent;
            this.MouseMovementAlgoLabel.Enabled = false;
            this.MouseMovementAlgoLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MouseMovementAlgoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MouseMovementAlgoLabel.Location = new System.Drawing.Point(158, 60);
            this.MouseMovementAlgoLabel.Name = "MouseMovementAlgoLabel";
            this.MouseMovementAlgoLabel.Size = new System.Drawing.Size(120, 23);
            this.MouseMovementAlgoLabel.TabIndex = 23;
            this.MouseMovementAlgoLabel.Text = "Mouse Algorithm";
            // 
            // SimilarityNumeric
            // 
            this.SimilarityNumeric.BackColor = System.Drawing.Color.Transparent;
            this.SimilarityNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SimilarityNumeric.BorderRadius = 5;
            this.SimilarityNumeric.BorderThickness = 0;
            this.SimilarityNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SimilarityNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SimilarityNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimilarityNumeric.ForeColor = System.Drawing.Color.White;
            this.SimilarityNumeric.Location = new System.Drawing.Point(210, 125);
            this.SimilarityNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SimilarityNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SimilarityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SimilarityNumeric.Name = "SimilarityNumeric";
            this.SimilarityNumeric.Size = new System.Drawing.Size(73, 21);
            this.SimilarityNumeric.TabIndex = 20;
            this.SimilarityNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.SimilarityNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SimilarityNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SimilarityNumeric.ValueChanged += new System.EventHandler(this.SimilarityNumeric_ValueChanged);
            // 
            // CursorColorPreview
            // 
            this.CursorColorPreview.BackColor = System.Drawing.Color.White;
            this.CursorColorPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CursorColorPreview.BorderThickness = 2;
            this.CursorColorPreview.Location = new System.Drawing.Point(464, 146);
            this.CursorColorPreview.Name = "CursorColorPreview";
            this.CursorColorPreview.Size = new System.Drawing.Size(29, 23);
            this.CursorColorPreview.TabIndex = 22;
            // 
            // SimilaritySlider
            // 
            this.SimilaritySlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SimilaritySlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.SimilaritySlider.Location = new System.Drawing.Point(12, 124);
            this.SimilaritySlider.Maximum = 255;
            this.SimilaritySlider.Minimum = 1;
            this.SimilaritySlider.Name = "SimilaritySlider";
            this.SimilaritySlider.Size = new System.Drawing.Size(192, 23);
            this.SimilaritySlider.TabIndex = 19;
            this.SimilaritySlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.SimilaritySlider.ValueChanged += new System.EventHandler(this.SimilaritySlider_ValueChanged);
            // 
            // CursorColorLabel
            // 
            this.CursorColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.CursorColorLabel.Enabled = false;
            this.CursorColorLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.CursorColorLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CursorColorLabel.Location = new System.Drawing.Point(261, 156);
            this.CursorColorLabel.Name = "CursorColorLabel";
            this.CursorColorLabel.Size = new System.Drawing.Size(92, 23);
            this.CursorColorLabel.TabIndex = 21;
            this.CursorColorLabel.Text = "Cursor Color";
            // 
            // SimilarityLabel
            // 
            this.SimilarityLabel.BackColor = System.Drawing.Color.Transparent;
            this.SimilarityLabel.Enabled = false;
            this.SimilarityLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.SimilarityLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SimilarityLabel.Location = new System.Drawing.Point(289, 124);
            this.SimilarityLabel.Name = "SimilarityLabel";
            this.SimilarityLabel.Size = new System.Drawing.Size(109, 23);
            this.SimilarityLabel.TabIndex = 18;
            this.SimilarityLabel.Text = "Color Similarity";
            // 
            // CursorColorButton
            // 
            this.CursorColorButton.BorderRadius = 13;
            this.CursorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CursorColorButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CursorColorButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CursorColorButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CursorColorButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CursorColorButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CursorColorButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CursorColorButton.ForeColor = System.Drawing.Color.White;
            this.CursorColorButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CursorColorButton.Location = new System.Drawing.Point(261, 185);
            this.CursorColorButton.Name = "CursorColorButton";
            this.CursorColorButton.Size = new System.Drawing.Size(232, 29);
            this.CursorColorButton.TabIndex = 20;
            this.CursorColorButton.Text = "Change Color";
            this.CursorColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // TargetColorPreview
            // 
            this.TargetColorPreview.BackColor = System.Drawing.Color.White;
            this.TargetColorPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TargetColorPreview.BorderThickness = 2;
            this.TargetColorPreview.Location = new System.Drawing.Point(216, 156);
            this.TargetColorPreview.Name = "TargetColorPreview";
            this.TargetColorPreview.Size = new System.Drawing.Size(29, 23);
            this.TargetColorPreview.TabIndex = 19;
            // 
            // TargetColorLabel
            // 
            this.TargetColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.TargetColorLabel.Enabled = false;
            this.TargetColorLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.TargetColorLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TargetColorLabel.Location = new System.Drawing.Point(13, 156);
            this.TargetColorLabel.Name = "TargetColorLabel";
            this.TargetColorLabel.Size = new System.Drawing.Size(91, 23);
            this.TargetColorLabel.TabIndex = 18;
            this.TargetColorLabel.Text = "Target Color";
            // 
            // TargetColorButton
            // 
            this.TargetColorButton.BorderRadius = 13;
            this.TargetColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TargetColorButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.TargetColorButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.TargetColorButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.TargetColorButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.TargetColorButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TargetColorButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetColorButton.ForeColor = System.Drawing.Color.White;
            this.TargetColorButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.TargetColorButton.Location = new System.Drawing.Point(13, 185);
            this.TargetColorButton.Name = "TargetColorButton";
            this.TargetColorButton.Size = new System.Drawing.Size(232, 29);
            this.TargetColorButton.TabIndex = 1;
            this.TargetColorButton.Text = "Change Color";
            this.TargetColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // DetectionPanelHeader
            // 
            this.DetectionPanelHeader.Controls.Add(this.DetectionPanelTitle);
            this.DetectionPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.DetectionPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.DetectionPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.DetectionPanelHeader.Name = "DetectionPanelHeader";
            this.DetectionPanelHeader.Size = new System.Drawing.Size(507, 47);
            this.DetectionPanelHeader.TabIndex = 0;
            // 
            // DetectionPanelTitle
            // 
            this.DetectionPanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DetectionPanelTitle.BackColor = System.Drawing.Color.Transparent;
            this.DetectionPanelTitle.Enabled = false;
            this.DetectionPanelTitle.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.DetectionPanelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.DetectionPanelTitle.Location = new System.Drawing.Point(211, 7);
            this.DetectionPanelTitle.Name = "DetectionPanelTitle";
            this.DetectionPanelTitle.Size = new System.Drawing.Size(84, 28);
            this.DetectionPanelTitle.TabIndex = 5;
            this.DetectionPanelTitle.Text = "Detection";
            this.DetectionPanelTitle.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TimingPanel
            // 
            this.TimingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.TimingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimingPanel.Controls.Add(this.HardrockLabel);
            this.TimingPanel.Controls.Add(this.HardrockEnabled);
            this.TimingPanel.Controls.Add(this.MaxDistanceLabel);
            this.TimingPanel.Controls.Add(this.MaxDistanceNumeric);
            this.TimingPanel.Controls.Add(this.MaxDistanceSlider);
            this.TimingPanel.Controls.Add(this.AudioOffsetSliderLabel);
            this.TimingPanel.Controls.Add(this.TimingPanelHeader);
            this.TimingPanel.Controls.Add(this.AudioOffsetSliderNumeric);
            this.TimingPanel.Controls.Add(this.MaxBPMSlider);
            this.TimingPanel.Controls.Add(this.AudioOffsetSlider);
            this.TimingPanel.Controls.Add(this.MaxBPMNumeric);
            this.TimingPanel.Controls.Add(this.MaxBPMLabel);
            this.TimingPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TimingPanel.Location = new System.Drawing.Point(35, 240);
            this.TimingPanel.Name = "TimingPanel";
            this.TimingPanel.Size = new System.Drawing.Size(507, 228);
            this.TimingPanel.TabIndex = 16;
            // 
            // HardrockLabel
            // 
            this.HardrockLabel.BackColor = System.Drawing.Color.Transparent;
            this.HardrockLabel.Enabled = false;
            this.HardrockLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.HardrockLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HardrockLabel.Location = new System.Drawing.Point(55, 52);
            this.HardrockLabel.Name = "HardrockLabel";
            this.HardrockLabel.Size = new System.Drawing.Size(84, 23);
            this.HardrockLabel.TabIndex = 22;
            this.HardrockLabel.Text = "HR Tapping";
            // 
            // HardrockEnabled
            // 
            this.HardrockEnabled.Animated = true;
            this.HardrockEnabled.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabled.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabled.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabled.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardrockEnabled.Location = new System.Drawing.Point(14, 55);
            this.HardrockEnabled.Name = "HardrockEnabled";
            this.HardrockEnabled.Size = new System.Drawing.Size(35, 20);
            this.HardrockEnabled.TabIndex = 21;
            this.HardrockEnabled.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabled.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabled.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabled.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabled.CheckedChanged += new System.EventHandler(this.HardrockEnabled_CheckedChanged);
            // 
            // MaxDistanceLabel
            // 
            this.MaxDistanceLabel.BackColor = System.Drawing.Color.Transparent;
            this.MaxDistanceLabel.Enabled = false;
            this.MaxDistanceLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MaxDistanceLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MaxDistanceLabel.Location = new System.Drawing.Point(289, 139);
            this.MaxDistanceLabel.Name = "MaxDistanceLabel";
            this.MaxDistanceLabel.Size = new System.Drawing.Size(96, 23);
            this.MaxDistanceLabel.TabIndex = 18;
            this.MaxDistanceLabel.Text = "Max Distance";
            // 
            // MaxDistanceNumeric
            // 
            this.MaxDistanceNumeric.BackColor = System.Drawing.Color.Transparent;
            this.MaxDistanceNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxDistanceNumeric.BorderRadius = 5;
            this.MaxDistanceNumeric.BorderThickness = 0;
            this.MaxDistanceNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MaxDistanceNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MaxDistanceNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxDistanceNumeric.ForeColor = System.Drawing.Color.White;
            this.MaxDistanceNumeric.Location = new System.Drawing.Point(210, 140);
            this.MaxDistanceNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaxDistanceNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxDistanceNumeric.Name = "MaxDistanceNumeric";
            this.MaxDistanceNumeric.Size = new System.Drawing.Size(73, 21);
            this.MaxDistanceNumeric.TabIndex = 17;
            this.MaxDistanceNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.MaxDistanceNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxDistanceNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxDistanceNumeric.ValueChanged += new System.EventHandler(this.MaxDistanceNumeric_ValueChanged);
            // 
            // MaxDistanceSlider
            // 
            this.MaxDistanceSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaxDistanceSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.MaxDistanceSlider.Location = new System.Drawing.Point(12, 139);
            this.MaxDistanceSlider.Minimum = 1;
            this.MaxDistanceSlider.Name = "MaxDistanceSlider";
            this.MaxDistanceSlider.Size = new System.Drawing.Size(192, 23);
            this.MaxDistanceSlider.TabIndex = 16;
            this.MaxDistanceSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxDistanceSlider.ValueChanged += new System.EventHandler(this.MaxDistanceSlider_ValueChanged);
            // 
            // AudioOffsetSliderLabel
            // 
            this.AudioOffsetSliderLabel.BackColor = System.Drawing.Color.Transparent;
            this.AudioOffsetSliderLabel.Enabled = false;
            this.AudioOffsetSliderLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.AudioOffsetSliderLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AudioOffsetSliderLabel.Location = new System.Drawing.Point(289, 110);
            this.AudioOffsetSliderLabel.Name = "AudioOffsetSliderLabel";
            this.AudioOffsetSliderLabel.Size = new System.Drawing.Size(89, 23);
            this.AudioOffsetSliderLabel.TabIndex = 15;
            this.AudioOffsetSliderLabel.Text = "Audio Offset";
            // 
            // TimingPanelHeader
            // 
            this.TimingPanelHeader.Controls.Add(this.TimingPanelLabel);
            this.TimingPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimingPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.TimingPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.TimingPanelHeader.Name = "TimingPanelHeader";
            this.TimingPanelHeader.Size = new System.Drawing.Size(507, 47);
            this.TimingPanelHeader.TabIndex = 0;
            // 
            // TimingPanelLabel
            // 
            this.TimingPanelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TimingPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimingPanelLabel.Enabled = false;
            this.TimingPanelLabel.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.TimingPanelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.TimingPanelLabel.Location = new System.Drawing.Point(179, 7);
            this.TimingPanelLabel.Name = "TimingPanelLabel";
            this.TimingPanelLabel.Size = new System.Drawing.Size(148, 28);
            this.TimingPanelLabel.TabIndex = 5;
            this.TimingPanelLabel.Text = "Timing & Hitscan";
            this.TimingPanelLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AudioOffsetSliderNumeric
            // 
            this.AudioOffsetSliderNumeric.BackColor = System.Drawing.Color.Transparent;
            this.AudioOffsetSliderNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AudioOffsetSliderNumeric.BorderRadius = 5;
            this.AudioOffsetSliderNumeric.BorderThickness = 0;
            this.AudioOffsetSliderNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AudioOffsetSliderNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AudioOffsetSliderNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioOffsetSliderNumeric.ForeColor = System.Drawing.Color.White;
            this.AudioOffsetSliderNumeric.Location = new System.Drawing.Point(210, 111);
            this.AudioOffsetSliderNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AudioOffsetSliderNumeric.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.AudioOffsetSliderNumeric.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.AudioOffsetSliderNumeric.Name = "AudioOffsetSliderNumeric";
            this.AudioOffsetSliderNumeric.Size = new System.Drawing.Size(73, 21);
            this.AudioOffsetSliderNumeric.TabIndex = 14;
            this.AudioOffsetSliderNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.AudioOffsetSliderNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AudioOffsetSliderNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AudioOffsetSliderNumeric.ValueChanged += new System.EventHandler(this.AudioOffsetNumeric_ValueChange);
            // 
            // MaxBPMSlider
            // 
            this.MaxBPMSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaxBPMSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.MaxBPMSlider.Location = new System.Drawing.Point(12, 81);
            this.MaxBPMSlider.Maximum = 500;
            this.MaxBPMSlider.Minimum = 1;
            this.MaxBPMSlider.Name = "MaxBPMSlider";
            this.MaxBPMSlider.Size = new System.Drawing.Size(192, 23);
            this.MaxBPMSlider.TabIndex = 10;
            this.MaxBPMSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxBPMSlider.ValueChanged += new System.EventHandler(this.MaxBPMSlider_ValueChange);
            // 
            // AudioOffsetSlider
            // 
            this.AudioOffsetSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AudioOffsetSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.AudioOffsetSlider.Location = new System.Drawing.Point(12, 110);
            this.AudioOffsetSlider.Maximum = 300;
            this.AudioOffsetSlider.Minimum = -300;
            this.AudioOffsetSlider.Name = "AudioOffsetSlider";
            this.AudioOffsetSlider.Size = new System.Drawing.Size(192, 23);
            this.AudioOffsetSlider.TabIndex = 13;
            this.AudioOffsetSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AudioOffsetSlider.ValueChanged += new System.EventHandler(this.AudioOffsetSlider_ValueChanged);
            // 
            // MaxBPMNumeric
            // 
            this.MaxBPMNumeric.BackColor = System.Drawing.Color.Transparent;
            this.MaxBPMNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxBPMNumeric.BorderRadius = 5;
            this.MaxBPMNumeric.BorderThickness = 0;
            this.MaxBPMNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MaxBPMNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MaxBPMNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxBPMNumeric.ForeColor = System.Drawing.Color.White;
            this.MaxBPMNumeric.Location = new System.Drawing.Point(210, 82);
            this.MaxBPMNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaxBPMNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.MaxBPMNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxBPMNumeric.Name = "MaxBPMNumeric";
            this.MaxBPMNumeric.Size = new System.Drawing.Size(73, 21);
            this.MaxBPMNumeric.TabIndex = 11;
            this.MaxBPMNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.MaxBPMNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MaxBPMNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxBPMNumeric.ValueChanged += new System.EventHandler(this.MaxBPMNumeric_ValueChange);
            // 
            // MaxBPMLabel
            // 
            this.MaxBPMLabel.BackColor = System.Drawing.Color.Transparent;
            this.MaxBPMLabel.Enabled = false;
            this.MaxBPMLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MaxBPMLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MaxBPMLabel.Location = new System.Drawing.Point(289, 81);
            this.MaxBPMLabel.Name = "MaxBPMLabel";
            this.MaxBPMLabel.Size = new System.Drawing.Size(66, 23);
            this.MaxBPMLabel.TabIndex = 12;
            this.MaxBPMLabel.Text = "Max BPM";
            // 
            // AimbotTabPanel
            // 
            this.AimbotTabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.AimbotTabPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AimbotTabPanel.Controls.Add(this.HardrockEnabledLabelAA);
            this.AimbotTabPanel.Controls.Add(this.PullawayNumeric);
            this.AimbotTabPanel.Controls.Add(this.HardrockEnabledAA);
            this.AimbotTabPanel.Controls.Add(this.AimbotKeybindLabel);
            this.AimbotTabPanel.Controls.Add(this.PullawaySlider);
            this.AimbotTabPanel.Controls.Add(this.PullawayLabel);
            this.AimbotTabPanel.Controls.Add(this.AimbotKeybindSet);
            this.AimbotTabPanel.Controls.Add(this.StrengthLabel);
            this.AimbotTabPanel.Controls.Add(this.AimbotStrengthNumericUpDown);
            this.AimbotTabPanel.Controls.Add(this.AimbotStrengthSlider);
            this.AimbotTabPanel.Controls.Add(this.SmoothingLabel);
            this.AimbotTabPanel.Controls.Add(this.AimbotSmoothingSliderNumericUpDown);
            this.AimbotTabPanel.Controls.Add(this.AimbotSmoothingSlider);
            this.AimbotTabPanel.Controls.Add(this.FovLabel);
            this.AimbotTabPanel.Controls.Add(this.AimbotFovSliderNumericUpDown);
            this.AimbotTabPanel.Controls.Add(this.AimbotFovSlider);
            this.AimbotTabPanel.Controls.Add(this.AimbotTabPanelSwitchLabel);
            this.AimbotTabPanel.Controls.Add(this.AimbotTabPanelSwitch);
            this.AimbotTabPanel.Controls.Add(this.AimbotTabPanelHeader);
            this.AimbotTabPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AimbotTabPanel.Location = new System.Drawing.Point(35, 3);
            this.AimbotTabPanel.Name = "AimbotTabPanel";
            this.AimbotTabPanel.Size = new System.Drawing.Size(507, 228);
            this.AimbotTabPanel.TabIndex = 0;
            // 
            // HardrockEnabledLabelAA
            // 
            this.HardrockEnabledLabelAA.BackColor = System.Drawing.Color.Transparent;
            this.HardrockEnabledLabelAA.Enabled = false;
            this.HardrockEnabledLabelAA.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.HardrockEnabledLabelAA.ForeColor = System.Drawing.SystemColors.Control;
            this.HardrockEnabledLabelAA.Location = new System.Drawing.Point(289, 78);
            this.HardrockEnabledLabelAA.Name = "HardrockEnabledLabelAA";
            this.HardrockEnabledLabelAA.Size = new System.Drawing.Size(73, 23);
            this.HardrockEnabledLabelAA.TabIndex = 24;
            this.HardrockEnabledLabelAA.Text = "HR Aiming";
            // 
            // PullawayNumeric
            // 
            this.PullawayNumeric.BackColor = System.Drawing.Color.Transparent;
            this.PullawayNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PullawayNumeric.BorderRadius = 5;
            this.PullawayNumeric.BorderThickness = 0;
            this.PullawayNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PullawayNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PullawayNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PullawayNumeric.ForeColor = System.Drawing.Color.White;
            this.PullawayNumeric.Location = new System.Drawing.Point(210, 194);
            this.PullawayNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PullawayNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PullawayNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PullawayNumeric.Name = "PullawayNumeric";
            this.PullawayNumeric.Size = new System.Drawing.Size(73, 21);
            this.PullawayNumeric.TabIndex = 25;
            this.PullawayNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.PullawayNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PullawayNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PullawayNumeric.ValueChanged += new System.EventHandler(this.PullawayNumeric_ValueChanged);
            // 
            // HardrockEnabledAA
            // 
            this.HardrockEnabledAA.Animated = true;
            this.HardrockEnabledAA.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabledAA.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabledAA.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabledAA.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabledAA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardrockEnabledAA.Location = new System.Drawing.Point(248, 81);
            this.HardrockEnabledAA.Name = "HardrockEnabledAA";
            this.HardrockEnabledAA.Size = new System.Drawing.Size(35, 20);
            this.HardrockEnabledAA.TabIndex = 23;
            this.HardrockEnabledAA.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabledAA.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HardrockEnabledAA.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabledAA.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HardrockEnabledAA.CheckedChanged += new System.EventHandler(this.HardrockEnabledAA_CheckedChanged);
            // 
            // AimbotKeybindLabel
            // 
            this.AimbotKeybindLabel.BackColor = System.Drawing.Color.Transparent;
            this.AimbotKeybindLabel.Enabled = false;
            this.AimbotKeybindLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.AimbotKeybindLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AimbotKeybindLabel.Location = new System.Drawing.Point(112, 78);
            this.AimbotKeybindLabel.Name = "AimbotKeybindLabel";
            this.AimbotKeybindLabel.Size = new System.Drawing.Size(116, 23);
            this.AimbotKeybindLabel.TabIndex = 18;
            this.AimbotKeybindLabel.Text = "Change Keybind";
            // 
            // PullawaySlider
            // 
            this.PullawaySlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PullawaySlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.PullawaySlider.Location = new System.Drawing.Point(12, 193);
            this.PullawaySlider.Maximum = 1000;
            this.PullawaySlider.Minimum = 1;
            this.PullawaySlider.Name = "PullawaySlider";
            this.PullawaySlider.Size = new System.Drawing.Size(192, 23);
            this.PullawaySlider.TabIndex = 24;
            this.PullawaySlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PullawaySlider.ValueChanged += new System.EventHandler(this.PullawaySlider_ValueChanged);
            // 
            // PullawayLabel
            // 
            this.PullawayLabel.BackColor = System.Drawing.Color.Transparent;
            this.PullawayLabel.Enabled = false;
            this.PullawayLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.PullawayLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PullawayLabel.Location = new System.Drawing.Point(289, 193);
            this.PullawayLabel.Name = "PullawayLabel";
            this.PullawayLabel.Size = new System.Drawing.Size(127, 23);
            this.PullawayLabel.TabIndex = 23;
            this.PullawayLabel.Text = "Pullaway Distance";
            // 
            // AimbotKeybindSet
            // 
            this.AimbotKeybindSet.BorderRadius = 7;
            this.AimbotKeybindSet.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.AimbotKeybindSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotKeybindSet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AimbotKeybindSet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AimbotKeybindSet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.AimbotKeybindSet.DisabledState.ForeColor = System.Drawing.Color.White;
            this.AimbotKeybindSet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotKeybindSet.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotKeybindSet.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotKeybindSet.ForeColor = System.Drawing.Color.White;
            this.AimbotKeybindSet.Location = new System.Drawing.Point(12, 78);
            this.AimbotKeybindSet.Name = "AimbotKeybindSet";
            this.AimbotKeybindSet.Size = new System.Drawing.Size(94, 26);
            this.AimbotKeybindSet.TabIndex = 2;
            this.AimbotKeybindSet.Text = "Ctrl";
            this.AimbotKeybindSet.TextOffset = new System.Drawing.Point(0, -2);
            this.AimbotKeybindSet.Click += new System.EventHandler(this.AimbotKeybindSet_Click);
            // 
            // StrengthLabel
            // 
            this.StrengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.StrengthLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.StrengthLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.StrengthLabel.Location = new System.Drawing.Point(289, 164);
            this.StrengthLabel.Name = "StrengthLabel";
            this.StrengthLabel.Size = new System.Drawing.Size(63, 23);
            this.StrengthLabel.TabIndex = 12;
            this.StrengthLabel.Text = "Strength";
            // 
            // AimbotStrengthNumericUpDown
            // 
            this.AimbotStrengthNumericUpDown.BackColor = System.Drawing.Color.Transparent;
            this.AimbotStrengthNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotStrengthNumericUpDown.BorderRadius = 5;
            this.AimbotStrengthNumericUpDown.BorderThickness = 0;
            this.AimbotStrengthNumericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AimbotStrengthNumericUpDown.DecimalPlaces = 4;
            this.AimbotStrengthNumericUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotStrengthNumericUpDown.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotStrengthNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AimbotStrengthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.AimbotStrengthNumericUpDown.Location = new System.Drawing.Point(210, 165);
            this.AimbotStrengthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AimbotStrengthNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.AimbotStrengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.AimbotStrengthNumericUpDown.Name = "AimbotStrengthNumericUpDown";
            this.AimbotStrengthNumericUpDown.Size = new System.Drawing.Size(73, 21);
            this.AimbotStrengthNumericUpDown.TabIndex = 11;
            this.AimbotStrengthNumericUpDown.TextOffset = new System.Drawing.Point(0, -3);
            this.AimbotStrengthNumericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotStrengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AimbotStrengthNumericUpDown.ValueChanged += new System.EventHandler(this.AimbotStrengthNumericUpDown_ValueChanged);
            // 
            // AimbotStrengthSlider
            // 
            this.AimbotStrengthSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotStrengthSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.AimbotStrengthSlider.Location = new System.Drawing.Point(12, 164);
            this.AimbotStrengthSlider.Maximum = 10000;
            this.AimbotStrengthSlider.Minimum = 1;
            this.AimbotStrengthSlider.Name = "AimbotStrengthSlider";
            this.AimbotStrengthSlider.Size = new System.Drawing.Size(192, 23);
            this.AimbotStrengthSlider.TabIndex = 10;
            this.AimbotStrengthSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotStrengthSlider.ValueChanged += new System.EventHandler(this.AimbotStrengthSlider_ValueChanged);
            // 
            // SmoothingLabel
            // 
            this.SmoothingLabel.BackColor = System.Drawing.Color.Transparent;
            this.SmoothingLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.SmoothingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SmoothingLabel.Location = new System.Drawing.Point(289, 135);
            this.SmoothingLabel.Name = "SmoothingLabel";
            this.SmoothingLabel.Size = new System.Drawing.Size(78, 23);
            this.SmoothingLabel.TabIndex = 9;
            this.SmoothingLabel.Text = "Smoothing";
            // 
            // AimbotSmoothingSliderNumericUpDown
            // 
            this.AimbotSmoothingSliderNumericUpDown.BackColor = System.Drawing.Color.Transparent;
            this.AimbotSmoothingSliderNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotSmoothingSliderNumericUpDown.BorderRadius = 5;
            this.AimbotSmoothingSliderNumericUpDown.BorderThickness = 0;
            this.AimbotSmoothingSliderNumericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AimbotSmoothingSliderNumericUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotSmoothingSliderNumericUpDown.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotSmoothingSliderNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AimbotSmoothingSliderNumericUpDown.Location = new System.Drawing.Point(210, 136);
            this.AimbotSmoothingSliderNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AimbotSmoothingSliderNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AimbotSmoothingSliderNumericUpDown.Name = "AimbotSmoothingSliderNumericUpDown";
            this.AimbotSmoothingSliderNumericUpDown.Size = new System.Drawing.Size(73, 21);
            this.AimbotSmoothingSliderNumericUpDown.TabIndex = 8;
            this.AimbotSmoothingSliderNumericUpDown.TextOffset = new System.Drawing.Point(0, -3);
            this.AimbotSmoothingSliderNumericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotSmoothingSliderNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AimbotSmoothingSliderNumericUpDown.ValueChanged += new System.EventHandler(this.AimbotSmoothingSliderNumericUpDown_ValueChanged);
            // 
            // AimbotSmoothingSlider
            // 
            this.AimbotSmoothingSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotSmoothingSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.AimbotSmoothingSlider.Location = new System.Drawing.Point(12, 135);
            this.AimbotSmoothingSlider.Minimum = 1;
            this.AimbotSmoothingSlider.Name = "AimbotSmoothingSlider";
            this.AimbotSmoothingSlider.Size = new System.Drawing.Size(192, 23);
            this.AimbotSmoothingSlider.TabIndex = 7;
            this.AimbotSmoothingSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotSmoothingSlider.ValueChanged += new System.EventHandler(this.AimbotSmoothingSlider_ValueChanged);
            // 
            // FovLabel
            // 
            this.FovLabel.BackColor = System.Drawing.Color.Transparent;
            this.FovLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.FovLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.FovLabel.Location = new System.Drawing.Point(289, 106);
            this.FovLabel.Name = "FovLabel";
            this.FovLabel.Size = new System.Drawing.Size(59, 23);
            this.FovLabel.TabIndex = 6;
            this.FovLabel.Text = "Fov SIze";
            // 
            // AimbotFovSliderNumericUpDown
            // 
            this.AimbotFovSliderNumericUpDown.BackColor = System.Drawing.Color.Transparent;
            this.AimbotFovSliderNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotFovSliderNumericUpDown.BorderRadius = 5;
            this.AimbotFovSliderNumericUpDown.BorderThickness = 0;
            this.AimbotFovSliderNumericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AimbotFovSliderNumericUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotFovSliderNumericUpDown.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotFovSliderNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.AimbotFovSliderNumericUpDown.Location = new System.Drawing.Point(210, 107);
            this.AimbotFovSliderNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AimbotFovSliderNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AimbotFovSliderNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AimbotFovSliderNumericUpDown.Name = "AimbotFovSliderNumericUpDown";
            this.AimbotFovSliderNumericUpDown.Size = new System.Drawing.Size(73, 21);
            this.AimbotFovSliderNumericUpDown.TabIndex = 5;
            this.AimbotFovSliderNumericUpDown.TextOffset = new System.Drawing.Point(0, -3);
            this.AimbotFovSliderNumericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotFovSliderNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AimbotFovSliderNumericUpDown.ValueChanged += new System.EventHandler(this.AimbotFovSliderNumericUpDown_ValueChanged);
            // 
            // AimbotFovSlider
            // 
            this.AimbotFovSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotFovSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.AimbotFovSlider.Location = new System.Drawing.Point(12, 106);
            this.AimbotFovSlider.Maximum = 1000;
            this.AimbotFovSlider.Minimum = 1;
            this.AimbotFovSlider.Name = "AimbotFovSlider";
            this.AimbotFovSlider.Size = new System.Drawing.Size(192, 23);
            this.AimbotFovSlider.TabIndex = 3;
            this.AimbotFovSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotFovSlider.ValueChanged += new System.EventHandler(this.AimbotFovSlider_ValueChanged);
            // 
            // AimbotTabPanelSwitchLabel
            // 
            this.AimbotTabPanelSwitchLabel.BackColor = System.Drawing.Color.Transparent;
            this.AimbotTabPanelSwitchLabel.Enabled = false;
            this.AimbotTabPanelSwitchLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.AimbotTabPanelSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AimbotTabPanelSwitchLabel.Location = new System.Drawing.Point(53, 51);
            this.AimbotTabPanelSwitchLabel.Name = "AimbotTabPanelSwitchLabel";
            this.AimbotTabPanelSwitchLabel.Size = new System.Drawing.Size(60, 23);
            this.AimbotTabPanelSwitchLabel.TabIndex = 2;
            this.AimbotTabPanelSwitchLabel.Text = "Enabled";
            // 
            // AimbotTabPanelSwitch
            // 
            this.AimbotTabPanelSwitch.Animated = true;
            this.AimbotTabPanelSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotTabPanelSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotTabPanelSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotTabPanelSwitch.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotTabPanelSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotTabPanelSwitch.Location = new System.Drawing.Point(12, 54);
            this.AimbotTabPanelSwitch.Name = "AimbotTabPanelSwitch";
            this.AimbotTabPanelSwitch.Size = new System.Drawing.Size(35, 20);
            this.AimbotTabPanelSwitch.TabIndex = 1;
            this.AimbotTabPanelSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotTabPanelSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotTabPanelSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotTabPanelSwitch.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotTabPanelSwitch.CheckedChanged += new System.EventHandler(this.AimbotTabPanelSwitch_CheckedChanged);
            // 
            // AimbotTabPanelHeader
            // 
            this.AimbotTabPanelHeader.Controls.Add(this.AimbotTabPanelTitle);
            this.AimbotTabPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.AimbotTabPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.AimbotTabPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.AimbotTabPanelHeader.Name = "AimbotTabPanelHeader";
            this.AimbotTabPanelHeader.Size = new System.Drawing.Size(507, 47);
            this.AimbotTabPanelHeader.TabIndex = 0;
            // 
            // AimbotTabPanelTitle
            // 
            this.AimbotTabPanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AimbotTabPanelTitle.BackColor = System.Drawing.Color.Transparent;
            this.AimbotTabPanelTitle.Enabled = false;
            this.AimbotTabPanelTitle.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.AimbotTabPanelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.AimbotTabPanelTitle.Location = new System.Drawing.Point(209, 7);
            this.AimbotTabPanelTitle.Name = "AimbotTabPanelTitle";
            this.AimbotTabPanelTitle.Size = new System.Drawing.Size(88, 28);
            this.AimbotTabPanelTitle.TabIndex = 5;
            this.AimbotTabPanelTitle.Text = "Aim Assist";
            this.AimbotTabPanelTitle.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RelaxPanel
            // 
            this.RelaxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.RelaxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RelaxPanel.Controls.Add(this.RelaxKeybindLabel);
            this.RelaxPanel.Controls.Add(this.RelaxKeybindSet);
            this.RelaxPanel.Controls.Add(this.CurrentModsComboBox);
            this.RelaxPanel.Controls.Add(this.CurrentModsLabel);
            this.RelaxPanel.Controls.Add(this.PlaystyleComboBox);
            this.RelaxPanel.Controls.Add(this.PlaystyleComboBoxLabel);
            this.RelaxPanel.Controls.Add(this.RelaxPanelSwitchLabel);
            this.RelaxPanel.Controls.Add(this.RelaxPanelSwitch);
            this.RelaxPanel.Controls.Add(this.RelaxPanelHeader);
            this.RelaxPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RelaxPanel.Location = new System.Drawing.Point(35, 3);
            this.RelaxPanel.Name = "RelaxPanel";
            this.RelaxPanel.Size = new System.Drawing.Size(507, 228);
            this.RelaxPanel.TabIndex = 2;
            // 
            // RelaxKeybindLabel
            // 
            this.RelaxKeybindLabel.BackColor = System.Drawing.Color.Transparent;
            this.RelaxKeybindLabel.Enabled = false;
            this.RelaxKeybindLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.RelaxKeybindLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.RelaxKeybindLabel.Location = new System.Drawing.Point(112, 77);
            this.RelaxKeybindLabel.Name = "RelaxKeybindLabel";
            this.RelaxKeybindLabel.Size = new System.Drawing.Size(116, 23);
            this.RelaxKeybindLabel.TabIndex = 20;
            this.RelaxKeybindLabel.Text = "Change Keybind";
            // 
            // RelaxKeybindSet
            // 
            this.RelaxKeybindSet.BorderRadius = 7;
            this.RelaxKeybindSet.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.RelaxKeybindSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RelaxKeybindSet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RelaxKeybindSet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RelaxKeybindSet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.RelaxKeybindSet.DisabledState.ForeColor = System.Drawing.Color.White;
            this.RelaxKeybindSet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RelaxKeybindSet.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RelaxKeybindSet.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelaxKeybindSet.ForeColor = System.Drawing.Color.White;
            this.RelaxKeybindSet.Location = new System.Drawing.Point(12, 77);
            this.RelaxKeybindSet.Name = "RelaxKeybindSet";
            this.RelaxKeybindSet.Size = new System.Drawing.Size(94, 26);
            this.RelaxKeybindSet.TabIndex = 19;
            this.RelaxKeybindSet.Text = "Ctrl";
            this.RelaxKeybindSet.TextOffset = new System.Drawing.Point(0, -2);
            this.RelaxKeybindSet.Click += new System.EventHandler(this.RelaxKeybindSet_Click);
            // 
            // CurrentModsComboBox
            // 
            this.CurrentModsComboBox.BackColor = System.Drawing.Color.Transparent;
            this.CurrentModsComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CurrentModsComboBox.BorderRadius = 15;
            this.CurrentModsComboBox.BorderThickness = 0;
            this.CurrentModsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CurrentModsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CurrentModsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentModsComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CurrentModsComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CurrentModsComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CurrentModsComboBox.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentModsComboBox.ForeColor = System.Drawing.Color.White;
            this.CurrentModsComboBox.ItemHeight = 30;
            this.CurrentModsComboBox.Items.AddRange(new object[] {
            "None",
            "DoubleTime",
            "Nightcore",
            "HalfTime"});
            this.CurrentModsComboBox.Location = new System.Drawing.Point(13, 148);
            this.CurrentModsComboBox.Name = "CurrentModsComboBox";
            this.CurrentModsComboBox.Size = new System.Drawing.Size(140, 36);
            this.CurrentModsComboBox.TabIndex = 10;
            this.CurrentModsComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrentModsComboBox_SelectedIndexChanged);
            // 
            // CurrentModsLabel
            // 
            this.CurrentModsLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentModsLabel.Enabled = false;
            this.CurrentModsLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.CurrentModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentModsLabel.Location = new System.Drawing.Point(159, 155);
            this.CurrentModsLabel.Name = "CurrentModsLabel";
            this.CurrentModsLabel.Size = new System.Drawing.Size(98, 23);
            this.CurrentModsLabel.TabIndex = 9;
            this.CurrentModsLabel.Text = "Current Mods";
            // 
            // PlaystyleComboBox
            // 
            this.PlaystyleComboBox.BackColor = System.Drawing.Color.Transparent;
            this.PlaystyleComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PlaystyleComboBox.BorderRadius = 15;
            this.PlaystyleComboBox.BorderThickness = 0;
            this.PlaystyleComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlaystyleComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PlaystyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaystyleComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PlaystyleComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PlaystyleComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.PlaystyleComboBox.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaystyleComboBox.ForeColor = System.Drawing.Color.White;
            this.PlaystyleComboBox.ItemHeight = 30;
            this.PlaystyleComboBox.Items.AddRange(new object[] {
            "Single Tap",
            "Alternate",
            "Mouse Only",
            "TapX"});
            this.PlaystyleComboBox.Location = new System.Drawing.Point(13, 106);
            this.PlaystyleComboBox.Name = "PlaystyleComboBox";
            this.PlaystyleComboBox.Size = new System.Drawing.Size(140, 36);
            this.PlaystyleComboBox.TabIndex = 8;
            this.PlaystyleComboBox.SelectedIndexChanged += new System.EventHandler(this.PlaystyleComboBox_SelectedIndexChanged);
            // 
            // PlaystyleComboBoxLabel
            // 
            this.PlaystyleComboBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlaystyleComboBoxLabel.Enabled = false;
            this.PlaystyleComboBoxLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.PlaystyleComboBoxLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PlaystyleComboBoxLabel.Location = new System.Drawing.Point(159, 113);
            this.PlaystyleComboBoxLabel.Name = "PlaystyleComboBoxLabel";
            this.PlaystyleComboBoxLabel.Size = new System.Drawing.Size(62, 23);
            this.PlaystyleComboBoxLabel.TabIndex = 7;
            this.PlaystyleComboBoxLabel.Text = "Playstyle";
            // 
            // RelaxPanelSwitchLabel
            // 
            this.RelaxPanelSwitchLabel.BackColor = System.Drawing.Color.Transparent;
            this.RelaxPanelSwitchLabel.Enabled = false;
            this.RelaxPanelSwitchLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.RelaxPanelSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.RelaxPanelSwitchLabel.Location = new System.Drawing.Point(53, 51);
            this.RelaxPanelSwitchLabel.Name = "RelaxPanelSwitchLabel";
            this.RelaxPanelSwitchLabel.Size = new System.Drawing.Size(60, 23);
            this.RelaxPanelSwitchLabel.TabIndex = 2;
            this.RelaxPanelSwitchLabel.Text = "Enabled";
            // 
            // RelaxPanelSwitch
            // 
            this.RelaxPanelSwitch.Animated = true;
            this.RelaxPanelSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RelaxPanelSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RelaxPanelSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RelaxPanelSwitch.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RelaxPanelSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RelaxPanelSwitch.Location = new System.Drawing.Point(12, 54);
            this.RelaxPanelSwitch.Name = "RelaxPanelSwitch";
            this.RelaxPanelSwitch.Size = new System.Drawing.Size(35, 20);
            this.RelaxPanelSwitch.TabIndex = 1;
            this.RelaxPanelSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RelaxPanelSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RelaxPanelSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RelaxPanelSwitch.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RelaxPanelSwitch.CheckedChanged += new System.EventHandler(this.RelaxPanelSwitch_CheckedChanged);
            // 
            // RelaxPanelHeader
            // 
            this.RelaxPanelHeader.Controls.Add(this.RelaxPanelLabel);
            this.RelaxPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.RelaxPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.RelaxPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.RelaxPanelHeader.Name = "RelaxPanelHeader";
            this.RelaxPanelHeader.Size = new System.Drawing.Size(507, 47);
            this.RelaxPanelHeader.TabIndex = 0;
            // 
            // RelaxPanelLabel
            // 
            this.RelaxPanelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RelaxPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.RelaxPanelLabel.Enabled = false;
            this.RelaxPanelLabel.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.RelaxPanelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.RelaxPanelLabel.Location = new System.Drawing.Point(229, 7);
            this.RelaxPanelLabel.Name = "RelaxPanelLabel";
            this.RelaxPanelLabel.Size = new System.Drawing.Size(48, 28);
            this.RelaxPanelLabel.TabIndex = 5;
            this.RelaxPanelLabel.Text = "Relax";
            this.RelaxPanelLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConfigPanel
            // 
            this.ConfigPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.ConfigPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConfigPanel.Controls.Add(this.AdvancedButton);
            this.ConfigPanel.Controls.Add(this.CreateConfigButton);
            this.ConfigPanel.Controls.Add(this.CreateConfigText);
            this.ConfigPanel.Controls.Add(this.DeleteConfigButton);
            this.ConfigPanel.Controls.Add(this.ResetConfigButton);
            this.ConfigPanel.Controls.Add(this.LoadConfigButton);
            this.ConfigPanel.Controls.Add(this.SaveConfigButton);
            this.ConfigPanel.Controls.Add(this.ConfigTableHeader);
            this.ConfigPanel.Controls.Add(this.ConfigTable);
            this.ConfigPanel.Controls.Add(this.ConfigComboBox);
            this.ConfigPanel.Controls.Add(this.ConfigPanelHeader);
            this.ConfigPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConfigPanel.Location = new System.Drawing.Point(35, 3);
            this.ConfigPanel.Name = "ConfigPanel";
            this.ConfigPanel.Size = new System.Drawing.Size(507, 465);
            this.ConfigPanel.TabIndex = 22;
            // 
            // AdvancedButton
            // 
            this.AdvancedButton.BorderRadius = 15;
            this.AdvancedButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AdvancedButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AdvancedButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AdvancedButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AdvancedButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AdvancedButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.AdvancedButton.ForeColor = System.Drawing.Color.White;
            this.AdvancedButton.Location = new System.Drawing.Point(284, 220);
            this.AdvancedButton.Name = "AdvancedButton";
            this.AdvancedButton.Size = new System.Drawing.Size(207, 34);
            this.AdvancedButton.TabIndex = 31;
            this.AdvancedButton.Text = "Advanced";
            this.AdvancedButton.Click += new System.EventHandler(this.AdvancedButton_Click);
            // 
            // CreateConfigButton
            // 
            this.CreateConfigButton.BorderRadius = 15;
            this.CreateConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CreateConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CreateConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CreateConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CreateConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CreateConfigButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.CreateConfigButton.ForeColor = System.Drawing.Color.White;
            this.CreateConfigButton.Location = new System.Drawing.Point(284, 415);
            this.CreateConfigButton.Name = "CreateConfigButton";
            this.CreateConfigButton.Size = new System.Drawing.Size(207, 34);
            this.CreateConfigButton.TabIndex = 30;
            this.CreateConfigButton.Text = "Create";
            this.CreateConfigButton.Click += new System.EventHandler(this.CreateConfigButton_Click);
            // 
            // CreateConfigText
            // 
            this.CreateConfigText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CreateConfigText.BorderRadius = 10;
            this.CreateConfigText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CreateConfigText.DefaultText = "";
            this.CreateConfigText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CreateConfigText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CreateConfigText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CreateConfigText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CreateConfigText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CreateConfigText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.CreateConfigText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateConfigText.ForeColor = System.Drawing.Color.White;
            this.CreateConfigText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.CreateConfigText.Location = new System.Drawing.Point(284, 375);
            this.CreateConfigText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateConfigText.MaxLength = 300;
            this.CreateConfigText.Name = "CreateConfigText";
            this.CreateConfigText.PasswordChar = '\0';
            this.CreateConfigText.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.CreateConfigText.PlaceholderText = "config.json";
            this.CreateConfigText.SelectedText = "";
            this.CreateConfigText.Size = new System.Drawing.Size(207, 34);
            this.CreateConfigText.TabIndex = 29;
            this.CreateConfigText.WordWrap = false;
            // 
            // DeleteConfigButton
            // 
            this.DeleteConfigButton.BorderRadius = 15;
            this.DeleteConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DeleteConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DeleteConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DeleteConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DeleteConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DeleteConfigButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.DeleteConfigButton.ForeColor = System.Drawing.Color.White;
            this.DeleteConfigButton.Location = new System.Drawing.Point(284, 180);
            this.DeleteConfigButton.Name = "DeleteConfigButton";
            this.DeleteConfigButton.Size = new System.Drawing.Size(207, 34);
            this.DeleteConfigButton.TabIndex = 28;
            this.DeleteConfigButton.Text = "Delete";
            this.DeleteConfigButton.Click += new System.EventHandler(this.DeleteConfigButton_Click);
            // 
            // ResetConfigButton
            // 
            this.ResetConfigButton.BorderRadius = 15;
            this.ResetConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ResetConfigButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.ResetConfigButton.ForeColor = System.Drawing.Color.White;
            this.ResetConfigButton.Location = new System.Drawing.Point(284, 140);
            this.ResetConfigButton.Name = "ResetConfigButton";
            this.ResetConfigButton.Size = new System.Drawing.Size(207, 34);
            this.ResetConfigButton.TabIndex = 27;
            this.ResetConfigButton.Text = "Reset";
            this.ResetConfigButton.Click += new System.EventHandler(this.ResetConfigButton_Click);
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.BorderRadius = 15;
            this.LoadConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoadConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoadConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoadConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoadConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LoadConfigButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.LoadConfigButton.ForeColor = System.Drawing.Color.White;
            this.LoadConfigButton.Location = new System.Drawing.Point(284, 100);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(207, 34);
            this.LoadConfigButton.TabIndex = 26;
            this.LoadConfigButton.Text = "Load";
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.BorderRadius = 15;
            this.SaveConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SaveConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SaveConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SaveConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SaveConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveConfigButton.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.SaveConfigButton.ForeColor = System.Drawing.Color.White;
            this.SaveConfigButton.Location = new System.Drawing.Point(284, 60);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(207, 34);
            this.SaveConfigButton.TabIndex = 25;
            this.SaveConfigButton.Text = "Save";
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // ConfigTableHeader
            // 
            this.ConfigTableHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ConfigTableHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ConfigTableHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConfigTableHeader.Controls.Add(this.CloudConfigButton);
            this.ConfigTableHeader.Controls.Add(this.LocalConfigButton);
            this.ConfigTableHeader.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConfigTableHeader.Location = new System.Drawing.Point(13, 57);
            this.ConfigTableHeader.Name = "ConfigTableHeader";
            this.ConfigTableHeader.Size = new System.Drawing.Size(245, 36);
            this.ConfigTableHeader.TabIndex = 24;
            // 
            // CloudConfigButton
            // 
            this.CloudConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CloudConfigButton.BackColor = System.Drawing.Color.Transparent;
            this.CloudConfigButton.BorderRadius = 5;
            this.CloudConfigButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.CloudConfigButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloudConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloudConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloudConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloudConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloudConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.CloudConfigButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F);
            this.CloudConfigButton.ForeColor = System.Drawing.Color.White;
            this.CloudConfigButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CloudConfigButton.Location = new System.Drawing.Point(124, 4);
            this.CloudConfigButton.Name = "CloudConfigButton";
            this.CloudConfigButton.Size = new System.Drawing.Size(116, 27);
            this.CloudConfigButton.TabIndex = 26;
            this.CloudConfigButton.Text = "Cloud";
            // 
            // LocalConfigButton
            // 
            this.LocalConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LocalConfigButton.BackColor = System.Drawing.Color.Transparent;
            this.LocalConfigButton.BorderRadius = 5;
            this.LocalConfigButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.LocalConfigButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LocalConfigButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LocalConfigButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LocalConfigButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LocalConfigButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LocalConfigButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LocalConfigButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F);
            this.LocalConfigButton.ForeColor = System.Drawing.Color.White;
            this.LocalConfigButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.LocalConfigButton.Location = new System.Drawing.Point(5, 4);
            this.LocalConfigButton.Name = "LocalConfigButton";
            this.LocalConfigButton.Size = new System.Drawing.Size(116, 27);
            this.LocalConfigButton.TabIndex = 25;
            this.LocalConfigButton.Text = "Local";
            // 
            // ConfigTable
            // 
            this.ConfigTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ConfigTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ConfigTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConfigTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConfigTable.Location = new System.Drawing.Point(14, 96);
            this.ConfigTable.Name = "ConfigTable";
            this.ConfigTable.Size = new System.Drawing.Size(245, 313);
            this.ConfigTable.TabIndex = 23;
            // 
            // ConfigComboBox
            // 
            this.ConfigComboBox.BackColor = System.Drawing.Color.Transparent;
            this.ConfigComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ConfigComboBox.BorderRadius = 15;
            this.ConfigComboBox.BorderThickness = 0;
            this.ConfigComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfigComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ConfigComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ConfigComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ConfigComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ConfigComboBox.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigComboBox.ForeColor = System.Drawing.Color.White;
            this.ConfigComboBox.ItemHeight = 30;
            this.ConfigComboBox.Location = new System.Drawing.Point(14, 415);
            this.ConfigComboBox.Name = "ConfigComboBox";
            this.ConfigComboBox.Size = new System.Drawing.Size(245, 36);
            this.ConfigComboBox.TabIndex = 10;
            this.ConfigComboBox.SelectedIndexChanged += new System.EventHandler(this.ConfigComboBox_SelectedIndexChanged);
            // 
            // ConfigPanelHeader
            // 
            this.ConfigPanelHeader.Controls.Add(this.ConfigPanelHeaderLabel);
            this.ConfigPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfigPanelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ConfigPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.ConfigPanelHeader.Name = "ConfigPanelHeader";
            this.ConfigPanelHeader.Size = new System.Drawing.Size(507, 47);
            this.ConfigPanelHeader.TabIndex = 0;
            // 
            // ConfigPanelHeaderLabel
            // 
            this.ConfigPanelHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ConfigPanelHeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConfigPanelHeaderLabel.Enabled = false;
            this.ConfigPanelHeaderLabel.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.ConfigPanelHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.ConfigPanelHeaderLabel.Location = new System.Drawing.Point(224, 7);
            this.ConfigPanelHeaderLabel.Name = "ConfigPanelHeaderLabel";
            this.ConfigPanelHeaderLabel.Size = new System.Drawing.Size(59, 28);
            this.ConfigPanelHeaderLabel.TabIndex = 5;
            this.ConfigPanelHeaderLabel.Text = "Config";
            this.ConfigPanelHeaderLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SpooferPanel
            // 
            this.SpooferPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.SpooferPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SpooferPanel.Controls.Add(this.CheckSerialsButton);
            this.SpooferPanel.Controls.Add(this.SpoofSerialsButton);
            this.SpooferPanel.Controls.Add(this.SerialsPanel);
            this.SpooferPanel.Controls.Add(this.SpooferHeader);
            this.SpooferPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SpooferPanel.Location = new System.Drawing.Point(35, 3);
            this.SpooferPanel.Name = "SpooferPanel";
            this.SpooferPanel.Size = new System.Drawing.Size(507, 465);
            this.SpooferPanel.TabIndex = 21;
            // 
            // CheckSerialsButton
            // 
            this.CheckSerialsButton.BorderRadius = 15;
            this.CheckSerialsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckSerialsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CheckSerialsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CheckSerialsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CheckSerialsButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CheckSerialsButton.Font = new System.Drawing.Font("Comfortaa", 11F);
            this.CheckSerialsButton.ForeColor = System.Drawing.Color.White;
            this.CheckSerialsButton.Location = new System.Drawing.Point(262, 393);
            this.CheckSerialsButton.Name = "CheckSerialsButton";
            this.CheckSerialsButton.Size = new System.Drawing.Size(231, 45);
            this.CheckSerialsButton.TabIndex = 3;
            this.CheckSerialsButton.Text = "Check serials";
            this.CheckSerialsButton.Click += new System.EventHandler(this.CheckSerialsButton_Click);
            // 
            // SpoofSerialsButton
            // 
            this.SpoofSerialsButton.BorderRadius = 15;
            this.SpoofSerialsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SpoofSerialsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SpoofSerialsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SpoofSerialsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SpoofSerialsButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SpoofSerialsButton.Font = new System.Drawing.Font("Comfortaa", 11F);
            this.SpoofSerialsButton.ForeColor = System.Drawing.Color.White;
            this.SpoofSerialsButton.Location = new System.Drawing.Point(14, 393);
            this.SpoofSerialsButton.Name = "SpoofSerialsButton";
            this.SpoofSerialsButton.Size = new System.Drawing.Size(231, 45);
            this.SpoofSerialsButton.TabIndex = 2;
            this.SpoofSerialsButton.Text = "Spoof serials";
            this.SpoofSerialsButton.Click += new System.EventHandler(this.SpoofSerialsButton_Click);
            // 
            // SerialsPanel
            // 
            this.SerialsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SerialsPanel.Controls.Add(this.MACSerial);
            this.SerialsPanel.Controls.Add(this.MacLabel);
            this.SerialsPanel.Controls.Add(this.DiskSerial);
            this.SerialsPanel.Controls.Add(this.DiskLabel);
            this.SerialsPanel.Controls.Add(this.Separator);
            this.SerialsPanel.Controls.Add(this.BaseBoardSerial);
            this.SerialsPanel.Controls.Add(this.BaseBoardLabel);
            this.SerialsPanel.Controls.Add(this.CpuSerial);
            this.SerialsPanel.Controls.Add(this.CpuLabel);
            this.SerialsPanel.Location = new System.Drawing.Point(14, 59);
            this.SerialsPanel.Name = "SerialsPanel";
            this.SerialsPanel.Size = new System.Drawing.Size(480, 314);
            this.SerialsPanel.TabIndex = 1;
            // 
            // MACSerial
            // 
            this.MACSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MACSerial.BorderRadius = 10;
            this.MACSerial.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MACSerial.DefaultText = "";
            this.MACSerial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MACSerial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MACSerial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MACSerial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MACSerial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MACSerial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.MACSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MACSerial.ForeColor = System.Drawing.Color.White;
            this.MACSerial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.MACSerial.Location = new System.Drawing.Point(262, 145);
            this.MACSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MACSerial.MaxLength = 300;
            this.MACSerial.Name = "MACSerial";
            this.MACSerial.PasswordChar = '\0';
            this.MACSerial.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.MACSerial.PlaceholderText = "SERIAL-HERE";
            this.MACSerial.SelectedText = "";
            this.MACSerial.Size = new System.Drawing.Size(199, 27);
            this.MACSerial.TabIndex = 37;
            this.MACSerial.WordWrap = false;
            // 
            // MacLabel
            // 
            this.MacLabel.BackColor = System.Drawing.Color.Transparent;
            this.MacLabel.Enabled = false;
            this.MacLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MacLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MacLabel.Location = new System.Drawing.Point(262, 116);
            this.MacLabel.Name = "MacLabel";
            this.MacLabel.Size = new System.Drawing.Size(97, 23);
            this.MacLabel.TabIndex = 36;
            this.MacLabel.Text = "MAC Address:";
            this.MacLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DiskSerial
            // 
            this.DiskSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DiskSerial.BorderRadius = 10;
            this.DiskSerial.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DiskSerial.DefaultText = "";
            this.DiskSerial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DiskSerial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DiskSerial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DiskSerial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DiskSerial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DiskSerial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DiskSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiskSerial.ForeColor = System.Drawing.Color.White;
            this.DiskSerial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DiskSerial.Location = new System.Drawing.Point(21, 145);
            this.DiskSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DiskSerial.MaxLength = 300;
            this.DiskSerial.Name = "DiskSerial";
            this.DiskSerial.PasswordChar = '\0';
            this.DiskSerial.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.DiskSerial.PlaceholderText = "SERIAL-HERE";
            this.DiskSerial.SelectedText = "";
            this.DiskSerial.Size = new System.Drawing.Size(199, 27);
            this.DiskSerial.TabIndex = 35;
            this.DiskSerial.WordWrap = false;
            // 
            // DiskLabel
            // 
            this.DiskLabel.BackColor = System.Drawing.Color.Transparent;
            this.DiskLabel.Enabled = false;
            this.DiskLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.DiskLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DiskLabel.Location = new System.Drawing.Point(21, 116);
            this.DiskLabel.Name = "DiskLabel";
            this.DiskLabel.Size = new System.Drawing.Size(78, 23);
            this.DiskLabel.TabIndex = 34;
            this.DiskLabel.Text = "Disk Serial:";
            this.DiskLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Separator
            // 
            this.Separator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Separator.Location = new System.Drawing.Point(235, 0);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(10, 314);
            this.Separator.TabIndex = 33;
            // 
            // BaseBoardSerial
            // 
            this.BaseBoardSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BaseBoardSerial.BorderRadius = 10;
            this.BaseBoardSerial.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BaseBoardSerial.DefaultText = "";
            this.BaseBoardSerial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BaseBoardSerial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BaseBoardSerial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BaseBoardSerial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BaseBoardSerial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BaseBoardSerial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.BaseBoardSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseBoardSerial.ForeColor = System.Drawing.Color.White;
            this.BaseBoardSerial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.BaseBoardSerial.Location = new System.Drawing.Point(262, 50);
            this.BaseBoardSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BaseBoardSerial.MaxLength = 300;
            this.BaseBoardSerial.Name = "BaseBoardSerial";
            this.BaseBoardSerial.PasswordChar = '\0';
            this.BaseBoardSerial.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.BaseBoardSerial.PlaceholderText = "SERIAL-HERE";
            this.BaseBoardSerial.SelectedText = "";
            this.BaseBoardSerial.Size = new System.Drawing.Size(199, 27);
            this.BaseBoardSerial.TabIndex = 32;
            this.BaseBoardSerial.WordWrap = false;
            // 
            // BaseBoardLabel
            // 
            this.BaseBoardLabel.BackColor = System.Drawing.Color.Transparent;
            this.BaseBoardLabel.Enabled = false;
            this.BaseBoardLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.BaseBoardLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseBoardLabel.Location = new System.Drawing.Point(262, 21);
            this.BaseBoardLabel.Name = "BaseBoardLabel";
            this.BaseBoardLabel.Size = new System.Drawing.Size(125, 23);
            this.BaseBoardLabel.TabIndex = 31;
            this.BaseBoardLabel.Text = "BaseBoard Serial:";
            this.BaseBoardLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CpuSerial
            // 
            this.CpuSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CpuSerial.BorderRadius = 10;
            this.CpuSerial.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CpuSerial.DefaultText = "";
            this.CpuSerial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.CpuSerial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CpuSerial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CpuSerial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CpuSerial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CpuSerial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.CpuSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CpuSerial.ForeColor = System.Drawing.Color.White;
            this.CpuSerial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.CpuSerial.Location = new System.Drawing.Point(20, 50);
            this.CpuSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CpuSerial.MaxLength = 300;
            this.CpuSerial.Name = "CpuSerial";
            this.CpuSerial.PasswordChar = '\0';
            this.CpuSerial.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.CpuSerial.PlaceholderText = "SERIAL-HERE";
            this.CpuSerial.SelectedText = "";
            this.CpuSerial.Size = new System.Drawing.Size(199, 27);
            this.CpuSerial.TabIndex = 30;
            this.CpuSerial.WordWrap = false;
            // 
            // CpuLabel
            // 
            this.CpuLabel.BackColor = System.Drawing.Color.Transparent;
            this.CpuLabel.Enabled = false;
            this.CpuLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.CpuLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CpuLabel.Location = new System.Drawing.Point(20, 21);
            this.CpuLabel.Name = "CpuLabel";
            this.CpuLabel.Size = new System.Drawing.Size(78, 23);
            this.CpuLabel.TabIndex = 21;
            this.CpuLabel.Text = "Cpu Serial:";
            this.CpuLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SpooferHeader
            // 
            this.SpooferHeader.Controls.Add(this.SpooferHeaderLabel);
            this.SpooferHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpooferHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.SpooferHeader.Location = new System.Drawing.Point(0, 0);
            this.SpooferHeader.Name = "SpooferHeader";
            this.SpooferHeader.Size = new System.Drawing.Size(507, 47);
            this.SpooferHeader.TabIndex = 0;
            // 
            // SpooferHeaderLabel
            // 
            this.SpooferHeaderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SpooferHeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpooferHeaderLabel.Enabled = false;
            this.SpooferHeaderLabel.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.SpooferHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(194)))));
            this.SpooferHeaderLabel.Location = new System.Drawing.Point(218, 7);
            this.SpooferHeaderLabel.Name = "SpooferHeaderLabel";
            this.SpooferHeaderLabel.Size = new System.Drawing.Size(70, 28);
            this.SpooferHeaderLabel.TabIndex = 5;
            this.SpooferHeaderLabel.Text = "Spoofer";
            this.SpooferHeaderLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DragZone2
            // 
            this.DragZone2.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragZone2.Location = new System.Drawing.Point(0, 0);
            this.DragZone2.Name = "DragZone2";
            this.DragZone2.Size = new System.Drawing.Size(578, 32);
            this.DragZone2.TabIndex = 0;
            this.DragZone2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseDown);
            this.DragZone2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseMove);
            this.DragZone2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseUp);
            // 
            // SidepanelButtonsBorder
            // 
            this.SidepanelButtonsBorder.BorderRadius = 20;
            this.SidepanelButtonsBorder.TargetControl = this.SidepanelButtons;
            // 
            // MiniCreditsBorder
            // 
            this.MiniCreditsBorder.BorderRadius = 20;
            this.MiniCreditsBorder.TargetControl = this.MiniCredits;
            // 
            // AimbotTabPanelBorder
            // 
            this.AimbotTabPanelBorder.BorderRadius = 50;
            this.AimbotTabPanelBorder.TargetControl = this.AimbotTabPanel;
            // 
            // DetectionPanelBorder
            // 
            this.DetectionPanelBorder.BorderRadius = 50;
            this.DetectionPanelBorder.TargetControl = this.DetectionPanel;
            // 
            // RelaxPanelBorder
            // 
            this.RelaxPanelBorder.BorderRadius = 50;
            this.RelaxPanelBorder.TargetControl = this.RelaxPanel;
            // 
            // TimingPanelBorder
            // 
            this.TimingPanelBorder.BorderRadius = 50;
            this.TimingPanelBorder.TargetControl = this.TimingPanel;
            // 
            // SpooferPanelBorder
            // 
            this.SpooferPanelBorder.BorderRadius = 50;
            this.SpooferPanelBorder.TargetControl = this.SpooferPanel;
            // 
            // SerialsBorder
            // 
            this.SerialsBorder.BorderRadius = 30;
            this.SerialsBorder.TargetControl = this.SerialsPanel;
            // 
            // ConfigPanelBorder
            // 
            this.ConfigPanelBorder.BorderRadius = 50;
            this.ConfigPanelBorder.TargetControl = this.ConfigPanel;
            // 
            // ConfigTableBorder
            // 
            this.ConfigTableBorder.BorderRadius = 15;
            this.ConfigTableBorder.TargetControl = this.ConfigTable;
            // 
            // ConfigTableHeaderBorder
            // 
            this.ConfigTableHeaderBorder.BorderRadius = 15;
            this.ConfigTableHeaderBorder.TargetControl = this.ConfigTableHeader;
            // 
            // MainGUI
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(817, 534);
            this.Controls.Add(this.MainContent);
            this.Controls.Add(this.Sidepanel);
            this.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGUI";
            this.Text = "Osussist v3 | By: Takkeshi | https://takkeshi.pages.dev";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.Sidepanel.ResumeLayout(false);
            this.Sidepanel.PerformLayout();
            this.MiniCredits.ResumeLayout(false);
            this.MiniCredits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreditsImage)).EndInit();
            this.SidepanelButtons.ResumeLayout(false);
            this.MainContent.ResumeLayout(false);
            this.Content.ResumeLayout(false);
            this.DetectionPanel.ResumeLayout(false);
            this.DetectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimilarityNumeric)).EndInit();
            this.DetectionPanelHeader.ResumeLayout(false);
            this.DetectionPanelHeader.PerformLayout();
            this.TimingPanel.ResumeLayout(false);
            this.TimingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDistanceNumeric)).EndInit();
            this.TimingPanelHeader.ResumeLayout(false);
            this.TimingPanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOffsetSliderNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBPMNumeric)).EndInit();
            this.AimbotTabPanel.ResumeLayout(false);
            this.AimbotTabPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PullawayNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotStrengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotSmoothingSliderNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AimbotFovSliderNumericUpDown)).EndInit();
            this.AimbotTabPanelHeader.ResumeLayout(false);
            this.AimbotTabPanelHeader.PerformLayout();
            this.RelaxPanel.ResumeLayout(false);
            this.RelaxPanel.PerformLayout();
            this.RelaxPanelHeader.ResumeLayout(false);
            this.RelaxPanelHeader.PerformLayout();
            this.ConfigPanel.ResumeLayout(false);
            this.ConfigTableHeader.ResumeLayout(false);
            this.ConfigPanelHeader.ResumeLayout(false);
            this.ConfigPanelHeader.PerformLayout();
            this.SpooferPanel.ResumeLayout(false);
            this.SerialsPanel.ResumeLayout(false);
            this.SerialsPanel.PerformLayout();
            this.SpooferHeader.ResumeLayout(false);
            this.SpooferHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            AimbotButton_Click(sender, e);
        }

        private void DragZone_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void DragZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void DragZone_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void AimbotButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            AimbotButton.Checked = true;
            this.AimbotTabPanel.Show();
            this.AimbotTabPanelSwitch.Checked = Config.config.aimbotenabled;

            // Set keybind
            this.AimbotKeybindSet.Text = Config.config.keybindings.aimbotkey.ToString();

            // Hardrock
            this.HardrockEnabledAA.Checked = Config.config.aimbotsettings.hardrockenabled;

            // FOV Size
            int fovSize = Math.Max(this.AimbotFovSlider.Minimum, Math.Min(this.AimbotFovSlider.Maximum, Config.config.aimbotsettings.fovsize));
            this.AimbotFovSlider.Value = fovSize;
            this.AimbotFovSliderNumericUpDown.Value = fovSize;

            // Smoothing
            int smoothing = Math.Max(this.AimbotSmoothingSlider.Minimum, Math.Min(this.AimbotSmoothingSlider.Maximum, Config.config.aimbotsettings.smoothing));
            this.AimbotSmoothingSlider.Value = smoothing;
            this.AimbotSmoothingSliderNumericUpDown.Value = smoothing;

            // Strength
            int strengthSliderValue = Math.Max(this.AimbotStrengthSlider.Minimum, Math.Min(this.AimbotStrengthSlider.Maximum, (int)(Config.config.aimbotsettings.strength * 10000)));
            this.AimbotStrengthSlider.Value = strengthSliderValue;
            this.AimbotStrengthNumericUpDown.Value = (decimal)Math.Min(1f, (Config.config.aimbotsettings.strength + (float)AimbotStrengthNumericUpDown.Increment));

            // Pullaway
            int pullaway = Math.Max(this.PullawaySlider.Minimum, Math.Min(this.PullawaySlider.Maximum, Config.config.aimbotsettings.pullawaydistance));
            this.PullawaySlider.Value = pullaway;
            this.PullawayNumeric.Value = pullaway;

            // Detection
            this.DetectionPanel.Show();

            //Mouse Algotrithm
            this.MouseAlgorithmCombo.SelectedIndex = (int)Config.config.aimbotsettings.algorithm;

            // Sensitivity
            int sensitivitySliderValue = Math.Max(this.SensitivitySlider.Minimum, Math.Min(this.SensitivitySlider.Maximum, (int)(Config.config.osusettings.sensitivity * 10)));
            this.SensitivitySlider.Value = sensitivitySliderValue;
            this.SensitivityNumeric.Value = (decimal)Math.Min(6f, (Config.config.osusettings.sensitivity + (float)AimbotStrengthNumericUpDown.Increment));

            // Similarity
            int similarity = Math.Max(this.SimilaritySlider.Minimum, Math.Min(this.SimilaritySlider.Maximum, Config.config.aimbotsettings.similarity));
            this.SimilaritySlider.Value = similarity;
            this.SimilarityNumeric.Value = similarity;

            // Target Color
            this.TargetColorPreview.BackColor = Config.config.aimbotsettings.targetcolor.ToColor();

            // Cursor Color
            this.CursorColorPreview.BackColor = Config.config.aimbotsettings.cursorcolor.ToColor();
        }

        private void MouseAlgorithmCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.algorithm = (MouseAlgorithms)this.MouseAlgorithmCombo.SelectedIndex;
        }

        private void PullawayNumeric_ValueChanged(object sender, EventArgs e)
        {
            int pullaway = (int)Math.Max(this.PullawaySlider.Minimum, Math.Min(this.PullawaySlider.Maximum, this.PullawayNumeric.Value));
            Config.config.aimbotsettings.pullawaydistance = pullaway;
            this.PullawaySlider.Value = pullaway;
        }

        private void PullawaySlider_ValueChanged(object sender, EventArgs e)
        {
            int pullaway = this.PullawaySlider.Value;
            Config.config.aimbotsettings.pullawaydistance = pullaway;
            this.PullawayNumeric.Value = pullaway;
        }

        private void AimbotKeybindSet_Click(object sender, EventArgs e)
        {
            AimbotKeybindSet.Enabled = false;
            KeybindListener.StartListening(out VirtualKeyCode key, (capturedKey) =>
            {
                AimbotKeybindSet.Enabled = true;
                Config.config.keybindings.aimbotkey = capturedKey;
                AimbotKeybindSet.Text = capturedKey.ToString();
                AimbotKeybindSet.Checked = false;
            });
        }

        private void SimilaritySlider_ValueChanged(object sender, EventArgs e)
        {
            int similarity = this.SimilaritySlider.Value;
            Config.config.aimbotsettings.similarity = similarity;
            this.SimilarityNumeric.Value = similarity;
        }

        private void SimilarityNumeric_ValueChanged(object sender, EventArgs e)
        {
            int similarity = (int)Math.Max(this.SimilaritySlider.Minimum, Math.Min(this.SimilaritySlider.Maximum, this.SimilarityNumeric.Value));
            Config.config.aimbotsettings.similarity = similarity;
            this.SimilaritySlider.Value = similarity;
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)sender;
                if (button.Name == "TargetColorButton")
                {
                    Config.config.aimbotsettings.targetcolor = new RgbColor(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                    this.TargetColorPreview.BackColor = colorDialog.Color;
                }
                else if (button.Name == "CursorColorButton")
                {
                    Config.config.aimbotsettings.cursorcolor = new RgbColor(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                    this.CursorColorPreview.BackColor = colorDialog.Color;
                }
            }
        }

        private void AimbotTabPanelSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Config.config.aimbotenabled = this.AimbotTabPanelSwitch.Checked;
        }

        private void AimbotFovSliderNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int fovSize = (int)Math.Max(this.AimbotFovSlider.Minimum, Math.Min(this.AimbotFovSlider.Maximum, this.AimbotFovSliderNumericUpDown.Value));
            Config.config.aimbotsettings.fovsize = fovSize;
            this.AimbotFovSlider.Value = fovSize;
        }

        private void AimbotFovSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.fovsize = this.AimbotFovSlider.Value;
            this.AimbotFovSliderNumericUpDown.Value = this.AimbotFovSlider.Value;
        }

        private void AimbotSmoothingSliderNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int smoothing = (int)Math.Max(this.AimbotSmoothingSlider.Minimum, Math.Min(this.AimbotSmoothingSlider.Maximum, this.AimbotSmoothingSliderNumericUpDown.Value));
            Config.config.aimbotsettings.smoothing = smoothing;
            this.AimbotSmoothingSlider.Value = smoothing;
        }

        private void AimbotSmoothingSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.smoothing = this.AimbotSmoothingSlider.Value;
            this.AimbotSmoothingSliderNumericUpDown.Value = this.AimbotSmoothingSlider.Value;
        }

        private void AimbotStrengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal strength = Math.Max(0m, Math.Min(1m, this.AimbotStrengthNumericUpDown.Value));
            Config.config.aimbotsettings.strength = (float)strength;

            int sliderValue = (int)(strength * 10000);
            if (sliderValue != this.AimbotStrengthSlider.Value)
            {
                this.AimbotStrengthSlider.Value = Math.Max(this.AimbotStrengthSlider.Minimum,
                    Math.Min(this.AimbotStrengthSlider.Maximum, sliderValue));
            }
        }

        private void AimbotStrengthSlider_ValueChanged(object sender, EventArgs e)
        {
            float strength = Math.Max(0f, Math.Min(1f, (float)this.AimbotStrengthSlider.Value / 10000f));
            Config.config.aimbotsettings.strength = strength;

            decimal numericValue = (decimal)strength;
            if (numericValue != this.AimbotStrengthNumericUpDown.Value)
            {
                this.AimbotStrengthNumericUpDown.Value = Math.Max(this.AimbotStrengthNumericUpDown.Minimum, 
                    Math.Min(this.AimbotStrengthNumericUpDown.Maximum, numericValue));
            }
        }

        private void HardrockEnabledAA_CheckedChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.hardrockenabled = this.HardrockEnabledAA.Checked;
        }

        private void SensitivitySlider_ValueChanged(object sender, EventArgs e)
        {
            float sensitivity = Math.Max(0f, Math.Min(6f, (float)this.SensitivitySlider.Value / 10f));
            Config.config.osusettings.sensitivity = (float)sensitivity;

            decimal numericValue = (decimal)sensitivity;
            if (numericValue != this.SensitivityNumeric.Value)
            {
                this.SensitivityNumeric.Value = Math.Max(this.SensitivityNumeric.Minimum,
                    Math.Min(this.SensitivityNumeric.Maximum, numericValue));
            }
        }

        private void SensitivityNumeric_ValueChanged(object sender, EventArgs e)
        {
            decimal sensitivity = Math.Max(0m, Math.Min(6m, this.SensitivityNumeric.Value));
            Config.config.osusettings.sensitivity = (float)sensitivity;

            int sliderValue = (int)(sensitivity * 10);
            if (sliderValue != this.SensitivitySlider.Value)
            {
                this.SensitivitySlider.Value = Math.Max(this.SensitivitySlider.Minimum,
                    Math.Min(this.SensitivitySlider.Maximum, sliderValue));
            }
        }

        private void RelaxButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            RelaxButton.Checked = true;

            this.RelaxPanel.Show();
            this.TimingPanel.Show();

            // Keybind set
            this.RelaxKeybindSet.Text = Config.config.keybindings.relaxkey.ToString();

            // Relax Switch
            this.RelaxPanelSwitch.Checked = Config.config.relaxenabled;

            // Playstyle
            this.PlaystyleComboBox.SelectedIndex = (int)Config.config.relaxsettings.playstyle;

            // Current Mods
            this.CurrentModsComboBox.SelectedIndex = CurrentMods_IndexFix(OsuSDK.Instance.CurrentMods);

            // Hardrock
            this.HardrockEnabled.Checked = Config.config.relaxsettings.hardrockenabled;

            // MaxBPM
            this.MaxBPMSlider.Value = Config.config.relaxsettings.maxsingletapbpm;
            this.MaxBPMNumeric.Value = Config.config.relaxsettings.maxsingletapbpm;

            // Audio Offset
            this.AudioOffsetSlider.Value = Config.config.osusettings.audiooffset;
            this.AudioOffsetSliderNumeric.Value = Config.config.osusettings.audiooffset;

            // Max Distance
            this.MaxDistanceSlider.Value = Config.config.relaxsettings.hitscanmaxdistance;
            this.MaxDistanceNumeric.Value = Config.config.relaxsettings.hitscanmaxdistance;
        }

        private void HardrockEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.hardrockenabled = this.HardrockEnabled.Checked;
        }

        private void RelaxKeybindSet_Click(object sender, EventArgs e)
        {
            RelaxKeybindSet.Enabled = false;
            KeybindListener.StartListening(out VirtualKeyCode key, (capturedKey) =>
            {
                RelaxKeybindSet.Enabled = true;
                Config.config.keybindings.relaxkey = capturedKey;
                RelaxKeybindSet.Text = capturedKey.ToString();
                RelaxKeybindSet.Checked = false;
            });
        }

        private void MaxDistanceSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.hitscanmaxdistance = this.MaxDistanceSlider.Value;
            this.MaxDistanceNumeric.Value = this.MaxDistanceSlider.Value;
        }

        private void MaxDistanceNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.hitscanmaxdistance = (int)this.MaxDistanceNumeric.Value;
            this.MaxDistanceSlider.Value = (int)this.MaxDistanceNumeric.Value;
        }

        private int CurrentMods_IndexFix(Mods ActiveMods)
        {
            if (ActiveMods.HasFlag(Mods.DoubleTime))
            {
                return 1;
            }
            else if (ActiveMods.HasFlag(Mods.Nightcore))
            {
                return 2;
            }
            else if (ActiveMods.HasFlag(Mods.HalfTime))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private void CurrentModsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.CurrentModsComboBox.SelectedIndex)
            {
                case 0:
                    OsuSDK.Instance.CurrentMods = Mods.None;
                    break;
                case 1:
                    OsuSDK.Instance.CurrentMods = Mods.DoubleTime;
                    break;
                case 2:
                    OsuSDK.Instance.CurrentMods = Mods.Nightcore;
                    break;
                case 3:
                    OsuSDK.Instance.CurrentMods = Mods.HalfTime;
                    break;
            }
        }

        private void AudioOffsetSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.osusettings.audiooffset = this.AudioOffsetSlider.Value;
            this.AudioOffsetSliderNumeric.Value = this.AudioOffsetSlider.Value;
        }

        private void AudioOffsetNumeric_ValueChange(object sender, EventArgs e)
        {
            Config.config.osusettings.audiooffset = (int)this.AudioOffsetSliderNumeric.Value;
            this.AudioOffsetSlider.Value = (int)this.AudioOffsetSliderNumeric.Value;
        }

        private void MaxBPMSlider_ValueChange(object sender, EventArgs e)
        {
            Config.config.relaxsettings.maxsingletapbpm = this.MaxBPMSlider.Value;
            this.MaxBPMNumeric.Value = this.MaxBPMSlider.Value;
        }

        private void MaxBPMNumeric_ValueChange(object sender, EventArgs e)
        {
            Config.config.relaxsettings.maxsingletapbpm = (int)this.MaxBPMNumeric.Value;
            this.MaxBPMSlider.Value = (int)this.MaxBPMNumeric.Value;
        }

        private void RelaxPanelSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Config.config.relaxenabled = this.RelaxPanelSwitch.Checked;
        }

        private void PlaystyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.playstyle = (PlayStyles)this.PlaystyleComboBox.SelectedIndex;
        }

        private void SpooferButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            SpooferButton.Checked = true;

            this.SpooferPanel.Show();
        }

        private void CheckSerialsButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> serials = Spoofer.GetHWIDs();
            CpuSerial.Text = serials["CPU"];
            BaseBoardSerial.Text = serials["BaseBoard"];
            DiskSerial.Text = serials["Disk"];
            MACSerial.Text = serials["MACAddress"];
        }

        private void SpoofSerialsButton_Click(object sender, EventArgs e)
        {
            bool completedSpoof = Spoofer.SpoofHWIDs(out string msg);
            if (completedSpoof)
            {
                MessageBox.Show("Spoofed HWIDs successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Failed to spoof HWIDs.\n{msg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManiaButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            ManiaButton.Checked = true;
        }

        private void CatchButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            CatchButton.Checked = true;
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Content.Controls)
            {
                control.Hide();
            }
            ResetButtons();
            ConfigButton.Checked = true;

            this.ConfigPanel.Show();

            this.LocalConfigButton.Checked = true;

            PopulateConfigTable(Config.GetConfigFiles());
        }
        private void ConfigComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastConfigIndex = this.ConfigComboBox.SelectedIndex;
        }

        private void AdvancedButton_Click(object sender, EventArgs e)
        {
            if (AdvancedOptions != null && !AdvancedOptions.IsDisposed)
            {
                AdvancedOptions.BringToFront();
                return;
            }
            else
            {
                AdvancedOptions = new AdvancedOptions();
                AdvancedOptions.Show();
            }
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            if (this.ConfigComboBox.Text == "")
            {
                MessageBox.Show("Please select the config file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Config.configInstance.Save(this.ConfigComboBox.Text);
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            if (this.ConfigComboBox.Text == "")
            {
                MessageBox.Show("Please select the config file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Config.configInstance.Load(this.ConfigComboBox.Text);
        }

        private void DeleteConfigButton_Click(object sender, EventArgs e)
        {
            if (this.ConfigComboBox.Text == "")
            {
                MessageBox.Show("Please select the config file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Config.configInstance.Delete(this.ConfigComboBox.Text);
            PopulateConfigTable(Config.GetConfigFiles());
        }

        private void ResetConfigButton_Click(object sender, EventArgs e)
        {
            if (this.ConfigComboBox.Text == "")
            {
                MessageBox.Show("Please select the config file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Config.configInstance.Reset(this.ConfigComboBox.Text);
        }

        private void CreateConfigButton_Click(object sender, EventArgs e)
        {
            if (this.CreateConfigText.Text == "")
            {
                MessageBox.Show("Please enter the config name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Config.GetConfigFiles().Contains(this.CreateConfigText.Text))
            {
                MessageBox.Show("Config with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!this.CreateConfigText.Text.Contains(".json"))
            {
                this.CreateConfigText.Text += ".json";
            }

            Config.configInstance.Create(this.CreateConfigText.Text);
            PopulateConfigTable(Config.GetConfigFiles());
        }

        private void PopulateConfigTable(List<string> configNames)
        {
            this.ConfigComboBox.Items.Clear();
            this.ConfigTable.Controls.Clear();

            for (int i = 0; i < configNames.Count; i++)
            {
                SpawnConfigNameObject(configNames[i], new Vector2(5, 0 + (i * 32)));
            }

            this.ConfigComboBox.Items.AddRange(configNames.ToArray());
            if (this.ConfigComboBox.SelectedIndex == -1)
            {
                if (this.ConfigComboBox.Items.Count >= LastConfigIndex)
                {
                    this.ConfigComboBox.SelectedIndex = LastConfigIndex;
                }
                else
                {
                    this.ConfigComboBox.SelectedIndex = 0;
                }
                
            }
        }

        private void SpawnConfigNameObject(string name, Vector2 position)
        {
            this.ConfigNameDynamic = new Guna.UI2.WinForms.Guna2Button();
            // 
            // ConfigNameDynamic
            // 
            this.ConfigNameDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigNameDynamic.BackColor = System.Drawing.Color.Transparent;
            this.ConfigNameDynamic.BorderRadius = 5;
            this.ConfigNameDynamic.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ConfigNameDynamic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfigNameDynamic.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ConfigNameDynamic.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ConfigNameDynamic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ConfigNameDynamic.DisabledState.ForeColor = System.Drawing.Color.White;
            this.ConfigNameDynamic.Enabled = false;
            this.ConfigNameDynamic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ConfigNameDynamic.Font = new System.Drawing.Font("Comfortaa", 8.999999F);
            this.ConfigNameDynamic.ForeColor = System.Drawing.Color.White;
            this.ConfigNameDynamic.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ConfigNameDynamic.Location = new System.Drawing.Point((int)position.X, (int)position.Y);
            this.ConfigNameDynamic.Size = new System.Drawing.Size(235, 27);
            this.ConfigNameDynamic.TabIndex = 27;
            this.ConfigNameDynamic.Text = name;
            this.ConfigTable.Controls.Add(this.ConfigNameDynamic);
        }

        private void ResetButtons()
        {
            AimbotButton.Checked = false;
            RelaxButton.Checked = false;
            SpooferButton.Checked = false;
            ManiaButton.Checked = false;
            CatchButton.Checked = false;
            ConfigButton.Checked = false;
        }

        private void DiscordButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/PdeTUZ3M62");
        }

        private void WebsiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://osussist.pages.dev/");
        }
    }
}
