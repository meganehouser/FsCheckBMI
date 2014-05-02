using System;
using System.Windows.Forms;

namespace FsCheckBMI
{
    public partial class BMIForm : Form
    {
        public BMIForm()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            var validator = new Validator();

            if(!validator.IsValid(this.txtHeight.Text))
            {
                MessageBox.Show("身長の入力値が不正です。");
                return;
            }

            if(!validator.IsValid(this.txtWeight.Text))
            {
                MessageBox.Show("体重の入力値が不正です。");
            }

            var height = int.Parse(this.txtHeight.Text);
            var weight = int.Parse(this.txtWeight.Text);
            this.txtBmi.Text = BMI.Compute(height, weight).ToString("F2");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtHeight.Text = "";
            this.txtWeight.Text = "";
            this.txtBmi.Text = "";
        }
    }
}
