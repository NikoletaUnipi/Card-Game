using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGameSep2021
{
    public partial class top10 : Form
    {
        List<Player> players = new List<Player>();
        public top10(List<Player> shortedPlayers)
        {
            InitializeComponent();
            players = shortedPlayers;
        }

        private void top10_Load(object sender, EventArgs e)
        {
            Label[] lbls = GetLabels();
            for (int i = 0; i < 10; i++){

                lbls[i].Text =lbls[i].Text + players[i].player_Username;
                
            }
        }

        private Label[] GetLabels()
        {
            List<Label> labels = new List<Label>();

            foreach (Control c in this.Controls)
            {
                var current = c as Label;

                if (current != null)
                    labels.Add(current);
            }

            return labels.ToArray();
        }
    }
}
