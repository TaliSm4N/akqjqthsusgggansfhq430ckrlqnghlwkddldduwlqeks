/*===============================================================================================
 PlaySound Example
 Copyright (c), Firelight Technologies Pty, Ltd 2004-2014.

 This example shows how to simply load and play multiple sounds.  This is about the simplest
 use of FMOD.
 This makes FMOD decode the into memory when it loads.  If the sounds are big and possibly take
 up a lot of ram, then it would be better to use the FMOD_CREATESTREAM flag so that it is 
 streamed in realtime as it plays.
===============================================================================================*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace playsound
{
    public class PlaySound : System.Windows.Forms.Form
    {
        private FMOD.System     system  = null;
        private FMOD.Sound      sound1  = null, sound2 = null, sound3 = null;
        private FMOD.Channel    channel = null;
        private uint            ms      = 0;
        private uint            lenms   = 0;
        private bool            playing = false;
        private bool            paused  = false;
        private int channelsplaying = 0;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Label label;
        private CheckBox checkBox1;
        private Button button1;
        private System.ComponentModel.IContainer components;

        bool active = false;

        public PlaySound()
        {
            InitializeComponent();
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                FMOD.RESULT     result;
            
                /*
                    Shut down
                */
                if (sound1 != null)
                {
                    result = sound1.release();
                    ERRCHECK(result);
                }
                if (sound2 != null)
                {
                    result = sound2.release();
                    ERRCHECK(result);
                }
                if (sound3 != null)
                {
                    result = sound3.release();
                    ERRCHECK(result);
                }

                if (system != null)
                {
                    result = system.close();
                    ERRCHECK(result);
                    result = system.release();
                    ERRCHECK(result);
                }

                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 251);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(527, 26);
            this.statusBar.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(0, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(288, 34);
            this.label.TabIndex = 5;
            this.label.Text = "Copyright (c) Firelight Technologies 2004-2014";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(321, 153);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // PlaySound
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(527, 277);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.statusBar);
            this.Name = "PlaySound";
            this.Text = "Play Sound Example";
            this.Load += new System.EventHandler(this.PlaySound_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlaySound_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main() 
        {
            Application.Run(new PlaySound());
        }

        private void PlaySound_Load(object sender, System.EventArgs e)
        {
            uint            version = 0;
            FMOD.RESULT     result;

            /*
                Create a System object and initialize.
            */
            result = FMOD.Factory.System_Create(ref system);
            ERRCHECK(result);

            result = system.getVersion(ref version);
            ERRCHECK(result);
            if (version < FMOD.VERSION.number)
            {
                MessageBox.Show("Error!  You are using an old version of FMOD " + version.ToString("X") + ".  This program requires " + FMOD.VERSION.number.ToString("X") + ".");
                Application.Exit();
            }

            result = system.init(100, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
            ERRCHECK(result);

            result = system.createSound("../../../../../examples/media/drumloop.wav", (FMOD.MODE._2D | FMOD.MODE.HARDWARE | FMOD.MODE.CREATESTREAM), ref sound1);
            ERRCHECK(result);


            result = sound1.setMode(FMOD.MODE.LOOP_NORMAL);

            ERRCHECK(result);

            result = system.createSound("../../../../../examples/media/jaguar.wav", FMOD.MODE.SOFTWARE, ref sound2);
            ERRCHECK(result);

            result = system.createSound("../../../../../examples/media/swish.wav", FMOD.MODE.HARDWARE, ref sound3);
            ERRCHECK(result);
        }

      //  private void button1_Click(object sender, System.EventArgs e)
      //  {
      //      FMOD.RESULT     result;
      // 
      //      result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, false, ref channel);
      //      ERRCHECK(result);
      //  }
      // 
      //  private void button2_Click(object sender, System.EventArgs e)
      //  {
      //      FMOD.RESULT     result;
      // 
      //      result = system.playSound(FMOD.CHANNELINDEX.FREE, sound2, false, ref channel);
      //      ERRCHECK(result);
      //  }
      // 
      //  private void button3_Click(object sender, System.EventArgs e)
      //  {
      //      FMOD.RESULT     result;
      // 
      //      result = system.playSound(FMOD.CHANNELINDEX.FREE, sound3, false, ref channel);
      //      ERRCHECK(result);
      //  }
       
        //private void exit_button_Click(object sender, System.EventArgs e)
        //{
        //    Application.Exit();
        //}
        //
        private void timer_Tick(object sender, System.EventArgs e)
        {   
            FMOD.RESULT     result;

            if (channel != null)
            {
                FMOD.Sound currentsound = null;

                result = channel.isPlaying(ref playing);
                if ((result != FMOD.RESULT.OK) && (result != FMOD.RESULT.ERR_INVALID_HANDLE) && (result != FMOD.RESULT.ERR_CHANNEL_STOLEN))
                {
                    ERRCHECK(result);
                }

                result = channel.getPaused(ref paused);
                if ((result != FMOD.RESULT.OK) && (result != FMOD.RESULT.ERR_INVALID_HANDLE) && (result != FMOD.RESULT.ERR_CHANNEL_STOLEN))
                {
                    ERRCHECK(result);
                }

                result = channel.getPosition(ref ms, FMOD.TIMEUNIT.MS);
                if ((result != FMOD.RESULT.OK) && (result != FMOD.RESULT.ERR_INVALID_HANDLE) && (result != FMOD.RESULT.ERR_CHANNEL_STOLEN))
                {
                    ERRCHECK(result);
                }
               
                channel.getCurrentSound(ref currentsound);
                if (currentsound != null)
                {
                    result = currentsound.getLength(ref lenms, FMOD.TIMEUNIT.MS);
                    if ((result != FMOD.RESULT.OK) && (result != FMOD.RESULT.ERR_INVALID_HANDLE) && (result != FMOD.RESULT.ERR_CHANNEL_STOLEN))
                    {
                        ERRCHECK(result);
                    }
                }
            }

            if (system != null)
            {
                system.getChannelsPlaying(ref channelsplaying);
            
                system.update();
            }

            statusBar.Text = "Time " + ms/1000/60 + ":" + ms/1000%60 + ":" + ms/10%100 + "/" + lenms/1000/60 + ":" + lenms/1000%60 + ":" + lenms/10%100
                + " : " + (paused ? "Paused " : playing ? "Playing" : "Stopped") + " : Channels Playing " + channelsplaying;
        }

        private void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                timer.Stop();
                MessageBox.Show("FMOD error! " + result + " - " + FMOD.Error.String(result));
                Environment.Exit(-1);
            }
        }

        private void PlaySound_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                FMOD.RESULT result;
                
                result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, false, ref channel);
                ERRCHECK(result);
            }
            else if (e.KeyCode == Keys.B)
            {
                FMOD.RESULT result;
                bool paused = false;

                if (channel != null)
                {
                    result = channel.getPaused(ref paused);
                    ERRCHECK(result);
                    result = channel.setPaused(!paused);
                    ERRCHECK(result);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.A)
            //{
            //    FMOD.RESULT result;
            //
            //    result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, false, ref channel);
            //    ERRCHECK(result);
            //}
            //else if (e.KeyCode == Keys.B)
            //{
            //    FMOD.RESULT result;
            //    bool paused = false;
            //
            //    if (channel != null)
            //    {
            //        result = channel.getPaused(ref paused);
            //        ERRCHECK(result);
            //        result = channel.setPaused(!paused);
            //        ERRCHECK(result);
            //    }
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //FMOD.RESULT result;
            

            if (active)
            {
                active = false;

                FMOD.RESULT result;
                bool paused = false;

                if (channel != null)
                {
                    result = channel.getPaused(ref paused);
                    ERRCHECK(result);
                    result = channel.setPaused(!paused);
                    ERRCHECK(result);
                }
            }
            else
            {
                active = true;
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (active)
            {
                if (e.KeyCode == Keys.A)
                {
                    FMOD.RESULT result;

                    result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, false, ref channel);
                    ERRCHECK(result);
                }
                else if (e.KeyCode == Keys.B)
                {
                    FMOD.RESULT result;
                    bool paused = false;

                    if (channel != null)
                    {
                        result = channel.getPaused(ref paused);
                        ERRCHECK(result);
                        result = channel.setPaused(!paused);
                        ERRCHECK(result);
                    }
                }
            }
        }

    }
}
