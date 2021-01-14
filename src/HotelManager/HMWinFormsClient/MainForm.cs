using System;
using System.Configuration;
using System.Windows.Forms;
using HMCore;
using HMCore.Database;
using HMCore.Models;

namespace HMWinFormsClient
{
	public partial class MainForm : Form
	{
		private readonly HMDatabase db;

		public MainForm()
		{
			InitializeComponent();

			db = Dependency.Resolve<HMDatabase>();
			db.AddRooms(db.DefaultHotel, uint.Parse(ConfigurationManager.AppSettings["HotelSize"]));
		}

		private void Reserve_Click(object sender, EventArgs e)
		{
			try
			{
				string errorMessage = null;

				if (!int.TryParse(tbTo.Text, out int to)) errorMessage = "'To' field not valid.";
				if (!int.TryParse(tbFrom.Text, out int from)) errorMessage = "'From' field not valid";

				if (errorMessage != null)
				{
					MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Reservation reservation = db.MakeReservation(db.DefaultHotel, from, to);

				if (reservation != null)
				{
					MessageBox.Show($"Your reservation has been accepted. Your room: {reservation.RoomID}.", "Accepted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("We are sorry, but we could not accept your reservation. :(", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An unexpected error has occured. Please, report the bug.\r\n\r\n{ex.GetType().FullName}: {ex.Message}\r\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
