using System;
using System.Windows;
using System.Data.SQLite;
using YchetPer.Connection;

namespace YchetPer
{
    /// <summary>
    /// Логика взаимодействия для EdditModel.xaml
    /// </summary>
    public partial class EdditModel : Window
    {
        public EdditModel()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {

                if (String.IsNullOrEmpty(TbTitl.Text))
                {
                    MessageBox.Show("Заполните поле", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    connection.Open();
                    string query = $@"INSERT INTO Models('Model') values (@Model)";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.Parameters.AddWithValue("@Model", TbTitl.Text);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }
    }
}
