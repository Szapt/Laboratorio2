using System;
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
        //creamos las variables y las inicializamos 
        string rectaIng1 = "y=mx+b";
        string rectaIng2 = "y=mx+b";
        string rectaPIng1 = "y=mx+b";
        string rectaPIng2 = "y=mx+b";
        int longitud = 0;
        float m1=0;
        float m2=0;
        float b1 = 0;
        float b2 = 0;
        double resulNumX = -1111111111;
        double resulNumY = -1111111111;

        
        //funcion para hallar m 
        public string pendienteString(int indexMRec, int indexXRec, string rectaIng)
        {
            int recorrido = 0;
            recorrido = indexXRec - indexMRec+1 ;
            string pendienteString = rectaIng.Substring(indexMRec, recorrido);
            return pendienteString;
        }
        //funcion para hallar b
        public string interceptoString(int indexMasRec, int length, string rectaIng)
        {
            int recorrido2 = length - indexMasRec;

            //sumamos +3 en indexX ya que rectaIng1.Length empieza desde 1 y no 0 e indexX se encuentra dos casillas antes de el primer valor de b 
            string intercepString = rectaIng.Substring(indexMasRec,recorrido2);
           return intercepString;
        }
        //funcion para hallar la coordenada x de la intersección
        public double interseccionX(float m1,float m2,float b1, float b2)
        {
            return (b2-b1)/(m1-m2);
        }
        //funcion para hallar la coordenada y de la intersección
        public double interseccionY(float m1,float b1, double interseccionX)
        {
            return (m1 * interseccionX) + b1;
        }
        //funcion para trannsformar de la forma y-yo=m(x-x0) a la forma y=mx+b
        private string convertForma(string rectaPend)
        {
            int longitudP = rectaPend.Length; 
            int indexMp1 = rectaPend.IndexOf("=")+ 1;
            int indexXp1 = rectaPend.IndexOf("x")-1;
            int indexXo = rectaPend.IndexOf("x") + 1;
            int indexYo = rectaPend.IndexOf("y")+1;
            int indexYo1 = rectaPend.IndexOf("=") - 1;
            int distancia = indexXp1 - indexMp1;
            int distanciaYo = indexYo1-indexYo+1;
            int distanciaXo = longitudP - indexXo -1;
            string mFormPend = rectaPend.Substring(indexMp1, distancia);
            float mFormPendNum = float.Parse(mFormPend);
            float xo = float.Parse(rectaPend.Substring(indexXo, distanciaXo));
            float yo = float.Parse(rectaPend.Substring(indexYo, distanciaYo));
            float b = (mFormPendNum * xo) + (yo * -1);
            string bString = Convert.ToString(b); 
            //Aquí se unen todas 
            string formaCambiada ="y=";
            formaCambiada = formaCambiada + mFormPend + "x"+bString;
            return formaCambiada;
        }
        public Form1()
        {
            InitializeComponent();
        }
        //texto predeterminado para cuando inicie el codigo y cuando los label esten vacios
        string txtPredet1 = "Ingresa tu primera recta";
        string txtPredet2 = "Ingresa tu segunda recta";
        private void opcionEleg(object sender, EventArgs e)
        {
            //En caso de escoger la forma base
            if (opcion.SelectedItem.ToString() == "y = mx+b")
            {
                // Mostrar los elementos Label para "m" y "b"
                fRecta1.Visible = true;
                fRecta2.Visible = true;
                btnObtener.Visible = true;
                fPuntoPend1.Visible = false;
                fPuntoPend2.Visible = false;


                               
            }
            //En caso de haber escogido la forma punto pendiente
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
       
        //evento cuando el usuario presione el boton de obtener en el frame
        private void btnObtener_Click(object sender, EventArgs e)
        {
            if (opcion.SelectedItem.ToString() == "y = mx+b")
            {
                //Si el usuario digitó almenos un valor en el label 
                if (fRecta1.Text != txtPredet1 && fRecta2.Text != txtPredet2)
                {
                    string resultado = "no entendi marce";
                    if (fRecta1.Text == "y=x" && fRecta2.Text == "y=x")
                    {
                        resultado = "Son la misma recta";
                    }
                    else
                    {
                        rectaIng1 = fRecta1.Text;
                        rectaIng2 = fRecta2.Text;

                        
                        int longitud1 = rectaIng1.Length-1;
                        int indexM1 = rectaIng1.IndexOf("=") + 1;
                        int indexX1 = rectaIng1.IndexOf("x")-1;
                        int indexMas1 = rectaIng1.IndexOf("+");
                        string pendString1 ;
                        string intercepString1 ;
                        // Comprobamos si la ecuación de la primera recta es "y=x"
                        if (rectaIng1 == "y=x")
                        {
                            pendString1 = "1";
                            intercepString1 = "0";
                        }
                        else
                        {
                            // Calculamos la pendiente y la intersección de la primera recta utilizando funciones externas
                            pendString1 = pendienteString(indexM1, indexX1, rectaIng1);
                             intercepString1 = interceptoString(indexMas1, longitud1 + 1, rectaIng1);
                        }
                        // Convertimos las cadenas a números flotantes para su uso posterior
                        m1 = float.Parse(pendString1);
                        b1 = float.Parse(intercepString1);
                        string pendString2;
                        string intercepString2;

                        // Calculamos la longitud y los índices necesarios para la segunda recta
                        int longitud2 = rectaIng2.Length;
                        int indexM2 = rectaIng2.IndexOf("=") + 1;
                        int indexX2 = rectaIng2.IndexOf("x") - 1;
                        int indexMas2 = rectaIng2.IndexOf("+");
                        if (rectaIng2 == "y=x")
                        {
                            pendString2 = "1";
                            intercepString2 = "0";
                        }
                        else
                        {
                             pendString2 = pendienteString(indexM2, indexX2, rectaIng2);
                             intercepString2 = interceptoString(indexMas2, longitud2, rectaIng2);
                        }

                        m2 = float.Parse(pendString2);
                        b2 = float.Parse(intercepString2);
                        // Comprobamos si las rectas son paralelas
                        if (m2 == m1)
                        {
                            resultado = "las rectas no se intersectan, ¡son paralelas!";
                        }
                        else
                        {
                            // Calculamos la intersección en x utilizando la función externa
                            resulNumX = interseccionX(m1, m2, b1, b2);
                            bool perpend = (m1 * m2 == -1);
                            // Calculamos la intersección en y utilizando la función externa
                            resulNumY = interseccionY(m1, b1, resulNumX);
                            if (perpend)
                            {
                                resultado = "Las rectas son perpendiculares y se intersectan en x: " + resulNumX + " y en y: " + resulNumY;
                            }
                            else
                            {
                                resultado = "Las rectas se intersectan en x: " + resulNumX + " y en y: " + resulNumY;
                            }
                            //Esto es solo de prueba, regresa cambiarlo a el resul luego
                            label1.Text = resultado;
                        }
                    }
                    label1.Text = resultado;





                }


            }
            else if (opcion.SelectedItem.ToString() == "y-yo = m(x-xo)")
            {
                string resultado = "Nada";
                rectaPIng1 = fPuntoPend1.Text;
                rectaPIng2 = fPuntoPend2.Text;

                string formCambiada1 = convertForma(rectaPIng1);
                string formCambiada2 = convertForma(rectaPIng2);

                //Aqui es simplemente volver a aplicar la lógica que empleamos para y=mx+b
                int longitudP1 = rectaPIng1.Length+1;
                int indexPM1 = rectaPIng1.IndexOf("=")+1;
                int indexPX1 = rectaPIng1.IndexOf("x") - 2;
                int indexPMas1 = rectaPIng1.IndexOf("+");
                string pendString1 = pendienteString(indexPM1, indexPX1, rectaPIng1);
                string intercepString1 = interceptoString(indexPMas1, longitudP1-2, rectaPIng1);
                m1 = float.Parse(pendString1);
                b1 = float.Parse(intercepString1);

                int longitudP2 = rectaIng2.Length+1;
                int indexPM2 = rectaPIng2.IndexOf("=") + 1;
                int indexPX2 = rectaPIng2.IndexOf("x") - 2;
                int indexPMas2 = rectaIng2.IndexOf("+");
                string pendString2 = pendienteString(indexPM2, indexPX2, rectaPIng2);
                string intercepString2 = interceptoString(indexPMas2, longitudP2-2, rectaPIng2);
                m2 = float.Parse(pendString2);
                b2 = float.Parse(intercepString2);

                if (m2 == m1)
                {
                    resultado = "las rectas no se intersectan, ¡son paralelas!";
                }
                else
                {
                    resulNumX = interseccionX(m1, m2, b1, b2);
                    string resulStringX = Convert.ToString(resulNumX);
                    bool perpend = (m1 * m2 == -1);
                    resulNumY = interseccionY(m1, b1, resulNumX);
                    string resulStringY = Convert.ToString(resulNumY);
                    if (perpend)
                    {
                        resultado = "Las rectas son perpendiculares y se intersectan en x: " + resulStringX + " y en y: " + resulStringY;
                    }
                    else
                    {
                        resultado = "Las rectas se intersectan en x: " + resulStringX + " y en y: " + resulStringY;
                    }
                    
                }
                label1.Text = resultado;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
