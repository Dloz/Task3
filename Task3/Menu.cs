using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms;

namespace ATS {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e) {
            var monitor = new Monitor();
            monitor.Show();
        }

        private void Menu_Load(object sender, System.EventArgs e) {

        }
    }
}
