using UrnaEletronica.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UrnaEletronica
{
    public partial class frmUrna : Form
    {

        public class Artistas
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Foto { get; set; }
            public int Votos { get; set; }

            public Artistas(string id, string nome, string imagem)
            {
                Id = id;
                Nome = nome;
                Foto = imagem;
                Votos = 0;
            }
        }

        public List<Artistas> artistas = new List<Artistas>()
        {
            new Artistas("25", "Anitta", "anitta"),
            new Artistas("11", "Gloria Groove", "gloriagroove"),
            new Artistas("04", "Liniker", "liniker")
        };

        public frmUrna()
        {
            InitializeComponent();
        }

        public void InserirNumero(string numero)
        {
            if (txtNumero1.Text == "")
            {
                txtNumero1.Text = numero;
            }
            else
            {
                txtNumero2.Text = numero;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            InserirNumero(btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            InserirNumero(btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            InserirNumero(btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            InserirNumero(btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            InserirNumero(btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            InserirNumero(btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            InserirNumero(btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            InserirNumero(btn8.Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            InserirNumero(btn9.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            InserirNumero(btn0.Text);
        }

        private void btnCorrigir_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text != "" || txtNumero2.Text != "")
            {
                LimparDados();
            }
        }

        private void btnCandidatos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anitta - 25 \nGloria Groove - 11 \nLiniker - 04");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var numero1 = txtNumero1.Text;
            var numero2 = txtNumero2.Text;
            var codigo = numero1 + numero2;

            Artistas artista = artistas.Where(x => x.Id == codigo).FirstOrDefault();

            var existeArtista = artistas.Where(x => x.Id == codigo).Any();

            if (txtNumero1.Text != "" && txtNumero2.Text != "" && existeArtista)
            {
                var imagem = (Image)Properties.Resources.ResourceManager.GetObject(artista.Foto);

                lblNome.Text = artista.Nome;
                picFotos.Image = imagem;
                artista.Votos++;

                MessageBox.Show("Voto confirmado");
                LimparDados();
            }
            else
            {
                MessageBox.Show("Informe um número válido");
                LimparDados();
                return;
            }
        }

        public void LimparDados()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblNome.Text = "...";
            picFotos.Image = null;
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto anulado");
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            var maxVotos = artistas.Max(a => a.Votos);

            var vencedores = artistas.Where(a => a.Votos == maxVotos).ToList();

            if (vencedores.Count > 1)
            {
                var msg = "Empate! \n";
                foreach (var vendedor in vencedores)
                {
                    msg += vendedor.Nome + " com " + vendedor.Votos + " votos\n";
                }
                MessageBox.Show(msg);
            }
            else
            {
                var vencedor = vencedores.First();
                MessageBox.Show("Artista vendedor(a) do Ano é : " + vencedor.Nome + " com " + vencedor.Votos + " votos");
            }

            foreach (var artistas in artistas)
            {
                artistas.Votos = 0;
            }
        }
    }
}
