using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CardGameSep2021
{
    class Card 
    {

        string[] background_image = Directory.GetFiles("background");
        private  string cardBack;
        private bool isOpen;// field
        private string cardFront;// field
        private bool paralyzed;
        PictureBox picturebox;
        public Card(PictureBox picturebox,string cardFront)//constructor bool isOpen, string URL
        {
            cardBack = background_image[0];
           isOpen = false;
           this.cardFront = cardFront;
            this.picturebox = picturebox;
            picturebox.ImageLocation = cardBack;
            paralyzed = false;
        }
     public PictureBox pictureBox // property
        {
            get { return picturebox; }
            set { picturebox = value; }
        }
        public bool IsOpen // property
        {
            get { return isOpen; }
            set { isOpen = value; }
        }
        public string cardFronT// property
        { 
            get { return cardFront; }
            set { cardFront = value; }
        }

        public string cardBacK // property
        { 
            get { return cardBack; }
            
            
        }
       public bool Paralyzed // property
        {
            get { return paralyzed; }
            set { paralyzed = value; }
        }
        public void updateUrl (string url,bool value){

            if (!paralyzed) { picturebox.ImageLocation = url; }
            isOpen = value;
        }
    }
}
