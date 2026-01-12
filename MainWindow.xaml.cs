using System;
using System.Collections.Generic;
using System.Windows;
using Shop_Kazakov.Classes;

namespace Shop_Kazakov
{
    public partial class MainWindow : Window
    {
        private List<object> allChildrenItems;
        private List<object> allSportItems;
        private List<object> allElectronikItems;
        private List<object> allItems;

        public MainWindow()
        {
            InitializeComponent();


            LoadAllData();
            CreateUI();
        }

        private void LoadAllData()
        {
            try
            {
                allChildrenItems = ChildrenContext.GetAllItems();
                allSportItems = SportContext.GetAllItems();
                allElectronikItems = ElectronikContext.GetAllItems();

                allItems = new List<object>();
                allItems.AddRange(allChildrenItems);
                allItems.AddRange(allSportItems);
                allItems.AddRange(allElectronikItems);

                System.Diagnostics.Debug.WriteLine($"Загружено: Детские - {allChildrenItems.Count}, Спорт - {allSportItems.Count}, Электроника - {allElectronikItems.Count}, Всего - {allItems.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void CreateUI()
        {
            parent.Children.Clear();

            if (allItems == null || allItems.Count == 0)
            {
                LoadAllData();
            }

            foreach (var item in allItems)
            {
                try
                {
                    parent.Children.Add(new Elements.Item(item));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка создания элемента: {ex.Message}");
                }
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string searchText = SerchTextBox.Text.Trim();
            parent.Children.Clear();

            if (string.IsNullOrEmpty(searchText))
            {
                foreach (var item in allItems)
                {
                    parent.Children.Add(new Elements.Item(item));
                }
            }
            else
            {
                foreach (var item in allItems)
                {
                    var shopItem = item as Models.Shop;
                    if (shopItem != null &&
                        shopItem.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        parent.Children.Add(new Elements.Item(item));
                    }
                }
            }
        }

        public void RefreshData()
        {
            LoadAllData();
            CreateUI();
        }
    }
}