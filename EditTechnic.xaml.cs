using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YchetPer.Connection;

namespace YchetPer
{
    /// <summary>
    /// Логика взаимодействия для EditTechnic.xaml
    /// </summary>
    public partial class EditTechnic : Window
    {
        string idi;
        public EditTechnic(DataRowView drv)
        {
            InitializeComponent();
            CbFill();
            CbClass.Text = drv["Class"].ToString();
            CbTitle.Text = drv["Title"].ToString();
            CbBrand.Text = drv["Brand"].ToString();
            CbModel.Text = drv["Model"].ToString();
            CbNumKab.Text = drv["NumKab"].ToString();
            TbNumber.Text = drv["Number"].ToString();
            CbCondition.Text = drv["Condition"].ToString();
            StartWork.Text = drv["StartWork"].ToString();
            idi = drv["ID"].ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            CbFill();
            this.Close();
        }
        public void CbFill()  //Данные для комбобоксов 
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query1 = $@"SELECT * FROM Types"; // Типы
                    string query2 = $@"SELECT * FROM Conditions"; // Состояние
                    string query3 = $@"SELECT * FROM NumberKabs"; // Кабинеты
                    string query4 = $@"SELECT * FROM Brands"; // Бренд
                    string query5 = $@"SELECT * FROM Titles"; // Устройства
                    string query6 = $@"SELECT * FROM Models"; // Устройства

                    //----------------------------------------------
                    SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                    SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                    SQLiteCommand cmd4 = new SQLiteCommand(query4, connection);
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, connection);
                    SQLiteCommand cmd6 = new SQLiteCommand(query6, connection);
                    //----------------------------------------------
                    SQLiteDataAdapter SDA1 = new SQLiteDataAdapter(cmd1);
                    SQLiteDataAdapter SDA2 = new SQLiteDataAdapter(cmd2);
                    SQLiteDataAdapter SDA3 = new SQLiteDataAdapter(cmd3);
                    SQLiteDataAdapter SDA4 = new SQLiteDataAdapter(cmd4);
                    SQLiteDataAdapter SDA5 = new SQLiteDataAdapter(cmd5);
                    SQLiteDataAdapter SDA6 = new SQLiteDataAdapter(cmd6);
                    //----------------------------------------------
                    DataTable dt1 = new DataTable("Types");
                    DataTable dt2 = new DataTable("Conditions");
                    DataTable dt3 = new DataTable("NumberKabs");
                    DataTable dt4 = new DataTable("Brands");
                    DataTable dt5 = new DataTable("Titles");
                    DataTable dt6 = new DataTable("Models");
                    //----------------------------------------------
                    SDA1.Fill(dt1);
                    SDA2.Fill(dt2);
                    SDA3.Fill(dt3);
                    SDA4.Fill(dt4);
                    SDA5.Fill(dt5);
                    SDA6.Fill(dt6);
                    //----------------------------------------------
                    CbClass.ItemsSource = dt1.DefaultView;
                    CbClass.DisplayMemberPath = "Class";
                    CbClass.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbCondition.ItemsSource = dt2.DefaultView;
                    CbCondition.DisplayMemberPath = "Condition";
                    CbCondition.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbNumKab.ItemsSource = dt3.DefaultView;
                    CbNumKab.DisplayMemberPath = "NumKab";
                    CbNumKab.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbBrand.ItemsSource = dt4.DefaultView;
                    CbBrand.DisplayMemberPath = "Brand";
                    CbBrand.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbTitle.ItemsSource = dt5.DefaultView;
                    CbTitle.DisplayMemberPath = "Title";
                    CbTitle.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbModel.ItemsSource = dt6.DefaultView;
                    CbModel.DisplayMemberPath = "Model";
                    CbModel.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void CbKab()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query3 = $@"SELECT * FROM NumberKabs"; // Кабинеты
                    SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                    SQLiteDataAdapter SDA3 = new SQLiteDataAdapter(cmd3);
                    DataTable dt3 = new DataTable("NumberKabs");
                    SDA3.Fill(dt3);
                    CbNumKab.ItemsSource = dt3.DefaultView;
                    CbNumKab.DisplayMemberPath = "NumKab";
                    CbNumKab.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void CbTitl()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query5 = $@"SELECT * FROM Titles"; // Устройства
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, connection);
                    SQLiteDataAdapter SDA5 = new SQLiteDataAdapter(cmd5);
                    DataTable dt5 = new DataTable("Titles");
                    SDA5.Fill(dt5);
                    CbTitle.ItemsSource = dt5.DefaultView;
                    CbTitle.DisplayMemberPath = "Title";
                    CbTitle.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void CbBrands()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))// Бренды
            {
                try
                {
                    connection.Open();
                    string query5 = $@"SELECT * FROM Brands";
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, connection);
                    SQLiteDataAdapter SDA5 = new SQLiteDataAdapter(cmd5);
                    DataTable dt5 = new DataTable("Brands");
                    SDA5.Fill(dt5);
                    CbBrand.ItemsSource = dt5.DefaultView;
                    CbBrand.DisplayMemberPath = "Brand";
                    CbBrand.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void CbModels()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))// Модели
            {
                try
                {
                    connection.Open();
                    string query5 = $@"SELECT * FROM Models";
                    SQLiteCommand cmd5 = new SQLiteCommand(query5, connection);
                    SQLiteDataAdapter SDA5 = new SQLiteDataAdapter(cmd5);
                    DataTable dt5 = new DataTable("Models");
                    SDA5.Fill(dt5);
                    CbModel.ItemsSource = dt5.DefaultView;
                    CbModel.DisplayMemberPath = "Model";
                    CbModel.SelectedValuePath = "ID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void UpdateDevices()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                connection.Open();
                if ((String.IsNullOrEmpty(TbNumber.Text) || String.IsNullOrEmpty(CbClass.Text) || CbNumKab.SelectedIndex == -1 || CbCondition.SelectedIndex == -1 || CbTitle.SelectedIndex == -1 || CbBrand.SelectedIndex == -1 || CbModel.SelectedIndex == -1))
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int id, id2, id3, id4, id5, id6;
                    bool resultClass = int.TryParse(CbClass.SelectedValue.ToString(), out id);
                    bool resultKab = int.TryParse(CbNumKab.SelectedValue.ToString(), out id2);
                    bool resultCon = int.TryParse(CbCondition.SelectedValue.ToString(), out id3);
                    bool resultTitl = int.TryParse(CbTitle.SelectedValue.ToString(), out id4);
                    bool resultBrand = int.TryParse(CbBrand.SelectedValue.ToString(), out id5);
                    bool resultModel = int.TryParse(CbModel.SelectedValue.ToString(), out id6);
                    string query = $@"UPDATE Devices SET IDType=@IDType, IDKabuneta=@IDKabuneta, IDTitle=@IDTitle,IDBrand=@IDBrand,IDModel=@IDModel, Number=@Number, IDCondition=@IDCondition, StartWork=@StartWork WHERE ID=@ID;";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID", idi);
                        cmd.Parameters.AddWithValue("@IDType", id);
                        cmd.Parameters.AddWithValue("@IDKabuneta", id2);
                        cmd.Parameters.AddWithValue("@IDTitle", id4);
                        cmd.Parameters.AddWithValue("@IDBrand", id5);
                        cmd.Parameters.AddWithValue("@IDModel", id6);
                        cmd.Parameters.AddWithValue("@Number", TbNumber.Text);
                        cmd.Parameters.AddWithValue("@IDCondition", id3);
                        cmd.Parameters.AddWithValue("@StartWork", StartWork.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные изменены");

                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void BtnEddit_Click(object sender, RoutedEventArgs e) //Добавление
        {
            UpdateDevices();
            this.Close();
        }

        private void BtnAddKab_Click(object sender, RoutedEventArgs e)
        {
            Eddit Edd = new Eddit();
            Edd.Owner = this;
            bool? result = Edd.ShowDialog();
            switch (result)
            {
                default:
                    CbKab();
                    break;
            }
        }

        private void BtnDellKab_Click(object sender, RoutedEventArgs e)
        {
            CheckDeletetKab();
            CbKab();
        }


        private void BtnAddTitl_Click(object sender, RoutedEventArgs e)
        {
            EdditTitle EddTitl = new EdditTitle();
            EddTitl.Owner = this;
            bool? result = EddTitl.ShowDialog();
            switch (result)
            {
                default:
                    CbTitl();
                    break;
            }
        }

        private void CheckDeletetTitle() //Удаление Устройства
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                if (CbTitle.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите какое название нужно удалить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int IdTil;
                    bool NumTitl = int.TryParse(CbTitle.SelectedValue.ToString(), out IdTil);
                    try
                    {
                        connection.Open();
                        string query3 = $@"SELECT COUNT(1) FROM Devices WHERE IDTitle=@IDTitle"; //Получение данных из таблицы Devices
                        SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                        cmd3.Parameters.AddWithValue("IDTitle", IdTil);
                        int count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                        if (count2 != 0)
                        {
                            MessageBox.Show("Это название используется", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            try
                            {
                                string query2 = $@"DELETE FROM Titles WHERE ID = '{IdTil}'";
                                SQLiteCommand cmd1 = new SQLiteCommand(query2, connection);
                                DataTable DT = new DataTable("Titles");
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Название удалёно");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }
        private void CheckDeletetKab() //Удаление Кабинета
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                if (CbNumKab.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите какой кабинет нужно удалить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int IdKab;
                    bool NumKab = int.TryParse(CbNumKab.SelectedValue.ToString(), out IdKab);
                    try
                    {
                        connection.Open();
                        string query3 = $@"SELECT COUNT(1) FROM Devices WHERE IDKabuneta=@IDKabuneta"; //Получение данных из таблицы Девайсы
                        SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                        cmd3.Parameters.AddWithValue("IDKabuneta", IdKab);
                        int count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                        if (count2 != 0)
                        {
                            MessageBox.Show("Этот кабинет используется", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            try
                            {
                                string query2 = $@"DELETE FROM NumberKabs WHERE ID = '{IdKab}'";
                                SQLiteCommand cmd1 = new SQLiteCommand(query2, connection);
                                DataTable DT = new DataTable("NumberKabs");
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Кабинет удалён");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }
        private void CheckDeletetBrand() //Удаление бренда
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                if (CbBrand.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите какой бренд нужно удалить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int IdKab;
                    bool NumKab = int.TryParse(CbBrand.SelectedValue.ToString(), out IdKab);
                    try
                    {
                        connection.Open();
                        string query3 = $@"SELECT COUNT(1) FROM Devices WHERE IDBrand=@IDBrand"; //Получение данных из таблицы Девайсы
                        SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                        cmd3.Parameters.AddWithValue("IDBrand", IdKab);
                        int count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                        if (count2 != 0)
                        {
                            MessageBox.Show("Этот бренд используется", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            try
                            {
                                string query2 = $@"DELETE FROM Brands WHERE ID = '{IdKab}'";
                                SQLiteCommand cmd1 = new SQLiteCommand(query2, connection);
                                DataTable DT = new DataTable("Brands");
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Бренд удалён");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }
        private void CheckDeletetModel() //Удаление модели
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                if (CbModel.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите какую модель нужно удалить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int IdKab;
                    bool NumKab = int.TryParse(CbModel.SelectedValue.ToString(), out IdKab);
                    try
                    {
                        connection.Open();
                        string query3 = $@"SELECT COUNT(1) FROM Devices WHERE IDModel=@IDModel"; //Получение данных из таблицы Девайсы
                        SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);
                        cmd3.Parameters.AddWithValue("IDModel", IdKab);
                        int count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                        if (count2 != 0)
                        {
                            MessageBox.Show("Эта модель используется", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            try
                            {
                                string query2 = $@"DELETE FROM Models WHERE ID = '{IdKab}'";
                                SQLiteCommand cmd1 = new SQLiteCommand(query2, connection);
                                DataTable DT = new DataTable("Models");
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Модель удалена");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }
        private void BtnDellTilt_Click(object sender, RoutedEventArgs e)
        {
            CheckDeletetTitle();
            CbTitl();
        }

        private void BtnAddBrend_Click(object sender, RoutedEventArgs e) //Добавление Бренда
        {
            EdditBrand EddBrand = new EdditBrand();
            EddBrand.Owner = this;
            bool? result = EddBrand.ShowDialog();
            switch (result)
            {
                default:
                    CbBrands();
                    break;
            }
        }

        private void BtnDelBrend_Click(object sender, RoutedEventArgs e) //Удаение Бренда
        {
            CheckDeletetBrand();
            CbBrands();
        }

        private void BtnAddModel_Click(object sender, RoutedEventArgs e) //Добавление Модели
        {
            EdditModel EddModel = new EdditModel();
            EddModel.Owner = this;
            bool? result = EddModel.ShowDialog();
            switch (result)
            {
                default:
                    CbModels();
                    break;
            }
        }

        private void BtnDelModel_Click(object sender, RoutedEventArgs e)
        {
            CheckDeletetModel();
            CbModels();
        }
    }
}
