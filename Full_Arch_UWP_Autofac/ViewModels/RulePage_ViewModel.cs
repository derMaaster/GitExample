using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Arch_UWP_Autofac.Helpers;
using NodaTime;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class RulePage_ViewModel:NotificationBaseHelper
    {
        private string DataComboboxSelection_;
        public string DataComboboxSelection
        {
            get { return DataComboboxSelection_; }
            set { SetProperty(ref DataComboboxSelection_, value); }
        }
        public ObservableCollection<string> DataSources { get; } = new ObservableCollection<string>();

        private ObservableCollection<Karre> listData = new ObservableCollection<Karre>();
        public ObservableCollection<Karre> ListData { get { return this.listData; } }

        public MyICommand<ComboBox> ComboboxSelectionChanged_Command { get; private set; }
        public RulePage_ViewModel()
        {
            LoadDataSourcesCombobox();
            ComboboxSelectionChanged_Command = new MyICommand<ComboBox>(ComboboxSelectionChanged);
        }

        public void ComboboxSelectionChanged(ComboBox comboBox)
        {
            string comboboxSelection = comboBox.SelectedItem.ToString();

            switch (comboboxSelection)
            {
                case "LoadObservableCollection":
                    LoadKarreIn();
                    break;
                case "Mense":
                    //MainListData = KryMense();
                    break;
                case "InstantDoubleString":
                    //MainListData = InstantDoubleString();
                    break;
            }
        }
        private void LoadDataSourcesCombobox()
        {
            DataSources.Add("LoadObservableCollection");
            DataSources.Add("Mense");
            DataSources.Add("InstantDoubleString");
        }
        private void LoadObservableCollection()
        {

        }
        private void LoadKarreIn()
        {
            ListData.Add(new Karre
            {
                Toyotas = "Corolla",
                Audis = "A3"
            });
        }
        public ObservableCollection<Karre> KryKarre()
        {
            ObservableCollection<Karre> karre = new ObservableCollection<Karre>();
            karre.Add(new Karre { Toyotas = "Corolla", Audis = "A3" });
            karre.Add(new Karre { Toyotas = "Land Cruiser", Audis = "Q7" });
            karre.Add(new Karre { Toyotas = "Camry", Audis = "A7" });
            karre.Add(new Karre { Toyotas = "Camry", Audis = "A7" });
            karre.Add(new Karre { Toyotas = "Prado", Audis = "TT" });

            return karre;
        }
        public ObservableCollection<string> KryStringList()
        {
            ObservableCollection<string> stringList = new ObservableCollection<string>();
            stringList.Add("string1");
            stringList.Add("string2");
            stringList.Add("string3");
            stringList.Add("string4");
            stringList.Add("string5");

            return stringList;
        }

    }
}
