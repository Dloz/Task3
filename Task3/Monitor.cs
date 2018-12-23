using ATS;
using ATS.ATS;
using ATS.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms {
    public partial class Monitor : Form {       
        AutomaticTelephoneStation ats = new AutomaticTelephoneStation();

        public Monitor() {
            InitializeComponent();
        }
        private void Monitor_Load(object sender, EventArgs e) {
            var json = new DataContractJsonSerializer(typeof(AutomaticTelephoneStation));
            using (var fstr = new FileStream("ATS.json", FileMode.OpenOrCreate)) {
                ats = json.ReadObject(fstr) as AutomaticTelephoneStation;
            }
            ats = Program.Ats;
            listBox1.DataSource = ats.UsersData.Values.ToList();
            listBox1.DisplayMember = "Name";

            foreach (var customer in ats.UsersData.Values) {
                var lvi = new ListViewItem {Text = customer.Port.ToString()};
                switch (customer.Port.State) {
                    case PortState.Connected:
                        lvi.BackColor = Color.Green;
                        lvi.Tag = PortState.Connected;
                        break;
                    case PortState.Disconnected:
                        lvi.BackColor = Color.Red;
                        lvi.Tag = PortState.Disconnected;
                        break;
                    case PortState.Busy:
                        lvi.BackColor = Color.Yellow;
                        lvi.Tag = PortState.Busy;
                        break;
                    default:
                        break;
                }
                listView1.Items.Add(lvi);
            }
            //listBox2.DataSource = ats.Connections;
            listBox2.DisplayMember = "Item1";
            //listBox3.DataSource = ats.CallHistory;
            listBox3.DisplayMember = "Info";
            var timer = new System.Windows.Forms.Timer();
            timer1.Interval = 5;
            timer1.Start();
            Application.DoEvents();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            button1_Click(sender,e);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            var customer = (Customer)listBox1.SelectedItem;
            MessageBox.Show(customer.ToString());
        }


        private void button1_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView1.Items) {
                if (item.Tag.Equals(PortState.Connected)) {
                    item.BackColor = Color.Green;
                    item.Tag = PortState.Connected;
                }
                else if (item.Tag.Equals(PortState.Disconnected)) {
                    item.BackColor = Color.Red;
                    item.Tag = PortState.Disconnected;
                }
                else {
                    item.BackColor = Color.Yellow;
                    item.Tag = PortState.Busy;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            var thread = new Thread(new ParameterizedThreadStart(CallGenerator.Generate));
            thread.IsBackground = true;
            thread.Start(ats);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            MessageBox.Show("clicked");
        }

        private void timer1_Tick(object sender, EventArgs e) {
            listBox2.Items.Clear();
            foreach (var instance in ats.Connections) {
                listBox2.Items.Add(instance);
            }

        }

        private void connectionsBindingSource_CurrentChanged(object sender, EventArgs e) {
            MessageBox.Show("changed");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void button3_Click_1(object sender, EventArgs e) {
            listBox3.Items.Clear();
            foreach (var instance in ats.CallHistory) {
                listBox3.Items.Add(instance);
            }
        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e) {
            MessageBox.Show(listBox3.SelectedItem.ToString());
        }
    }
}
