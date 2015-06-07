using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

   


    public partial class Form1 : Form
    {
        RestClient client = new RestClient("http://192.168.0.110");

        public Form1()
        {
            InitializeComponent();
            client.Authenticator = new HttpBasicAuthenticator("admin", "apple1");
        }

        private static void RespCallback(IAsyncResult asynchronousResult)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var rq = new RestRequest("decoder_control.cgi");
            rq.AddParameter("command", "6", ParameterType.GetOrPost);
            IRestResponse response = client.Execute(rq);
            Console.WriteLine(response);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rq = new RestRequest("decoder_control.cgi");
            rq.AddParameter("command", "4", ParameterType.GetOrPost);
            IRestResponse response = client.Execute(rq);
            Console.WriteLine(response);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rq = new RestRequest("decoder_control.cgi");
            rq.AddParameter("command", "1", ParameterType.GetOrPost);
            IRestResponse response = client.Execute(rq);
            Console.WriteLine(response);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                button2_Click(this, null);
            if (e.KeyCode == Keys.D)
                button1_Click(this, null);
            if (e.KeyCode == Keys.W)
                button4_Click(this, null);
            if (e.KeyCode == Keys.S)
                button5_Click(this, null);
            if (e.KeyCode == Keys.X)
                button6_Click(this, null);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                button3_Click(this, null);
            if (e.KeyCode == Keys.D)
                button3_Click(this, null);
        }

        private void pulse()
        {
            var rq = new RestRequest("decoder_control.cgi");
            rq.AddParameter("command", "95", ParameterType.GetOrPost);
            client.ExecuteAsync(rq, response => { });
            Thread.Sleep(50);
            rq = new RestRequest("decoder_control.cgi");
            rq.AddParameter("command", "94", ParameterType.GetOrPost);
            client.ExecuteAsync(rq, response => { });
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pulse();
            pulse();             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pulse();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pulse();
            pulse();
            pulse();
        }
    }

}
