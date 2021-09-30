using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintanence.Entities;

namespace UserMaintanence
{
    public partial class Form1 : Form
    { BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            labelLastName.Text = Resource1.LastName;
            labelFirstName.Text = Resource1.FirstName;
            buttonAdd.Text = Resource1.Add;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                LastName = textBoxLastName.Text,
                FirstName = textBoxFirstName.Text
            };
            users.Add(u);
        }
    }
}
