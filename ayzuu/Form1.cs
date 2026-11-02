using System.Media;
using System.Speech.Synthesis;

namespace PlaneApp;

public partial class Form1 : Form
{
    private bool Gas = false;
    private bool Rev = false;
    private bool k = true; // Lights initially ON as in screenshot
    private SoundPlayer? sp;
    private SoundPlayer? spSeatbelt;
    private SoundPlayer? spBeep;
    private SoundPlayer? spTurbulence;
    private SpeechSynthesizer? synth;
    private System.Windows.Forms.Timer? shakeTimer;
    private int shakeCount = 0;
    private int originalCarX = 60;

    public Form1()
    {
        InitializeComponent();
        InitializeGame();
    }

    private void InitializeGame()
    {
        KeyPreview = true;
        KeyDown += Form1_KeyDown;
        FormClosing += Form1_FormClosing;

        // Load images
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string planePath = Path.Combine(baseDir, "plane.png");
        string lightPath = Path.Combine(baseDir, "light.png");

        if (File.Exists(planePath))
        {
            car.Image = Image.FromFile(planePath);
        }

        if (File.Exists(lightPath))
        {
            pictureBox1.Image = Image.FromFile(lightPath);
            pictureBox6.Image = Image.FromFile(lightPath);
        }

        // Align plane and lights initially
        car.Location = new Point((panelRunway.Width - car.Width) / 2, 190);
        originalCarX = car.Location.X;
        UpdateLightsPosition();

        // Initially lights are visible (matching screenshot)
        pictureBox1.Visible = true;
        pictureBox6.Visible = true;

        // Load sounds
        string soundPath = Path.Combine(baseDir, "sound.wav");
        if (File.Exists(@"D:\C# lesson\img and details\sound.wav"))
            soundPath = @"D:\C# lesson\img and details\sound.wav";

        if (File.Exists(soundPath))
        {
            try { sp = new SoundPlayer(soundPath); } catch { }
        }

        string seatbeltPath = Path.Combine(baseDir, "seatbelt.wav");
        if (File.Exists(seatbeltPath))
        {
            try { spSeatbelt = new SoundPlayer(seatbeltPath); } catch { }
        }

        string beepPath = Path.Combine(baseDir, "beep.wav");
        if (File.Exists(beepPath))
        {
            try { spBeep = new SoundPlayer(beepPath); } catch { }
        }

        string turbulencePath = Path.Combine(baseDir, "turbulence.wav");
        if (File.Exists(turbulencePath))
        {
            try { spTurbulence = new SoundPlayer(turbulencePath); } catch { }
        }

        // Initialize Speech Synthesizer for cabin announcements
        try
        {
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
        }
        catch
        {
            synth = null;
        }

        // Connect button events
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        button3.Click += button3_Click;
        button4.Click += button4_Click;
        btnLanding.Click += btnLanding_Click;
        btnTurbulence.Click += btnTurbulence_Click;
        btnSeatbelts.Click += btnSeatbelts_Click;
        btnThanks.Click += btnThanks_Click;
        btnBeep.Click += btnBeep_Click;

        timer1.Tick += timer1_Tick;
        timer2.Tick += timer2_Tick;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        // Turbulence shake timer
        shakeTimer = new System.Windows.Forms.Timer(components);
        shakeTimer.Interval = 35;
        shakeTimer.Tick += ShakeTimer_Tick;

        // Draw runway centerline marks
        panelRunway.Paint += PanelRunway_Paint;
    }

    private void PanelRunway_Paint(object? sender, PaintEventArgs e)
    {
        using Pen dashedPen = new Pen(Color.FromArgb(140, 255, 255, 255), 3);
        dashedPen.DashPattern = new float[] { 8, 8 };
        int centerX = panelRunway.Width / 2;
        e.Graphics.DrawLine(dashedPen, centerX, 0, centerX, panelRunway.Height);
    }

    private void UpdateLightsPosition()
    {
        int lightX = car.Location.X + (car.Width - pictureBox1.Width) / 2;
        int lightY = car.Location.Y - 15;
        pictureBox1.Location = new Point(lightX, lightY);
        pictureBox6.Location = new Point(lightX, lightY);
    }

    // 1. GAS Button
    private void button1_Click(object? sender, EventArgs e)
    {
        try
        {
            sp?.PlayLooping();
        }
        catch { }

        Gas = true;
        Rev = false;
        timer2.Stop();
        timer1.Start();
    }

    // 2. Break Button
    private void button2_Click(object? sender, EventArgs e)
    {
        try
        {
            sp?.Stop();
        }
        catch { }

        Gas = false;
        Rev = false;
        timer1.Stop();
        timer2.Stop();
    }

    // 3. Exit Confirmation
    private void button3_Click(object? sender, EventArgs e)
    {
        DialogResult d = MessageBox.Show("Are you sure game exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (d == DialogResult.Yes)
        {
            Close();
        }
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        DialogResult d = MessageBox.Show("Are you sure game exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (d == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

    // 4. ON/OFF Button (Headlights)
    private void button4_Click(object? sender, EventArgs e)
    {
        if (k == false)
        {
            k = true;
            button4.Text = "ON";
            pictureBox1.Visible = false;
            pictureBox6.Visible = false;
        }
        else
        {
            k = false;
            button4.Text = "OFF";
            pictureBox1.Visible = true;
            pictureBox6.Visible = true;
        }
    }

    // Forward movement (Gas)
    private void timer1_Tick(object? sender, EventArgs e)
    {
        if (Gas == true && car.Location.Y > 0)
        {
            car.Location = new Point(car.Location.X, car.Location.Y - 2);
            UpdateLightsPosition();
        }
        else
        {
            timer1.Stop();
            Gas = false;
            try { sp?.Stop(); } catch { }
            MessageBox.Show("Way end", "Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Reverse movement
    private void timer2_Tick(object? sender, EventArgs e)
    {
        if (Rev == true && car.Location.Y < panelRunway.Height - car.Height - 10)
        {
            car.Location = new Point(car.Location.X, car.Location.Y + 2);
            UpdateLightsPosition();
        }
        else
        {
            timer2.Stop();
            Rev = false;
            try { sp?.Stop(); } catch { }
            MessageBox.Show("Way end", "Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (int.TryParse(comboBox1.Text, out int b))
        {
            timer1.Interval = Math.Max(5, b);
        }
    }

    // Left navigation
    public void MoveLeft()
    {
        if (car.Location.X > 10)
        {
            car.Location = new Point(car.Location.X - 25, car.Location.Y);
            UpdateLightsPosition();
        }
    }

    // Right navigation
    public void MoveRight()
    {
        if (car.Location.X < panelRunway.Width - car.Width - 10)
        {
            car.Location = new Point(car.Location.X + 25, car.Location.Y);
            UpdateLightsPosition();
        }
    }

    private void pictureBox2_Click(object? sender, EventArgs e)
    {
        MoveLeft();
    }

    private void pictureBox3_Click(object? sender, EventArgs e)
    {
        MoveRight();
    }

    private void pictureBox4_Click(object? sender, EventArgs e)
    {
        Rev = true;
        Gas = false;
        timer1.Stop();
        timer2.Start();
    }

    private void pictureBox5_Click(object? sender, EventArgs e)
    {
        Gas = true;
        Rev = false;
        timer2.Stop();
        timer1.Start();
    }

    // Keyboard support for controls
    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
            case Keys.W:
                button1_Click(button1, EventArgs.Empty);
                break;
            case Keys.Down:
            case Keys.S:
                pictureBox4_Click(null, EventArgs.Empty);
                break;
            case Keys.Left:
            case Keys.A:
                MoveLeft();
                break;
            case Keys.Right:
            case Keys.D:
                MoveRight();
                break;
            case Keys.Space:
                button2_Click(button2, EventArgs.Empty);
                break;
            case Keys.L:
                button4_Click(button4, EventArgs.Empty);
                break;
        }
    }

    // Announcement 1: Eniş hazırlığı
    private void btnLanding_Click(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                spSeatbelt?.PlaySync();
                synth?.Speak("Diqqət, eniş hazırlığı! Təhlükəsizlik kəmərlərinizi bağlayın.");
            }
            catch { }
        });
    }

    // Announcement 2: Turbulans
    private void btnTurbulence_Click(object? sender, EventArgs e)
    {
        originalCarX = car.Location.X;
        shakeCount = 20;
        shakeTimer?.Start();

        Task.Run(() =>
        {
            try
            {
                spTurbulence?.PlaySync();
                synth?.Speak("Diqqət, turbulans zonası! Zəhmət olmasa yerinizdə əyləşin.");
            }
            catch { }
        });
    }

    private void ShakeTimer_Tick(object? sender, EventArgs e)
    {
        if (shakeCount > 0)
        {
            shakeCount--;
            int offset = (shakeCount % 2 == 0) ? 6 : -6;
            car.Location = new Point(Math.Clamp(originalCarX + offset, 5, panelRunway.Width - car.Width - 5), car.Location.Y);
            UpdateLightsPosition();
        }
        else
        {
            shakeTimer?.Stop();
            car.Location = new Point(originalCarX, car.Location.Y);
            UpdateLightsPosition();
        }
    }

    // Announcement 3: Kəmərlər
    private void btnSeatbelts_Click(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                spSeatbelt?.PlaySync();
                synth?.Speak("Təhlükəsizlik kəmərlərinizi bağlayın.");
            }
            catch { }
        });
    }

    // Announcement 4: Təşəkkürlər
    private void btnThanks_Click(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                spSeatbelt?.PlaySync();
                synth?.Speak("Bizimlə uçduğunuz üçün təşəkkür edirik! Xoş günlər.");
            }
            catch { }
        });
    }

    // Announcement 5: Beep
    private void btnBeep_Click(object? sender, EventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                spBeep?.Play();
            }
            catch
            {
                Console.Beep(880, 200);
            }
        });
    }
}
