using System;
using System.Windows.Forms;

namespace SharedDoc
{
    public partial class LoginDialog : Form
    {
        private bool _loginDataIsCorrect;
        private LoginData _loginData;
        
        public LoginDialog(LoginData loginData)
        {
            _loginData = loginData;

            InitializeComponent();
            _loginDataIsCorrect = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (_loginData.Username.Contains(textBoxUsername.Text))
            {
                if (_loginData.Password.Contains(textBoxPassword.Text))
                {
                    _loginDataIsCorrect = true;

                    this.Close();
                }
            }

            labelIncorectLoginData.Text = "Incorect data entered!";
        }   

        private void LoginDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_loginDataIsCorrect)
            {
                Application.Exit();
            }
        }
    }
}
