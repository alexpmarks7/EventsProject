using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EventsProjectGUI;
using EventsProjectBusiness;

namespace EventsProjectGUI
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class NewVenueWindow : Window
	{
		private CRUDManager _CRUDManager = new CRUDManager();
		public NewVenueWindow()
		{
			InitializeComponent();
		}

		private void AddVenueButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (VenueIDText.Text != "" && VenueNameText.Text != "" && VenueCityText.Text != "" && VenueCountryText.Text != "" && VenueCapacityText.Text != "")
				{
					_CRUDManager.CreateVenue(VenueIDText.Text, VenueNameText.Text, VenueCityText.Text, VenueCountryText.Text, Int32.Parse(VenueCapacityText.Text));
					this.Close();
				}
				else
				{
					MessageBox.Show("Invalid entry");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
