using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanKeJson;

namespace RollCallTool
{
    public partial class Form1 : Form
    {
        string lastName = null;
        string[] titles = { "一个很厉害又没有那么厉害的点名器", "世界第一的点名器", "二零二六届八班的dyc开发的点名器", "一个超简陋的点名器" };

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = RandomName();
            while (name == lastName)
            {
                name = RandomName();
            }
            lastName = name;
            label1.Text = name;
        }

        private string RandomName()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "list.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<JsonData> names = JSON.ToData(jsonContent).array;
            Random random = new Random();
            int index = random.Next(names.Count);
            string selectedName = names[index];
            return selectedName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {

                Random random = new Random();
                int index = random.Next(titles.Length);
                string title = titles[index];
                this.Text = title;

                string name = RandomName();
                while (name == lastName)
                {
                    name = RandomName();
                }
                lastName = name;
                label1.Text = name;
            }));
        }
    }
}
