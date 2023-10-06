﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_Sz
{
    public partial class Form1 : Form
    {
        
        string rectaIng1 = "y=mx+b";
        string rectaIng2 = "y=mx+b";
        string rectaPIng1 = "y=mx+b";
        string rectaPIng2 = "y=mx+b";
        int longitud = 0;
        float m1=0;
        float m2=0;
        float b1 = 0;
        float b2 = 0;
        double resulNum = -1111111111;

        

        public string pendienteString(int indexMRec, int indexXRec, string rectaIng)
        {
            int recorrido = 0;
            recorrido = indexXRec - indexMRec + 1;
            string pendienteString = rectaIng.Substring(indexMRec, recorrido);
            return pendienteString;
        }
        public string interceptoString(int indexMasRec, int length, string rectaIng)
        {
            int recorrido2 = length - indexMasRec;

            //sumamos +3 en indexX ya que rectaIng1.Length empieza desde 1 y no 0 e indexX se encuentra dos casillas antes de el primer valor de b 
            string intercepString = rectaIng.Substring(indexMasRec,recorrido2);
           return intercepString;
        }

        public double interseccion(float m1,float m2,float b1, float b2)
        {
            return (b2-b1)/(m1-m2);
        }
        public string convertForma(string rectaPend)
        {
            int indexMp1 = rectaPend.IndexOf("=")+ 1;
            int indexXp1 = rectaPend.IndexOf("x")-2;
            int distancia = indexXp1 - indexMp1;
            string mFormPend = rectaPend.Substring(indexMp1, distancia);
           
            
            
            //Aquí se unen todas 
            string formaCambiada ="y=";
            return formaCambiada = formaCambiada+mFormPend;
        }
        public Form1()
        {
            InitializeComponent();
        }

        string txtPredet1 = "Ingresa tu primera recta";
        string txtPredet2 = "Ingresa tu segunda recta";
        private void opcionEleg(object sender, EventArgs e)
        {
            if (opcion.SelectedItem.ToString() == "y = mx+b")
            {
                // Mostrar los elementos Label para "m" y "b"
                fRecta1.Visible = true;
                fRecta2.Visible = true;
                btnObtener.Visible = true;
                fPuntoPend1.Visible = false;
                fPuntoPend2.Visible = false;


                               
            }
            else if (opcion.SelectedItem.ToString() == "y-yo = m(x-xo)")
            {
                // Mostrar los elementos Label para "m" y "b"
                fRecta1.Visible = false;
                fRecta2.Visible = false;
                btnObtener.Visible = true;
                fPuntoPend1.Visible = true;
                fPuntoPend2.Visible = true;
            }
        }
       

        private void btnObtener_Click(object sender, EventArgs e)
        {
            if(opcion.SelectedItem.ToString() == "y = mx+b")
            {
                if (fRecta1.Text != txtPredet1 && fRecta2.Text != txtPredet2)
                {
                    rectaIng1 = fRecta1.Text;
                    rectaIng2 = fRecta2.Text;
                    rectaPIng1 = fPuntoPend1.Text;
                    rectaPIng2 = fPuntoPend2.Text;

                    int longitud1 = rectaIng1.Length;
                    int indexM1 = rectaIng1.IndexOf("=") + 1;
                    int indexX1 = rectaIng1.IndexOf("x") - 1;
                    int indexMas1 = rectaIng1.IndexOf("+");
                    String pendString1 = pendienteString(indexM1, indexX1, rectaIng1);
                    string intercepString1 = interceptoString(indexMas1, longitud1, rectaIng1);
                     m1 = float.Parse(pendString1);
                     b1 = float.Parse(intercepString1);

                    int longitud2 = rectaIng2.Length;
                    int indexM2 = rectaIng2.IndexOf("=") + 1;
                    int indexX2 = rectaIng2.IndexOf("x") - 1;
                    int indexMas2 = rectaIng2.IndexOf("+");
                    string pendString2 = pendienteString(indexM2, indexX2, rectaIng2);
                    string intercepString2 = interceptoString(indexMas2, longitud2, rectaIng2);
                     m2 = float.Parse(pendString2);
                     b2 = float.Parse(intercepString2);
                    string resultado = "no entendi marce";
                    if (m2 == m1)
                    {
                        resultado = "las rectas no se intersectan, ¡son paralelas!";
                    }
                    else 
                    {
                        resulNum = interseccion(m1, m2, b1, b2);
                        bool perpend = (m1 * m2 == -1);

                        if (perpend)
                        {
                            resultado = "Las rectas son perpendiculares y se intersectan en x: " + resulNum;
                        }
                        else
                        {
                            resultado = "Las rectas se intersectan en x: " + resulNum;
                        }
                    }
                    

                    //Esto es solo de prueba, regresa cambiarlo a el resul luego
                    label1.Text = resultado;
                }
               

            }
            else if (opcion.SelectedItem.ToString() == "y-yo = m(x-xo)")
            {

            }
            else
            {
                label1.Text = "eror";
            }



        }
       


        private void fRecta1_Enter(object sender, EventArgs e)
        {
            // Borra el texto predeterminado cuando el usuario hace clic en el TextBox
            if (fRecta1.Text == txtPredet1)
            {
                fRecta1.Text = "";
            }
        }

        private void fRecta1_Leave(object sender, EventArgs e)
        {
            // Restaura el texto predeterminado si el TextBox está vacío cuando el usuario sale de él
            if (string.IsNullOrWhiteSpace(fRecta1.Text))
            {
                fRecta1.Text = txtPredet1;
            }
        }

        private void fRecta2_Enter(object sender, EventArgs e)
        {
            // Borra el texto predeterminado cuando el usuario hace clic en el TextBox
            if (fRecta2.Text == txtPredet2)
            {
                fRecta2.Text = "";
            }
        }

        private void fRecta2_Leave(object sender, EventArgs e)
        {
            // Restaura el texto predeterminado si el TextBox está vacío cuando el usuario sale de él
            if (string.IsNullOrWhiteSpace(fRecta2.Text))
            {
                fRecta2.Text = txtPredet2;
            }
        }
        private void fPuntoPend1_Enter(object sender, EventArgs e)
        {
            // Borra el texto predeterminado cuando el usuario hace clic en el TextBox
            if (fPuntoPend1.Text == txtPredet1)
            {
                fPuntoPend1.Text = "";
            }
        }

        private void fPuntoPend1_Leave(object sender, EventArgs e)
        {
            // Restaura el texto predeterminado si el TextBox está vacío cuando el usuario sale de él
            if (string.IsNullOrWhiteSpace(fPuntoPend1.Text))
            {
                fPuntoPend1.Text = txtPredet1;
            }
        }

        private void fPuntoPend2_Enter(object sender, EventArgs e)
        {
            // Borra el texto predeterminado cuando el usuario hace clic en el TextBox
            if (fPuntoPend2.Text == txtPredet2)
            {
                fPuntoPend2.Text = "";
            }
        }

        private void fPuntoPend2_Leave(object sender, EventArgs e)
        {
            // Restaura el texto predeterminado si el TextBox está vacío cuando el usuario sale de él
            if (string.IsNullOrWhiteSpace(fPuntoPend2.Text))
            {
                fPuntoPend2.Text = txtPredet2;
            }
        }






















        private void fRecta1_TextChanged(object sender, EventArgs e)
        {
        }
        private void fRecta2_TextChanged(object sender, EventArgs e)
        {
        }

        private void fRecta1_Textcolor(object sender, EventArgs e)
        {}

        private void fRecta1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
