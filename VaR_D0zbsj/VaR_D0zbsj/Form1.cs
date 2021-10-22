using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaR_D0zbsj.Entities;

namespace VaR_D0zbsj
{
    public partial class Form1 : Form
    {
        List<Tick> Ticks;
        PortfolioEntities context = new PortfolioEntities();
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        List<string> rendezettLista;


        public Form1()
        {
            InitializeComponent();

            CreatePortfolio();

            Ticks = context.Ticks.ToList();
            dGTick.DataSource = Ticks;
            List<Tick> l = context.Ticks.ToList();

            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
            foreach (var item in nyereségekRendezve)
            {
                rendezettLista.Add(item.ToString());
            }
        }

        public void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dGPortfolio.DataSource = Portfolio;
        }

        public decimal GetPortfolioValue (DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last =(from x in Ticks
                           where item.Index == x.Index.Trim()
                              && date <= x.TradingDay
                           select x)
                           .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = @"Desktop";      
            saveDialog.DefaultExt = "txt";
            saveDialog.FileName = "teszt";
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveDialog.FileName, rendezettLista);
            }
        }
    }
}
