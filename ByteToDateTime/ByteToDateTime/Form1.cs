using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ByteToDateTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }
        public static string Pbb(byte[] b)
        {
            var st = new StringBuilder();
            st.Append("#region theB\n");
            st.Append(" byte[] x ={");

            foreach (var c in b)
            {
                if (c == 0)
                {
                    st.Append("(byte) Convert.ToInt32(new DateTime(01, 01, 01).AddYears(0).ToString().Remove(9).Substring(8)");
                }
                else
                {
                    st.Append(c).Append(",");
                }
            }
            st.Append(" };");
            st.Append("#endregion");
            return st.ToString();
        }
        public static string backt(byte[] b)
       {
           var st = new StringBuilder();
           foreach (var c in b)
           {
               if (c >= 100 )
               {
                  st.Append("(byte) Convert.ToInt32(new DateTime(01, 01, 01).AddYears(");
                  st.Append( (c - 1).ToString());
                  st.Append( ").ToString().Remove(10).Substring(7)),\n");
               }
               if (c >= 10 && c <= 99)
               {
                     st.Append("(byte) Convert.ToInt32(new DateTime(01, 01, 01).AddYears(");
                  st.Append( (c - 1).ToString());
                  st.Append( ").ToString().Remove(10).Substring(8)),\n");

               
               }
               if (c <= 9 && c != 0 )
               {
                   st.Append("(byte) Convert.ToInt32(new DateTime(01, 01, 01).AddYears(");
                   st.Append((c - 1).ToString());
                   st.Append(").ToString().Remove(10).Substring(9)),\n");
               }
 
               if (c == 0)
               {
                   st.Append("(byte) Convert.ToInt32(new DateTime(01, 01, 01).AddYears(0 ).ToString().Remove(9).Substring(8)),");
               }
           }
 
           return st.ToString();
       }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            byte[] file = File.ReadAllBytes(textBox1.Text);
            string resutl = Pbb(file);
            File.WriteAllText(textBox1.Text + "Converted.txt", resutl);
            
            MessageBox.Show("done ybo3mo");

        }
    }
}
