using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.Common;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace TestTaskNovosib
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private DataSet get_information(string sp, SqlConnection connection)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(sp, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);
            return dataSet;
        }

        private DataSet get_information(string sp, SqlConnection connection, string param)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(sp, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@city", param);


            SqlDataAdapter adapter = new SqlDataAdapter(command);

            

            adapter.Fill(dataSet);
            return dataSet;
        }

        private DataSet get_information(string sp, SqlConnection connection, int param)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(sp, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@factoryId", param);


            SqlDataAdapter adapter = new SqlDataAdapter(command);



            adapter.Fill(dataSet);
            return dataSet;
        }

        private void put_information_in_comboBox(DataSet dataSet, int table_number = 0)
        {
            // count = 1 для cities
            // count = 2 для factories, когда выбран город, цех или сотрудник
            // count = 3 для factories, когда ничего не выбрано
            // count = 4 для employees, когда выбран цех или сотрудник
            // count = 4 для employees, когда ничего не выюрано
            String info = "";

            if (dataSet.DataSetName == "cities")
            {
                for (int i = 0; i < dataSet.Tables[table_number].Rows.Count; i++)
                {
                    comboBoxSelectCity.Items.Add(dataSet.Tables[table_number].Rows[i].ItemArray[0]);
                }
            }
            else if (dataSet.DataSetName == "factories")
            {
                for (int i = 0; i < dataSet.Tables[table_number].Rows.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        info += dataSet.Tables[table_number].Rows[i].ItemArray[j].ToString() + " ";
                    }
                    comboBoxSelectFactory.Items.Add(info.Substring(0, info.Length - 1));
                    info = "";
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[table_number].Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        info += dataSet.Tables[table_number].Rows[i].ItemArray[j].ToString() + " ";
                    }
                    comboBoxSelectEmployee.Items.Add(info.Substring(0, info.Length - 1));
                    info = "";
                }
            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sp = "sp_select_all_cities";
            DataSet cities = get_information(sp, connection);
            cities.DataSetName = "cities";
            sp = "sp_select_all_factories";
            DataSet factories = get_information(sp, connection);
            factories.DataSetName = "factories";

            sp = "sp_select_all_employees";
            DataSet employees = get_information(sp, connection);
            employees.DataSetName = "employees";


            put_information_in_comboBox(cities);
            put_information_in_comboBox(factories);
            put_information_in_comboBox(employees);

        }

        private void reset_comboBoxes()
        {
            comboBoxSelectCity.Items.Clear();
            comboBoxSelectFactory.Items.Clear();
            comboBoxSelectEmployee.Items.Clear();
            comboBoxSelectCity.IsEnabled = true;
            comboBoxSelectFactory.IsEnabled = true;
            comboBoxSelectEmployee.IsEnabled = true;
        }

        private class Factory
        {
            public string Type { get; }
            public Factory(string type) { Type = type; }
        }
        private class Employee
        {
            public int Id { get; }
            public string Name { get; }
            public string Surname { get; }
            public string FathersName { get; }
            public Employee(int id, string name, string surname, string fathersName)
            {
                Id = id;
                Name = name;
                Surname = surname;
                FathersName = fathersName;
            }
        }

        private class WorkData
        {
            public int Id { get; }
            public string City { get; }
            public Factory Factory { get; }
            public Employee Employee { get; }
            public bool Brigade { get; }
            public int WorkShit { get; }
            public WorkData(int id, string city, Factory factory, Employee employee, bool brigade, int workShit)
            {
                Id = id;
                City = city;
                Factory = factory;
                Employee = employee;
                Brigade = brigade;
                WorkShit = workShit;
            }
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            bool form_ready = true;
            if (comboBoxSelectCity.SelectedValue == null)
            {
                Errors.Content += "Необходимо выбрать город \n";
                form_ready = false;
            }
            if (comboBoxSelectFactory.SelectedValue == null)
            {
                Errors.Content += "Необходимо выбрать цех \n";
                form_ready = false;
            }
            if (comboBoxSelectEmployee.SelectedValue == null)
            {
                Errors.Content += "Необходимо выбрать сотрудника \n";
                form_ready = false;
            }
            if ((Brigade1.IsChecked == false) && (Brigade2.IsChecked == false))
            {
                Errors.Content += "Необходимо выбрать бригаду \n";
                form_ready = false;
            }
            if (WorkingShift.Value == 0)
            {
                Errors.Content += "Смена не может быть 0 часов";
                form_ready = false;
            }

            if (form_ready)
            {
                Errors.Content = string.Empty;

                string help;

                String city = comboBoxSelectCity.SelectedValue.ToString();

                help = comboBoxSelectFactory.SelectedValue.ToString();
                int factoryId = Convert.ToInt32(help.Substring(0, help.IndexOf(" ")));
                string factoryType = help.Substring(help.IndexOf(" ") + 1, help.LastIndexOf(" "));

                help = comboBoxSelectEmployee.SelectedValue.ToString();
                int employeeId = Convert.ToInt32(help.Substring(0, help.IndexOf(" ")));
                help = help.Substring(help.IndexOf(" ") + 1);
                string name = help.Substring(0, help.IndexOf(" "));
                help = help.Substring(help.IndexOf(" ") + 1);
                string surname = help.Substring(0, help.IndexOf(" "));
                help = help.Substring(help.IndexOf(" ") + 1);
                string fathersName = help.Substring(0, help.IndexOf(" "));
                

                bool brigade;
                if (Brigade1.IsChecked == true) brigade = true; else brigade = false;
                
                int workingShift = Convert.ToInt32(WorkingShift.Value);

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string sp = "sp_insert_into_WorkDatas";


                DataSet dataSet = new DataSet();
                SqlCommand command = new SqlCommand(sp, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@factoryId", factoryId);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                command.Parameters.AddWithValue("@brigade", brigade);
                command.Parameters.AddWithValue("@workingShift", workingShift);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                Console.WriteLine(dataSet.Tables[0].Rows[0].ItemArray[0]);

                int id = Convert.ToInt32(dataSet.Tables[0].Rows[0].ItemArray[0]);


                Factory factory = new Factory(factoryType);
                Employee employee = new Employee(employeeId, name, surname, fathersName);
                WorkData workData = new WorkData(id, city, factory, employee, brigade, workingShift);


                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(workData, options);
                Console.WriteLine(json);

                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                {            
                    JsonSerializer.Serialize<WorkData>(fs, workData, options);

                    Console.WriteLine("Data has been saved to file");
                }

                buttonReset_Click(sender, e);
            }
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            reset_comboBoxes();
            Brigade1.IsChecked = false;
            Brigade2.IsChecked = false;
            WorkingShift.Value = 0;
            Errors.Content = string.Empty;
            Grid_Loaded(sender, e );
        }


        private void comboBoxSelectCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((comboBoxSelectCity.SelectedValue != null) && (comboBoxSelectFactory.SelectedValue == null))
            {
                Errors.Content = string.Empty;
                comboBoxSelectCity.IsEnabled = false;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string sp = "sp_select_factories_and_employees_in_city";
                DataSet factories_and_employees = get_information(sp, connection, comboBoxSelectCity.SelectedValue.ToString());
                factories_and_employees.DataSetName = "factories";

                comboBoxSelectFactory.Items.Clear();
                put_information_in_comboBox(factories_and_employees);

                factories_and_employees.DataSetName = "employees";
                comboBoxSelectEmployee.Items.Clear();
                put_information_in_comboBox(factories_and_employees, 1);

                
            }

        }

        private void comboBoxSelectFactory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((comboBoxSelectFactory.SelectedValue != null) && (comboBoxSelectEmployee.SelectedValue == null))
            {
                Errors.Content = string.Empty;
                comboBoxSelectFactory.IsEnabled = false;

                if (comboBoxSelectCity.SelectedValue == null)
                {
                    string city = comboBoxSelectFactory.SelectedValue.ToString();


                    city = city.Substring(city.LastIndexOf(" ") + 1);


                    comboBoxSelectCity.SelectedItem = city;

                    comboBoxSelectCity.IsEnabled = false;

                    
                }
                int factoryId = Convert.ToInt32(comboBoxSelectFactory.SelectedValue.ToString().Substring(0, comboBoxSelectFactory.SelectedValue.ToString().IndexOf(" ")));
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string sp = "sp_select_employees_in_factory";
                DataSet employees = get_information(sp, connection, factoryId);
                employees.DataSetName = "employees";
                comboBoxSelectEmployee.Items.Clear();
                put_information_in_comboBox(employees);
            }
        }

        private void comboBoxSelectEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSelectEmployee.SelectedValue != null)
            {
                Errors.Content = string.Empty;
                comboBoxSelectEmployee.IsEnabled = false;
                string factoryId = comboBoxSelectEmployee.SelectedValue.ToString().Substring(comboBoxSelectEmployee.SelectedValue.ToString().LastIndexOf(" ") + 1);
                for (int i = 0; i < comboBoxSelectFactory.Items.Count; i++)
                {
                    if (comboBoxSelectFactory.Items[i].ToString().Substring(0, comboBoxSelectFactory.Items[i].ToString().IndexOf(" ")) == factoryId)
                    {
                        comboBoxSelectFactory.IsEnabled = false;
                        comboBoxSelectFactory.SelectedIndex = i;
                    }
                }
                if (comboBoxSelectCity.SelectedValue == null)
                {
                    string city = comboBoxSelectFactory.SelectedValue.ToString();


                    city = city.Substring(city.LastIndexOf(" ") + 1);


                    comboBoxSelectCity.SelectedItem = city;

                    comboBoxSelectCity.IsEnabled = false;
                }

            }


        }

        private void WorkingShift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Errors.Content = string.Empty;
            WorkingShiftLabel.Content = WorkingShift.Value;
        }

        private void Brigade1_Checked(object sender, RoutedEventArgs e)
        {
            Errors.Content = string.Empty;
        }

        private void Brigade2_Checked(object sender, RoutedEventArgs e)
        {
            Errors.Content = string.Empty;
        }
    }
}
