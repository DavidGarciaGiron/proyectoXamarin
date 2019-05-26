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
    public class GetAllGastosAllPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public GetAllGastosAllPage()
        {
            this.Title = "Registro de Gastos";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Gastos>().OrderBy(x => x.Nombre).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

        }
    }
} 