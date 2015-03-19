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
using Pakketo;

namespace PakketoWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void B_nieuwPakket_Click(object sender, EventArgs e)
        {
            #region geen_zin_gehad_om_een_volledig_select_statement_te_maken_:P

            int getThemaID = 1;
            Thema thema = Thema.getThema(getThemaID);
            while (thema == null)
            {
                if (getThemaID == 10)
                {
                    MessageBox.Show("wel eerst un thema aanmaken!");
                    return;
                }
                getThemaID++;
                thema = Thema.getThema(getThemaID);
            }
            int getKleurID = 1;
            Kleur kleur = Kleur.getKleur(getThemaID);
            while (kleur == null)
            {
                if (getKleurID == 10)
                {
                    MessageBox.Show("wel eerst un kleur aanmaken!");
                    return;
                }
                getKleurID++;
                kleur = Kleur.getKleur(getKleurID);
            }

            #endregion

            #region hier_is_wel_al_1ne_gemaakt
            List<Product> lijst_producten = Product.getAllProducts();
            #endregion

            if (lijst_producten.Count == 0)
            {
                MessageBox.Show("wel eerst un paar producten aanmaken?");
                return;
            }
            if (T_pakket_naam.Text.Length == 0)
            {
                MessageBox.Show("Yo wel ff pakket naam invoeren!");
                return;
            }

            //voeg nieuwe pakket met alle producten als relatie
            Pakket b = new Pakket();
            b.Naam = T_pakket_naam.Text;
            b.Hoogte = 1;
            b.Breedte = 1;
            b.Lengte = 1;
            b.Prijs = 1;
            b.Thema = thema;
            b.Kleur = kleur;
            b.Producten = lijst_producten;
            b.savePakket();
            MessageBox.Show("Pakket aangemaakt! met producten relaties");
        }

        private void B_maakProduct_Click(object sender, EventArgs e)
        {
            if (T_product_naam.Text.Length == 0)
            {
                MessageBox.Show("yo wel product naam invoeren!"); 
                return;
            }

            Product p = new Product();
            p.Beschrijving = "boeiend";
            p.Breedte = 1;
            p.Hoogte = 1;
            p.Lengte = 1;
            p.Naam = T_product_naam.Text;
            p.Prijs = 1;

            Product.newProduct(p);
            MessageBox.Show("Product aangemaakt!");
        }

        private void B_nieuwThema_Click(object sender, EventArgs e)
        {
            if (T_thema_naam.Text.Length == 0)
            {
                MessageBox.Show("yo wel thema naam invoeren!");
                return;
            }
            Thema t = new Thema();
            t.Naam = T_thema_naam.Text;
            t.Patroon = "boeiend";

            Thema.newThema(t);
            MessageBox.Show("Thema aangemaakt!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (T_kleur_naam.Text.Length == 0)
            {
                MessageBox.Show("yo wel kleur naam invoeren!");
                return;
            }

            Kleur k = new Kleur();
            k.Naam = T_kleur_naam.Text;
            k.HexCode = "boeiend";
            Kleur.newKleur(k);
            MessageBox.Show("Kleur aangemaakt!");
        }
    }
}
