using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        //폼 기본 클래스
        private FMOD.System system = null;//system 변수
        private FMOD.Sound[] sound = new FMOD.Sound[32];//sound 변수
        private FMOD.Channel[] channel = new FMOD.Channel[32];
        //private bool paused = false;
        //private bool playing = false;

        string a = "C:/Users/JYCHOI/Downloads/Alex_Medvick_-_Master_of_Man_Soundpack_(Week_2)_(Ableton-Traktor-WAVs)/Alex Medvick - Master of Man Soundpack (Week 2) (Ableton-Traktor-WAVs)/Alex Medvick - Master of Man WAVs/1-Kick.wav";
        string b = "C:/Users/JYCHOI/Downloads/Alex_Medvick_-_Master_of_Man_Soundpack_(Week_2)_(Ableton-Traktor-WAVs)/Alex Medvick - Master of Man Soundpack (Week 2) (Ableton-Traktor-WAVs)/Alex Medvick - Master of Man WAVs/5-Eeehhhxt.wav";
        string c = "C:/Users/JYCHOI/Downloads/Alex_Medvick_-_Master_of_Man_Soundpack_(Week_2)_(Ableton-Traktor-WAVs)/Alex Medvick - Master of Man Soundpack (Week 2) (Ableton-Traktor-WAVs)/Alex Medvick - Master of Man WAVs/7-Mastery of Man.wav";

        bool active=false;

        //private int channelsplaying = 0;

        static void Main()
        {
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uint version = 0;
            FMOD.RESULT result;

            result = FMOD.Factory.System_Create(ref system);

            result = system.getVersion(ref version);

            result = system.init(100, FMOD.INITFLAGS.NORMAL, (IntPtr)null);

            result = system.createSound(a, (FMOD.MODE._2D | FMOD.MODE.HARDWARE | FMOD.MODE.CREATESTREAM), ref sound[0]);

            result = sound[0].setMode(FMOD.MODE.LOOP_NORMAL);

            result = system.createSound(b, (FMOD.MODE._2D | FMOD.MODE.HARDWARE | FMOD.MODE.CREATESTREAM), ref sound[1]);

            result = sound[1].setMode(FMOD.MODE.LOOP_NORMAL);

            result = system.createSound(c, (FMOD.MODE._2D | FMOD.MODE.SOFTWARE | FMOD.MODE.CREATESTREAM), ref sound[2]);

            result = sound[2].setMode(FMOD.MODE.LOOP_NORMAL);
        }

        private void ON_Click(object sender, EventArgs e)
        {//사운드재생 켜기
            active = true;
        }

        private void ON_KeyDown(object sender, KeyEventArgs e)
        {
            if (active)
            {
                if (e.KeyCode == Keys.Q)
                {
                    FMOD.RESULT result;

                    result = system.playSound(FMOD.CHANNELINDEX.FREE, sound[0], false, ref channel[0]);
                }
                else if (e.KeyCode == Keys.W)
                {
                    FMOD.RESULT result;
                    bool paused = false;

                    if (channel != null)
                    {
                        result = channel[0].getPaused(ref paused);
                        //ERRCHECK(result);
                        result = channel[0].setPaused(!paused);
                        //ERRCHECK(result);
                    }
                }
                if (e.KeyCode == Keys.A)
                {
                    FMOD.RESULT result;

                    result = system.playSound(FMOD.CHANNELINDEX.FREE, sound[1], false, ref channel[1]);
                }
                else if (e.KeyCode == Keys.S)
                {
                    FMOD.RESULT result;
                    bool paused = false;

                    if (channel != null)
                    {
                        result = channel[1].getPaused(ref paused);
                        //ERRCHECK(result);
                        result = channel[1].setPaused(!paused);
                        //ERRCHECK(result);
                    }
                }
                if (e.KeyCode == Keys.Z)
                {
                    FMOD.RESULT result;

                    result = system.playSound(FMOD.CHANNELINDEX.FREE, sound[2], false, ref channel[2]);
                }
                else if (e.KeyCode == Keys.X)
                {
                    FMOD.RESULT result;
                    bool paused = false;

                    if (channel != null)
                    {
                        result = channel[2].getPaused(ref paused);
                        //ERRCHECK(result);
                        result = channel[2].setPaused(!paused);
                        //ERRCHECK(result);
                    }
                }
            }
        }

        private void OFF_Click(object sender, EventArgs e)
        {//사운드재생 끄기
            active = false;

            for (int i = 0; i < 32; i++)
            {
                FMOD.RESULT result;
                bool paused = false;

                if (channel[i] != null)
                {
                    //result = channel[i].getPaused(ref paused);
                    //  ERRCHECK(result);
                    result = channel[i].setPaused(!paused);
                    //ERRCHECK(result);
                }
            }
        }

        
    }
}