using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lab_Data_Access_with_LINQ
{
    public partial class Entity_Framework : Form
    {
        public Entity_Framework()
        {
            InitializeComponent();
        }

        private void Entity_Framework_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dollarComputersDataSet.products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.dollarComputersDataSet.products);

        }
    }
}
