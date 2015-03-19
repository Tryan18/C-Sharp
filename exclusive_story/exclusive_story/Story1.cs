/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WMPLib;
using System.Windows.Forms;
using System.IO;

namespace exclusive_story
{
    public class Story1
    {
        private Form1 form;
        private List<String> tekst = new List<string>();
        private WindowsMediaPlayer music = new WindowsMediaPlayer();
        private WindowsMediaPlayer sound = new WindowsMediaPlayer();
        private PictureBox yoshi = new PictureBox();
        private PictureBox boo = new PictureBox();
        private Timer boo_animation = new Timer();
        private Timer scene_animation = new Timer();
        private Timer yoshi_animation = new Timer();
        private int tikker = 0;
        private bool scare = false;
        private int scene = 0;

        public Story1(Form1 f)
        {
            form = f;
            form.L_title.Text = "Story : Yoshi's Island      ";
            tekst.Add("Yoshi : Hey, Mario look over there is a BOO coming this way.      ");
            tekst.Add("Boo : BOOOO, i'm a scary ghost can you see me?      ");
            tekst.Add("Yoshi : well, uhm.. i can't see your eyes that is.      ");
            tekst.Add("Boo : well well what about this?      ");
            tekst.Add("Boo : Coming for yaa :D");
            tekst.Add("Yoshi : WAAAAAAH !!! run away!");
            yoshi_animation.Interval = 500;
            yoshi_animation.Tick += new EventHandler(yoshi_animation_Tick);
            boo_animation.Interval = 1000;
            boo_animation.Tick += new EventHandler(boo_animation_Tick);
            scene_animation.Interval = 1000;
            scene_animation.Tick += new EventHandler(scene_animation_Tick);
            scene_animation.Start();
        }

        void yoshi_animation_Tick(object sender, EventArgs e)
        {
            switch (scene)
            {
                case 1:
                    if ((yoshi.Left + yoshi.Width) > 0)
                        yoshi.Left -= 5;
                    else
                        (sender as Timer).Stop();
                    break;
            }
        }

        void boo_animation_Tick(object sender, EventArgs e)
        {
            switch (scene)
            {
                case 0:
                    if (scare)
                        boo.Image = Properties.Resources.boe;
                    else
                        boo.Image = Properties.Resources.boe_scare;
                    scare = !scare;
                    break;
                case 1:
                    if (boo.Left > 0)
                        boo.Left -= 5;
                    else
                        boo_animation.Stop();
                    break;
            }
        }

        void scene_animation_Tick(object sender, EventArgs e)
        {
            if (!form.log.speedtekst.Enabled)
            {
                switch (tikker)
                {
                    case 0:
                        form.log.inputTekst(tekst[1]);
                        form.log.Start();
                        break;
                    case 1:
                        form.log.inputTekst(tekst[2]);
                        form.log.Start();
                        break;
                    case 2:
                        form.log.inputTekst(tekst[3]);
                        form.log.Start();
                        boo_animation.Start();
                        break;
                    case 3:
                        form.log.inputTekst(tekst[4]);
                        form.log.Start();
                        boo_animation.Stop();
                        boo_animation.Interval = 100;
                        scene = 1;
                        boo_animation.Start();
                        break;
                    case 4:
                        form.log.inputTekst(tekst[5]);
                        form.log.Start();
                        yoshi.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        yoshi_animation.Start();
                        (sender as Timer).Stop();
                        break;
                }
                tikker++;
            }
        }

        public void Start()
        {
            String fileName = "yoshi_island.mp3";
            if (!File.Exists(Application.StartupPath + "//yoshi_island.mp3"))
            {
                byte[] buffer = Properties.Resources.yoshi_island;
                FileStream outputStream = new FileStream(fileName, FileMode.Create);
                outputStream.Write(buffer, 0, buffer.Length);
                outputStream.Close();
            }
            music.URL = fileName;
            music.controls.play();
            form.log.inputTekst(tekst[0]);
            form.log.Start();

            //yoshi coming
            yoshi.Image = Properties.Resources.yoshi_mario;
            yoshi.Width = 200;
            yoshi.Height = 200;
            yoshi.Top = form.P_story.Top + (form.P_story.Height/6);
            yoshi.Left = form.P_story.Left;
            yoshi.SizeMode = PictureBoxSizeMode.StretchImage;
            yoshi.Show();
            form.P_story.Controls.Add(yoshi);


            //BOO coming
            boo.Image = Properties.Resources.boe;
            boo.Width = 100;
            boo.Height = 100;
            boo.Top = form.P_story.Top + (form.P_story.Height / 4);
            boo.Left = form.P_story.Left + (form.P_story.Width - boo.Width);
            boo.SizeMode = PictureBoxSizeMode.StretchImage;
            boo.Show();
            form.P_story.Controls.Add(boo);

        }

        public void Stop()
        {
            music.controls.pause();
            sound.controls.pause();
        }
    }
}
