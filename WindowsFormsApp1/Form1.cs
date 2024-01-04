using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private class Books
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string qty { get; set; }
            public string images { get; set; }
        };
        List<Books> books = new List<Books>();
        int count=-1;
        public Form1()
        {
            InitializeComponent();
        }
        private void pic_box_Click(object sender, EventArgs e)
        {
            OpenFileDialog of=new OpenFileDialog();
            DialogResult pic_selected= of.ShowDialog();
            if(pic_selected == DialogResult.OK) 
            {
                string image_path = of.FileName;
                pic_box.Image = Image.FromFile(image_path);
                pic_box.Tag = image_path; // Reset the Tag after using the image
                Books book = new Books
                {
                    images = image_path
                };
                books.Add(book);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try 
            {
                if((pic_box.Tag == null || pic_box.Tag.Equals(Properties.Resources.noImage)))
                {
                    MessageBox.Show(" Please Input Image first! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Books current_book = books[books.Count - 1];
                current_book.Id = txt_bookID.Text.Trim();
                current_book.Name = txt_bookID.Text.Trim();
                current_book.qty = txt_bookQty.Text.Trim();
                txt_bookID.Clear();
                txt_bookName.Clear();
                txt_bookQty.Clear();
                pic_box.Image = Properties.Resources.noImage;
                pic_box.Tag = null;// Use Tag to store the image path
            }
            catch(Exception)
            {
                MessageBox.Show(" Please Input Image first! ","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            navigate(1);
        }
        private void navigate(int direction)
        {
            try 
            {
                int imageIndex = books.Count - 1;
                count += direction;
                if (count < 0)
                {
                    count = 0;
                }
                else if (count > imageIndex)
                {
                    count = imageIndex;
                }
                txt_bookID.Text=books[count].Id.ToString();
                txt_bookName.Text=books[count].Name.ToString();
                txt_bookQty.Text=books[count].qty.ToString();
                pic_box.Image = Image.FromFile(books[count].images);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show(" Please Input image first. ","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            navigate(-1);
        }
    }
}
