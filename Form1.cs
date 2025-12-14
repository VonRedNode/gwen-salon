using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShopDemo
{
    public class User
    {
        public string Name { get; set; }
        public List<string> PurchaseHistory { get; set; } = new();
    }

    public class Form1 : Form
    {
        ComboBox cmbUsers, cmbItems;
        TabControl tabControl;
        ListBox lstHistory;
        Label lblShopkeeper;

        List<User> users;
        User currentUser;

        public Form1()
        {
            Text = "Shop Demo";
            Width = 600;
            Height = 400;

            InitializeData();
            InitializeUI();
        }

        private void InitializeData()
        {
            users = new List<User>
            {
                new User { Name = "Alice" },
                new User { Name = "Bob" },
                new User { Name = "Charlie" }
            };
        }

        private void InitializeUI()
        {
            Label lblUser = new Label
            {
                Text = "Select User:",
                Location = new Point(10, 15),
                AutoSize = true
            };

            cmbUsers = new ComboBox
            {
                Location = new Point(100, 10),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbUsers.DataSource = users;
            cmbUsers.DisplayMember = "Name";
            cmbUsers.SelectedIndexChanged += UserChanged;

            tabControl = new TabControl
            {
                Location = new Point(10, 50),
                Size = new Size(560, 300),
                Enabled = false
            };

            // TAB 1 — HISTORY
            var tabHistory = new TabPage("Purchase History");
            lstHistory = new ListBox { Dock = DockStyle.Fill };
            tabHistory.Controls.Add(lstHistory);

            // TAB 2 — PURCHASE
            var tabPurchase = new TabPage("Purchase");
            cmbItems = new ComboBox
            {
                Location = new Point(20, 20),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbItems.Items.AddRange(new[] { "Sword", "Shield", "Potion" });

            Button btnBuy = new Button
            {
                Text = "Buy Item",
                Location = new Point(200, 18)
            };
            btnBuy.Click += BuyItem;

            tabPurchase.Controls.Add(cmbItems);
            tabPurchase.Controls.Add(btnBuy);

            // TAB 3 — SHOPKEEPER
            var tabShopkeeper = new TabPage("Shopkeeper");
            lblShopkeeper = new Label
            {
                Location = new Point(20, 20),
                AutoSize = true
            };

            Button btnTalk = new Button
            {
                Text = "Talk",
                Location = new Point(20, 60)
            };
            btnTalk.Click += Talk;

            tabShopkeeper.Controls.Add(lblShopkeeper);
            tabShopkeeper.Controls.Add(btnTalk);

            tabControl.TabPages.AddRange(new[]
            {
                tabHistory, tabPurchase, tabShopkeeper
            });

            Controls.Add(lblUser);
            Controls.Add(cmbUsers);
            Controls.Add(tabControl);
        }

        private void UserChanged(object sender, EventArgs e)
        {
            currentUser = (User)cmbUsers.SelectedItem;
            tabControl.Enabled = true;

            lblShopkeeper.Text = $"Hello {currentUser.Name}!";
            UpdateHistory();
        }

        private void UpdateHistory()
        {
            lstHistory.Items.Clear();
            foreach (var item in currentUser.PurchaseHistory)
                lstHistory.Items.Add(item);
        }

        private void BuyItem(object sender, EventArgs e)
        {
            if (cmbItems.SelectedItem == null) return;

            string item = cmbItems.SelectedItem.ToString();
            currentUser.PurchaseHistory.Add(item);
            UpdateHistory();

            MessageBox.Show($"{currentUser.Name} bought a {item}!");
        }

        private void Talk(object sender, EventArgs e)
        {
            string text = currentUser.Name;


            /*
            switch(currentUser.Name)
            {
                "Alice" => "Welcome back, Alice!",
                "Bob" => "Bob, good to see you.",
                "Charlie" => "Ah, Charlie!",
                _ => "Hello!"
            };

            MessageBox.Show(text, "Shopkeeper");

            */
        }
    }
}
