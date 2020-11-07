using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfApp1.DataBase;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Collections;
using WPFMVVMHelper;

namespace WpfApp1
{
    public class MV :peremlog
    {
        private RestoranDataContext restoran = new RestoranDataContext();
        private string select = "";
        public IEnumerable test
        {
            get => Restoran.Bluda.Where(a => a.nazv.Contains(Select));
        }

        private ObservableCollection<Bluda> selectBlud;

        public ObservableCollection<Bluda> SelectBlud 
        { 
            get => selectBlud;
            set => Set(ref selectBlud, value);
        }
        public RestoranDataContext Restoran
        {
            get => restoran;
            set => Set(ref restoran, value);
        }

        public string Select
        {
            get => select;
            set
                {
                if(Set(ref select,value))
                SelectBlud =new ObservableCollection<Bluda>(SelectKateg.Kat_bluda.Select(s => s.Bluda).Where(a=>a.nazv.Contains(value)));
            }
        }

        private Kategoria selectKateg;


        public Kategoria SelectKateg
        {
            get => selectKateg;
            set
            {
                if (Set(ref selectKateg, value))
                {
                    OnPropertyChanged(nameof(test));

                    SelectBlud = new ObservableCollection<Bluda>(value.Kat_bluda.Select(s => s.Bluda));
                }

            }
        }

       
        public lamdaCommand Refresh_DB { get; }

        public lamdaCommand<Bluda> AddImage { get; }

        public lamdaCommand Add_Kat_Bluda { get; }


        public MV()
        {
            SelectBlud = new ObservableCollection<Bluda>(restoran.Bluda);

            Refresh_DB = new lamdaCommand(OnRefresh_DB);
            AddImage = new lamdaCommand<Bluda>(OnAddImage);
            Add_Kat_Bluda = new lamdaCommand(OnAdd_Kat_Bluda);

        }

    public void OnRefresh_DB()
        {
            Restoran.SubmitChanges();
            Restoran = new RestoranDataContext();
        }

        public void OnAddImage(Bluda bluda)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                bluda.Image = File.ReadAllBytes(open.FileName);
            }
        }

        public void OnAdd_Kat_Bluda()
        {
            Restoran.Kat_bluda.InsertOnSubmit(new Kat_bluda() { Bluda = Restoran.Bluda.First(), Kategoria = Restoran.Kategoria.First() });
            Restoran.SubmitChanges();
            Restoran.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Restoran.Kat_bluda);
        }
    }
}
