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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using GUI.UI_Klant_Beheer;
using GUI.UI_Thema_Beheer;
using GUI.UI_Kleuren_Beheer;
using CC;


namespace GUI
{
    public partial class UI_hoofd_menu : NForm
    {
        private Timer timer;

        public UI_hoofd_menu(string status)
        {
            InitializeComponent();
            maakRestrictie(status);
            L_status.Text = status;
            //set timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            
            //this.FrameAppearance = NUIManager.GetPredefinedFrame(PredefinedFrame.VistaSlate);
            FormClosed += new FormClosedEventHandler(Hoofd_Venster_FormClosed);
        }

        private void maakRestrictie(string status)
        {
            switch (status)
            {
                case "Systeem Beheerder":
                    tool_klantbeheer.Enabled = true;
                    tool_kleurenbeheer.Enabled = true;
                    tool_pakketbeheer.Enabled = true;
                    tool_productbeheer.Enabled = true;
                    tool_themabeheer.Enabled = true;
                    B_klantbeheer.Enabled = true;
                    B_kleurenbeheer.Enabled = true;
                    B_pakketbeheer.Enabled = true;
                    B_productbeheer.Enabled = true;
                    B_themabeheer.Enabled = true;
                    break;
                case "Klant Medewerker":
                    tool_klantbeheer.Enabled = true;
                    tool_pakketbeheer.Enabled = true;
                    B_klantbeheer.Enabled = true;
                    B_pakketbeheer.Enabled = true;
                    break;
                case "Ontwerper":
                    B_kleurenbeheer.Enabled = true;
                    tool_kleurenbeheer.Enabled = true;
                    tool_themabeheer.Enabled = true;
                    B_themabeheer.Enabled = true;
                    break;
                case "Product Medewerker":
                    B_productbeheer.Enabled = true;
                    tool_productbeheer.Enabled = true;
                    break;
                case "Systeem Afkraker":
                    tool_klantbeheer.Enabled = true;
                    tool_kleurenbeheer.Enabled = true;
                    tool_pakketbeheer.Enabled = true;
                    tool_productbeheer.Enabled = true;
                    tool_themabeheer.Enabled = true;
                    B_klantbeheer.Enabled = true;
                    B_kleurenbeheer.Enabled = true;
                    B_pakketbeheer.Enabled = true;
                    B_productbeheer.Enabled = true;
                    B_themabeheer.Enabled = true;
                    break;
            }
        }

        void Hoofd_Venster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Events

        //timer tick
        void timer_Tick(object sender, EventArgs e)
        {
            label_DatumTijd.Text = DateTime.Now.ToString();
        }

        //pakket beheren button mousehover
        private void nButton_PakketBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Pakket Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Pakket Beheren";
            
            nTooltip.SetTooltip(B_pakketbeheer);
        }

        //pakket beheren button mouseleave
        private void nButton_PakketBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }

        //klant beheren button mousehover
        private void nButton_KlantBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Klant Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Klant Beheren";
            
            nTooltip.SetTooltip(B_klantbeheer);
        }

        //klant beheren button mouseleave;
        private void nButton_KlantBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }

        //producten beheren button mousehover
        private void nButton_ProductenBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Producten Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Producten Beheren";

            nTooltip.SetTooltip(B_productbeheer);
        }

        //producten beheren button mouseleave
        private void nButton_ProductenBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }

        //bestellingen beheren button mousehover
        private void nButton_BestellingenBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Bestellingen Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Bestellingen Beheren";

            nTooltip.SetTooltip(B_bestellingbeheer);
        }

        //bestellingen beheren button mouseleave
        private void nButton_BestellingenBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }

        //kleuren beheren button mousehover
        private void nButton_KleurenBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Kleuren Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Kleuren Beheren";

            nTooltip.SetTooltip(B_kleurenbeheer);
        }

        //kleuren beheren button mouseleave
        private void nButton_KleurenBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }

        //themas beheren button mousehover
        private void nButton_ThemasBeheren_MouseHover(object sender, EventArgs e)
        {
            nTooltip.Heading.Text = "Themas Beheren";
            //nTooltip.Content.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec sit amet pede id urna sodales iaculis. Duis a justo.";

            label_statusBar.Text = "Themas Beheren";

            nTooltip.SetTooltip(B_themabeheer);
        }

        //themas beheren button mouseleave
        private void nButton_ThemasBeheren_MouseLeave(object sender, EventArgs e)
        {
            statusBarTextWijzigen();
        }


        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pakketBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open pakket beheren venster
            openPakketBeheer();
        }

        private void productBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open product beheren venster
            openProductBeheer();
        }

        private void kleurenBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open kleuren beheren venster
            openKleurenBeheer();
        }

        private void klantenBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open klanten beheren venster
            openKlantBeheer();
        }

        private void bestellingenBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open bestellingen beheren venster
        }

        private void themasBeherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open themas beheren venster
            openThemaBeheer();
        }

        private void nButton_PakketBeheren_Click(object sender, EventArgs e)
        {
            //open pakket beheren venster
            openPakketBeheer();
        }

        private void nButton_ProductenBeheren_Click(object sender, EventArgs e)
        {
            //open producten beheren venster
            openProductBeheer();
        }

        private void nButton_KleurenBeheren_Click(object sender, EventArgs e)
        {
            //open kleuren beheren venster
            openKleurenBeheer();
        }

        private void nButton_KlantBeheren_Click(object sender, EventArgs e)
        {
            //open klanten beheren venster
            openKlantBeheer();
        }

        private void nButton_BestellingenBeheren_Click(object sender, EventArgs e)
        {
            //open bestellingen beheren venster
        }

        private void nButton_ThemasBeheren_Click(object sender, EventArgs e)
        {
            //open themas beheren venster
            openThemaBeheer();
        }

        #endregion


        #region Methodes


        // statusbar text naar standard Pakketo
        private void statusBarTextWijzigen()
        {
            label_statusBar.Text = "Pakketo";
        }

        private void openPakketBeheer()
        {
            UI_pakket_beheer pakketbeheer = new UI_pakket_beheer();
            this.Hide();
            pakketbeheer.Show();
            pakketbeheer.FormClosed += new FormClosedEventHandler(pakketbeheer_FormClosed);
        }

        void pakketbeheer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void openProductBeheer()
        {
            UI_product_beheer productbeheer = new UI_product_beheer();
            productbeheer.Show();
            productbeheer.FormClosed += new FormClosedEventHandler(productbeheer_FormClosed);
            this.Hide();
        }

        void productbeheer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void openThemaBeheer()
        {
            UI_thema_beheer themabeheer = new UI_thema_beheer();
            themabeheer.Show();
            this.Hide();
            themabeheer.FormClosed += new FormClosedEventHandler(themabeheer_FormClosed);
        }

        void themabeheer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void openKlantBeheer()
        {
            UI_klant_beheer klantbeheer = new UI_klant_beheer();
            this.Hide();
            klantbeheer.Show();
            klantbeheer.FormClosed += new FormClosedEventHandler(klantbeheer_FormClosed);
        }

        void klantbeheer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void openKleurenBeheer()
        {
            UI_kleuren_beheer kleurenbeheer = new UI_kleuren_beheer();
            this.Hide();
            kleurenbeheer.Show();
            kleurenbeheer.FormClosed += new FormClosedEventHandler(kleurenbeheer_FormClosed);
        }

        void kleurenbeheer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        #endregion


    }
}
