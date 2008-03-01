using System.Windows.Forms;

namespace Mono.Sms
{
    public partial class CodigoValidacion : Form
    {
        private string codigoValidacion;

        public CodigoValidacion()
        {
            InitializeComponent();
        }

        public PictureBox PictureBox
        {
            set { this.pic = value; }
            get { return this.pic; }
        }

        public string CodigoDeValidacion
        {
            get { return codigoValidacion; }
        }

        private void btnEnviar_Click(object sender, System.EventArgs e) 
        {
            if(textBox1.Text != string.Empty) codigoValidacion = textBox1.Text;
            Close();
        }
    }
}