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
    public class EditGastosPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nombreEntry;
        private Entry _apellidosEntry;
        private Entry _fechaGastoEntry;
        private Entry _montoEntry;
        private Entry _tipoGastoEntry;
        private Button _button;

        Gastos _gastos = new Gastos();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditGastosPage()
        {
            this.Title = "Actualizar Registro de Gastos";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Gastos>().OrderBy(x => x.Nombre).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Nombre del Usuario";
            stackLayout.Children.Add(_nombreEntry);

            _apellidosEntry = new Entry();
            _apellidosEntry.Keyboard = Keyboard.Text;
            _apellidosEntry.Placeholder = "Apellidos del Usuario";
            stackLayout.Children.Add(_apellidosEntry);

            _fechaGastoEntry = new Entry();
            _fechaGastoEntry.Keyboard = Keyboard.Text;
            _fechaGastoEntry.Placeholder = "Fecha de Gasto";
            stackLayout.Children.Add(_fechaGastoEntry);

            _montoEntry = new Entry();
            _montoEntry.Keyboard = Keyboard.Text;
            _montoEntry.Placeholder = "Cantidad de Gasto";
            stackLayout.Children.Add(_montoEntry);

            _tipoGastoEntry = new Entry();
            _tipoGastoEntry.Keyboard = Keyboard.Text;
            _tipoGastoEntry.Placeholder = "Detalle de Gasto";
            stackLayout.Children.Add(_tipoGastoEntry);

            _button = new Button();
            _button.Text = "Actualizar";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Gastos gastos = new Gastos()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Nombre = _nombreEntry.Text,
                Apellidos = _apellidosEntry.Text,
                FechaGasto = _fechaGastoEntry.Text,
                Monto = _montoEntry.Text,
                TipoGasto = _tipoGastoEntry.Text
            };
            db.Update(gastos);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _gastos = (Gastos)e.SelectedItem;
            _idEntry.Text = _gastos.Id.ToString();
            _nombreEntry.Text = _gastos.Nombre;
            _apellidosEntry.Text = _gastos.Apellidos;
            _fechaGastoEntry.Text = _gastos.FechaGasto;
            _montoEntry.Text = _gastos.Monto;
            _tipoGastoEntry.Text = _gastos.TipoGasto;

        }

    }
}