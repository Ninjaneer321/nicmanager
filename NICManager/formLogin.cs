using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NICManager
{
    public partial class formLogin : Form
    {
        private string username, password, passwordHash;
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        public string GetUsername() {
            return username;
        }

        public string GetPassword() {
            return password;
        }

        public void SetUsername(string username) {
            username = username.Trim();
        }
        public void SetPassword(string password) {
            password = password.Trim();
        }
    }
}
