using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        public Form1()
        {
            InitializeComponent();

            CreatePortfolio();

            Ticks = context.Ticks.ToList();
            dGTick.DataSource = Ticks;
            List<Tick> l = context.Ticks.ToList();
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
    }
}
