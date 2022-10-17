using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0"; 
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResultado.Text = testeOperadores(" + ", txtResultado.Text);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            txtResultado.Text = testeOperadores(" - ", txtResultado.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtResultado.Text = testeOperadores(" * ", txtResultado.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtResultado.Text = testeOperadores(" / ", txtResultado.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtConta.Text = txtResultado.Text + " = ";
                txtResultado.Text = Calculo(txtResultado.Text);
            }
            else
                MessageBox.Show("Não há calculo para ser efetuado, insira um valor!");
        }

        private static string Calculo(string txt)
        {
            List<float> valores = new List<float>();
            List<char> operadores = new List<char>();
            string txtValor = "";

            //adicionando valores ao vetor e os operadores
            for(int i = 0; i < txt.Length; i++)
            {
                if(txt.ElementAt(i) > 47 || txt.ElementAt(i) == 46 || txt.ElementAt(i) == 32)
                {
                    txtValor += txt.ElementAt(i);
                }
                else if(txt.ElementAt(i) != ' ' && txt.ElementAt(i) < 48)
                {
                    operadores.Add(txt.ElementAt(i));
                }

                if((txtValor.Length > 0 && txtValor.ElementAt(txtValor.Length-1) == ' ') || i == (txt.Length-1))
                {
                    if(txtValor.ElementAt(txtValor.Length - 1) == ' ')
                    txtValor = txtValor.Remove(txtValor.Length-1,1);

                    if(txtValor.Length > 0)
                    {
                        valores.Add(float.Parse(txtValor, CultureInfo.InvariantCulture));
                        txtValor = "";
                    }
  
                }
            }

          
            
            //verificacoes de operadores e realizando calculos
            while(operadores.Count > 0)
            {
                if(operadores.Contains('/'))
                {
                    //fazendo a conta
                    int index = operadores.IndexOf('/');
                    valores[index] /= valores.ElementAt(index + 1);

                    //removendo da conta
                    operadores.RemoveAt(index);
                    valores.RemoveAt(index + 1);


                }
                else if(operadores.Contains('*'))
                {
                    int index = operadores.IndexOf('*');
                    valores[index] *= valores.ElementAt(index + 1);

                    operadores.RemoveAt(index);
                    valores.RemoveAt(index + 1);
                }
                else if(operadores.Contains('-'))
                {
                    int index = operadores.IndexOf('-');
                    valores[index] -= valores.ElementAt(index + 1);

                    operadores.RemoveAt(index);
                    valores.RemoveAt(index + 1);
                }
                else
                {
                    int index = operadores.IndexOf('+');
                    valores[index] += valores.ElementAt(index + 1);

                    operadores.RemoveAt(index);
                    valores.RemoveAt(index + 1);
                }
            }

            txt = Convert.ToString(valores.ElementAt(0));
            return (txt);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0 && txtResultado.Text[txtResultado.Text.Length - 1] != ' ')
            {
                txtResultado.Text = txtResultado.Text.Remove(txtResultado.Text.Length - 1, 1);
            }
            else if(txtResultado.Text.Length > 0 && txtResultado.Text[txtResultado.Text.Length - 1] == ' ')
            {
                txtResultado.Text = txtResultado.Text.Remove(txtResultado.Text.Length - 3, 3);
            }
            else
                MessageBox.Show("Não há valor nenhum!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            txtConta.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtResultado.Text += ".";
        }

        private static string testeOperadores(string operador, string txt)
        {
            if (txt.Length > 0 && txt.ElementAt(txt.Length - 1) > 47)
                return(txt += operador);
            else if (txt.Length > 0 && txt.ElementAt(txt.Length - 1) <= 47 && txt.ElementAt(txt.Length - 1) != 46)
            {
                txt = txt.Remove(txt.Length - 3, 3);
                return(txt += operador);
            }
            else
                MessageBox.Show("Não é possível atribuir um operador sem digitos");
            return (txt);

        }

    }
}
