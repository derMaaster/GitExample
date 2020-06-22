using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System.Data;
using Full_Arch_UWP_Autofac.Helpers;

namespace Full_Arch_UWP_Autofac.ViewModels
{
    public class DataGridPage_ViewModel:NotificationBaseHelper
    {
        private object MainListData_;
        public object MainListData 
        {
            get { return MainListData_; }
            set { SetProperty(ref MainListData_, value); }
        }

        public ObservableCollection<string> DataSources { get; } = new ObservableCollection<string>();
        public MyICommand<ComboBox> ComboboxSelectionChanged_Command { get; private set; }

        private string DataComboboxSelection_;
        public string DataComboboxSelection
        {
            get { return DataComboboxSelection_; }
            set { SetProperty(ref DataComboboxSelection_, value); }
        }


        public DataGridPage_ViewModel()
        {
            LoadDataSourcesCombobox();
            ComboboxSelectionChanged_Command = new MyICommand<ComboBox>(ComboboxSelectionChanged);
        }

        public void ComboboxSelectionChanged(ComboBox comboBox)
        {
            string comboboxSelection = comboBox.SelectedItem.ToString();

            switch (comboboxSelection)
            {
                case "Karre":
                    MainListData = KryKarre();
                    break;
                case "Mense":
                    MainListData = KryMense();
                    break;
            }
        }
        public void LoadDataSourcesCombobox()
        {
            DataSources.Add("Karre");
            DataSources.Add("Mense");
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
        public ObservableCollection<Mense> KryMense()
        {
            ObservableCollection<Mense> mense = new ObservableCollection<Mense>();
            mense.Add(new Mense { Fiks = "Winston", Onfiks = "tannie",Slim="Einstein",Katte="Linda" });
            mense.Add(new Mense { Fiks = "Allister", Onfiks = "ma", Slim = "Taleb", Katte = "Heloise" });
            mense.Add(new Mense { Fiks = "Andrew", Onfiks = "tannie Elsabe", Slim = "Seneca", Katte = "Jana" });
            mense.Add(new Mense { Fiks = "Tinei", Onfiks = "Re-an", Slim = "Eldredge", Katte = "Linda 2" });
            mense.Add(new Mense { Fiks = "Roan", Onfiks = "Jomone", Slim = "Vic E Frankl", Katte = "Anja" });
            mense.Add(new Mense { Fiks = "Jolan", Onfiks = "Bernarn", Slim = "Hitler", Katte = "BambiPilot" });

            return mense;
        }
    }

    public class Karre
    {
        public string Toyotas { get; set; }
        public string Audis { get; set; }
    }
    public class Mense
    {
        public string Fiks { get; set; }
        public string Onfiks { get; set; }
        public string Slim { get; set; }
        public string Katte { get; set; }
    }
}
