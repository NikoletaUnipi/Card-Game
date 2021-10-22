using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CardGameSep2021
{
    public partial class Form1 : Form
    {
        List<Player> players = new List<Player>();
        Player current;
        PictureBox[] boxes;
        List<Card> cards = new List<Card>();
        Card[] openCards = { null,null }; //a cards that are already opened
        static int s = 0;
        string[] images_innitial= { };
        public Form1(string username)
        {
            InitializeComponent();
            current = new Player(username, 0, 0);
            Organiser organiser = new Organiser();

            players = organiser.GetPlayers("TextFile1.txt");
           
        }

       
        public void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            timer1.Enabled = true;
           
            images_innitial = Directory.GetFiles("images");

            images_innitial = mixedArray(images_innitial);//μπερδεύουμε τις εικόνες

            boxes = GetPictureBoxes();
            
            int imageCounter = 0;
            foreach (PictureBox box in boxes)
            {

                if (imageCounter < images_innitial.Length)
                {
                    Card card = new Card(box, images_innitial[imageCounter]);
                    card.pictureBox.Click += pictureBox1_ClicK;
                    cards.Add(card);
                }
                else {
                   if(imageCounter== images_innitial.Length)
                    {
                        images_innitial = mixedArray(images_innitial);//μπερδεύουμε ξανά τις εικόνες
                    }
                        Card card = new Card(box, images_innitial[imageCounter- images_innitial.Length]);
                    card.pictureBox.Click += pictureBox1_ClicK;
                    cards.Add(card);
                }

                imageCounter++;

            }

        }
        
        public void pictureBox1_ClicK(object sender, EventArgs e)
        {
            current.player_Tries += 1;
            foreach (Card card in cards)
            {

                if (card.pictureBox== (PictureBox)sender)
                {
                  // MessageBox.Show("Sender is" +sender.ToString());
                    
                        //καμία κάρτα δεν έχει ανοιχτεί
                        if (openCards[0] == null && openCards[1] == null){
                            card.updateUrl(card.cardFronT, true);

                            openCards[0] = card;
                        }else if (openCards[1] == null){//μια κάρτα έχει ήδη ανοιχτεί


                            card.updateUrl(card.cardFronT, true);
                            openCards[1] = card;
                            checkForMatch(openCards[0], openCards[1]);
                    }
                    else { //αν υπάρχουν ήδη 2 ανοιγμένες κάρτες
                           
                            openCards[0].updateUrl(card.cardBacK, false);
                            openCards[1].updateUrl(card.cardBacK, false);
                            openCards[0] = card;
                            card.updateUrl(card.cardFronT, true);
                            openCards[1] = null;

                    }

                    break;
                }                  
                  
            }

        }
        //code from https://social.msdn.microsoft.com/Forums/en-US/ca6cf0ae-fb76-4227-97ee-165bdbd9a754/how-do-i-create-an-array-of-pictureboxes-like-i-did-in-vb-60?forum=csharpgeneral
        private PictureBox[] GetPictureBoxes()
        {
            List<PictureBox> boxes = new List<PictureBox>();

            foreach (Control c in this.Controls)
            {
                var current = c as PictureBox;

                if (current != null)
                    boxes.Add(current);
            }

            return boxes.ToArray();
        }

        string[] mixedArray(string[] array) {
           
            for (int i = array.Length -1; i > 0; i--)
            {
                Random random = new Random();
                int index = random.Next(4);
               
                string temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }

            return array;
        }
        void checkForMatch(Card card0,Card card1)
        {
            if (card0.cardFronT == card1.cardFronT)
            {
                card0.Paralyzed = true;
                card1.Paralyzed = true;
                if (endOfGame()) {
                    label1.Text = "Game over";
                }
            }
        }
        bool endOfGame() {
            bool flag = true;
            foreach (Card card in cards)
            {
                if (card.Paralyzed == false)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                current.player_Seconds = s;
                timer1.Enabled = false;
                players.Add(current);
                Organiser organiser = new Organiser();
                organiser.storeData(players, "TextFile1.txt");
                List<Player> shorted =organiser.getTop10(players);
                new top10(shorted).Show();
            }
            return flag;
        }

        private void timer1_On_Tick(object sender, EventArgs e)
        {
            s =s+1;
            string str =s.ToString()+ " sec";
            label2.Text = str;
        }

        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void endGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Card card in cards)
            {
                card.updateUrl(card.cardFronT, true);
                card.Paralyzed = true;
            }
            if (endOfGame())
            {
                label1.Text = "Game over";
            }
            timer1.Enabled = false;
           
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                images_innitial = files;
            }
            images_innitial = mixedArray(images_innitial);
            int imageCounter = 0;
            foreach (Card card in cards)
            {

                if (imageCounter < images_innitial.Length)
                {
                    card.cardFronT = images_innitial[imageCounter];
                }
                else
                {
                    if (imageCounter == images_innitial.Length)
                    {
                        images_innitial = mixedArray(images_innitial);//μπερδεύουμε ξανά τις εικόνες
                    }
                    card.cardFronT = images_innitial[imageCounter-images_innitial.Length];
                }

                imageCounter++;

            }
        }
    }
}

