using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinSQLite.Models;

namespace XamarinSQLite.Views
{
    public class AddGastosPage : ContentPage
    {
        private Entry _nombreEntry;
        private Entry _apellidosEntry;
        private Entry _fechaGastoEntry;
        private Entry _montoEntry;
        private Entry _tipoGastoEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AddGastosPage()
        {
            this.Title = "Registrar un Nuevo Gasto";

            StackLayout stackLayout = new StackLayout();

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre";
            stackLayout.Children.Add(_nombreEntry);

            _apellidosEntry = new Entry();
            _apellidosEntry.Keyboard = Keyboard.Text;
            _apellidosEntry.Placeholder = "Apellidos";
            stackLayout.Children.Add(_apellidosEntry);

            _fechaGastoEntry = new Entry();
            _fechaGastoEntry.Keyboard = Keyboard.Text;
            _fechaGastoEntry.Placeholder = "Fecha";
            stackLayout.Children.Add(_fechaGastoEntry);

            _montoEntry = new Entry();
            _montoEntry.Keyboard = Keyboard.Text;
            _montoEntry.Placeholder = "Monto Gastado";
            stackLayout.Children.Add(_montoEntry);

            _tipoGastoEntry = new Entry();
            _tipoGastoEntry.Keyboard = Keyboard.Text;
            _tipoGastoEntry.Placeholder = "Detalle de Gasto";
            stackLayout.Children.Add(_tipoGastoEntry);

            _saveButton = new Button();
            _saveButton.Text = "Registrar";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Gastos>();

            var maxPK = db.Table<Gastos>().OrderByDescending(c => c.Id).FirstOrDefault();

            Gastos gastos = new Gastos()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Nombre = _nombreEntry.Text,
                Apellidos = _apellidosEntry.Text,
                FechaGasto = _fechaGastoEntry.Text,
                Monto = _montoEntry.Text,
                TipoGasto = _tipoGastoEntry.Text
            };
            db.Insert(gastos);
            await DisplayAlert(null, "El registro de gasto de: " + gastos.Nombre + " fue guardado exitosamente.", "Ok");
            await Navigation.PopAsync();
        }

    }
}