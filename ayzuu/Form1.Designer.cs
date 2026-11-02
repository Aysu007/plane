namespace PlaneApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        panelRunway = new Panel();
        pictureBox1 = new PictureBox();
        pictureBox6 = new PictureBox();
        car = new PictureBox();
        panelControls = new Panel();
        btnLanding = new Button();
        btnTurbulence = new Button();
        btnSeatbelts = new Button();
        btnThanks = new Button();
        btnBeep = new Button();
        button1 = new Button();
        button2 = new Button();
        button4 = new Button();
        button3 = new Button();
        comboBox1 = new ComboBox();
        timer1 = new System.Windows.Forms.Timer(components);
        timer2 = new System.Windows.Forms.Timer(components);

        panelRunway.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
        ((System.ComponentModel.ISupportInitialize)car).BeginInit();
        panelControls.SuspendLayout();
        SuspendLayout();

        // 
        // panelRunway
        // 
        panelRunway.BackColor = Color.FromArgb(96, 96, 96);
        panelRunway.Controls.Add(pictureBox1);
        panelRunway.Controls.Add(pictureBox6);
        panelRunway.Controls.Add(car);
        panelRunway.Location = new Point(0, 0);
        panelRunway.Name = "panelRunway";
        panelRunway.Size = new Size(260, 480);
        panelRunway.TabIndex = 0;

        // 
        // pictureBox1 (Headlight flare)
        // 
        pictureBox1.BackColor = Color.Transparent;
        pictureBox1.Location = new Point(105, 265);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(50, 50);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;

        // 
        // pictureBox6 (Secondary light flare)
        // 
        pictureBox6.BackColor = Color.Transparent;
        pictureBox6.Location = new Point(105, 265);
        pictureBox6.Name = "pictureBox6";
        pictureBox6.Size = new Size(50, 50);
        pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox6.TabIndex = 2;
        pictureBox6.TabStop = false;

        // 
        // car (Airplane)
        // 
        car.BackColor = Color.Transparent;
        car.Location = new Point(60, 280);
        car.Name = "car";
        car.Size = new Size(140, 165);
        car.SizeMode = PictureBoxSizeMode.Zoom;
        car.TabIndex = 0;
        car.TabStop = false;

        // 
        // panelControls
        // 
        panelControls.BackColor = Color.FromArgb(235, 235, 235);
        panelControls.Controls.Add(btnLanding);
        panelControls.Controls.Add(btnTurbulence);
        panelControls.Controls.Add(btnSeatbelts);
        panelControls.Controls.Add(btnThanks);
        panelControls.Controls.Add(btnBeep);
        panelControls.Controls.Add(button1);
        panelControls.Controls.Add(button2);
        panelControls.Controls.Add(button4);
        panelControls.Controls.Add(button3);
        panelControls.Controls.Add(comboBox1);
        panelControls.Location = new Point(260, 0);
        panelControls.Name = "panelControls";
        panelControls.Size = new Size(345, 480);
        panelControls.TabIndex = 1;

        // 
        // btnLanding (Eniş hazırlığı)
        // 
        btnLanding.BackColor = Color.FromArgb(255, 127, 0);
        btnLanding.FlatAppearance.BorderSize = 1;
        btnLanding.FlatStyle = FlatStyle.Flat;
        btnLanding.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnLanding.ForeColor = Color.Black;
        btnLanding.Location = new Point(12, 12);
        btnLanding.Name = "btnLanding";
        btnLanding.Size = new Size(320, 36);
        btnLanding.TabIndex = 0;
        btnLanding.Text = "Eniş hazırlığı";
        btnLanding.UseVisualStyleBackColor = false;

        // 
        // btnTurbulence (Turbulans)
        // 
        btnTurbulence.BackColor = Color.FromArgb(255, 127, 0);
        btnTurbulence.FlatAppearance.BorderSize = 1;
        btnTurbulence.FlatStyle = FlatStyle.Flat;
        btnTurbulence.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnTurbulence.ForeColor = Color.Black;
        btnTurbulence.Location = new Point(12, 54);
        btnTurbulence.Name = "btnTurbulence";
        btnTurbulence.Size = new Size(320, 36);
        btnTurbulence.TabIndex = 1;
        btnTurbulence.Text = "Turbulans";
        btnTurbulence.UseVisualStyleBackColor = false;

        // 
        // btnSeatbelts (Kəmərlər)
        // 
        btnSeatbelts.BackColor = Color.FromArgb(255, 127, 0);
        btnSeatbelts.FlatAppearance.BorderSize = 1;
        btnSeatbelts.FlatStyle = FlatStyle.Flat;
        btnSeatbelts.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnSeatbelts.ForeColor = Color.Black;
        btnSeatbelts.Location = new Point(12, 96);
        btnSeatbelts.Name = "btnSeatbelts";
        btnSeatbelts.Size = new Size(320, 36);
        btnSeatbelts.TabIndex = 2;
        btnSeatbelts.Text = "Kəmərlər";
        btnSeatbelts.UseVisualStyleBackColor = false;

        // 
        // btnThanks (Təşəkkürlər)
        // 
        btnThanks.BackColor = Color.FromArgb(255, 127, 0);
        btnThanks.FlatAppearance.BorderSize = 1;
        btnThanks.FlatStyle = FlatStyle.Flat;
        btnThanks.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnThanks.ForeColor = Color.Black;
        btnThanks.Location = new Point(12, 138);
        btnThanks.Name = "btnThanks";
        btnThanks.Size = new Size(320, 36);
        btnThanks.TabIndex = 3;
        btnThanks.Text = "Təşəkkürlər";
        btnThanks.UseVisualStyleBackColor = false;

        // 
        // btnBeep (Beep)
        // 
        btnBeep.BackColor = Color.FromArgb(255, 127, 0);
        btnBeep.FlatAppearance.BorderSize = 1;
        btnBeep.FlatStyle = FlatStyle.Flat;
        btnBeep.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnBeep.ForeColor = Color.Black;
        btnBeep.Location = new Point(12, 180);
        btnBeep.Name = "btnBeep";
        btnBeep.Size = new Size(320, 36);
        btnBeep.TabIndex = 4;
        btnBeep.Text = "Beep";
        btnBeep.UseVisualStyleBackColor = false;

        // 
        // button1 (GAS)
        // 
        button1.BackColor = Color.FromArgb(0, 138, 0);
        button1.FlatAppearance.BorderSize = 1;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button1.ForeColor = Color.White;
        button1.Location = new Point(18, 236);
        button1.Name = "button1";
        button1.Size = new Size(138, 52);
        button1.TabIndex = 5;
        button1.Text = "GAS";
        button1.UseVisualStyleBackColor = false;

        // 
        // button2 (Break)
        // 
        button2.BackColor = Color.FromArgb(180, 0, 0);
        button2.FlatAppearance.BorderSize = 1;
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button2.ForeColor = Color.White;
        button2.Location = new Point(188, 236);
        button2.Name = "button2";
        button2.Size = new Size(138, 52);
        button2.TabIndex = 6;
        button2.Text = "Break";
        button2.UseVisualStyleBackColor = false;

        // 
        // button4 (ON/OFF)
        // 
        button4.BackColor = Color.FromArgb(0, 0, 204);
        button4.FlatAppearance.BorderColor = Color.White;
        button4.FlatAppearance.BorderSize = 2;
        button4.FlatStyle = FlatStyle.Flat;
        button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        button4.ForeColor = Color.White;
        button4.Location = new Point(6, 298);
        button4.Name = "button4";
        button4.Size = new Size(332, 44);
        button4.TabIndex = 7;
        button4.Text = "ON/OFF";
        button4.UseVisualStyleBackColor = false;

        // 
        // button3 (Exit Button - hidden shortcut or accessible)
        // 
        button3.Location = new Point(230, 440);
        button3.Name = "button3";
        button3.Size = new Size(100, 26);
        button3.TabIndex = 8;
        button3.Text = "Exit";
        button3.Visible = false;

        // 
        // comboBox1 (Speed selector)
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "10", "20", "30", "50" });
        comboBox1.Location = new Point(18, 440);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(100, 23);
        comboBox1.TabIndex = 9;
        comboBox1.Visible = false;

        // 
        // timer1 (Gas / Forward Timer)
        // 
        timer1.Interval = 20;

        // 
        // timer2 (Reverse Timer)
        // 
        timer2.Interval = 20;

        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(605, 360);
        Controls.Add(panelControls);
        Controls.Add(panelRunway);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Plane";

        panelRunway.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
        ((System.ComponentModel.ISupportInitialize)car).EndInit();
        panelControls.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelRunway;
    private Panel panelControls;
    private PictureBox car;
    private PictureBox pictureBox1;
    private PictureBox pictureBox6;
    private Button btnLanding;
    private Button btnTurbulence;
    private Button btnSeatbelts;
    private Button btnThanks;
    private Button btnBeep;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private ComboBox comboBox1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Timer timer2;
}
