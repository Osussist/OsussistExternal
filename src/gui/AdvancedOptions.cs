using Osussist.src.config;
using Osussist.src.config.objects;
using Osussist.src.osu;
using System.Drawing;
using System.Windows.Forms;

namespace Osussist.src.gui
{
    public class AdvancedOptions : Form
    {
        private Guna.UI2.WinForms.Guna2Panel AimbotPanel;
        private Guna.UI2.WinForms.Guna2Button AimbotButton;
        private Guna.UI2.WinForms.Guna2Panel Header;
        private Guna.UI2.WinForms.Guna2Elipse Border;
        private Guna.UI2.WinForms.Guna2HtmlLabel Title;
        private Guna.UI2.WinForms.Guna2Button RelaxButton;
        private Guna.UI2.WinForms.Guna2CircleButton CloseButton;
        private System.ComponentModel.IContainer components;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Guna.UI2.WinForms.Guna2Elipse AimbotBorder;
        private Guna.UI2.WinForms.Guna2Button OtherButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel MovementDelayLabel;
        private Guna.UI2.WinForms.Guna2NumericUpDown MovementToNumeric;
        private Guna.UI2.WinForms.Guna2HtmlLabel to;
        private Guna.UI2.WinForms.Guna2NumericUpDown MovementFromNumeric;
        private Guna.UI2.WinForms.Guna2HtmlLabel HitcircleRadiusLabel;
        private Guna.UI2.WinForms.Guna2NumericUpDown HitcircleRadiusNumeric;
        private Guna.UI2.WinForms.Guna2TrackBar HitcircleRadiusSlider;
        private Guna.UI2.WinForms.Guna2NumericUpDown MinAreaNumeric;
        private Guna.UI2.WinForms.Guna2TrackBar MinAreaSlider;
        private Guna.UI2.WinForms.Guna2HtmlLabel MinAreaLabel;
        private Guna.UI2.WinForms.Guna2Elipse OtherBorder;
        private Guna.UI2.WinForms.Guna2Elipse RelaxBorder;
        private Guna.UI2.WinForms.Guna2Panel RelaxPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel HitscanRadiusAddLabel;
        private Guna.UI2.WinForms.Guna2Panel OtherPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel OverridesLabel;
        private Guna.UI2.WinForms.Guna2NumericUpDown HitscanRadiusAddNumeric;
        private Guna.UI2.WinForms.Guna2TrackBar HitscanRadiusAddSlider;
        private Guna.UI2.WinForms.Guna2HtmlLabel AimbotOverrideLabel;
        private Guna.UI2.WinForms.Guna2ToggleSwitch AimbotOverrideSwitch;
        private Guna.UI2.WinForms.Guna2NumericUpDown HitscanRadiusMulNumeric;
        private Guna.UI2.WinForms.Guna2TrackBar HitscanRadiusMulSlider;
        private Guna.UI2.WinForms.Guna2HtmlLabel HitScanRadiusMulLabel;
        private Point dragFormPoint;

        private OsuSDK SDK { get; set; }

        public AdvancedOptions()
        {
            SDK = OsuSDK.Instance;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedOptions));
            this.AimbotPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.MinAreaNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.MinAreaSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.MinAreaLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.HitcircleRadiusNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.HitcircleRadiusSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.HitcircleRadiusLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MovementToNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.to = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MovementFromNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.MovementDelayLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotButton = new Guna.UI2.WinForms.Guna2Button();
            this.Header = new Guna.UI2.WinForms.Guna2Panel();
            this.CloseButton = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Border = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RelaxButton = new Guna.UI2.WinForms.Guna2Button();
            this.AimbotBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.OtherButton = new Guna.UI2.WinForms.Guna2Button();
            this.OtherBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.OtherPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.AimbotOverrideLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotOverrideSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.OverridesLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RelaxBorder = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RelaxPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.HitscanRadiusMulNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.HitscanRadiusMulSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.HitScanRadiusMulLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.HitscanRadiusAddNumeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.HitscanRadiusAddSlider = new Guna.UI2.WinForms.Guna2TrackBar();
            this.HitscanRadiusAddLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AimbotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinAreaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitcircleRadiusNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementToNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementFromNumeric)).BeginInit();
            this.Header.SuspendLayout();
            this.OtherPanel.SuspendLayout();
            this.RelaxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HitscanRadiusMulNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitscanRadiusAddNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // AimbotPanel
            // 
            this.AimbotPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.AimbotPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AimbotPanel.Controls.Add(this.MinAreaNumeric);
            this.AimbotPanel.Controls.Add(this.MinAreaSlider);
            this.AimbotPanel.Controls.Add(this.MinAreaLabel);
            this.AimbotPanel.Controls.Add(this.HitcircleRadiusNumeric);
            this.AimbotPanel.Controls.Add(this.HitcircleRadiusSlider);
            this.AimbotPanel.Controls.Add(this.HitcircleRadiusLabel);
            this.AimbotPanel.Controls.Add(this.MovementToNumeric);
            this.AimbotPanel.Controls.Add(this.to);
            this.AimbotPanel.Controls.Add(this.MovementFromNumeric);
            this.AimbotPanel.Controls.Add(this.MovementDelayLabel);
            this.AimbotPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AimbotPanel.Location = new System.Drawing.Point(12, 75);
            this.AimbotPanel.Name = "AimbotPanel";
            this.AimbotPanel.Size = new System.Drawing.Size(326, 393);
            this.AimbotPanel.TabIndex = 2;
            this.AimbotPanel.Visible = false;
            // 
            // MinAreaNumeric
            // 
            this.MinAreaNumeric.BackColor = System.Drawing.Color.Transparent;
            this.MinAreaNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MinAreaNumeric.BorderRadius = 5;
            this.MinAreaNumeric.BorderThickness = 0;
            this.MinAreaNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MinAreaNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MinAreaNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAreaNumeric.ForeColor = System.Drawing.Color.White;
            this.MinAreaNumeric.Location = new System.Drawing.Point(206, 151);
            this.MinAreaNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MinAreaNumeric.Name = "MinAreaNumeric";
            this.MinAreaNumeric.Size = new System.Drawing.Size(73, 21);
            this.MinAreaNumeric.TabIndex = 34;
            this.MinAreaNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.MinAreaNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MinAreaNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinAreaNumeric.ValueChanged += new System.EventHandler(this.MinAreaNumeric_ValueChanged);
            // 
            // MinAreaSlider
            // 
            this.MinAreaSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinAreaSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.MinAreaSlider.Location = new System.Drawing.Point(8, 150);
            this.MinAreaSlider.Maximum = 1000;
            this.MinAreaSlider.Name = "MinAreaSlider";
            this.MinAreaSlider.Size = new System.Drawing.Size(192, 23);
            this.MinAreaSlider.TabIndex = 33;
            this.MinAreaSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MinAreaSlider.ValueChanged += new System.EventHandler(this.MinAreaSlider_ValueChanged);
            // 
            // MinAreaLabel
            // 
            this.MinAreaLabel.BackColor = System.Drawing.Color.Transparent;
            this.MinAreaLabel.Enabled = false;
            this.MinAreaLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MinAreaLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinAreaLabel.Location = new System.Drawing.Point(8, 121);
            this.MinAreaLabel.Name = "MinAreaLabel";
            this.MinAreaLabel.Size = new System.Drawing.Size(65, 23);
            this.MinAreaLabel.TabIndex = 32;
            this.MinAreaLabel.Text = "Min Area";
            // 
            // HitcircleRadiusNumeric
            // 
            this.HitcircleRadiusNumeric.BackColor = System.Drawing.Color.Transparent;
            this.HitcircleRadiusNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitcircleRadiusNumeric.BorderRadius = 5;
            this.HitcircleRadiusNumeric.BorderThickness = 0;
            this.HitcircleRadiusNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HitcircleRadiusNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HitcircleRadiusNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitcircleRadiusNumeric.ForeColor = System.Drawing.Color.White;
            this.HitcircleRadiusNumeric.Location = new System.Drawing.Point(206, 93);
            this.HitcircleRadiusNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HitcircleRadiusNumeric.Name = "HitcircleRadiusNumeric";
            this.HitcircleRadiusNumeric.Size = new System.Drawing.Size(73, 21);
            this.HitcircleRadiusNumeric.TabIndex = 31;
            this.HitcircleRadiusNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.HitcircleRadiusNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitcircleRadiusNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HitcircleRadiusNumeric.ValueChanged += new System.EventHandler(this.HitcircleRadiusNumeric_ValueChanged);
            // 
            // HitcircleRadiusSlider
            // 
            this.HitcircleRadiusSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HitcircleRadiusSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.HitcircleRadiusSlider.Location = new System.Drawing.Point(8, 92);
            this.HitcircleRadiusSlider.Maximum = 1000;
            this.HitcircleRadiusSlider.Name = "HitcircleRadiusSlider";
            this.HitcircleRadiusSlider.Size = new System.Drawing.Size(192, 23);
            this.HitcircleRadiusSlider.TabIndex = 30;
            this.HitcircleRadiusSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitcircleRadiusSlider.ValueChanged += new System.EventHandler(this.HitcircleRadiusSlider_ValueChanged);
            // 
            // HitcircleRadiusLabel
            // 
            this.HitcircleRadiusLabel.BackColor = System.Drawing.Color.Transparent;
            this.HitcircleRadiusLabel.Enabled = false;
            this.HitcircleRadiusLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.HitcircleRadiusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HitcircleRadiusLabel.Location = new System.Drawing.Point(8, 63);
            this.HitcircleRadiusLabel.Name = "HitcircleRadiusLabel";
            this.HitcircleRadiusLabel.Size = new System.Drawing.Size(111, 23);
            this.HitcircleRadiusLabel.TabIndex = 29;
            this.HitcircleRadiusLabel.Text = "Hitcircle Radius";
            // 
            // MovementToNumeric
            // 
            this.MovementToNumeric.BackColor = System.Drawing.Color.Transparent;
            this.MovementToNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MovementToNumeric.BorderRadius = 5;
            this.MovementToNumeric.BorderThickness = 0;
            this.MovementToNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MovementToNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MovementToNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovementToNumeric.ForeColor = System.Drawing.Color.White;
            this.MovementToNumeric.Location = new System.Drawing.Point(113, 36);
            this.MovementToNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MovementToNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MovementToNumeric.Name = "MovementToNumeric";
            this.MovementToNumeric.Size = new System.Drawing.Size(73, 21);
            this.MovementToNumeric.TabIndex = 28;
            this.MovementToNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.MovementToNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MovementToNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MovementToNumeric.ValueChanged += new System.EventHandler(this.MovementToNumeric_ValueChanged);
            // 
            // to
            // 
            this.to.BackColor = System.Drawing.Color.Transparent;
            this.to.Enabled = false;
            this.to.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.to.ForeColor = System.Drawing.SystemColors.Control;
            this.to.Location = new System.Drawing.Point(87, 34);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(20, 23);
            this.to.TabIndex = 27;
            this.to.Text = "to:";
            // 
            // MovementFromNumeric
            // 
            this.MovementFromNumeric.BackColor = System.Drawing.Color.Transparent;
            this.MovementFromNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MovementFromNumeric.BorderRadius = 5;
            this.MovementFromNumeric.BorderThickness = 0;
            this.MovementFromNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MovementFromNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MovementFromNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovementFromNumeric.ForeColor = System.Drawing.Color.White;
            this.MovementFromNumeric.Location = new System.Drawing.Point(8, 36);
            this.MovementFromNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MovementFromNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MovementFromNumeric.Name = "MovementFromNumeric";
            this.MovementFromNumeric.Size = new System.Drawing.Size(73, 21);
            this.MovementFromNumeric.TabIndex = 26;
            this.MovementFromNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.MovementFromNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.MovementFromNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MovementFromNumeric.ValueChanged += new System.EventHandler(this.MovementFromNumeric_ValueChanged);
            // 
            // MovementDelayLabel
            // 
            this.MovementDelayLabel.BackColor = System.Drawing.Color.Transparent;
            this.MovementDelayLabel.Enabled = false;
            this.MovementDelayLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.MovementDelayLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MovementDelayLabel.Location = new System.Drawing.Point(8, 7);
            this.MovementDelayLabel.Name = "MovementDelayLabel";
            this.MovementDelayLabel.Size = new System.Drawing.Size(116, 23);
            this.MovementDelayLabel.TabIndex = 19;
            this.MovementDelayLabel.Text = "Movement Delay";
            // 
            // AimbotButton
            // 
            this.AimbotButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.AimbotButton.BorderRadius = 5;
            this.AimbotButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.AimbotButton.Checked = true;
            this.AimbotButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.AimbotButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AimbotButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AimbotButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AimbotButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AimbotButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.AimbotButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimbotButton.ForeColor = System.Drawing.Color.White;
            this.AimbotButton.Location = new System.Drawing.Point(18, 48);
            this.AimbotButton.Name = "AimbotButton";
            this.AimbotButton.Size = new System.Drawing.Size(100, 32);
            this.AimbotButton.TabIndex = 3;
            this.AimbotButton.Text = "Aimbot";
            this.AimbotButton.Click += new System.EventHandler(this.AimbotButton_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Header.Controls.Add(this.CloseButton);
            this.Header.Controls.Add(this.Title);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(350, 39);
            this.Header.TabIndex = 4;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseDown);
            this.Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseMove);
            this.Header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragZone_MouseUp);
            // 
            // CloseButton
            // 
            this.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(84)))));
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(319, 11);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CloseButton.Size = new System.Drawing.Size(17, 17);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "guna2CircleButton1";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Enabled = false;
            this.Title.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(68)))), ((int)(((byte)(171)))));
            this.Title.Location = new System.Drawing.Point(12, 5);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(161, 28);
            this.Title.TabIndex = 0;
            this.Title.Text = "Advanced Settings";
            // 
            // Border
            // 
            this.Border.BorderRadius = 10;
            this.Border.TargetControl = this;
            // 
            // RelaxButton
            // 
            this.RelaxButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.RelaxButton.BorderRadius = 5;
            this.RelaxButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.RelaxButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.RelaxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RelaxButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RelaxButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RelaxButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RelaxButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RelaxButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.RelaxButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelaxButton.ForeColor = System.Drawing.Color.White;
            this.RelaxButton.Location = new System.Drawing.Point(122, 48);
            this.RelaxButton.Name = "RelaxButton";
            this.RelaxButton.Size = new System.Drawing.Size(105, 32);
            this.RelaxButton.TabIndex = 5;
            this.RelaxButton.Text = "Relax";
            this.RelaxButton.Click += new System.EventHandler(this.RelaxButton_Click);
            // 
            // AimbotBorder
            // 
            this.AimbotBorder.BorderRadius = 15;
            this.AimbotBorder.TargetControl = this.AimbotPanel;
            // 
            // OtherButton
            // 
            this.OtherButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.OtherButton.BorderRadius = 5;
            this.OtherButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.OtherButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.OtherButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OtherButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OtherButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OtherButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OtherButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OtherButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.OtherButton.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherButton.ForeColor = System.Drawing.Color.White;
            this.OtherButton.Location = new System.Drawing.Point(231, 48);
            this.OtherButton.Name = "OtherButton";
            this.OtherButton.Size = new System.Drawing.Size(100, 32);
            this.OtherButton.TabIndex = 6;
            this.OtherButton.Text = "Other";
            this.OtherButton.Click += new System.EventHandler(this.OtherButton_Click);
            // 
            // OtherBorder
            // 
            this.OtherBorder.BorderRadius = 15;
            this.OtherBorder.TargetControl = this.OtherPanel;
            // 
            // OtherPanel
            // 
            this.OtherPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.OtherPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OtherPanel.Controls.Add(this.AimbotOverrideLabel);
            this.OtherPanel.Controls.Add(this.AimbotOverrideSwitch);
            this.OtherPanel.Controls.Add(this.OverridesLabel);
            this.OtherPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OtherPanel.Location = new System.Drawing.Point(12, 75);
            this.OtherPanel.Name = "OtherPanel";
            this.OtherPanel.Size = new System.Drawing.Size(326, 393);
            this.OtherPanel.TabIndex = 36;
            this.OtherPanel.Visible = false;
            // 
            // AimbotOverrideLabel
            // 
            this.AimbotOverrideLabel.BackColor = System.Drawing.Color.Transparent;
            this.AimbotOverrideLabel.Enabled = false;
            this.AimbotOverrideLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.AimbotOverrideLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AimbotOverrideLabel.Location = new System.Drawing.Point(49, 34);
            this.AimbotOverrideLabel.Name = "AimbotOverrideLabel";
            this.AimbotOverrideLabel.Size = new System.Drawing.Size(152, 23);
            this.AimbotOverrideLabel.TabIndex = 21;
            this.AimbotOverrideLabel.Text = "Override Aimbot Type";
            // 
            // AimbotOverrideSwitch
            // 
            this.AimbotOverrideSwitch.Animated = true;
            this.AimbotOverrideSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotOverrideSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotOverrideSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotOverrideSwitch.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotOverrideSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AimbotOverrideSwitch.Location = new System.Drawing.Point(8, 37);
            this.AimbotOverrideSwitch.Name = "AimbotOverrideSwitch";
            this.AimbotOverrideSwitch.Size = new System.Drawing.Size(35, 20);
            this.AimbotOverrideSwitch.TabIndex = 20;
            this.AimbotOverrideSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotOverrideSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AimbotOverrideSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotOverrideSwitch.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.AimbotOverrideSwitch.CheckedChanged += new System.EventHandler(this.AimbotOverrideSwitch_CheckedChanged);
            // 
            // OverridesLabel
            // 
            this.OverridesLabel.BackColor = System.Drawing.Color.Transparent;
            this.OverridesLabel.Enabled = false;
            this.OverridesLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.OverridesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OverridesLabel.Location = new System.Drawing.Point(8, 7);
            this.OverridesLabel.Name = "OverridesLabel";
            this.OverridesLabel.Size = new System.Drawing.Size(70, 23);
            this.OverridesLabel.TabIndex = 19;
            this.OverridesLabel.Text = "Overrides";
            // 
            // RelaxBorder
            // 
            this.RelaxBorder.BorderRadius = 15;
            this.RelaxBorder.TargetControl = this.RelaxPanel;
            // 
            // RelaxPanel
            // 
            this.RelaxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(53)))));
            this.RelaxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RelaxPanel.Controls.Add(this.HitscanRadiusMulNumeric);
            this.RelaxPanel.Controls.Add(this.HitscanRadiusMulSlider);
            this.RelaxPanel.Controls.Add(this.HitScanRadiusMulLabel);
            this.RelaxPanel.Controls.Add(this.HitscanRadiusAddNumeric);
            this.RelaxPanel.Controls.Add(this.HitscanRadiusAddSlider);
            this.RelaxPanel.Controls.Add(this.HitscanRadiusAddLabel);
            this.RelaxPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RelaxPanel.Location = new System.Drawing.Point(12, 75);
            this.RelaxPanel.Name = "RelaxPanel";
            this.RelaxPanel.Size = new System.Drawing.Size(326, 393);
            this.RelaxPanel.TabIndex = 35;
            this.RelaxPanel.Visible = false;
            // 
            // HitscanRadiusMulNumeric
            // 
            this.HitscanRadiusMulNumeric.BackColor = System.Drawing.Color.Transparent;
            this.HitscanRadiusMulNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusMulNumeric.BorderRadius = 5;
            this.HitscanRadiusMulNumeric.BorderThickness = 0;
            this.HitscanRadiusMulNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HitscanRadiusMulNumeric.DecimalPlaces = 2;
            this.HitscanRadiusMulNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HitscanRadiusMulNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitscanRadiusMulNumeric.ForeColor = System.Drawing.Color.White;
            this.HitscanRadiusMulNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.HitscanRadiusMulNumeric.Location = new System.Drawing.Point(206, 95);
            this.HitscanRadiusMulNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HitscanRadiusMulNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.HitscanRadiusMulNumeric.Name = "HitscanRadiusMulNumeric";
            this.HitscanRadiusMulNumeric.Size = new System.Drawing.Size(73, 21);
            this.HitscanRadiusMulNumeric.TabIndex = 24;
            this.HitscanRadiusMulNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.HitscanRadiusMulNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusMulNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HitscanRadiusMulNumeric.ValueChanged += new System.EventHandler(this.HitscanRadiusMulNumeric_ValueChanged);
            // 
            // HitscanRadiusMulSlider
            // 
            this.HitscanRadiusMulSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HitscanRadiusMulSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.HitscanRadiusMulSlider.Location = new System.Drawing.Point(8, 94);
            this.HitscanRadiusMulSlider.Minimum = 1;
            this.HitscanRadiusMulSlider.Name = "HitscanRadiusMulSlider";
            this.HitscanRadiusMulSlider.Size = new System.Drawing.Size(192, 23);
            this.HitscanRadiusMulSlider.TabIndex = 23;
            this.HitscanRadiusMulSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusMulSlider.Value = 1;
            this.HitscanRadiusMulSlider.ValueChanged += new System.EventHandler(this.HitscanRadiusMulSlider_ValueChanged);
            // 
            // HitScanRadiusMulLabel
            // 
            this.HitScanRadiusMulLabel.BackColor = System.Drawing.Color.Transparent;
            this.HitScanRadiusMulLabel.Enabled = false;
            this.HitScanRadiusMulLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.HitScanRadiusMulLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HitScanRadiusMulLabel.Location = new System.Drawing.Point(8, 65);
            this.HitScanRadiusMulLabel.Name = "HitScanRadiusMulLabel";
            this.HitScanRadiusMulLabel.Size = new System.Drawing.Size(176, 23);
            this.HitScanRadiusMulLabel.TabIndex = 22;
            this.HitScanRadiusMulLabel.Text = "Hitscan Radius Multiplier";
            // 
            // HitscanRadiusAddNumeric
            // 
            this.HitscanRadiusAddNumeric.BackColor = System.Drawing.Color.Transparent;
            this.HitscanRadiusAddNumeric.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusAddNumeric.BorderRadius = 5;
            this.HitscanRadiusAddNumeric.BorderThickness = 0;
            this.HitscanRadiusAddNumeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HitscanRadiusAddNumeric.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HitscanRadiusAddNumeric.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitscanRadiusAddNumeric.ForeColor = System.Drawing.Color.White;
            this.HitscanRadiusAddNumeric.Location = new System.Drawing.Point(206, 37);
            this.HitscanRadiusAddNumeric.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.HitscanRadiusAddNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HitscanRadiusAddNumeric.Name = "HitscanRadiusAddNumeric";
            this.HitscanRadiusAddNumeric.Size = new System.Drawing.Size(73, 21);
            this.HitscanRadiusAddNumeric.TabIndex = 21;
            this.HitscanRadiusAddNumeric.TextOffset = new System.Drawing.Point(0, -3);
            this.HitscanRadiusAddNumeric.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusAddNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HitscanRadiusAddNumeric.ValueChanged += new System.EventHandler(this.HitscanRadiusAddNumeric_ValueChanged);
            // 
            // HitscanRadiusAddSlider
            // 
            this.HitscanRadiusAddSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HitscanRadiusAddSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.HitscanRadiusAddSlider.Location = new System.Drawing.Point(8, 36);
            this.HitscanRadiusAddSlider.Maximum = 250;
            this.HitscanRadiusAddSlider.Minimum = 1;
            this.HitscanRadiusAddSlider.Name = "HitscanRadiusAddSlider";
            this.HitscanRadiusAddSlider.Size = new System.Drawing.Size(192, 23);
            this.HitscanRadiusAddSlider.TabIndex = 20;
            this.HitscanRadiusAddSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.HitscanRadiusAddSlider.ValueChanged += new System.EventHandler(this.HitscanRadiusAddSlider_ValueChanged);
            // 
            // HitscanRadiusAddLabel
            // 
            this.HitscanRadiusAddLabel.BackColor = System.Drawing.Color.Transparent;
            this.HitscanRadiusAddLabel.Enabled = false;
            this.HitscanRadiusAddLabel.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.HitscanRadiusAddLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HitscanRadiusAddLabel.Location = new System.Drawing.Point(8, 7);
            this.HitscanRadiusAddLabel.Name = "HitscanRadiusAddLabel";
            this.HitscanRadiusAddLabel.Size = new System.Drawing.Size(137, 23);
            this.HitscanRadiusAddLabel.TabIndex = 19;
            this.HitscanRadiusAddLabel.Text = "Hitscan Radius Add";
            // 
            // AdvancedOptions
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(350, 480);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.AimbotPanel);
            this.Controls.Add(this.OtherPanel);
            this.Controls.Add(this.RelaxPanel);
            this.Controls.Add(this.OtherButton);
            this.Controls.Add(this.AimbotButton);
            this.Controls.Add(this.RelaxButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancedOptions";
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.AdvancedOptions_Load);
            this.AimbotPanel.ResumeLayout(false);
            this.AimbotPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinAreaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitcircleRadiusNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementToNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementFromNumeric)).EndInit();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.OtherPanel.ResumeLayout(false);
            this.OtherPanel.PerformLayout();
            this.RelaxPanel.ResumeLayout(false);
            this.RelaxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HitscanRadiusMulNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HitscanRadiusAddNumeric)).EndInit();
            this.ResumeLayout(false);

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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AimbotButton_Click(object sender, EventArgs e)
        {
            HidePanels();
            ResetButtons();
            AimbotButton.Checked = true;

            AimbotPanel.Show();
            MovementFromNumeric.Value = Config.config.aimbotsettings.movementdelay.from;
            MovementToNumeric.Value = Config.config.aimbotsettings.movementdelay.to;
            HitcircleRadiusSlider.Value = Config.config.aimbotsettings.hitobjectradius;
            HitcircleRadiusNumeric.Value = Config.config.aimbotsettings.hitobjectradius;
            MinAreaSlider.Value = Config.config.aimbotsettings.minarea;
            MinAreaNumeric.Value = Config.config.aimbotsettings.minarea;
        }

        private void RelaxButton_Click(object sender, EventArgs e)
        {
            HidePanels();
            ResetButtons();
            RelaxButton.Checked = true;

            RelaxPanel.Show();

            HitscanRadiusAddSlider.Value = Config.config.relaxsettings.hitscanradiusadd;
            HitscanRadiusAddNumeric.Value = Config.config.relaxsettings.hitscanradiusadd;
            int strengthSliderValue = Math.Max(this.HitscanRadiusMulSlider.Minimum, Math.Min(this.HitscanRadiusMulSlider.Maximum, (int)(Config.config.relaxsettings.hitscanmultiplier * 100)));
            HitscanRadiusMulSlider.Value = strengthSliderValue;
            HitscanRadiusMulNumeric.Value = (decimal)Math.Min(1f, (Config.config.relaxsettings.hitscanmultiplier + (float)HitscanRadiusMulNumeric.Increment));
        }

        private void OtherButton_Click(object sender, EventArgs e)
        {
            HidePanels();
            ResetButtons();
            OtherButton.Checked = true;

            OtherPanel.Show();

            AimbotOverrideSwitch.Checked = Config.config.overrides.overrideaimbot;
        }

        private void ResetButtons()
        {
            AimbotButton.Checked = false;
            RelaxButton.Checked = false;
            OtherButton.Checked = false;
        }

        private void HidePanels()
        {
            AimbotPanel.Hide();
            RelaxPanel.Hide();
            OtherPanel.Hide();
        }

        private void AdvancedOptions_Load(object sender, EventArgs e)
        {
            this.AimbotButton_Click(null, null);
        }

        private void MovementFromNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.movementdelay = new VarianceInt((int)MovementFromNumeric.Value, Config.config.aimbotsettings.movementdelay.to);
        }

        private void MovementToNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.movementdelay = new VarianceInt(Config.config.aimbotsettings.movementdelay.from, (int)MovementToNumeric.Value);
        }

        private void HitcircleRadiusSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.hitobjectradius = HitcircleRadiusSlider.Value;
            HitcircleRadiusNumeric.Value = HitcircleRadiusSlider.Value;
        }

        private void HitcircleRadiusNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.hitobjectradius = (int)HitcircleRadiusNumeric.Value;
            HitcircleRadiusSlider.Value = (int)HitcircleRadiusNumeric.Value;
        }

        private void MinAreaSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.minarea = MinAreaSlider.Value;
            MinAreaNumeric.Value = MinAreaSlider.Value;
        }

        private void MinAreaNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.aimbotsettings.minarea = (int)MinAreaNumeric.Value;
            MinAreaSlider.Value = (int)MinAreaNumeric.Value;
        }

        private void HitscanRadiusAddNumeric_ValueChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.hitscanradiusadd = (int)HitscanRadiusAddNumeric.Value;
            HitscanRadiusAddSlider.Value = (int)HitscanRadiusAddNumeric.Value;
        }

        private void HitscanRadiusAddSlider_ValueChanged(object sender, EventArgs e)
        {
            Config.config.relaxsettings.hitscanradiusadd = HitscanRadiusAddSlider.Value;
            HitscanRadiusAddNumeric.Value = HitscanRadiusAddSlider.Value;
        }

        private void AimbotOverrideSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Config.config.overrides.overrideaimbot = AimbotOverrideSwitch.Checked;
        }

        private void HitscanRadiusMulSlider_ValueChanged(object sender, EventArgs e)
        {
            float mul = Math.Max(0f, Math.Min(1f, (float)this.HitscanRadiusMulSlider.Value / 100f));
            Config.config.relaxsettings.hitscanmultiplier = mul;

            decimal numericValue = (decimal)mul;
            if (numericValue != this.HitscanRadiusMulNumeric.Value)
            {
                this.HitscanRadiusMulNumeric.Value = Math.Max(this.HitscanRadiusMulNumeric.Minimum,
                                                                Math.Min(this.HitscanRadiusMulNumeric.Maximum, numericValue));
            }
        }

        private void HitscanRadiusMulNumeric_ValueChanged(object sender, EventArgs e)
        {
            decimal mul = Math.Max(0m, Math.Min(1m, this.HitscanRadiusMulNumeric.Value));
            Config.config.relaxsettings.hitscanmultiplier = (float)mul;

            int sliderValue = (int)(mul * 100);
            if (sliderValue != this.HitscanRadiusMulSlider.Value)
            {
                this.HitscanRadiusMulSlider.Value = Math.Max(this.HitscanRadiusMulSlider.Minimum,
                                                   Math.Min(this.HitscanRadiusMulSlider.Maximum, sliderValue));
            }
        }
    }
}
