using lista_uczestnikow.ModelDanych;

namespace lista_uczestnikow
{
    public partial class Form1 : Form
    {
        Pobierac pobierac;
        public Form1()
        {
            InitializeComponent();
            pobierac = new Pobierac();
            pobierac.PobierzDaneZBazy();
            PokazDane();

        }
        public void PokazDane()
        {
            TextBox1.Clear();
            foreach(Osoba osoba in pobierac.listaOsob)
                TextBox1.Text += osoba.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pobierac.listaOsob.Sort();
            PokazDane();
        }
    }
}