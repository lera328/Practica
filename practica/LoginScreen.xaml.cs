using System;
using System.Collections.Generic;
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

namespace practica
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

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			List<String> userNames = new List<string>();
			using (UserContext db = new UserContext())
			{
				var users = db.Users.ToList();
				//for(int i = 0; i < 10; i++)
				//{
				//	userNames.Add(users.ElementAt(i).login);
				//}
				foreach (var p in users)
					userNames.Add(p.login);
			}
			comboBox.ItemsSource = userNames;
		}



		private void BtEnter_Click(object sender, RoutedEventArgs e)
		{
			string password = tbPassword.Text;
			bool isPasswordCorrect = false;
			using (UserContext db=new UserContext()){
				
				foreach(var user in db.Users)
				{
					if (password == user.password)
					{
						isPasswordCorrect = true;break;
					}
				}
			}
			if (isPasswordCorrect)
			{
				Window1 mainScreen = new Window1();
				mainScreen.Show();
				this.Close();
			}
			else MessageBox.Show("Неверный пароль");

			
		}

		
	}
}
