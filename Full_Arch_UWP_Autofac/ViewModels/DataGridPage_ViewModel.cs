using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System.Data;
using Full_Arch_UWP_Autofac.Helpers;
using NodaTime;


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
                case "InstantDoubleString":
                    MainListData = InstantDoubleString();
                    break;
            }
        }
        public void LoadDataSourcesCombobox()
        {
            DataSources.Add("Karre");
            DataSources.Add("Mense");
            DataSources.Add("InstantDoubleString");
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
        public ObservableCollection<InstantDoubleStringUint> InstantDoubleString()
        {
            IClock clock = SystemClock.Instance;

            ObservableCollection<InstantDoubleStringUint> mense = new ObservableCollection<InstantDoubleStringUint>();
            mense.Add(new InstantDoubleStringUint { Tyd = clock.GetCurrentInstant(), Nommer = 234656, Teks = "Einstein en Linda wa jy" });
            mense.Add(new InstantDoubleStringUint { Tyd = clock.GetCurrentInstant(), Nommer = 23, Teks = "fooooooook" });
            mense.Add(new InstantDoubleStringUint { Tyd = clock.GetCurrentInstant(), Nommer = 26, Teks = "gaan die instant post?" });
            mense.Add(new InstantDoubleStringUint { Tyd = clock.GetCurrentInstant(), Nommer = 213466777888, Teks = "hostaaa fo... re rof taaal" });

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
    public class InstantDoubleStringUint
    {
        public Instant Tyd { get; set; }
        public double Nommer { get; set; }
        public string Teks { get; set; }
    }
}
